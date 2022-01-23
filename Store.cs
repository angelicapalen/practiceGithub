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
    public partial class Store : Form
    {
        public DataSet dsCurrent;
        public DataTable dtSmall, dtMedium, dtLarge;
        public string currentPath;

        public Store()
        {
            InitializeComponent();
            currentPath = string.Format(@"{0}\Current.xml", Application.StartupPath);
            frmInitialized();

        }

        void frmInitialized()
        {
            string customerPath = string.Format(@"{0}\Customer.xml", Application.StartupPath);

            if (!File.Exists(customerPath))
            {
                MessageBox.Show("No data available");
                return;
            }

            //read Customer data
            DataSet dsCustomer = new DataSet();
            dsCustomer.ReadXml(customerPath);
            DataTable dtCustomer = new DataTable();
            dtCustomer = dsCustomer.Tables["Customer"];

            List<string> customerName = new List<string>();
            foreach (DataRow row in dtCustomer.Rows)
            {
                string cName = string.Format("{0}-{1},{2}", row["Customer ID"].ToString(), row["Last Name"].ToString(), row["First Name"].ToString());
                customerName.Add(cName);
            }

            cboCustomer.DataSource = customerName;
            cboArea.SelectedIndex = 0;

            int num = new Random().Next(1000, 9999);
            tbBoxID.Text = RandomString(6);
        }

        private static Random random = new Random();

        private void CboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbBoxID.Text = RandomString(6);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            dsCurrent = new DataSet();
            switch (cboArea.Text)
            {
                case "Small":
                    dtSmall = new DataTable();
                    dtSmall.TableName = "Small";
                    dtSmall.Columns.Add("Customer Name");
                    dtSmall.Columns.Add("Box ID");
                    dtSmall.Columns.Add("Date Stored");

                    if (!File.Exists(currentPath))
                    {
                        dsCurrent.Tables.Add(dtSmall);
                    }
                    else
                    {
                        dsCurrent.ReadXml(currentPath);
                        dtSmall = dsCurrent.Tables["Small"];
                    }

                    DataRow newRow = dtSmall.NewRow();
                    newRow["Customer Name"] = cboCustomer.Text;
                    newRow["Box ID"] = tbBoxID.Text;
                    newRow["Date Stored"] = dtpickerDateStored.Value.Date.ToString("dd/MM/yyyy");

                    dtSmall.Rows.Add(newRow);
                    dsCurrent.WriteXml(currentPath);
                    MessageBox.Show("Data Saved.");
                    break;

                case "Medium":
                    dtMedium = new DataTable();
                    dtMedium.TableName = "Medium";
                    dtMedium.Columns.Add("Customer Name");
                    dtMedium.Columns.Add("Box ID");
                    dtMedium.Columns.Add("Date Stored");

                    if (!File.Exists(currentPath))
                    {
                        dsCurrent.Tables.Add(dtMedium);
                    }
                    else
                    {
                        dsCurrent.ReadXml(currentPath);
                        if (dsCurrent.Tables.Contains("Medium"))
                        {
                            dtMedium = dsCurrent.Tables["Medium"];
                        }
                        else
                        {
                            dsCurrent.Tables.Add(dtMedium);
                        }
                    }

                    DataRow newRowMedium = dtMedium.NewRow();
                    newRowMedium["Customer Name"] = cboCustomer.Text;
                    newRowMedium["Box ID"] = tbBoxID.Text;
                    newRowMedium["Date Stored"] = dtpickerDateStored.Value.Date.ToString("dd/MM/yyyy");

                    dtMedium.Rows.Add(newRowMedium);
                    dsCurrent.WriteXml(currentPath);
                    MessageBox.Show("Data Saved.");

                    break;

                case "Large":
                    dtLarge = new DataTable();
                    dtLarge.TableName = "Large";
                    dtLarge.Columns.Add("Customer Name");
                    dtLarge.Columns.Add("Box ID");
                    dtLarge.Columns.Add("Date Stored");

                    if (!File.Exists(currentPath))
                    {
                        dsCurrent.Tables.Add(dtLarge);
                    }
                    else
                    {
                        dsCurrent.ReadXml(currentPath);
                        if (dsCurrent.Tables.Contains("Large"))
                        {
                            dtLarge = dsCurrent.Tables["Large"];
                        }
                        else
                        {
                            dsCurrent.Tables.Add(dtLarge);
                        }
                        
                    }

                    DataRow newRowLarge = dtLarge.NewRow();
                    newRowLarge["Customer Name"] = cboCustomer.Text;
                    newRowLarge["Box ID"] = tbBoxID.Text;
                    newRowLarge["Date Stored"] = dtpickerDateStored.Value.Date.ToString("dd/MM/yyyy");

                    dtLarge.Rows.Add(newRowLarge);
                    dsCurrent.WriteXml(currentPath);
                    MessageBox.Show("Data Saved.");

                    break;

                default:
                    break;
            }
        }


       
    }
}
