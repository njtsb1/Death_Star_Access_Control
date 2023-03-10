
namespace ControlAcess.Forms
{
    partial class frmControlShips
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <stop name="disposing">true if managed resources should be disposed; otherwise, false.</stop>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNameShip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamePilot = new System.Windows.Forms.TextBox();
            this.dgvShips = new System.Windows.Forms.DataGridView();
            this.dgvPilots = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGoingout = new System.Windows.Forms.RadioButton();
            this.rdbComing = new System.Windows.Forms.RadioButton();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.btnSearchShip = new System.Windows.Forms.Button();
            this.btnSearchPilot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilots)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNameShip
            // 
            this.txtNameShip.Location = new System.Drawing.Point(56, 12);
            this.txtNameShip.Name = "txtNameShip";
            this.txtNameShip.Size = new System.Drawing.Size(620, 23);
            this.txtNameShip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ship:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pilot:";
            // 
            // txtNamePilot
            // 
            this.txtNamePilot.Location = new System.Drawing.Point(56, 218);
            this.txtNamePilot.Name = "txtNamePilot";
            this.txtNamePilot.Size = new System.Drawing.Size(620, 23);
            this.txtNamePilot.TabIndex = 2;
            // 
            // dgvShips
            // 
            this.dgvShips.AllowUserToAddRows = false;
            this.dgvShips.AllowUserToDeleteRows = false;
            this.dgvShips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShips.Location = new System.Drawing.Point(56, 41);
            this.dgvShips.Name = "dgvShips";
            this.dgvShips.RowTemplate.Height = 25;
            this.dgvShips.Size = new System.Drawing.Size(693, 171);
            this.dgvShips.TabIndex = 4;
            // 
            // dgvPilots
            // 
            this.dgvPilots.AllowUserToAddRows = false;
            this.dgvPilots.AllowUserToDeleteRows = false;
            this.dgvPilots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPilots.Location = new System.Drawing.Point(56, 247);
            this.dgvPilots.Name = "dgvPilots";
            this.dgvPilots.RowTemplate.Height = 25;
            this.dgvPilots.Size = new System.Drawing.Size(693, 171);
            this.dgvPilots.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbGoingout);
            this.groupBox1.Controls.Add(this.rdbComing);
            this.groupBox1.Location = new System.Drawing.Point(56, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 37);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdbGoingout
            // 
            this.rdbGoingout.AutoSize = true;
            this.rdbGoingout.Location = new System.Drawing.Point(171, 12);
            this.rdbGoingout.Name = "rdbGoingout";
            this.rdbGoingout.Size = new System.Drawing.Size(61, 19);
            this.rdbGoingout.TabIndex = 1;
            this.rdbGoingout.TabStop = true;
            this.rdbGoingout.Text = "Goingout";
            this.rdbGoingout.UseVisualStyleBackColor = true;
            // 
            // rdbComing
            // 
            this.rdbComing.AutoSize = true;
            this.rdbComing.Location = new System.Drawing.Point(21, 12);
            this.rdbComing.Name = "rdbComing";
            this.rdbComing.Size = new System.Drawing.Size(80, 19);
            this.rdbComing.TabIndex = 0;
            this.rdbComing.TabStop = true;
            this.rdbComing.Text = "Coming";
            this.rdbComing.UseVisualStyleBackColor = true;
            // 
            // btnAdvance
            // 
            this.btnAdvance.Location = new System.Drawing.Point(651, 435);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(75, 23);
            this.btnAdvance.TabIndex = 7;
            this.btnAdvance.Text = "Advance";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // btnSearchShip
            // 
            this.btnSearchShip.Location = new System.Drawing.Point(682, 11);
            this.btnSearchShip.Name = "btnSearchShip";
            this.btnSearchShip.Size = new System.Drawing.Size(67, 23);
            this.btnSearchShip.TabIndex = 8;
            this.btnSearchShip.Text = "Search";
            this.btnSearchShip.UseVisualStyleBackColor = true;
            this.btnSearchShip.Click += new System.EventHandler(this.btnSearchShip_Click);
            // 
            // btnSearchPilot
            // 
            this.btnSearchPilot.Location = new System.Drawing.Point(682, 217);
            this.btnSearchPilot.Name = "btnSearchPilot";
            this.btnSearchPilot.Size = new System.Drawing.Size(67, 23);
            this.btnSearchPilot.TabIndex = 9;
            this.btnSearchPilot.Text = "Search";
            this.btnSearchPilot.UseVisualStyleBackColor = true;
            this.btnSearchPilot.Click += new System.EventHandler(this.btnSearchPilot_Click);
            // 
            // frmControleNaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 474);
            this.Controls.Add(this.btnSearchPilot);
            this.Controls.Add(this.btnSearchShip);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPilots);
            this.Controls.Add(this.dgvShips);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNamePilot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNameShip);
            this.Name = "frmControlShips";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControlShipss_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPilots)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNameShip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamePilot;
        private System.Windows.Forms.DataGridView dgvShips;
        private System.Windows.Forms.DataGridView dgvPilots;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbGoingout;
        private System.Windows.Forms.RadioButton rdbComing;
        private System.Windows.Forms.Button btnAdvance;
        private System.Windows.Forms.Button btnSearchShip;
        private System.Windows.Forms.Button btnSearchPilot;
    }
}