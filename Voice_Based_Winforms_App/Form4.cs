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

        // TODO: implement actual training feature?
        // this form is a placeholder for future training functionality, and a space to help the user get familiar w azure model

        // define training phrases 
        private readonly string[] trainingPhrases = { "Hello", "Goodbye", "Start", "Stop", "Enter new patient" };
        private int currentPhraseIndex = 0;

        // model shows phrase, then user repeats it
        private async void btnStartTraining_Click(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription("EjD6w7pk9R811xWEUR9jVOfx8k1ndsVGjHkEfwwrsAjH5L5StuETJQQJ99BDACqBBLyXJ3w3AAAYACOGqJcR", "southeastasia");
            recognizer = new SpeechRecognizer(config);

            txtTraining.Clear();
            currentPhraseIndex = 0;
            SafeAppend("Voice training started.\r\n");
            SafeAppend($"Please say: \"{trainingPhrases[currentPhraseIndex]}\"\r\n");

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
                await recognizer.StartContinuousRecognitionAsync();
            };

            await recognizer.StartContinuousRecognitionAsync();
        }

        private void HandleTrainingPhrase(string text)
        {
            // normalize recognized text and expected phrase. trim punctuation at the end
            string recognized = text.Trim().ToLowerInvariant().TrimEnd('.', '!', '?');
            string expected = trainingPhrases[currentPhraseIndex].ToLowerInvariant();

            if (currentPhraseIndex < trainingPhrases.Length &&
                (recognized == expected || recognized.Replace(" ", "") == expected.Replace(" ", "")))
            {
                SafeAppend($"Training phrase recognized: {text}\r\n");
                currentPhraseIndex++;
                if (currentPhraseIndex < trainingPhrases.Length)
                {
                    SafeAppend($"Next, please say: \"{trainingPhrases[currentPhraseIndex]}\"\r\n");
                }
                else
                {
                    SafeAppend("Training complete! You have finished all phrases.\r\n");
                }
            }
            else
            {
                SafeAppend($"Unrecognized or out-of-order phrase: {text}. Please say: \"{trainingPhrases[currentPhraseIndex]}\"\r\n");
            }
        }

        // TODO: add mic icon and loading spinner

        private SpeechRecognizer? recognizer;
        public Form4()
        {
            InitializeComponent();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
