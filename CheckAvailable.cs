using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FrontDeskApp
{
    public partial class CheckAvailable : Form
    {
        public CheckAvailable()
        {
            InitializeComponent();
            frmInitialized();
        }

        void frmInitialized()
        {
            if (!File.Exists(string.Format(@"{0}\Current.xml", Application.StartupPath)))
            {
                tbSmallArea.Text = string.Format("46 storage available");
                tbMediumArea.Text = "14 storage available";
                tbLargeArea.Text = "12 storage available";
                return;
            }

            //check availability
            DataSet dsCurrent = new DataSet();
            dsCurrent.ReadXml(string.Format(@"{0}\Current.xml", Application.StartupPath));
            
            //small area
            if (!dsCurrent.Tables.Contains("Small"))
            {
                tbSmallArea.Text = string.Format("46 storage available");
                goto mediumArea;
            }
            DataTable dtSmall = new DataTable();
            dtSmall = dsCurrent.Tables["Small"];
            int totalRow = dtSmall.Rows.Count;
            tbSmallArea.Text = string.Format("{0} storage available", (46-totalRow).ToString());
            //medium area
            mediumArea:
            if (!dsCurrent.Tables.Contains("Medium"))
            {
                tbMediumArea.Text = "14 storage available";
                goto largeArea;
            }
            DataTable dtMedium = new DataTable();
            dtMedium = dsCurrent.Tables["Medium"];
            int medium = dtMedium.Rows.Count;
            tbMediumArea.Text = string.Format("{0} storage available",(14-medium).ToString());
            //large area
            largeArea:
            if (!dsCurrent.Tables.Contains("Large"))
            {
                tbLargeArea.Text = "12 storage available";
                return;
            }
            DataTable dtLarge = new DataTable();
            dtLarge = dsCurrent.Tables["Large"];
            int large = dtLarge.Rows.Count;
            tbLargeArea.Text = string.Format("{0} storage available", (12-large).ToString());
        }

        private void CheckAvailable_Load(object sender, EventArgs e)
        {

        }
    }
}
