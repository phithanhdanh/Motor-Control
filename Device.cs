using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using S7.Net;

namespace Motor_Control
{
    public class Device
    {
        public string IP;
        public string Name;
        public Plc thePLC = null;

        public short Level;
        public Motor_Data Motor_1_Data = new Motor_Data();
        public Motor_Data Motor_2_Data = new Motor_Data();
        public Motor_Data Motor_3_Data = new Motor_Data();


        System.Timers.Timer UpdateTimer = null;
        public Device(string ip, string name)
        {
            IP = ip;
            Name = name;
            thePLC = new Plc(CpuType.S71500, IP, 0, 1);

            UpdateTimer = new System.Timers.Timer(500);
            UpdateTimer.Elapsed += UpdateTimer_Tags;
            try
            {
                thePLC.Open();
                Console.WriteLine($"Connect to the PLC {Name} {IP} successfully");
                UpdateTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the PLC {IP}: {ex.Message}");
            }

            //UpdateTimer = new System.Timers.Timer(500);
            //UpdateTimer.Elapsed += UpdateTimer_Tags;
            //UpdateTimer.Enabled = true;
        }
        private void UpdateTimer_Tags(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            thePLC.ReadClass(Motor_1_Data, 1);
            thePLC.ReadClass(Motor_2_Data, 2);
            thePLC.ReadClass(Motor_3_Data, 3);

            object ob = thePLC.Read("MW100");
            Level = (short) Convert.ToInt16((ushort)ob);

            //Console.WriteLine($"Motor_1_Data: {Motor_1_Data.Mode} {Motor_1_Data.Runfeedback}");
            //Console.WriteLine($"Motor_2_Data: {Motor_2_Data.Mode} {Motor_2_Data.Runfeedback}");
            //Console.WriteLine($"Motor_3_Data: {Motor_3_Data.Mode} {Motor_3_Data.Runfeedback}");

        }

        public void Write(object value, string tagname)
        {
            string[] s = tagname.Split('.');
            switch (s[0])
            {
                case "Motor_1":
                    switch (s[1])
                    {
                        case "Mode":
                            thePLC.Write("DB1.DBW0",value);
                            break;
                        case "Start":
                            thePLC.Write("DB1.DBX2.0", value);
                            break;
                        case "Stop":
                            thePLC.Write("DB1.DBX2.1", value);
                            break;
                        case "Reset":
                            thePLC.Write("DB1.DBX2.5", value);
                            break;
                    }
                    break;
                case "Motor_2":
                    switch (s[1])
                    {
                        case "Mode":
                            thePLC.Write("DB2.DBW0", value);
                            break;
                        case "Start":
                            thePLC.Write("DB2.DBX2.0", value);
                            break;
                        case "Stop":
                            thePLC.Write("DB2.DBX2.1", value);
                            break;
                        case "Reset":
                            thePLC.Write("DB2.DBX2.5", value);
                            break;
                    }
                    break;
                case "Motor_3":
                    switch (s[1])
                    {
                        case "Mode":
                            thePLC.Write("DB3.DBW0", value);
                            break;
                        case "Start":
                            thePLC.Write("DB3.DBX2.0", value);
                            break;
                        case "Stop":
                            thePLC.Write("DB3.DBX2.1", value);
                            break;
                        case "Reset":
                            thePLC.Write("DB3.DBX2.5", value);
                            break;
                    }
                    break;
            }
        }
    }

    public class Motor_Data
    {
        public ushort Mode { get; set; }
        public bool Start { get; set; }
        public bool Stop { get; set; }
        public bool RunCondition { get; set; }
        public bool StopCondition { get; set; }
        public bool Runfeedback {  get; set; }
        public bool Reset { get; set; }
        public byte Output { get; set; }
        public bool Cmd { get; set; }
        public bool Fault { get; set; }
    }
}
