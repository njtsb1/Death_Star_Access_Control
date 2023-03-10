using ControlAcess.Dao;
using ControlAcess.Entidades;
using ControlAcess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAcess.Forms
{
    public partial class frmRegisterEntryOutput : Form
    {
        private Pilot _pilot;
        private Pilot _pilotCommander;
        private Ship _ship;
        private int idShip;
        private int _idPilot;
        private bool _arrival;
        private bool _pilotTraveling;

        public frmRegisterEntryOutput(int idShip, int _idPilot, bool _arrival)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _idShip = idShip;
            __idPilot = _idPilot;
            __arrival = _arrival;            

            InitializeComponent();
        }

        private async void frmRegisterEntryOutput_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            int? _idPilotCommander;
            using (var shipDao = new ShipDao())
            {
                _ship = await shipDao.ObterPorId(_idShip);
                _idPilotCommander = await shipDao.GetCommander(_idShip);
            }

            using (var pilotDao = new PilotDao())
            {
                _pilot = await pilotDao.GetById(__idPilot);
                _pilotTraveling = await pilotDao.PilotTraveling(__idPilot);

                if(_idPilotCommander.HasValue)
                    _pilotCommander = await pilotDao.ObterPorId(_idPilotCommander.Value);
            }

            lvAlerts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAlerts.PerformLayout();

            FillDataNave();
            FillPilotData();

            if (ItsValid())
            {
                btnRegistrar.Enabled = true;
                this.Height = 228;
            }
            else
            {
                btnRegistrar.Enabled = false;
                this.Height = 490;
            }

            if (__arrival)
                btnRegistrar.Text = "Registrar _arrival";
            else
                btnRegistrar.Text = "Registrar Exit";

            Cursor = Cursors.Default;
        }

        private void FillDataNave()
        {
            lblNameNave.Text = _nave.Name;
            lblModel.Text = _nave.Model;
            lblClass.Text = _nave.Class;
        }

        private void FillPilotData()
        {
            lblNamePilot.Text = _pilot.Name;
            lblYearofBirth.Text = _pilot.YearofBirth;
            lblPlanet.Text = _pilot.Planet.Name;
        }

        private bool ItsValid()
        {
            bool itsValid = PilotoItsValid();
            itsValid = NavitsValid() && itsValid;

            return itsValid;
        }

        private bool PilotItsValid()
        {
            bool itsValid = true;
            
            //Goingout
            if (!__arrival)
            {
                if (_pilotTraveling)
                {
                    itsValid = false;
                    lvAlerts.Items.Add(new ListViewItem("DANGER - PILOT HAS NOT ARRIVED FROM TRAVEL YET, MUST BE AN IMPOSER"));
                }

                if(!_pilot.Ships.Any(ship => ship.idShip == ship.idShip))
                {
                    itsValid = false;
                    lvAlerts.Items.Add(new ListViewItem("This pilot is not qualified for this ship"));
                }
            }

            //Coming
            if (__arrival && !_pilotTraveling)
            {
                itsValid = false;
                lvAlerts.Items.Add(new ListViewItem("DANGER - PILOT DIDN'T GO OUT, MUST BE AN IMPOSER"));
            }
            
            return itsValid;
        }

        private bool ShipIsVaIid()
        {
            bool itsValid = true;

            //Goingout
            if(!__arrival && _pilotCommander != null)
            {
                itsValid = false;
                lvAlerts.Items.Add(new ListViewItem("Ship is already underway"));
            }

            //Coming
            if (__arrival)
            {
                if (_pilotCommander == null)
                {
                    itsValid = false;
                    lvAlerts.Items.Add(new ListViewItem("DANGER - SHIP DID NOT LEAVE, MAY BE AN IMPOSER SHIP"));
                }

                if(_pilotCommander != null && _pilotCommander._idPilot != _pilot._idPilot)
                {
                    itsValid = false;
                    lvAlerts.Items.Add(new ListViewItem($"DANGER - PILOT WHO REMOVED THE SHIP WAS '{_pilotCommander.Name.ToUpper()}'"));
                }
            }

            return itsValid;
        }

        private void frmRegisterEntryOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (__arrival)
                await RegisterEntry();
            else
                await RegisterExit();

            btnRegister.Enabled = false;
            MessageBox.Show("Registration successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task RegisterEntry()
        {
            using (var pilotDao = new PilotDao())
                await pilotDao.RegisterEndTrip(__idPilot, _idShip);
        }

        private async Task RegisterExit()
        {
            using (var pilotDao = new PilotDao())
                await pilotDao.RegisterStartTravel(__idPilot, _idShip);
        }
    }
}
