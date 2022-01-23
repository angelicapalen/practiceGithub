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
    public partial class Customer : Form
    {
        public DataTable dtCustomer;
        public DataSet dsCustomer;
        public string customerPath;

        public Customer()
        {
            InitializeComponent();
            frmInitialized();

        }

        void frmInitialized()
        {
            this.dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dsCustomer = new DataSet();
            dtCustomer = new DataTable();
            customerPath = string.Format(@"{0}\Customer.xml", Application.StartupPath);

            LoadTable();
        }

        void LoadTable()
        {
            if (!File.Exists(customerPath))
            {
                MessageBox.Show("No data available.");
                return;
            }

            dgvCustomer.Rows.Clear();
            dsCustomer = new DataSet();
            dsCustomer.ReadXml(customerPath);

            foreach (DataRow drow in dsCustomer.Tables["Customer"].Rows)
            {
                int n = dgvCustomer.Rows.Add();
                dgvCustomer.Rows[n].Cells[0].Value = drow[0];
                dgvCustomer.Rows[n].Cells[1].Value = drow[1];
                dgvCustomer.Rows[n].Cells[2].Value = drow[2];
                dgvCustomer.Rows[n].Cells[3].Value = drow[3];
            }
        }

        DataTable createCustomerDT()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Customer";
            dt.Columns.Add("Customer ID", typeof(int));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("Phone Number", typeof(string));
            return dt;
        }

        private void BtnAddEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvCustomer.Rows[0].Clone();
            row.Cells[0].Value = tbCustomerID.Text;
            row.Cells[1].Value = tbFirstName.Text;
            row.Cells[2].Value = tbLastName.Text;
            row.Cells[3].Value = tbPhoneNumber.Text;

            foreach (DataGridViewRow rowCheck in dgvCustomer.Rows)
            {
                if ((string)rowCheck.Cells[0].Value == tbCustomerID.Text)
                {
                    MessageBox.Show("Customer ID exist");
                    return;
                }
            }

            dgvCustomer.Rows.Add(row);
            this.dgvCustomer.AllowUserToAddRows = false;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            dsCustomer = new DataSet();
            dtCustomer = new DataTable();
            dtCustomer.TableName = "Customer";
            dtCustomer.Columns.Add("Customer ID");
            dtCustomer.Columns.Add("First Name");
            dtCustomer.Columns.Add("Last Name");
            dtCustomer.Columns.Add("Phone Number");
            dsCustomer.Tables.Add(dtCustomer);

            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                DataRow drow = dsCustomer.Tables["Customer"].NewRow();
                drow["Customer ID"] = row.Cells[0].Value;
                drow["First Name"] = row.Cells[1].Value;
                drow["Last Name"] = row.Cells[2].Value;
                drow["Phone Number"] = row.Cells[3].Value;
                dsCustomer.Tables["Customer"].Rows.Add(drow);
            }

            dsCustomer.WriteXml(customerPath);
            MessageBox.Show("Data saved.");
        }

       
    }
}

