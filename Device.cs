using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using NModbus;
using Opc.UaFx.Client;

namespace Motor_Control
{
    public class Device
    {
        public string OpcUrl;
        public string Name;
        public byte NameSpaceIndex;
        public OpcClient thePLC = null;


        public bool Start;
        public bool Stop;
        public short Level;

        public Motor_Data Motor_1_Data = new Motor_Data();
        public Motor_Data Motor_2_Data = new Motor_Data();
        public Motor_Data Motor_3_Data = new Motor_Data();


        System.Timers.Timer UpdateTimer = null;
        public Device(string opcurl, byte namespaceindex, string name)
        {
            OpcUrl= opcurl;
            NameSpaceIndex= namespaceindex;
            Name = name;

            UpdateTimer = new System.Timers.Timer(500);
            UpdateTimer.Elapsed += UpdateTimer_Tags;

            try
            {
                thePLC = new OpcClient(OpcUrl);
                Console.WriteLine($"Connect to the PLC {Name} {OpcUrl} successfully");
                UpdateTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the PLC {OpcUrl}: {ex.Message}");
            }
        }
        private void UpdateTimer_Tags(object sender, System.Timers.ElapsedEventArgs e)
        {
            ushort[] ob = Master.ReadHoldingRegisters(ID, 100, 4);
            Motor_1_Data.Update(ob);
            ob = Master.ReadHoldingRegisters(ID, 104, 4);
            Motor_2_Data.Update(ob);
            ob = Master.ReadHoldingRegisters(ID, 108, 4);
            Motor_3_Data.Update(ob);

            ob = Master.ReadHoldingRegisters(ID, 114, 1);
            Level = (short)ob[0];

            //Console.WriteLine($"Motor_1_Data: {Motor_1_Data.Mode} {Motor_1_Data.Runfeedback}");
            //Console.WriteLine($"Motor_2_Data: {Motor_2_Data.Mode} {Motor_2_Data.Runfeedback}");
            //Console.WriteLine($"Motor_3_Data: {Motor_3_Data.Mode} {Motor_3_Data.Runfeedback}");

        }

        public void Write(object value, string tagname)
        {
            string[] s = tagname.Split('.');
            ushort tmp = (ushort) Convert.ToInt16(value);
            switch (s[0])
            {
                case "Motor_1":
                    switch (s[1])
                    {
                        case "Mode":
                            Master.WriteSingleRegister(ID, 100, tmp);
                            break;
                        case "Start":
                            Master.WriteSingleRegister(ID, 101, tmp);
                            break;
                        case "Stop":
                            Master.WriteSingleRegister(ID, 101, (ushort)(tmp << 7));
                            break;
                        case "Reset":
                            Master.WriteSingleRegister(ID, 102, (ushort)(tmp << 7));
                            break;
                    }
                    break;
                case "Motor_2":
                    switch (s[1])
                    {
                        case "Mode":
                            Master.WriteSingleRegister(ID, 104, tmp);
                            break;
                        case "Start":
                            Master.WriteSingleRegister(ID, 105, tmp);
                            break;
                        case "Stop":
                            Master.WriteSingleRegister(ID, 105, (ushort)(tmp << 7));
                            break;
                        case "Reset":
                            Master.WriteSingleRegister(ID, 106, (ushort)(tmp << 7));
                            break;
                    }
                    break;
                case "Motor_3":
                    switch (s[1])
                    {
                        case "Mode":
                            Master.WriteSingleRegister(ID, 108, tmp);
                            break;
                        case "Start":
                            Master.WriteSingleRegister(ID, 109, tmp);
                            break;
                        case "Stop":
                            Master.WriteSingleRegister(ID, 109, (ushort)(tmp << 7));
                            break;
                        case "Reset":
                            Master.WriteSingleRegister(ID, 110, (ushort)(tmp << 7));
                            break;
                    }
                    break;
                case "Start":
                    Master.WriteSingleRegister(ID, 112, tmp);
                    break;
                case "Stop":
                    Master.WriteSingleRegister(ID, 112, (ushort)(tmp << 7));
                    break;
            }
        }

        private void ReadClass(Motor_Data motor_Data,string name)
        {

        }
    }

    public class Motor_Data
    {

        public ushort Mode;
        public bool Start;
        public bool Stop;
        //public bool RunCondition;
        //public bool StopCondition;
        public bool Runfeedback;
        public bool Reset;
        //public byte Output;
        //public bool Cmd;
        public bool Fault;
        
        public void Update(ushort[] ob)
        {
            Mode = ob[0];
            Start = Convert.ToBoolean(ob[1] & 0x0001);
            Stop = Convert.ToBoolean((ob[1] >> 7) & 0x0001);
            Runfeedback = Convert.ToBoolean(ob[2] & 0x0001);
            Reset = Convert.ToBoolean((ob[2] >> 7) & 0x0001);
            Fault = Convert.ToBoolean(ob[3] & 0x0001);
        }

    }
}
