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
    public partial class Form4 : Form
    {

        private SpeechRecognizer? recognizer;
        public Form4()
        {
            InitializeComponent();
        }

        private async void btnStartTraining_Click(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription("EjD6w7pk9R811xWEUR9jVOfx8k1ndsVGjHkEfwwrsAjH5L5StuETJQQJ99BDACqBBLyXJ3w3AAAYACOGqJcR", "southeastasia");
            recognizer = new SpeechRecognizer(config);

            txtTraining.Clear();
            SafeAppend("Voice training started. Please say the training phrases.\r\n");

            recognizer.Recognizing += (s, evt) =>
            {
                SafeAppend($"Heard: {evt.Result.Text}\r\n");
            };

            recognizer.Recognized += (s, evt) =>
            {
                if (evt.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    SafeAppend($"Recognized: {evt.Result.Text}\r\n");
                    HandleTrainingPhrase(evt.Result.Text);
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

        private async void btnStopTraining_Click(object sender, EventArgs e)
        {
            if (recognizer != null)
            {
                await recognizer.StopContinuousRecognitionAsync();
                recognizer.Dispose();
                recognizer = null;
            }
            SafeAppend("Voice training stopped.\r\n");
        }

        private void SafeAppend(string message)
        {
            if (txtTraining.InvokeRequired)
            {
                txtTraining.Invoke(new MethodInvoker(() => txtTraining.AppendText(message)));
            }
            else
            {
                txtTraining.AppendText(message);
            }
        }


        private void HandleTrainingPhrase(string text)
        {
            // Define training phrases
            var trainingPhrases = new[] { "Hello", "Goodbye", "Start", "Stop", "Enter new patient" };

            if (Array.Exists(trainingPhrases, phrase => phrase.Equals(text, StringComparison.OrdinalIgnoreCase)))
            {
                SafeAppend($"Training phrase recognized: {text}\r\n");
            }
            else
            {
                SafeAppend($"Unrecognized phrase: {text}. Please try again.\r\n");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
