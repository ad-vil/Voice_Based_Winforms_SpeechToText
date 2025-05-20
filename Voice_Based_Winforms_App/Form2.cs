using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;

namespace Voice_Based_Winforms_App
{
    public partial class Form2 : Form
    {
        private SpeechRecognizer? recognizer;
        private int transcriptionState = 0; // init transcription status

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

        // transcription for commands in form 2

        // TODO:
        // fix follow up on commands like "enter new patient" command doesnt do anything yet
        // work on trying to make it better at recognizing commands?
        // names might be hard to capture, need to find a fix for that.
        private async void startTranscriptionBtn_Click(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription("EjD6w7pk9R811xWEUR9jVOfx8k1ndsVGjHkEfwwrsAjH5L5StuETJQQJ99BDACqBBLyXJ3w3AAAYACOGqJcR", "southeastasia");
            recognizer = new SpeechRecognizer(config);

            textBox1.Clear();
            SafeAppend("Listening...\r\n");

            recognizer.Recognizing += (s, evt) =>
            {
                SafeAppend($"Heard: {evt.Result.Text}\r\n");
            };

            recognizer.Recognized += (s, evt) =>
            {
                if (evt.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    SafeAppend($"Recognized: {evt.Result.Text}\r\n");

                    if (transcriptionState == 0 && evt.Result.Text.Equals("Enter new patient", StringComparison.OrdinalIgnoreCase))
                    {
                        transcriptionState = 1;
                        SafeAppend("State patient first name, last name, city, and country.\r\n");
                    }
                    else if (transcriptionState == 1)
                    {
                        processPatientDetails(evt.Result.Text);
                    }
                }
                else if (evt.Result.Reason == ResultReason.NoMatch)
                {
                    SafeAppend("No speech was recognized.\r\n");
                }
            };

            recognizer.Canceled += (s, evt) =>
            {
                SafeAppend($"Recognition canceled: {evt.Reason}\r\n");
                if (evt.Reason == CancellationReason.Error)
                {
                    SafeAppend($"Error details: {evt.ErrorDetails}\r\n");
                }
            };

            recognizer.SessionStopped += async (s, evt) =>
            {
                SafeAppend("Recognition stopped. Restarting...\r\n");
                await recognizer.StartContinuousRecognitionAsync(); // Restart recognition
            };

            await recognizer.StartContinuousRecognitionAsync();
        }

        private async void endTranscriptionBtn_Click(object sender, EventArgs e)
        {
            if (recognizer != null)
            {
                await recognizer.StopContinuousRecognitionAsync();
                recognizer.Dispose();
                recognizer = null;
            }
            SafeAppend("Transcription stopped.\r\n");
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void SafeAppend(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new MethodInvoker(() => textBox1.AppendText(message)));
            }
            else
            {
                textBox1.AppendText(message);
            }
        }
        private void processPatientDetails(string text)
        {
            var details = text.Split(' '); // Split by space
            if (details.Length == 4)
            {
                string firstName = details[0];
                string lastName = details[1];
                string city = details[2];
                string country = details[3];

                // Add new row to DataGrid
                dataGridView1.Rows.Add(firstName, lastName, city, country);

                // Save to CSV
                btnSave_Click(this, EventArgs.Empty);

                SafeAppend($"Entered patient {firstName} {lastName} from {city}, {country} into CSV.\r\n");
                transcriptionState = 0; // Reset state
            }
            else
            {
                SafeAppend("Invalid input. Please state first name, last name, city, and country.\r\n");
            }
        }

    }
}
