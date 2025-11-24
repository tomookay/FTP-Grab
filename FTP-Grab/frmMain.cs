using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Grab
{
    public partial class frmMain : Form
    {
        // control flags
        private bool startDownload = false;
        private bool _isDownloading = false;

        // stored remote path and optional credentials
        private string _remotePath = "/ftp/data";
        private string _LocalPath = "C:/savedFTPdata/";
        private string _ftpUser = "anonymous";
        private string _ftpPass = "anonymous";

        public frmMain()
        {
            InitializeComponent();

            // wire timer tick (designer does not hook the event)
            timerDownloadFTP.Tick += timerDownloadFTP_Tick;

            // use nudInterval (seconds) to set timer interval (ms)
            timerDownloadFTP.Interval = Math.Max(1, (int)nudInterval.Value) * 1000;

            // keep buttons consistent
            btnStop.Enabled = false;

            // update timer interval when user changes value
            nudInterval.ValueChanged += NudInterval_ValueChanged;

            lblRemotePath.Text = _remotePath;
            lblLocalPath.Text = _LocalPath;

        }

        // Thread-safe wrapper to append log text to txbFTPLog with timestamp.
        private void Log(string text)
        {
            string msg = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {text}{Environment.NewLine}";
            if (txbFTPLog.InvokeRequired)
            {
                txbFTPLog.Invoke(new Action(() => txbFTPLog.AppendText(msg)));
            }
            else
            {
                txbFTPLog.AppendText(msg);
            }
        }

        private void NudInterval_ValueChanged(object? sender, EventArgs e)
        {
            // update timer interval immediately (seconds -> ms)
            try
            {
                timerDownloadFTP.Interval = Math.Max(1, (int)nudInterval.Value) * 1000;
            }
            catch
            {
                // ignore invalid intervals
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string NewItem = Interaction.InputBox("Enter IP Address to add:", "Add IP Address", "", -1, -1);
            if (clbIPAddresses.Items.Contains(NewItem) == false && NewItem != "")
            {
                clbIPAddresses.Items.Add(NewItem);
            }
            else
            {
                // Was MessageBox.Show -> log instead
                Log("IP Address already exists or invalid input.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbIPAddresses.Items.Count; i++)
                clbIPAddresses.SetItemChecked(i, true);

            foreach (var item in clbIPAddresses.Items.OfType<string>().ToList())
            {
                clbIPAddresses.SetItemChecked(clbIPAddresses.Items.IndexOf(item), true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in clbIPAddresses.CheckedItems.OfType<string>().ToList())
            {
                clbIPAddresses.Items.Remove(item);
            }
        }

        private void selectLocalPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbdSelectPath.ShowDialog();
             _LocalPath = fbdSelectPath.SelectedPath;
            lblLocalPath.Text = _LocalPath;
        }

        // Only store remote path and credentials here (don't start downloads).
        private void selectRemotePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ask for remote folder path
            string remote = Interaction.InputBox("Enter remote FTP folder path to download (e.g. /pub/files):", "Remote Path", _remotePath, -1, -1);
            if (string.IsNullOrWhiteSpace(remote))
            {
                // Was MessageBox.Show -> log instead
                Log("Remote path is required.");
                return;
            }
            _remotePath = remote.Trim();

            // Ask for optional credentials (leave blank for anonymous)
            string user = Interaction.InputBox("Enter FTP username (leave blank for anonymous):", "FTP Username", _ftpUser, -1, -1);
            string pass = "";
            if (!string.IsNullOrEmpty(user))
            {
                pass = Interaction.InputBox("Enter FTP password (visible input):", "FTP Password", _ftpPass, -1, -1);
            }

            _ftpUser = user ?? "";
            _ftpPass = pass ?? "";

            // Informational message -> log instead of MessageBox
            Log("Remote path and credentials saved. Start the service to begin timed downloads.");

            lblRemotePath.Text = _remotePath;
        }

        // Start button handler (designer wired to btnStart_Click_1)
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            // Ensure prerequisites
            if (string.IsNullOrWhiteSpace(_remotePath))
            {
                // Was MessageBox.Show -> log instead
                Log("Remote path not set. Please select remote path first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lblLocalPath.Text))
            {
                var res = MessageBox.Show("No valid local path selected. Select one now?", "Local Path", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    fbdSelectPath.ShowDialog();
                    lblLocalPath.Text = fbdSelectPath.SelectedPath;
                }
            }

            if (string.IsNullOrWhiteSpace(lblLocalPath.Text))
            {
                // Was MessageBox.Show -> log instead
                Log("A valid local path is required to download files.");
                return;
            }

            // set flag and start timer
            startDownload = true;
            timerDownloadFTP.Interval = Math.Max(1, (int)nudInterval.Value) * 1000;
            timerDownloadFTP.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startDownload = false;
            timerDownloadFTP.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        // Timer tick handler: only attempt connection when startDownload == true.
        private async void timerDownloadFTP_Tick(object? sender, EventArgs e)
        {
            if (!startDownload) return;
            if (_isDownloading) return; // prevent overlapping runs

            var checkedIps = clbIPAddresses.CheckedItems.OfType<string>().ToList();
            if (checkedIps.Count == 0)
            {
                // nothing to do
                return;
            }

            _isDownloading = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            Cursor previous = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            var sb = new StringBuilder();
            try
            {
                foreach (var ip in checkedIps)
                {
                    try
                    {
                        sb.AppendLine($"Starting download from {ip}...");
                        await DownloadDirectoryRecursiveAsync(ip, _remotePath, lblLocalPath.Text, _ftpUser, _ftpPass);
                        sb.AppendLine($"Completed: {ip}");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine($"Failed {ip}: {ex.Message}");
                    }
                }
            }
            finally
            {
                _isDownloading = false;
                progressBar1.Style = ProgressBarStyle.Blocks;
                Cursor.Current = previous;
            }

            // show summary (non-blocking message) -> log instead
            if (sb.Length > 0)
                Log(sb.ToString());
        }

        /// <summary>
        /// Download a directory from an FTP server recursively.
        /// </summary>
        private async Task DownloadDirectoryRecursiveAsync(string server, string remoteDir, string localTargetBase, string username, string password)
        {
            // Normalize paths
            string remote = remoteDir.Trim().TrimStart('/'); // relative path portion
            string baseLocal = Path.Combine(localTargetBase, server.Replace(':', '_')); // create per-server folder
            if (!Directory.Exists(baseLocal)) Directory.CreateDirectory(baseLocal);

            await DownloadDirectoryContentsAsync(server, remote, baseLocal, username, password);
        }

        /// <summary>
        /// Download contents of a single remote folder into localFolder (creates localFolder).
        /// This method lists the directory and attempts to download items; when an item cannot be downloaded as a file,
        /// it will attempt to treat it as a directory and recurse.
        /// </summary>
        private async Task DownloadDirectoryContentsAsync(string server, string remoteRelativePath, string localFolder, string username, string password)
        {
            if (!Directory.Exists(localFolder)) Directory.CreateDirectory(localFolder);

            string listUrl = BuildFtpUri(server, remoteRelativePath);

            string[] entries;
            try
            {
                entries = await ListDirectoryAsync(listUrl, username, password);
            }
            catch (Exception)
            {
                // If we can't list the directory, rethrow to be handled by caller.
                throw;
            }

            foreach (var entry in entries)
            {
                if (string.IsNullOrWhiteSpace(entry))
                    continue;

                string entryName = entry.Trim();
                // Build remote and local paths
                string remoteEntryPath = string.IsNullOrEmpty(remoteRelativePath) ? entryName : $"{remoteRelativePath.TrimEnd('/')}/{entryName}";
                string localEntryPath = Path.Combine(localFolder, entryName);

                // Try to download as file
                try
                {
                    await DownloadFileAsync(server, remoteEntryPath, localEntryPath, username, password);
                    // file downloaded, continue
                }
                catch (WebException webEx)
                {
                    // If the download failed with a protocol error, treat as a directory and recurse.
                    // Other errors will bubble up.
                    if (webEx.Response is FtpWebResponse resp && resp.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        // directory or unavailable; attempt to recurse
                        await DownloadDirectoryContentsAsync(server, remoteEntryPath, localEntryPath, username, password);
                    }
                    else
                    {
                        // If it's another protocol error, attempt recursion as directory as a fallback
                        await DownloadDirectoryContentsAsync(server, remoteEntryPath, localEntryPath, username, password);
                    }
                }
                catch (Exception)
                {
                    // On unknown error treat as directory and recurse as best-effort
                    await DownloadDirectoryContentsAsync(server, remoteEntryPath, localEntryPath, username, password);
                }
            }
        }

        private string BuildFtpUri(string server, string remoteRelativePath)
        {
            // remoteRelativePath may be empty or a path like "folder/sub"
            string cleaned = remoteRelativePath?.Trim().TrimStart('/') ?? "";
            if (string.IsNullOrEmpty(cleaned))
                return $"ftp://{server}/";
            else
                return $"ftp://{server}/{cleaned}/";
        }

        /// <summary>
        /// Lists names in an FTP directory using ListDirectory (returns simple names, not details).
        /// </summary>
        private async Task<string[]> ListDirectoryAsync(string directoryUrl, string username, string password)
        {
            var req = (FtpWebRequest)WebRequest.Create(directoryUrl);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
                           if (!string.IsNullOrEmpty(username))
                req.Credentials = new NetworkCredential(username, password);
            else
                req.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
            req.UsePassive = true;
            req.UseBinary = true;
            req.KeepAlive = false;

            using (var resp = (FtpWebResponse)await req.GetResponseAsync())
            using (var stream = resp.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string content = await reader.ReadToEndAsync();
                // split by new lines. FTP returns CRLF separated listing
                var lines = content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                return lines;
            }
        }

        /// <summary>
        /// Downloads a single file from the FTP server to a local path.
        /// </summary>
        private async Task DownloadFileAsync(string server, string remoteFileRelativePath, string localFilePath, string username, string password)
        {
            string fileUrl = $"ftp://{server}/{remoteFileRelativePath}";
            var req = (FtpWebRequest)WebRequest.Create(fileUrl);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            if (!string.IsNullOrEmpty(username))
                req.Credentials = new NetworkCredential(username, password);
            else
                req.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");
            req.UseBinary = true;
            req.UsePassive = true;
            req.KeepAlive = false;

            using (var resp = (FtpWebResponse)await req.GetResponseAsync())
            using (var respStream = resp.GetResponseStream())
            {
                // Ensure local directory exists
                var localDir = Path.GetDirectoryName(localFilePath);
                if (!string.IsNullOrEmpty(localDir) && !Directory.Exists(localDir))
                    Directory.CreateDirectory(localDir);

                // Save to temporary file then move (safer)
                string tempFile = localFilePath + ".tmp";
                using (var fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await respStream.CopyToAsync(fs);
                }

                // Move/replace
                if (File.Exists(localFilePath))
                    File.Delete(localFilePath);
                File.Move(tempFile, localFilePath);
            }
        }

    }
}
