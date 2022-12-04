using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Control
{
    public partial class Motor_Faceplate : Form
    {
        Image pump_green = Image.FromFile(@"images\pump_base_green.gif");
        Image pump_red = Image.FromFile(@"images\pump_base_red.gif");
        Image light_yellow = Image.FromFile(@"images\Yellow pilot light 2.wmf");
        Image light_off = Image.FromFile(@"images\Pilot light 2 (off).wmf");

        bool tick = false;
        public Motor Parent = null;
        public Motor_Faceplate(Motor parent)
        {
            InitializeComponent();
            Parent = parent;
        }

        private void tbMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ushort temp;
                bool ret = ushort.TryParse(tbMode.Text, out temp);
                if (ret)
                {
                    Parent.Write(temp, "Mode");
                }
            }
        }

        private void btStart_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.Write(true, "Start");
        }

        private void btStart_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.Write(false, "Start");
        }

        private void btStop_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.Write(true, "Stop");

        }

        private void btStop_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.Write(false, "Stop");

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            tick = !tick;
            if (!Parent.Runfeedback)
            {
                pbRunfeedback.BackgroundImage = pump_red;
                pbRunfeedback.BackColor = Color.Transparent;
                pbRunfeedback.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                pbRunfeedback.BackgroundImage = pump_green;
                pbRunfeedback.BackColor = Color.Transparent;
                pbRunfeedback.BackgroundImageLayout = ImageLayout.Stretch;
            }

            if (Parent.Fault && tick)
            {
                pbFault.BackgroundImage = light_yellow;
                pbFault.BackColor = Color.Transparent;
                pbFault.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                pbFault.BackgroundImage = light_off;
                pbFault.BackColor = Color.Transparent;
                pbFault.BackgroundImageLayout = ImageLayout.Stretch;
            }
            

            tbModeReceive.Text = Parent.Mode.ToString();
        }

        private void btReset_MouseDown(object sender, MouseEventArgs e)
        {
            Parent.Write(true, "Reset");
        }

        private void btReset_MouseUp(object sender, MouseEventArgs e)
        {
            Parent.Write(false, "Reset");
        }
    }
}
