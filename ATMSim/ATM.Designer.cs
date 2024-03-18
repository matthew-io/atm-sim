namespace ATMSim
{
    partial class ATM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATM));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.balanceBtn = new System.Windows.Forms.Button();
            this.depositBtn = new System.Windows.Forms.Button();
            this.withdrawBtn = new System.Windows.Forms.Button();
            this.changePinBtn = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.statementBtn = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.transferBtn = new System.Windows.Forms.Button();
            this.withdrawLbl = new System.Windows.Forms.Label();
            this.chkBalanceLbl = new System.Windows.Forms.Label();
            this.depositLbl = new System.Windows.Forms.Label();
            this.changePinLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.transferLbl = new System.Windows.Forms.Label();
            this.statementLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(61, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(39, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter your PIN number";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(29, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 20);
            this.textBox2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Withdraw";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Enter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(162, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Show Balance";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Balance";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.label5);
            this.mainPanel.Controls.Add(this.textBox4);
            this.mainPanel.Controls.Add(this.button5);
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.textBox3);
            this.mainPanel.Controls.Add(this.button4);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.textBox2);
            this.mainPanel.Controls.Add(this.button3);
            this.mainPanel.Controls.Add(this.button2);
            this.mainPanel.Location = new System.Drawing.Point(716, 364);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(424, 188);
            this.mainPanel.TabIndex = 11;
            this.mainPanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Change Pin";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(296, 59);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(117, 20);
            this.textBox4.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(296, 85);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 16;
            this.button5.Text = "Enter";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Deposit";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(162, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(117, 20);
            this.textBox3.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(162, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Enter";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // balanceBtn
            // 
            this.balanceBtn.BackColor = System.Drawing.Color.Transparent;
            this.balanceBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.balanceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.balanceBtn.FlatAppearance.BorderSize = 0;
            this.balanceBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.balanceBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.balanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.balanceBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.balanceBtn.Image = ((System.Drawing.Image)(resources.GetObject("balanceBtn.Image")));
            this.balanceBtn.Location = new System.Drawing.Point(76, 551);
            this.balanceBtn.Name = "balanceBtn";
            this.balanceBtn.Size = new System.Drawing.Size(53, 51);
            this.balanceBtn.TabIndex = 12;
            this.balanceBtn.UseVisualStyleBackColor = false;
            this.balanceBtn.Click += new System.EventHandler(this.balanceBtn_Click);
            // 
            // depositBtn
            // 
            this.depositBtn.BackColor = System.Drawing.Color.Transparent;
            this.depositBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.depositBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.depositBtn.FlatAppearance.BorderSize = 0;
            this.depositBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.depositBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.depositBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.depositBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.depositBtn.Image = ((System.Drawing.Image)(resources.GetObject("depositBtn.Image")));
            this.depositBtn.Location = new System.Drawing.Point(76, 475);
            this.depositBtn.Name = "depositBtn";
            this.depositBtn.Size = new System.Drawing.Size(53, 51);
            this.depositBtn.TabIndex = 13;
            this.depositBtn.UseVisualStyleBackColor = false;
            // 
            // withdrawBtn
            // 
            this.withdrawBtn.BackColor = System.Drawing.Color.Transparent;
            this.withdrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.withdrawBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.withdrawBtn.FlatAppearance.BorderSize = 0;
            this.withdrawBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.withdrawBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.withdrawBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.withdrawBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.withdrawBtn.Image = ((System.Drawing.Image)(resources.GetObject("withdrawBtn.Image")));
            this.withdrawBtn.Location = new System.Drawing.Point(76, 625);
            this.withdrawBtn.Name = "withdrawBtn";
            this.withdrawBtn.Size = new System.Drawing.Size(53, 51);
            this.withdrawBtn.TabIndex = 14;
            this.withdrawBtn.UseVisualStyleBackColor = false;
            this.withdrawBtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // changePinBtn
            // 
            this.changePinBtn.BackColor = System.Drawing.Color.Transparent;
            this.changePinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.changePinBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changePinBtn.FlatAppearance.BorderSize = 0;
            this.changePinBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.changePinBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.changePinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePinBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changePinBtn.Image = ((System.Drawing.Image)(resources.GetObject("changePinBtn.Image")));
            this.changePinBtn.Location = new System.Drawing.Point(76, 399);
            this.changePinBtn.Name = "changePinBtn";
            this.changePinBtn.Size = new System.Drawing.Size(53, 51);
            this.changePinBtn.TabIndex = 15;
            this.changePinBtn.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.Location = new System.Drawing.Point(626, 400);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 51);
            this.button10.TabIndex = 19;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // statementBtn
            // 
            this.statementBtn.BackColor = System.Drawing.Color.Transparent;
            this.statementBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statementBtn.FlatAppearance.BorderSize = 0;
            this.statementBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.statementBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.statementBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statementBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.statementBtn.Image = ((System.Drawing.Image)(resources.GetObject("statementBtn.Image")));
            this.statementBtn.Location = new System.Drawing.Point(626, 626);
            this.statementBtn.Name = "statementBtn";
            this.statementBtn.Size = new System.Drawing.Size(53, 51);
            this.statementBtn.TabIndex = 18;
            this.statementBtn.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.Location = new System.Drawing.Point(626, 476);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(53, 51);
            this.button12.TabIndex = 17;
            this.button12.UseVisualStyleBackColor = false;
            // 
            // transferBtn
            // 
            this.transferBtn.BackColor = System.Drawing.Color.Transparent;
            this.transferBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.transferBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transferBtn.FlatAppearance.BorderSize = 0;
            this.transferBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.transferBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.transferBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transferBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.transferBtn.Image = ((System.Drawing.Image)(resources.GetObject("transferBtn.Image")));
            this.transferBtn.Location = new System.Drawing.Point(626, 552);
            this.transferBtn.Name = "transferBtn";
            this.transferBtn.Size = new System.Drawing.Size(53, 51);
            this.transferBtn.TabIndex = 16;
            this.transferBtn.UseVisualStyleBackColor = false;
            // 
            // withdrawLbl
            // 
            this.withdrawLbl.AutoSize = true;
            this.withdrawLbl.BackColor = System.Drawing.Color.Transparent;
            this.withdrawLbl.ForeColor = System.Drawing.Color.White;
            this.withdrawLbl.Location = new System.Drawing.Point(8, 247);
            this.withdrawLbl.Name = "withdrawLbl";
            this.withdrawLbl.Size = new System.Drawing.Size(70, 13);
            this.withdrawLbl.TabIndex = 20;
            this.withdrawLbl.Text = "WITHDRAW";
            // 
            // chkBalanceLbl
            // 
            this.chkBalanceLbl.AutoSize = true;
            this.chkBalanceLbl.BackColor = System.Drawing.Color.Transparent;
            this.chkBalanceLbl.ForeColor = System.Drawing.Color.White;
            this.chkBalanceLbl.Location = new System.Drawing.Point(8, 164);
            this.chkBalanceLbl.Name = "chkBalanceLbl";
            this.chkBalanceLbl.Size = new System.Drawing.Size(95, 13);
            this.chkBalanceLbl.TabIndex = 21;
            this.chkBalanceLbl.Text = "CHECK BALANCE";
            // 
            // depositLbl
            // 
            this.depositLbl.AutoSize = true;
            this.depositLbl.BackColor = System.Drawing.Color.Transparent;
            this.depositLbl.ForeColor = System.Drawing.Color.White;
            this.depositLbl.Location = new System.Drawing.Point(8, 91);
            this.depositLbl.Name = "depositLbl";
            this.depositLbl.Size = new System.Drawing.Size(54, 13);
            this.depositLbl.TabIndex = 22;
            this.depositLbl.Text = "DEPOSIT";
            // 
            // changePinLbl
            // 
            this.changePinLbl.AutoSize = true;
            this.changePinLbl.BackColor = System.Drawing.Color.Transparent;
            this.changePinLbl.ForeColor = System.Drawing.Color.White;
            this.changePinLbl.Location = new System.Drawing.Point(8, 16);
            this.changePinLbl.Name = "changePinLbl";
            this.changePinLbl.Size = new System.Drawing.Size(73, 13);
            this.changePinLbl.TabIndex = 23;
            this.changePinLbl.Text = "CHANGE PIN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.changePinLbl);
            this.panel1.Controls.Add(this.depositLbl);
            this.panel1.Controls.Add(this.chkBalanceLbl);
            this.panel1.Controls.Add(this.withdrawLbl);
            this.panel1.Location = new System.Drawing.Point(157, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 269);
            this.panel1.TabIndex = 24;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.transferLbl);
            this.panel2.Controls.Add(this.statementLbl);
            this.panel2.Location = new System.Drawing.Point(489, 408);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(113, 269);
            this.panel2.TabIndex = 25;
            this.panel2.Visible = false;
            // 
            // transferLbl
            // 
            this.transferLbl.AutoSize = true;
            this.transferLbl.BackColor = System.Drawing.Color.Transparent;
            this.transferLbl.ForeColor = System.Drawing.Color.White;
            this.transferLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transferLbl.Location = new System.Drawing.Point(8, 164);
            this.transferLbl.Name = "transferLbl";
            this.transferLbl.Size = new System.Drawing.Size(65, 13);
            this.transferLbl.TabIndex = 21;
            this.transferLbl.Text = "TRANSFER";
            // 
            // statementLbl
            // 
            this.statementLbl.AutoSize = true;
            this.statementLbl.BackColor = System.Drawing.Color.Transparent;
            this.statementLbl.ForeColor = System.Drawing.Color.White;
            this.statementLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.statementLbl.Location = new System.Drawing.Point(8, 247);
            this.statementLbl.Name = "statementLbl";
            this.statementLbl.Size = new System.Drawing.Size(109, 13);
            this.statementLbl.TabIndex = 20;
            this.statementLbl.Text = "PRINT STATEMENT";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(281, 436);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 80);
            this.panel3.TabIndex = 26;
            // 
            // ATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1059, 911);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.statementBtn);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.transferBtn);
            this.Controls.Add(this.changePinBtn);
            this.Controls.Add(this.withdrawBtn);
            this.Controls.Add(this.depositBtn);
            this.Controls.Add(this.balanceBtn);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ATM";
            this.Text = "ATM";
            this.Load += new System.EventHandler(this.ATM_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button balanceBtn;
        private System.Windows.Forms.Button depositBtn;
        private System.Windows.Forms.Button withdrawBtn;
        private System.Windows.Forms.Button changePinBtn;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button statementBtn;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button transferBtn;
        private System.Windows.Forms.Label withdrawLbl;
        private System.Windows.Forms.Label chkBalanceLbl;
        private System.Windows.Forms.Label depositLbl;
        private System.Windows.Forms.Label changePinLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label transferLbl;
        private System.Windows.Forms.Label statementLbl;
        private System.Windows.Forms.Panel panel3;
    }
}