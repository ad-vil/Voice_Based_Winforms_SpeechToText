using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Based_Winforms_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // simple button to go back to form 1
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // TODO: add input validation - don't allow blank fields
        // TODO: add save button functionality
        // TODO: clear input fields method instead of doing everything separately
        // TODO: make it so CSV doesnt reset on close, saves information

        private void Form2_Load(object sender, EventArgs e)
        {
            // initalize DataGrid columns
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("City", "City");
            dataGridView1.Columns.Add("Country", "Country");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // add new row to DataGrid
            dataGridView1.Rows.Add(fNameBox.Text, lNameBox.Text, cityBox.Text, countryBox.Text);
            // clear input fields
            fNameBox.Clear(); 
            lNameBox.Clear();
            cityBox.Clear();
            countryBox.Clear();
        }

        private void lNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cityBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void countryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) // prevents user from selecting 0 rows
            {
                // get selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // update row with new values
                selectedRow.Cells["FirstName"].Value = fNameBox.Text;
                selectedRow.Cells["LastName"].Value = lNameBox.Text;
                selectedRow.Cells["City"].Value = cityBox.Text;
                selectedRow.Cells["Country"].Value = countryBox.Text;
                // clear input fields
                fNameBox.Clear(); 
                lNameBox.Clear();
                cityBox.Clear(); 
                countryBox.Clear();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // remove selected row
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                // clear input fields
                fNameBox.Clear();
                lNameBox.Clear();
                cityBox.Clear();
                countryBox.Clear();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string csvFilePath = "data.csv";

            if (File.Exists(csvFilePath))
            {
                dataGridView1.Rows.Clear(); // clear existing rows - avoids duplicating
                var lines = File.ReadAllLines(csvFilePath);
                foreach (var line in lines)
                {
                    var values = line.Split(','); // comma for separation btwn values
                    dataGridView1.Rows.Add(values);
                }
            }
            else
            {
                MessageBox.Show("CSV file not found.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
