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
            ReadClass(Motor_1_Data, "MOTOR_1");
            ReadClass(Motor_2_Data, "MOTOR_2");
            ReadClass(Motor_3_Data, "MOTOR_3");

            var value = thePLC.ReadNode($"ns={NameSpaceIndex};s=\"LEVEL\"");
            Level = (short)value.Value;
            
            //Console.WriteLine($"Motor_1_Data: {Motor_1_Data.Mode} {Motor_1_Data.Runfeedback}");
            //Console.WriteLine($"Motor_2_Data: {Motor_2_Data.Mode} {Motor_2_Data.Runfeedback}");
            //Console.WriteLine($"Motor_3_Data: {Motor_3_Data.Mode} {Motor_3_Data.Runfeedback}");

        }

        public void Write(object value, string tagname)
        {
            string[] s = tagname.Split('.');
            //ushort tmp = (ushort) Convert.ToInt16(value);
            string tagName = $"ns={NameSpaceIndex};s=";
            switch (s[0])
            {
                case "Motor_1":
                    tagName = tagName + "\"MOTOR_1\"";
                    switch (s[1])
                    {
                        case "Mode":
                            tagName = tagName + ".\"MODE\"";
                            break;
                        case "Start":
                            tagName = tagName + ".\"START\"";
                            break;
                        case "Stop":
                            tagName = tagName + ".\"STOP\"";
                            break;
                        case "Reset":
                            tagName = tagName + ".\"RESET\"";
                            break;
                    }
                    break;
                case "Motor_2":
                    tagName = tagName + "\"MOTOR_2\"";
                    switch (s[1])
                    {
                        case "Mode":
                            tagName = tagName + ".\"MODE\"";
                            break;
                        case "Start":
                            tagName = tagName + ".\"START\"";
                            break;
                        case "Stop":
                            tagName = tagName + ".\"STOP\"";
                            break;
                        case "Reset":
                            tagName = tagName + ".\"RESET\"";
                            break;
                    }
                    break;
                case "Motor_3":
                    tagName = tagName + "\"MOTOR_3\"";
                    switch (s[1])
                    {
                        case "Mode":
                            tagName = tagName + ".\"MODE\"";
                            break;
                        case "Start":
                            tagName = tagName + ".\"START\"";
                            break;
                        case "Stop":
                            tagName = tagName + ".\"STOP\"";
                            break;
                        case "Reset":
                            tagName = tagName + ".\"RESET\"";
                            break;
                    }
                    break;
                case "Start":
                    tagName = tagName + "\"CTRL_PANEL\".\"START\"";
                    break;
                case "Stop":
                    tagName = tagName + "\"CTRL_PANEL\".\"STOP\"";
                    break;
            }
            thePLC.WriteNode(tagName, value);
            
        }

        private void ReadClass(Motor_Data motor_data,string name)
        {
            string tagName = $"ns={NameSpaceIndex};s=\"{name}\".";

            var value = thePLC.ReadNode(tagName + "\"MODE\"");
            motor_data.Mode = (ushort)value.Value;

            value = thePLC.ReadNode(tagName + "\"START\"");
            motor_data.Start = (bool)value.Value;

            value = thePLC.ReadNode(tagName + "\"STOP\"");
            motor_data.Stop = (bool)value.Value;

            value = thePLC.ReadNode(tagName + "\"RUNFEEDBACK\"");
            motor_data.Runfeedback = (bool)value.Value;

            value = thePLC.ReadNode(tagName + "\"RESET\"");
            motor_data.Reset = (bool)value.Value;

            value = thePLC.ReadNode(tagName + "\"FAULT\"");
            motor_data.Fault = (bool)value.Value;
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
  
    }
}
