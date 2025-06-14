using System;
using System.Collections.Generic;
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

        // TODO: finish implementing DB in this file
        //       convert input text boxes to voice commands - idk how to do this with unique names but it seems decent w most 

        private void Form2_Load(object sender, EventArgs e)
        {
            // initialize DataGrid columns
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns["Id"].Visible = false; // hide id from user
            dataGridView1.Columns.Add("FirstName", "First Name");
            dataGridView1.Columns.Add("LastName", "Last Name");
            dataGridView1.Columns.Add("City", "City");
            dataGridView1.Columns.Add("Country", "Country");

            LoadPatients(); // load from db
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // no need to save anymore, db is always up to date
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                // add new patient to db
                var p = new Patient
                {
                    FirstName = fNameBox.Text,
                    LastName = lNameBox.Text,
                    City = cityBox.Text,
                    Country = countryBox.Text
                };
                PatientRepository.Add(p);
                LoadPatients();
                clearInputs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && validateInputs())
            {
                // get selected row
                // need to make it so when you select a row it autfills into text boxes
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                // update patient in db
                var p = new Patient
                {
                    Id = id,
                    FirstName = fNameBox.Text,
                    LastName = lNameBox.Text,
                    City = cityBox.Text,
                    Country = countryBox.Text
                };
                PatientRepository.Update(p);
                LoadPatients();
                clearInputs();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        // THIS DOESNT WORK YET, NEED TO FIX IT
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this?");
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    PatientRepository.Delete(id);
                    LoadPatients();
                    clearInputs();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        private void LoadPatients()
        {
            dataGridView1.Rows.Clear();
            var patients = PatientRepository.GetAll();
            foreach (var p in patients)
            {
                dataGridView1.Rows.Add(p.Id, p.FirstName, p.LastName, p.City, p.Country);
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

                Form3 form3 = new Form3(firstName, lastName, city, country); // pass info to form 3
                form3.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a patient to view.");
            }
        }

        // transcription for commands in form 2 - doesnt do anything useful yet

        // TODO:
        // fix follow up on commands like "enter new patient" command doesnt do anything yet - want to use whisper ai?
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
                await recognizer.StartContinuousRecognitionAsync(); // restart recognition
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
            var details = text.Split(' '); // split by space
            if (details.Length == 4)
            {
                var p = new Patient
                {
                    FirstName = details[0],
                    LastName = details[1],
                    City = details[2],
                    Country = details[3]
                };
                PatientRepository.Add(p);
                LoadPatients();
                SafeAppend($"Entered patient {p.FirstName} {p.LastName} from {p.City}, {p.Country} into database.\r\n");
                transcriptionState = 0; // reset state
            }
            else
            {
                SafeAppend("Invalid input. Please state first name, last name, city, and country.\r\n");
            }
        }
    }
}
