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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ShowDialog();
        }

        private void BtnStore_Click(object sender, EventArgs e)
        {
            string customerPath = string.Format(@"{0}\Customer.xml", Application.StartupPath);

            if (!File.Exists(customerPath))
            {
                MessageBox.Show("No data for customers available.");
                return;
            }

            Store store = new Store();
            store.ShowDialog();
        }

        private void BtnRetrieve_Click(object sender, EventArgs e)
        {
            Retrieve retrieve = new Retrieve();
            retrieve.ShowDialog();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            ViewRecord viewRecord = new ViewRecord();
            viewRecord.ShowDialog();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            CheckAvailable checkAvailable = new CheckAvailable();
            checkAvailable.ShowDialog();
        }
    }
}
