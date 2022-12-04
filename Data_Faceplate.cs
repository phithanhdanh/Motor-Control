using System;
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
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            //datagrid.FirstDisplayedScrollingRowIndex = datagrid.RowCount - 1;

        }

        private void TrendsTimer_Tick(object sender, EventArgs e)
        {
            chart.Series["Level"].Points.Clear();
           
            for (int i = 0; i < Program.Root.Trends.Count; i++)
            {
                chart.Series["Level"].Points.AddXY(Program.Root.Trends[i].TimeStamp, Program.Root.Trends[i].Value);
            }

            datagrid.DataSource = null;
            datagrid.DataSource = Program.Root.Alarms;
            datagrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //datagrid.FirstDisplayedScrollingRowIndex = 5;
        }
    }
}
