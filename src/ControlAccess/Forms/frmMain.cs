using ControlAcess.Servicos;
using System;
using System.Windows.Forms;

namespace ControlAcess.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private async void btnSynchronize_Click(object sender, EventArgs e)
        {
            var synchronizer = new SynchronizerService();

            Cursor = Cursors.WaitCursor;
            await synchronizer.Synchronize();
            Cursor = Cursors.Default;

            MessageBox.Show("Sync completed successfully", "Synchronization", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmControlShips();
            frm.ShowDialog();
        }
    }
}
