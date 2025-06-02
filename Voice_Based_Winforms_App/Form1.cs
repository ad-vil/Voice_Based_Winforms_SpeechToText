using System;
using System.Windows.Forms;
using Microsoft.CognitiveServices.Speech;

namespace Voice_Based_Winforms_App
{
    public partial class Form1 : Form
    {
        private SpeechRecognizer? recognizer;

        // TODO: add mic icon and loading spinner
        //       maybe add something to this form later? its just placeholder right now
        public Form1()
        {
            InitializeComponent();
        }

        // extra button to go to form 2        
        private void form2btn_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtOutput.Text = "Click the button and start speaking";
        }

        // safely append text to the output box - checks to make sure correct thread is in use
        private void SafeAppend(string message)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new MethodInvoker(() => txtOutput.AppendText(message)));
            }
            else
            {
                txtOutput.AppendText(message);
            }
        }

        // button click method - starts transcription w/ key n region
        private async void btnStart_Click(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription("EjD6w7pk9R811xWEUR9jVOfx8k1ndsVGjHkEfwwrsAjH5L5StuETJQQJ99BDACqBBLyXJ3w3AAAYACOGqJcR", "southeastasia");

            recognizer = new SpeechRecognizer(config);

            txtOutput.Clear();
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

                    // switch to form 2 based on voice command
                    if (evt.Result.Text.Contains("go to form 2", StringComparison.OrdinalIgnoreCase))
                    {
                        recognizer.StopContinuousRecognitionAsync().Wait(); // stop recognition

                        // open form 2
                        this.Invoke(new MethodInvoker(() =>
                        {
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide(); // hide current
                        }));
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

            recognizer.SessionStopped += (s, evt) =>
            {
                SafeAppend("Recognition stopped.\r\n");
            };

            await recognizer.StartContinuousRecognitionAsync();
        }

        // stop button
        private async void button1_Click(object sender, EventArgs e)
        {
            if (recognizer != null)
            {
                await recognizer.StopContinuousRecognitionAsync();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
