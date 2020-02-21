using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecimalClockLibrary;

namespace DecimalClock
{
    public partial class Clock : Form
    {
        DecimalDateTime previous = DecimalDateTime.Now;

        public Clock()
        {
            InitializeComponent();

            lblDate.Text = DecimalDateTime.Now.DateString();

            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(SetTime);
            timer1.Interval = 864; // in miliseconds
            timer1.Start();
        }

        public void SetTime(object sender, EventArgs e)
        {
            lblTime.Text = DecimalDateTime.Now.TimeString();

            if(previous.Day != DecimalDateTime.Now.Day)
                lblDate.Text = DecimalDateTime.Now.DateString();
        }
    }

}
