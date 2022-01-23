using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrontDeskApp
{
    public partial class RetrieveDate : Form
    {
        public static string retrieveDate;

        public RetrieveDate()
        {
            InitializeComponent();
        }

        private void BtnRetrieveBox_Click(object sender, EventArgs e)
        {
            retrieveDate = monthCalendar1.SelectionRange.Start.ToShortDateString();
            this.Hide();

        }
    }
}
