using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NModbus;
using S7.Net;

namespace Motor_Control
{
    public class Device
    {
        public string IP;
        public string Name;
        public int Port;
        public byte ID;
        public TcpClient Client = null;
        public IModbusMaster Master = null;

        public bool Start;
        public bool Stop;
        public short Level;

        public Motor_Data Motor_1_Data = new Motor_Data();
        public Motor_Data Motor_2_Data = new Motor_Data();
        public Motor_Data Motor_3_Data = new Motor_Data();


        System.Timers.Timer UpdateTimer = null;
        public Device(string ip, int port, byte id, string name)
        {
            IP = ip;
            Port = port;
            ID = id;
            Name = name;

            UpdateTimer = new System.Timers.Timer(500);
            UpdateTimer.Elapsed += UpdateTimer_Tags;

            try
            {
                Client = new TcpClient(IP, Port);
                var factory = new ModbusFactory();
                Master = factory.CreateMaster(Client);
                Console.WriteLine($"Connect to the PLC {Name} {IP} successfully");
                UpdateTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot connect to the PLC {IP}: {ex.Message}");
            }
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
        private ushort StartAddress;
        private IModbusMaster Master;
        private byte ID;

        public ushort Mode;
        public bool Start;
        public bool Stop;
        public bool RunCondition;
        public bool StopCondition;
        public bool Runfeedback;
        public bool Reset;
        //public byte Output;
        //public bool Cmd;
        public bool Fault;
        public Modbus_Motor_Data(IModbusMaster master, byte id, ushort address)
        {
            StartAddress = address;
            Master = master;
            ID = id;
        }
        public void Read_Modbus()
        {
            ushort[] ob = Master.ReadHoldingRegisters(ID, StartAddress, 4);
            Mode = ob[0];
            Start = Convert.ToBoolean(ob[1] & 0x0001);
            Stop = Convert.ToBoolean((ob[1] >> 8) & 0x0001);
            RunCondition = Convert.ToBoolean(ob[2] & 0x0001);
            StopCondition = Convert.ToBoolean((ob[2] >> 8) & 0x0001);
            Runfeedback = Convert.ToBoolean(ob[3] & 0x0001);
            Reset = Convert.ToBoolean((ob[3] >> 8) & 0x0001);
            Fault = Convert.ToBoolean(ob[4] & 0x0001);
        }

    }
}
