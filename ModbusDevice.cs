using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Control
{
    public class ModbusDevice
    {
        public string IP;
        public int Port;
        public byte ID;
        public string Name;

        public bool Start;
        public bool Stop;
        public short Level;
        public bool Motor;



        internal TcpClient Client = null;
        internal IModbusMaster Master = null;

        System.Timers.Timer UpdateTimer = null;

        public ModbusDevice(string ip, int port, byte id, string name)
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
            bool[] ob = Master.ReadCoils(ID, 0, 3);
            Start = ob[0];
            Stop = ob[1];
            Motor = ob[2];

            ushort[] ob1 = Master.ReadHoldingRegisters(ID, 100, 1);
            Level = (short)Convert.ToInt16(ob1[0]);

            Console.WriteLine( "-----------------Modbus Data------------------");
            Console.WriteLine($"Start: {Start}  Stop: {Stop}    Motor: {Motor}");
            Console.WriteLine($"Level: {Level}");
        }
    }

    public class Modbus_Motor_Data
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
            Stop = Convert.ToBoolean((ob[1]>>8) & 0x0001);
            RunCondition = Convert.ToBoolean(ob[2] & 0x0001);
            StopCondition = Convert.ToBoolean((ob[2] >> 8) & 0x0001);
            Runfeedback = Convert.ToBoolean(ob[3] & 0x0001);
            Reset = Convert.ToBoolean((ob[3] >> 8) & 0x0001);
            Fault = Convert.ToBoolean(ob[4] & 0x0001);
        }
         
    }
}
