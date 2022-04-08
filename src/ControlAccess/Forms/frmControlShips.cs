using ControlAcess.Dao;
using ControlAcess.Extensions;
using System;
using System.Windows.Forms;

namespace ControlAcess.Forms
{
    public partial class frmControlShips : Form
    {
        private readonly PilotDao _pilotDao;
        private readonly ShipDao _shipDao;

        public frmControlShips()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _pilotDao = new PilotDao();
            _shipDao = new ShipDao();
            InitializeComponent();
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if(!rdbComing.Checked && !rdbGoingout.Checked)
            {
                MessageBox.Show("It is necessary to inform if the ship is arriving or leaving the Death Star!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvShips.Rows.Count == 0 || dgvShips.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("You only need to select one ship!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvPilots.Rows.Count == 0 || dgvPilots.Rows.GetCountRowsChecked(1) != 1)
            {
                MessageBox.Show("É preciso selecionar apenas um piloto da nave!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var idPilot = int.Parse(dgvPilots.Rows[dgvPilots.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var idShip = int.Parse(dgvShips.Rows[dgvShips.Rows.GetFirstIndexChecked(1)].Cells[0].Value.ToString());
            var frm = new frmRegistrarEntradaSaida(idShip, idPilot, rdbComing.Checked);
            frm.ShowDialog();
        }

        private void frmControlShips_FormClosing(object sender, FormClosingEventArgs e)
        {
            _shipDao?.Dispose();
            _pilotDao?.Dispose();
            Dispose();
        }

        private async void btnSearchship_Click(object sender, EventArgs e)
        {
            dgvShips.Rows.Clear();
            dgvShips.Columns.Clear();

            if (string.IsNullOrEmpty(txtNameShip.Text))
                return;

            Cursor = Cursors.WaitCursor;
            DataGridViewTextBoxColumn idShipColumn = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn checkShipColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn nameShipColumn = new DataGridViewTextBoxColumn();

            idShipColumn.Visible = false;

            idShipColumn.ReadOnly = true;
            checkShipColumn.ReadOnly = false;
            nameShipColumn.ReadOnly = true;

            nameShipColumn.Width = 500;

            dgvShips.RowHeadersVisible = false;
            dgvShips.ColumnHeadersVisible = false;
            dgvShips.Columns.Add(idShipColumn);
            dgvShips.Columns.Add(checkShipColumn);
            dgvShips.Columns.Add(nameShipColumn);

            var ships = await _shipDao.GetByNameLike(txtNameShip.Text);
            foreach (var ship in ships)
                dgvShips.Rows.Add(ship.idShip, false, ship.Name);

            dgvShips.PerformLayout();
            Cursor = Cursors.Default;
        }

        private async void btnSearchPilot_Click(object sender, EventArgs e)
        {
            dgvPilots.Rows.Clear();
            dgvPilots.Columns.Clear();

            if (string.IsNullOrEmpty(txtNamePilot.Text))
                return;

            Cursor = Cursors.WaitCursor;
            DataGridViewTextBoxColumn idPilotColumn = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn checkPilotColumn = new DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn namePilotColumn = new DataGridViewTextBoxColumn();

            idPilotColumn.Visible = false;

            idPilotColumn.ReadOnly = true;
            checkPilotColumn.ReadOnly = false;
            namePilotColumn.ReadOnly = true;

            namePilotColumn.Width = 500;

            dgvPilots.RowHeadersVisible = false;
            dgvPilots.ColumnHeadersVisible = false;
            dgvPilots.Columns.Add(idPilotColumn);
            dgvPilots.Columns.Add(checkPilotColumn);
            dgvPilots.Columns.Add(namePilotColumn);

            var pilots = await _pilotDao.GetByNameike(txtNamePilot.Text);
            foreach (var pilot in pilots)
                dgvPilots.Rows.Add(pilot.idPilot, false, pilot.Name);

            dgvShips.PerformLayout();
            Cursor = Cursors.Default;
        }
    }
}
