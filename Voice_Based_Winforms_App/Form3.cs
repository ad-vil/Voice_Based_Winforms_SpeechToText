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
    public partial class Form3 : Form
    {
        public string firstName;
        public string lastName;
        public string city;
        public string country;

        public Form3(string firstName, string lastName, string city, string country) // ctor to accept patient info from form 2
        {
            InitializeComponent();
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.country = country;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // display patient info in labels
            firstNameLbl.Text = $"First Name: {firstName}";
            lastNameLbl.Text = $"Last Name: {lastName}";
            cityLbl.Text = $"City: {city}";
            countryLbl.Text = $"Country: {country}";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void btnNextForm_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }
    }
}
