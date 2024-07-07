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
            SuspendLayout();
            // 
            // btnRoll
            // 
            btnRoll.Location = new Point(367, 409);
            btnRoll.Name = "btnRoll";
            btnRoll.Size = new Size(94, 29);
            btnRoll.TabIndex = 0;
            btnRoll.Text = "Roll";
            btnRoll.UseVisualStyleBackColor = true;
            btnRoll.Click += btnRoll_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(559, 239);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(429, 309);
            txtLog.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(559, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 2;
            label1.Text = "Player 1:";
            // 
            // lblMoney1
            // 
            lblMoney1.AutoSize = true;
            lblMoney1.Location = new Point(559, 29);
            lblMoney1.Name = "lblMoney1";
            lblMoney1.Size = new Size(97, 20);
            lblMoney1.TabIndex = 3;
            lblMoney1.Text = "Money: XXXX";
            // 
            // lblPos1
            // 
            lblPos1.AutoSize = true;
            lblPos1.Location = new Point(559, 49);
            lblPos1.Name = "lblPos1";
            lblPos1.Size = new Size(101, 20);
            lblPos1.TabIndex = 4;
            lblPos1.Text = "Current pos: X";
            // 
            // lblPos2
            // 
            lblPos2.AutoSize = true;
            lblPos2.Location = new Point(667, 49);
            lblPos2.Name = "lblPos2";
            lblPos2.Size = new Size(101, 20);
            lblPos2.TabIndex = 7;
            lblPos2.Text = "Current pos: X";
            // 
            // lblMoney2
            // 
            lblMoney2.AutoSize = true;
            lblMoney2.Location = new Point(667, 29);
            lblMoney2.Name = "lblMoney2";
            lblMoney2.Size = new Size(97, 20);
            lblMoney2.TabIndex = 6;
            lblMoney2.Text = "Money: XXXX";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(667, 9);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 5;
            label6.Text = "Player 2:";
            // 
            // lblPos4
            // 
            lblPos4.AutoSize = true;
            lblPos4.Location = new Point(883, 49);
            lblPos4.Name = "lblPos4";
            lblPos4.Size = new Size(101, 20);
            lblPos4.TabIndex = 10;
            lblPos4.Text = "Current pos: X";
            // 
            // lblMoney4
            // 
            lblMoney4.AutoSize = true;
            lblMoney4.Location = new Point(883, 29);
            lblMoney4.Name = "lblMoney4";
            lblMoney4.Size = new Size(97, 20);
            lblMoney4.TabIndex = 9;
            lblMoney4.Text = "Money: XXXX";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(883, 9);
            label9.Name = "label9";
            label9.Size = new Size(64, 20);
            label9.TabIndex = 8;
            label9.Text = "Player 4:";
            // 
            // lblPos3
            // 
            lblPos3.AutoSize = true;
            lblPos3.Location = new Point(780, 49);
            lblPos3.Name = "lblPos3";
            lblPos3.Size = new Size(101, 20);
            lblPos3.TabIndex = 13;
            lblPos3.Text = "Current pos: X";
            // 
            // lblMoney3
            // 
            lblMoney3.AutoSize = true;
            lblMoney3.Location = new Point(780, 29);
            lblMoney3.Name = "lblMoney3";
            lblMoney3.Size = new Size(97, 20);
            lblMoney3.TabIndex = 12;
            lblMoney3.Text = "Money: XXXX";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(780, 9);
            label12.Name = "label12";
            label12.Size = new Size(64, 20);
            label12.TabIndex = 11;
            label12.Text = "Player 3:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 560);
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
            Name = "Form1";
            Text = "Form1";
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
    }
}
