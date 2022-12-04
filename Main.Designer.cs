namespace Motor_Control
{
    partial class Main
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
            this.btMotor_1 = new System.Windows.Forms.Button();
            this.btMotor_2 = new System.Windows.Forms.Button();
            this.btMotor_3 = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.TrendTimer = new System.Windows.Forms.Timer(this.components);
            this.btData = new System.Windows.Forms.Button();
            this.prbTankLevel = new Motor_Control.customProgressBar();
            this.SuspendLayout();
            // 
            // btMotor_1
            // 
            this.btMotor_1.Location = new System.Drawing.Point(148, 70);
            this.btMotor_1.Name = "btMotor_1";
            this.btMotor_1.Size = new System.Drawing.Size(152, 70);
            this.btMotor_1.TabIndex = 0;
            this.btMotor_1.Text = "MOTOR 1";
            this.btMotor_1.UseVisualStyleBackColor = true;
            this.btMotor_1.Click += new System.EventHandler(this.btMotor_1_Click);
            // 
            // btMotor_2
            // 
            this.btMotor_2.Location = new System.Drawing.Point(148, 442);
            this.btMotor_2.Name = "btMotor_2";
            this.btMotor_2.Size = new System.Drawing.Size(152, 70);
            this.btMotor_2.TabIndex = 0;
            this.btMotor_2.Text = "MOTOR 2";
            this.btMotor_2.UseVisualStyleBackColor = true;
            this.btMotor_2.Click += new System.EventHandler(this.btMotor_2_Click);
            // 
            // btMotor_3
            // 
            this.btMotor_3.Location = new System.Drawing.Point(771, 264);
            this.btMotor_3.Name = "btMotor_3";
            this.btMotor_3.Size = new System.Drawing.Size(152, 70);
            this.btMotor_3.TabIndex = 0;
            this.btMotor_3.Text = "MOTOR 3";
            this.btMotor_3.UseVisualStyleBackColor = true;
            this.btMotor_3.Click += new System.EventHandler(this.btMotor_3_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(1113, 126);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(152, 70);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btStart_MouseDown);
            this.btStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btStart_MouseUp);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(1113, 228);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(152, 70);
            this.btStop.TabIndex = 0;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btStop_MouseDown);
            this.btStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btStop_MouseUp);
            // 
            // TrendTimer
            // 
            this.TrendTimer.Enabled = true;
            this.TrendTimer.Interval = 1000;
            this.TrendTimer.Tick += new System.EventHandler(this.TrendTimer_Tick);
            // 
            // btData
            // 
            this.btData.Location = new System.Drawing.Point(1113, 334);
            this.btData.Name = "btData";
            this.btData.Size = new System.Drawing.Size(152, 70);
            this.btData.TabIndex = 2;
            this.btData.Text = "DATA";
            this.btData.UseVisualStyleBackColor = true;
            this.btData.Click += new System.EventHandler(this.btData_Click);
            // 
            // prbTankLevel
            // 
            this.prbTankLevel.Location = new System.Drawing.Point(444, 87);
            this.prbTankLevel.Name = "prbTankLevel";
            this.prbTankLevel.Size = new System.Drawing.Size(139, 405);
            this.prbTankLevel.TabIndex = 3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 802);
            this.Controls.Add(this.prbTankLevel);
            this.Controls.Add(this.btData);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btMotor_3);
            this.Controls.Add(this.btMotor_2);
            this.Controls.Add(this.btMotor_1);
            this.Name = "Main";
            this.Text = "Main Page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btMotor_1;
        private System.Windows.Forms.Button btMotor_2;
        private System.Windows.Forms.Button btMotor_3;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Timer TrendTimer;
        private System.Windows.Forms.Button btData;
        private customProgressBar prbTankLevel;
    }
}

