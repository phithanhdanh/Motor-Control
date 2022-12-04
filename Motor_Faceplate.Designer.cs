namespace Motor_Control
{
    partial class Motor_Faceplate
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
            this.components = new System.ComponentModel.Container();
            this.tbMode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.pbRunfeedback = new System.Windows.Forms.PictureBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tbModeReceive = new System.Windows.Forms.TextBox();
            this.pbFault = new System.Windows.Forms.PictureBox();
            this.btReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRunfeedback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFault)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMode
            // 
            this.tbMode.Location = new System.Drawing.Point(189, 35);
            this.tbMode.Name = "tbMode";
            this.tbMode.Size = new System.Drawing.Size(125, 31);
            this.tbMode.TabIndex = 0;
            this.tbMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "MODE";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(126, 155);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(138, 68);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btStart_MouseDown);
            this.btStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btStart_MouseUp);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(126, 247);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(138, 68);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btStop_MouseDown);
            this.btStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btStop_MouseUp);
            // 
            // pbRunfeedback
            // 
            this.pbRunfeedback.Location = new System.Drawing.Point(126, 457);
            this.pbRunfeedback.Name = "pbRunfeedback";
            this.pbRunfeedback.Size = new System.Drawing.Size(138, 138);
            this.pbRunfeedback.TabIndex = 3;
            this.pbRunfeedback.TabStop = false;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 250;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // tbModeReceive
            // 
            this.tbModeReceive.Location = new System.Drawing.Point(189, 92);
            this.tbModeReceive.Name = "tbModeReceive";
            this.tbModeReceive.Size = new System.Drawing.Size(125, 31);
            this.tbModeReceive.TabIndex = 0;
            this.tbModeReceive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMode_KeyDown);
            // 
            // pbFault
            // 
            this.pbFault.Location = new System.Drawing.Point(239, 568);
            this.pbFault.Name = "pbFault";
            this.pbFault.Size = new System.Drawing.Size(50, 50);
            this.pbFault.TabIndex = 3;
            this.pbFault.TabStop = false;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(126, 345);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(138, 68);
            this.btReset.TabIndex = 2;
            this.btReset.Text = "RESET";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btReset_MouseDown);
            this.btReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btReset_MouseUp);
            // 
            // Motor_Faceplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 670);
            this.Controls.Add(this.pbFault);
            this.Controls.Add(this.pbRunfeedback);
            this.Controls.Add(this.btReset);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbModeReceive);
            this.Controls.Add(this.tbMode);
            this.Name = "Motor_Faceplate";
            this.Text = "Motor_Faceplate";
            ((System.ComponentModel.ISupportInitialize)(this.pbRunfeedback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFault)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.PictureBox pbRunfeedback;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TextBox tbModeReceive;
        private System.Windows.Forms.PictureBox pbFault;
        private System.Windows.Forms.Button btReset;
    }
}