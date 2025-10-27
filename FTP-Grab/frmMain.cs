using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace FTP_Grab
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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
                MessageBox.Show("IP Address already exists or invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            lblLocalPath.Text = fbdSelectPath.SelectedPath;
        }
    }
}
