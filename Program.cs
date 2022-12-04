using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Control
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SCADA Root = new SCADA();
        [STAThread]

        static void Main()
        {
            ModbusDevice PLC_2 = new ModbusDevice("127.0.0.1", 502, 255, "PLC_2");
            Root.AddModbusDevice(PLC_2);

            Device PLC_1 = new Device("192.168.1.201", "PLC_1");
            Root.AddDevice(PLC_1);

            Motor motor = new Motor("Motor_1","PLC_1", 250, Root);
            Root.AddMotor(motor);
            motor = new Motor("Motor_2", "PLC_1", 250, Root);
            Root.AddMotor(motor);
            motor = new Motor("Motor_3", "PLC_1", 250, Root);
            Root.AddMotor(motor);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
