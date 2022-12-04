using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Control
{
    public class SCADA      //Root object
    {
        public List<Device> Devices = new List<Device>();
        public List<Motor> Motors = new List<Motor>();
        

        public short Level;
        System.Timers.Timer UpdateTimer = null;

        public List<TrendPoint> Trends = new List<TrendPoint>();
        public List<AlarmPoint> Alarms = new List<AlarmPoint>();

        public SCADA()
        {
            UpdateTimer = new System.Timers.Timer(1000);
            UpdateTimer.Elapsed += UpdateTags;
            UpdateTimer.Start();


        }


        public void AddDevice(Device dev)
        {
            Devices.Add(dev);
        }

        public Device FindDevice(string name)
        {
            foreach (Device dev in Devices)
            {
                if (dev.Name == name)
                {
                    return dev;
                }
            }
            return null;
        }

        public void AddMotor(Motor dev)
        {
            Motors.Add(dev);
        }

        public Motor FindMotor(string name)
        {
            foreach (Motor dev in Motors)
            {
                if (dev.Name == name)
                {
                    return dev;
                }
            }
            return null;
        }

        string Prev_Type = "";
        private void UpdateTags(object sender, System.Timers.ElapsedEventArgs e)
        {
            Device dev = FindDevice("PLC_1");
            if (dev != null)
            {
                Level = dev.Level;
                //Console.WriteLine($"Level is: {Level}");
                DateTime TimeStamp = DateTime.Now;
                TrendPoint p = new TrendPoint { TimeStamp = TimeStamp, Value = Level };
                Trends.Add(p);
                if (Trends.Count > 30)
                {
                    Trends.RemoveAt(0);
                }

                if (Level > 90)
                {
                    if (Prev_Type != "HIHI")
                    {
                        AlarmPoint alarm = new AlarmPoint { TimeStamp = TimeStamp, Value = Level, Type = "HIHI" };
                        Alarms.Add(alarm);
                        Prev_Type = "HIHI";
                    }
                }
                else if (Level > 80)
                {
                    if (Prev_Type != "HI")
                    {
                        AlarmPoint alarm = new AlarmPoint { TimeStamp = TimeStamp, Value = Level, Type = "HI" };
                        Alarms.Add(alarm);
                        Prev_Type = "HI";
                    }
                }
                else if (Level < 10)
                {
                    if (Prev_Type != "LOLO")
                    {
                        AlarmPoint alarm = new AlarmPoint { TimeStamp = TimeStamp, Value = Level, Type = "LOLO" };
                        Alarms.Add(alarm);
                        Prev_Type = "LOLO";
                    }
                }
                else if (Level < 20)
                {
                    if (Prev_Type != "LO")
                    {
                        AlarmPoint alarm = new AlarmPoint { TimeStamp = TimeStamp, Value = Level, Type = "LO" };
                        Alarms.Add(alarm);
                        Prev_Type = "LO";
                    }
                }
                else if (Prev_Type!="OK")
                {
                    AlarmPoint alarm = new AlarmPoint { TimeStamp = TimeStamp, Value = Level, Type = "OK" };
                    Alarms.Add(alarm);
                    Prev_Type = "OK";
                }
            }
        }
    }

    public class TrendPoint
    {
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
    }

    public class AlarmPoint
    {
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
    }
}
