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
    public partial class ViewRecord : Form
    {
        public DataSet dsRecord;
        public DataTable dtRecord;
        public string recordPath;

        public ViewRecord()
        {
            InitializeComponent();
            frmInitialized();
        }

        void frmInitialized()
        {
            this.dgvRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recordPath = string.Format(@"{0}\Record.xml", Application.StartupPath);
            if (!File.Exists(recordPath))
            {
                MessageBox.Show("No data available.");
                return;
            }

            dsRecord = new DataSet();
            dsRecord.ReadXml(recordPath);
            dtRecord = new DataTable();
            dtRecord = dsRecord.Tables["Record"];
            dgvRecord.DataSource = dtRecord;
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {

        }
    }
}
