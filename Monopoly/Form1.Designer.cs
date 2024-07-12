namespace Monopoly
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
            btnRoll = new Button();
            txtLog = new TextBox();
            label1 = new Label();
            lblMoney1 = new Label();
            lblPos1 = new Label();
            lblPos2 = new Label();
            lblMoney2 = new Label();
            label6 = new Label();
            lblPos4 = new Label();
            lblMoney4 = new Label();
            label9 = new Label();
            lblPos3 = new Label();
            lblMoney3 = new Label();
            label12 = new Label();
            lblOwned1 = new Label();
            lblOwned2 = new Label();
            lblOwned3 = new Label();
            lblOwned4 = new Label();
            btnUpgrade = new Button();
            btnConnect = new Button();
            txtIp = new TextBox();
            txtPort = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnCreateGame = new Button();
            txtServerPort = new TextBox();
            btnEndRound = new Button();
            lblPlayer = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnRoll
            // 
            btnRoll.Enabled = false;
            btnRoll.Location = new Point(222, 220);
            btnRoll.Margin = new Padding(3, 2, 3, 2);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(82, 22);
            btnRoll.TabIndex = 0;
            btnRoll.Text = "Roll";
            btnRoll.UseVisualStyleBackColor = true;
            btnRoll.Click += btnRoll_Click;
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtLog.Location = new Point(489, 194);
            txtLog.Margin = new Padding(3, 2, 3, 2);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(512, 422);
            txtLog.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(489, 7);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 2;
            label1.Text = "Player 0: (Red)";
            // 
            // lblMoney1
            // 
            lblMoney1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMoney1.AutoSize = true;
            lblMoney1.Location = new Point(489, 22);
            lblMoney1.Name = "lblMoney1";
            lblMoney1.Size = new Size(78, 15);
            lblMoney1.TabIndex = 3;
            lblMoney1.Text = "Money: XXXX";
            // 
            // lblPos1
            // 
            lblPos1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPos1.AutoSize = true;
            lblPos1.Location = new Point(489, 37);
            lblPos1.Name = "lblPos1";
            lblPos1.Size = new Size(82, 15);
            lblPos1.TabIndex = 4;
            lblPos1.Text = "Current pos: X";
            // 
            // lblPos2
            // 
            lblPos2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPos2.AutoSize = true;
            lblPos2.Location = new Point(636, 37);
            lblPos2.Name = "lblPos2";
            lblPos2.Size = new Size(82, 15);
            lblPos2.TabIndex = 7;
            lblPos2.Text = "Current pos: X";
            // 
            // lblMoney2
            // 
            lblMoney2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMoney2.AutoSize = true;
            lblMoney2.Location = new Point(636, 22);
            lblMoney2.Name = "lblMoney2";
            lblMoney2.Size = new Size(78, 15);
            lblMoney2.TabIndex = 6;
            lblMoney2.Text = "Money: XXXX";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(636, 7);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 5;
            label6.Text = "Player 1: (Blue)";
            // 
            // lblPos4
            // 
            lblPos4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPos4.AutoSize = true;
            lblPos4.Location = new Point(900, 37);
            lblPos4.Name = "lblPos4";
            lblPos4.Size = new Size(82, 15);
            lblPos4.TabIndex = 10;
            lblPos4.Text = "Current pos: X";
            // 
            // lblMoney4
            // 
            lblMoney4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMoney4.AutoSize = true;
            lblMoney4.Location = new Point(900, 22);
            lblMoney4.Name = "lblMoney4";
            lblMoney4.Size = new Size(78, 15);
            lblMoney4.TabIndex = 9;
            lblMoney4.Text = "Money: XXXX";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(900, 7);
            label9.Name = "label9";
            label9.Size = new Size(96, 15);
            label9.TabIndex = 8;
            label9.Text = "Player 3: (Yellow)";
            // 
            // lblPos3
            // 
            lblPos3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPos3.AutoSize = true;
            lblPos3.Location = new Point(772, 37);
            lblPos3.Name = "lblPos3";
            lblPos3.Size = new Size(82, 15);
            lblPos3.TabIndex = 13;
            lblPos3.Text = "Current pos: X";
            // 
            // lblMoney3
            // 
            lblMoney3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMoney3.AutoSize = true;
            lblMoney3.Location = new Point(772, 22);
            lblMoney3.Name = "lblMoney3";
            lblMoney3.Size = new Size(78, 15);
            lblMoney3.TabIndex = 12;
            lblMoney3.Text = "Money: XXXX";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(772, 7);
            label12.Name = "label12";
            label12.Size = new Size(93, 15);
            label12.TabIndex = 11;
            label12.Text = "Player 2: (Green)";
            // 
            // lblOwned1
            // 
            lblOwned1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwned1.AutoSize = true;
            lblOwned1.Location = new Point(489, 62);
            lblOwned1.Name = "lblOwned1";
            lblOwned1.Size = new Size(61, 45);
            lblOwned1.TabIndex = 14;
            lblOwned1.Text = "Owned:\r\nProperty 1\r\nProperty 2";
            // 
            // lblOwned2
            // 
            lblOwned2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwned2.AutoSize = true;
            lblOwned2.Location = new Point(636, 62);
            lblOwned2.Name = "lblOwned2";
            lblOwned2.Size = new Size(61, 45);
            lblOwned2.TabIndex = 15;
            lblOwned2.Text = "Owned:\r\nProperty 1\r\nProperty 2";
            // 
            // lblOwned3
            // 
            lblOwned3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwned3.AutoSize = true;
            lblOwned3.Location = new Point(772, 62);
            lblOwned3.Name = "lblOwned3";
            lblOwned3.Size = new Size(61, 45);
            lblOwned3.TabIndex = 16;
            lblOwned3.Text = "Owned:\r\nProperty 1\r\nProperty 2";
            // 
            // lblOwned4
            // 
            lblOwned4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOwned4.AutoSize = true;
            lblOwned4.Location = new Point(900, 62);
            lblOwned4.Name = "lblOwned4";
            lblOwned4.Size = new Size(61, 45);
            lblOwned4.TabIndex = 17;
            lblOwned4.Text = "Owned:\r\nProperty 1\r\nProperty 2";
            // 
            // btnUpgrade
            // 
            btnUpgrade.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUpgrade.Location = new Point(489, 168);
            btnUpgrade.Margin = new Padding(3, 2, 3, 2);
            btnUpgrade.Name = "btnUpgrade";
            btnUpgrade.Size = new Size(67, 22);
            btnUpgrade.TabIndex = 18;
            btnUpgrade.Text = "Upgrade";
            btnUpgrade.UseVisualStyleBackColor = true;
            btnUpgrade.Click += btnUpgrade_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(217, 22);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 22;
            btnConnect.Text = "Gå";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtIp
            // 
            txtIp.Location = new Point(6, 22);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(142, 23);
            txtIp.TabIndex = 23;
            txtIp.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(154, 22);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(55, 23);
            txtPort.TabIndex = 24;
            txtPort.Text = "1234";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(txtIp);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Location = new Point(12, 562);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 54);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gå med!";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(btnCreateGame);
            groupBox2.Controls.Add(txtServerPort);
            groupBox2.Location = new Point(323, 562);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(160, 54);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Skapa spel";
            // 
            // btnCreateGame
            // 
            btnCreateGame.Location = new Point(79, 21);
            btnCreateGame.Name = "btnCreateGame";
            btnCreateGame.Size = new Size(75, 23);
            btnCreateGame.TabIndex = 28;
            btnCreateGame.Text = "Skapa";
            btnCreateGame.UseVisualStyleBackColor = true;
            btnCreateGame.Click += btnCreateGame_Click;
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(6, 22);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(67, 23);
            txtServerPort.TabIndex = 27;
            txtServerPort.Text = "1234";
            // 
            // btnEndRound
            // 
            btnEndRound.Enabled = false;
            btnEndRound.Location = new Point(222, 192);
            btnEndRound.Name = "btnEndRound";
            btnEndRound.Size = new Size(75, 23);
            btnEndRound.TabIndex = 27;
            btnEndRound.Text = "End";
            btnEndRound.UseVisualStyleBackColor = true;
            btnEndRound.Click += btnEndRound_Click;
            // 
            // lblPlayer
            // 
            lblPlayer.Location = new Point(94, 88);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(51, 23);
            lblPlayer.TabIndex = 29;
            lblPlayer.Text = "Player: 1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 624);
            Controls.Add(lblPlayer);
            Controls.Add(btnEndRound);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnUpgrade);
            Controls.Add(lblOwned4);
            Controls.Add(lblOwned3);
            Controls.Add(lblOwned2);
            Controls.Add(lblOwned1);
            Controls.Add(lblPos3);
            Controls.Add(lblMoney3);
            Controls.Add(label12);
            Controls.Add(lblPos4);
            Controls.Add(lblMoney4);
            Controls.Add(label9);
            Controls.Add(lblPos2);
            Controls.Add(lblMoney2);
            Controls.Add(label6);
            Controls.Add(lblPos1);
            Controls.Add(lblMoney1);
            Controls.Add(label1);
            Controls.Add(txtLog);
            Controls.Add(btnRoll);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRoll;
        private TextBox txtLog;
        private Label label1;
        private Label lblMoney1;
        private Label lblPos1;
        private Label lblPos2;
        private Label lblMoney2;
        private Label label6;
        private Label lblPos4;
        private Label lblMoney4;
        private Label label9;
        private Label lblPos3;
        private Label lblMoney3;
        private Label label12;
        private Label lblOwned1;
        private Label lblOwned2;
        private Label lblOwned3;
        private Label lblOwned4;
        private Button btnUpgrade;
        private Button btnConnect;
        private TextBox txtIp;
        private TextBox txtPort;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnCreateGame;
        private TextBox txtServerPort;
        private Button btnEndRound;
        private TextBox lblPlayer;
    }
}
