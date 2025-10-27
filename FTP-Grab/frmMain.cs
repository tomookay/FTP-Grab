namespace FTP_Grab
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblIntervalTitle_Click(object sender, EventArgs e)
        {

        }

        private void selectLocalPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbdSelectPath.ShowDialog();
            lblLocalPath.Text = fbdSelectPath.SelectedPath;

        }
    }
}
