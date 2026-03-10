namespace Battle_Ships
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStart = new Button();
            dgvEnemy = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            dgvPlayer = new DataGridView();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            Column17 = new DataGridViewTextBoxColumn();
            Column18 = new DataGridViewTextBoxColumn();
            Column19 = new DataGridViewTextBoxColumn();
            Column20 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            btnPlace = new Button();
            btnReset = new Button();
            btnSurrender = new Button();
            rtbShipsLeft = new RichTextBox();
            label3 = new Label();
            btnRestart = new Button();
            btnTutorial = new Button();
            btnTutorial2 = new Button();
            richTextBox1 = new RichTextBox();
            thisExit = new Button();
            btnEasy = new Button();
            btnSmartAI = new Button();
            lblStart = new Label();
            lblSurrender = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEnemy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlayer).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Image = Properties.Resources.missile;
            btnStart.Location = new Point(651, 434);
            btnStart.Margin = new Padding(2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(111, 58);
            btnStart.TabIndex = 0;
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // dgvEnemy
            // 
            dgvEnemy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnemy.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10 });
            dgvEnemy.Location = new Point(501, 38);
            dgvEnemy.Margin = new Padding(2);
            dgvEnemy.Name = "dgvEnemy";
            dgvEnemy.ReadOnly = true;
            dgvEnemy.RowHeadersWidth = 62;
            dgvEnemy.RowTemplate.Height = 33;
            dgvEnemy.ScrollBars = ScrollBars.None;
            dgvEnemy.Size = new Size(464, 348);
            dgvEnemy.TabIndex = 1;
            dgvEnemy.CellMouseClick += dgvEnemy_CellMouseClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "A";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 40;
            // 
            // Column2
            // 
            Column2.HeaderText = "B";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 40;
            // 
            // Column3
            // 
            Column3.HeaderText = "C";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 40;
            // 
            // Column4
            // 
            Column4.HeaderText = "D";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 40;
            // 
            // Column5
            // 
            Column5.HeaderText = "E";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 40;
            // 
            // Column6
            // 
            Column6.HeaderText = "F";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 40;
            // 
            // Column7
            // 
            Column7.HeaderText = "G";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 40;
            // 
            // Column8
            // 
            Column8.HeaderText = "H";
            Column8.MinimumWidth = 8;
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            Column8.Width = 40;
            // 
            // Column9
            // 
            Column9.HeaderText = "I";
            Column9.MinimumWidth = 8;
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            Column9.Width = 40;
            // 
            // Column10
            // 
            Column10.HeaderText = "J";
            Column10.MinimumWidth = 8;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            Column10.Width = 40;
            // 
            // dgvPlayer
            // 
            dgvPlayer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayer.Columns.AddRange(new DataGridViewColumn[] { Column11, Column12, Column13, Column14, Column15, Column16, Column17, Column18, Column19, Column20 });
            dgvPlayer.Location = new Point(24, 38);
            dgvPlayer.Margin = new Padding(2);
            dgvPlayer.Name = "dgvPlayer";
            dgvPlayer.ReadOnly = true;
            dgvPlayer.RowHeadersWidth = 62;
            dgvPlayer.RowTemplate.Height = 33;
            dgvPlayer.ScrollBars = ScrollBars.None;
            dgvPlayer.Size = new Size(461, 348);
            dgvPlayer.TabIndex = 2;
            // 
            // Column11
            // 
            Column11.HeaderText = "A";
            Column11.MinimumWidth = 8;
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Width = 40;
            // 
            // Column12
            // 
            Column12.HeaderText = "B";
            Column12.MinimumWidth = 8;
            Column12.Name = "Column12";
            Column12.ReadOnly = true;
            Column12.Width = 40;
            // 
            // Column13
            // 
            Column13.HeaderText = "C";
            Column13.MinimumWidth = 8;
            Column13.Name = "Column13";
            Column13.ReadOnly = true;
            Column13.Width = 40;
            // 
            // Column14
            // 
            Column14.HeaderText = "D";
            Column14.MinimumWidth = 8;
            Column14.Name = "Column14";
            Column14.ReadOnly = true;
            Column14.Width = 40;
            // 
            // Column15
            // 
            Column15.HeaderText = "E";
            Column15.MinimumWidth = 8;
            Column15.Name = "Column15";
            Column15.ReadOnly = true;
            Column15.Width = 40;
            // 
            // Column16
            // 
            Column16.HeaderText = "F";
            Column16.MinimumWidth = 8;
            Column16.Name = "Column16";
            Column16.ReadOnly = true;
            Column16.Width = 40;
            // 
            // Column17
            // 
            Column17.HeaderText = "G";
            Column17.MinimumWidth = 8;
            Column17.Name = "Column17";
            Column17.ReadOnly = true;
            Column17.Width = 40;
            // 
            // Column18
            // 
            Column18.HeaderText = "H";
            Column18.MinimumWidth = 8;
            Column18.Name = "Column18";
            Column18.ReadOnly = true;
            Column18.Width = 40;
            // 
            // Column19
            // 
            Column19.HeaderText = "I";
            Column19.MinimumWidth = 8;
            Column19.Name = "Column19";
            Column19.ReadOnly = true;
            Column19.Width = 40;
            // 
            // Column20
            // 
            Column20.HeaderText = "J";
            Column20.MinimumWidth = 8;
            Column20.Name = "Column20";
            Column20.ReadOnly = true;
            Column20.Width = 40;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.MediumTurquoise;
            label1.Location = new Point(80, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 3;
            label1.Text = "Your grid";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(846, 7);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 4;
            label2.Text = "Enemy grid";
            // 
            // btnPlace
            // 
            btnPlace.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPlace.Location = new Point(207, 434);
            btnPlace.Margin = new Padding(2);
            btnPlace.Name = "btnPlace";
            btnPlace.Size = new Size(130, 58);
            btnPlace.TabIndex = 5;
            btnPlace.Text = "Place ship";
            btnPlace.UseVisualStyleBackColor = true;
            btnPlace.Click += btnPlace_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(470, 434);
            btnReset.Margin = new Padding(2);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(130, 58);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset ships";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSurrender
            // 
            btnSurrender.BackColor = Color.Red;
            btnSurrender.Enabled = false;
            btnSurrender.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSurrender.Image = (Image)resources.GetObject("btnSurrender.Image");
            btnSurrender.Location = new Point(60, 414);
            btnSurrender.Margin = new Padding(2);
            btnSurrender.Name = "btnSurrender";
            btnSurrender.Size = new Size(143, 96);
            btnSurrender.TabIndex = 7;
            btnSurrender.UseVisualStyleBackColor = false;
            btnSurrender.Visible = false;
            btnSurrender.Click += btnSurrender_Click;
            // 
            // rtbShipsLeft
            // 
            rtbShipsLeft.Location = new Point(354, 407);
            rtbShipsLeft.Margin = new Padding(2);
            rtbShipsLeft.Name = "rtbShipsLeft";
            rtbShipsLeft.ReadOnly = true;
            rtbShipsLeft.ScrollBars = RichTextBoxScrollBars.None;
            rtbShipsLeft.Size = new Size(112, 98);
            rtbShipsLeft.TabIndex = 9;
            rtbShipsLeft.Text = "Ships left:\nCarrier\nBattleship\nCruiser\nSubmarine\nDestroyer\n\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Black", 30F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(138, 184);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(210, 54);
            label3.TabIndex = 11;
            label3.Text = "___________";
            label3.Visible = false;
            // 
            // btnRestart
            // 
            btnRestart.Enabled = false;
            btnRestart.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRestart.Location = new Point(385, 184);
            btnRestart.Margin = new Padding(2);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(200, 73);
            btnRestart.TabIndex = 12;
            btnRestart.Text = "RESTART";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Visible = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnTutorial
            // 
            btnTutorial.BackColor = Color.FromArgb(255, 255, 220);
            btnTutorial.Location = new Point(990, 11);
            btnTutorial.Margin = new Padding(2);
            btnTutorial.Name = "btnTutorial";
            btnTutorial.Size = new Size(100, 29);
            btnTutorial.TabIndex = 13;
            btnTutorial.Text = "How To Place";
            btnTutorial.UseVisualStyleBackColor = false;
            btnTutorial.Click += btnTutorial_Click;
            // 
            // btnTutorial2
            // 
            btnTutorial2.BackColor = Color.FromArgb(255, 255, 220);
            btnTutorial2.Location = new Point(990, 62);
            btnTutorial2.Margin = new Padding(2);
            btnTutorial2.Name = "btnTutorial2";
            btnTutorial2.Size = new Size(100, 30);
            btnTutorial2.TabIndex = 14;
            btnTutorial2.Text = "How To Shoot";
            btnTutorial2.UseVisualStyleBackColor = false;
            btnTutorial2.Click += btnTutorial2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.None;
            richTextBox1.BackColor = Color.FromArgb(255, 255, 210);
            richTextBox1.Location = new Point(990, 108);
            richTextBox1.Margin = new Padding(2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(101, 97);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "Ship size:\nCarrier - 5\nBattleship - 4\nCruiser - 3\nSubmarine - 3\nDestroyer - 2\n\n";
            // 
            // thisExit
            // 
            thisExit.BackColor = SystemColors.Control;
            thisExit.CausesValidation = false;
            thisExit.Location = new Point(8, 7);
            thisExit.Margin = new Padding(2);
            thisExit.Name = "thisExit";
            thisExit.Size = new Size(52, 23);
            thisExit.TabIndex = 16;
            thisExit.Text = "Exit";
            thisExit.UseVisualStyleBackColor = false;
            thisExit.Click += thisExit_Click;
            // 
            // btnEasy
            // 
            btnEasy.BackColor = Color.White;
            btnEasy.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnEasy.ForeColor = Color.SeaGreen;
            btnEasy.Location = new Point(990, 221);
            btnEasy.Margin = new Padding(2);
            btnEasy.Name = "btnEasy";
            btnEasy.Size = new Size(100, 46);
            btnEasy.TabIndex = 19;
            btnEasy.Text = "Easy";
            btnEasy.UseVisualStyleBackColor = false;
            btnEasy.Click += btnEasy_Click;
            // 
            // btnSmartAI
            // 
            btnSmartAI.BackColor = Color.White;
            btnSmartAI.Font = new Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSmartAI.ForeColor = Color.FromArgb(255, 128, 0);
            btnSmartAI.Location = new Point(990, 275);
            btnSmartAI.Margin = new Padding(2);
            btnSmartAI.Name = "btnSmartAI";
            btnSmartAI.Size = new Size(100, 46);
            btnSmartAI.TabIndex = 20;
            btnSmartAI.Text = "Normal";
            btnSmartAI.UseVisualStyleBackColor = false;
            btnSmartAI.Click += btnSmartAI_Click;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.BackColor = SystemColors.Control;
            lblStart.Enabled = false;
            lblStart.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblStart.Location = new Point(486, 480);
            lblStart.Margin = new Padding(2, 0, 2, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(99, 25);
            lblStart.TabIndex = 22;
            lblStart.Text = "Start Game";
            // 
            // lblSurrender
            // 
            lblSurrender.AutoSize = true;
            lblSurrender.Enabled = false;
            lblSurrender.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblSurrender.Location = new Point(89, 495);
            lblSurrender.Margin = new Padding(2, 0, 2, 0);
            lblSurrender.Name = "lblSurrender";
            lblSurrender.Size = new Size(89, 25);
            lblSurrender.TabIndex = 23;
            lblSurrender.Text = "Surrender";
            lblSurrender.Visible = false;
            lblSurrender.Click += lblSurrender_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 540);
            Controls.Add(lblSurrender);
            Controls.Add(lblStart);
            Controls.Add(btnSmartAI);
            Controls.Add(btnEasy);
            Controls.Add(btnRestart);
            Controls.Add(label3);
            Controls.Add(thisExit);
            Controls.Add(btnTutorial);
            Controls.Add(btnTutorial2);
            Controls.Add(richTextBox1);
            Controls.Add(rtbShipsLeft);
            Controls.Add(btnSurrender);
            Controls.Add(btnReset);
            Controls.Add(btnPlace);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvPlayer);
            Controls.Add(dgvEnemy);
            Controls.Add(btnStart);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEnemy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private DataGridView dgvEnemy;
        private DataGridView dgvPlayer;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private DataGridViewTextBoxColumn Column17;
        private DataGridViewTextBoxColumn Column18;
        private DataGridViewTextBoxColumn Column19;
        private DataGridViewTextBoxColumn Column20;
        private Button btnPlace;
        private Button btnReset;
        private Button btnSurrender;
        private RichTextBox rtbShipsLeft;
        private Label label3;
        private Button btnRestart;
        private Button btnTutorial;
        private Button btnTutorial2;
        private RichTextBox richTextBox1;
        private Button thisExit;
        private RichTextBox richTextBox2;
        private Button btnEasy;
        private Button btnSmartAI;
        private Label lblStart;
        private Label lblSurrender;
    }
}