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
    public partial class Retrieve : Form
    {
        public Retrieve()
        {
            InitializeComponent();
            cboArea.SelectedIndex = 0;
            this.dgvRetrieve.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            dgvRetrieve.Rows.Clear();
            string currentPath = string.Format(@"{0}\Current.xml", Application.StartupPath);
            if (!File.Exists(currentPath))
            {
                MessageBox.Show("No data available");
                return;
            }
            DataSet dsStore = new DataSet();
            dsStore.ReadXml(currentPath);

            if (!dsStore.Tables.Contains(cboArea.Text))
            {
                MessageBox.Show("No data available.");
                return;
            }

            DataTable dtSel = new DataTable();
            dtSel = dsStore.Tables[cboArea.Text];  

            foreach (DataRow row in dtSel.Rows)
            {
                int n = dgvRetrieve.Rows.Add();
                dgvRetrieve.Rows[n].Cells[0].Value = row[0];
                dgvRetrieve.Rows[n].Cells[1].Value = row[1];
                dgvRetrieve.Rows[n].Cells[2].Value = row[2];
            }
        }

        private void BtnRetrieve_Click(object sender, EventArgs e)
        {
            
        }

        private void DgvRetrieve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RetrieveDate retrieve = new RetrieveDate();
            retrieve.ShowDialog();

            int index = e.RowIndex;// get the Row Index
            DataGridViewRow selectedRow = dgvRetrieve.Rows[index];
            selectedRow.Cells[3].Value = RetrieveDate.retrieveDate;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string recordPath = string.Format(@"{0}\Record.xml", Application.StartupPath);
            DataSet dsRecord = new DataSet();
            DataTable dtRecord = new DataTable();
            dtRecord.TableName = "Record";
            dtRecord.Columns.Add("Customer ID");
            dtRecord.Columns.Add("First Name");
            dtRecord.Columns.Add("Last Name");
            dtRecord.Columns.Add("Box ID");
            dtRecord.Columns.Add("Area");
            dtRecord.Columns.Add("Date Stored");
            dtRecord.Columns.Add("Date Retrieved");

            if (!File.Exists(recordPath))
            {
                dsRecord.Tables.Add(dtRecord);
            }
            else
            {
                dsRecord.ReadXml(recordPath);
                dtRecord = dsRecord.Tables["Record"];
            }

            foreach (DataGridViewRow row in dgvRetrieve.SelectedRows)
            {
                DataRow newRow = dtRecord.NewRow();
                string idName = row.Cells[0].Value.ToString();
                string[] splIDName = idName.Split('-');
                string[] name = splIDName[1].Split(',');
                newRow["Customer ID"] = splIDName[0];
                newRow["First Name"] = name[1];
                newRow["Last Name"] = name[0];
                newRow["Box ID"] = row.Cells[1].Value.ToString();
                newRow["Area"] = cboArea.Text;
                newRow["Date Stored"] = row.Cells[2].Value.ToString();
                newRow["Date Retrieved"] = RetrieveDate.retrieveDate;
                dtRecord.Rows.Add(newRow);
            }

            dsRecord.WriteXml(recordPath);

            int rowIndex = dgvRetrieve.CurrentCell.RowIndex;

            //delete row in current dataset
            DataGridViewRow selectedRow = dgvRetrieve.Rows[rowIndex];
            string boxID = selectedRow.Cells[1].Value.ToString();
            DataSet dsCurrent = new DataSet();
            dsCurrent.ReadXml(string.Format(@"{0}\Current.xml", Application.StartupPath));
            DataTable dtArea = new DataTable();
            dtArea = dsCurrent.Tables[cboArea.Text];
            DataRow rowDT = dtArea.AsEnumerable().Where(x => x["Box ID"].ToString().Equals(boxID)).Select(x => x).First();
            dtArea.Rows.Remove(rowDT);
            dtArea.AcceptChanges();
            dsCurrent.WriteXml(string.Format(@"{0}\Current.xml", Application.StartupPath));

            //delete selected row in datagridview 
            dgvRetrieve.Rows.RemoveAt(rowIndex);

            MessageBox.Show("Data Saved.");
        }
    }
}
