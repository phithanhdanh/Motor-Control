using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Motor_Control
{
    public partial class Main : Form
    {
        public Device Dev = null;

        public Main()
        {
            Dev = Program.Root.FindDevice("PLC_1");
            InitializeComponent();
            //chart.DataSource = Program.Root.Trends;
            //chart.Series["Level"].XValueMember = "TimeStamp";
            //chart.Series["Level"].YValueMembers = "Level";
            //chart.DataBind();

        }

        private void btMotor_1_Click(object sender, EventArgs e)
        {
            Motor_Faceplate fpl = new Motor_Faceplate(Program.Root.FindMotor("Motor_1"));
            fpl.Show();
        }

        private void btMotor_2_Click(object sender, EventArgs e)
        {
            Motor_Faceplate fpl = new Motor_Faceplate(Program.Root.FindMotor("Motor_2"));
            fpl.Show();
        }

        private void btMotor_3_Click(object sender, EventArgs e)
        {
            Motor_Faceplate fpl = new Motor_Faceplate(Program.Root.FindMotor("Motor_3"));
            fpl.Show();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (Dev != null)
            { 
                //prbTank.Value = Dev.Level;
                prbTankLevel.Value = Dev.Level;
                //Console.WriteLine($"Tank Level: {prbTank.Value}");
            }
        }

        private void btStart_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dev != null)
            {
                Dev.thePLC.Write("DB6.DBX0.0", true);
            }
        }

        private void btStart_MouseUp(object sender, MouseEventArgs e)
        {
            if (Dev != null)
            {
                Dev.thePLC.Write("DB6.DBX0.0",false);
            }
        }

        private void btStop_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dev != null)
            {
                Dev.thePLC.Write("DB6.DBX0.1", true);
            }
        }

        private void btStop_MouseUp(object sender, MouseEventArgs e)
        {
            if (Dev != null)
            {
                Dev.thePLC.Write("DB6.DBX0.1", false);
            }
        }

        private void TrendTimer_Tick(object sender, EventArgs e)
        {

            //Console.Clear();
            //for (int i = 0; i < Program.Root.Alarms.Count; i++)
            //{
            //    Console.WriteLine($"Timestamp = {Program.Root.Alarms[i].TimeStamp} " +
            //                        $"Level = {Program.Root.Alarms[i].Value} " +
            //                        $"Alarm = {Program.Root.Alarms[i].Type}");
            //}

            
        }

        private void btData_Click(object sender, EventArgs e)
        {
            Graph fpl = new Graph();
            fpl.Show();
        }

    }
}
