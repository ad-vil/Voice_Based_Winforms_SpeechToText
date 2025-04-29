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

        // simple button to go back to form 1
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        // TODO LIST

        // TODO: see if we can use a database instead of CSV
        // TODO: convert text boxes to voice commands

        private void Form2_Load(object sender, EventArgs e)
        {
            // initalize DataGrid columns
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("City", "City");
            dataGridView1.Columns.Add("Country", "Country");

            // auto load csv
            btnLoad_Click(this, EventArgs.Empty); // args simnulate the btn click
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnSave_Click(this, EventArgs.Empty); // auto save form on close
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                // add new row to DataGrid
                dataGridView1.Rows.Add(fNameBox.Text, lNameBox.Text, cityBox.Text, countryBox.Text);
                // clear input fields
                clearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && validateInputs()) // prevents user from selecting 0 rows
            {
                // get selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // update row with new values
                selectedRow.Cells["FirstName"].Value = fNameBox.Text;
                selectedRow.Cells["LastName"].Value = lNameBox.Text;
                selectedRow.Cells["City"].Value = cityBox.Text;
                selectedRow.Cells["Country"].Value = countryBox.Text;
                // clear input fields
                clearInputs();
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
                var result = MessageBox.Show("Are you sure you want to delete this?"); // delete confirmation
                if (result == DialogResult.Yes)
                {
                    // remove selected row
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    // clear input fields
                    clearInputs();
                }
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
            string csvFilePath = "data.csv";

            try
            {
                var lines = new List<string>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) // skipping new placeholder
                    {
                        // extracting values in cells
                        var values = new string[]
                        {
                            row.Cells["FirstName"].Value?.ToString() ?? "",
                            row.Cells["LastName"].Value?.ToString() ?? "",
                            row.Cells["City"].Value?.ToString() ?? "",
                            row.Cells["Country"].Value?.ToString() ?? ""
                        };
                        lines.Add(string.Join(",", values));
                    }
                }

                // write lines to csv
                File.WriteAllLines(csvFilePath, lines);

                MessageBox.Show("Data saved successfully to " + csvFilePath, "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // exception handling for file writing
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearInputs()
        {
            fNameBox.Clear();
            lNameBox.Clear();
            cityBox.Clear();
            countryBox.Clear();
        }

        private bool validateInputs()
        {
            if (string.IsNullOrWhiteSpace(fNameBox.Text) ||
                string.IsNullOrWhiteSpace(lNameBox.Text) ||
                string.IsNullOrWhiteSpace(cityBox.Text) ||
                string.IsNullOrWhiteSpace(countryBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
            return true;
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void fName_TextChanged(object sender, EventArgs e)
        {

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

        private void viewPatientBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // selecting patient data
                var selectedRow = dataGridView1.SelectedRows[0];
                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                string lastName = selectedRow.Cells["LastName"].Value.ToString();
                string city = selectedRow.Cells["City"].Value.ToString();
                string country = selectedRow.Cells["Country"].Value.ToString();

                Form3 form3 = new Form3(firstName, lastName, city, country); // have to pass info to form 3
                form3.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a patient to view.");
            }
        }
    }
}
