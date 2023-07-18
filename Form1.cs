using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VOHCB4I\SQLEXPRESS;Initial Catalog=Signin;Integrated Security=True");
       

        void ViewGrid()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeID", textid.Text); // Use the appropriate parameter(s) based on your stored procedure

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                gridView.DataSource = dt; // Populate the DataGridView with the retrieved data
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }




        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textid.Text) ||
        string.IsNullOrWhiteSpace(textFirstName.Text) ||
        string.IsNullOrWhiteSpace(textLastName.Text) ||
        string.IsNullOrWhiteSpace(textdob.Text) ||
        string.IsNullOrWhiteSpace(textAge.Text) ||
        string.IsNullOrWhiteSpace(textPhone.Text) ||
        string.IsNullOrWhiteSpace(textEmail.Text) ||
        string.IsNullOrWhiteSpace(textState.Text) ||
        string.IsNullOrWhiteSpace(textCity.Text) ||
        string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string[] textBoxNames = {
        "textFirstName",
        "textLastName",
        "textEmail",
        "textPhone",
        "textPassword",
        "textdob",
        "textage"
    };
            foreach (string textBoxName in textBoxNames)
            {
                switch (textBoxName)
                {
                    case "textFirstName":
                        if (!ValidateFirstName(textFirstName.Text))
                        {
                            return;
                        }
                        break;

                    case "textLastName":
                        if (!ValidateLastName(textLastName.Text))
                        {
                            return;
                        }
                        break;
                    case "textage":
                        if (!ValidateAge(textAge.Text))
                        {
                            return;
                        }
                        break;
                    case "textEmail":
                        if (!ValidateEmail(textEmail.Text))
                        {
                            return;
                        }
                        break;
                    case "textPhone":
                        if (!ValidatePhoneNumber(textPhone.Text))
                        {
                            return;
                        }
                        break;



                    case "textdob":
                        if (!ValidateDateOfBirth(textdob.Text))
                        {
                            return;
                        }
                        break;
                    case "textPassword":
                        if (!ValidatePassword(textPassword.Text))
                        {
                            return;
                        }
                        break;
                }
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("employeeINSERT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeID", textid.Text);
                cmd.Parameters.AddWithValue("@employeeFirstName", textFirstName.Text);
                cmd.Parameters.AddWithValue("@employeeLastName", textLastName.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", textdob.Text);
                cmd.Parameters.AddWithValue("@age", textAge.Text);
                cmd.Parameters.AddWithValue("@phoneNumber", textPhone.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
                cmd.Parameters.AddWithValue("@state", textState.Text);
                cmd.Parameters.AddWithValue("@city", textCity.Text);
                cmd.Parameters.AddWithValue("@password", textPassword.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }



        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textid.Text) ||
        string.IsNullOrWhiteSpace(textFirstName.Text) ||
        string.IsNullOrWhiteSpace(textLastName.Text) ||
        string.IsNullOrWhiteSpace(textdob.Text) ||
        string.IsNullOrWhiteSpace(textAge.Text) ||
        string.IsNullOrWhiteSpace(textPhone.Text) ||
        string.IsNullOrWhiteSpace(textEmail.Text) ||
        string.IsNullOrWhiteSpace(textState.Text) ||
        string.IsNullOrWhiteSpace(textCity.Text) ||
        string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string[] textBoxNames = {
        "textFirstName",
        "textLastName",
        "textEmail",
        "textPhone",
        "textPassword",
        "textdob",
        "textage"
    };
            foreach (string textBoxName in textBoxNames)
            {
                switch (textBoxName)
                {
                    case "textFirstName":
                        if (!ValidateFirstName(textFirstName.Text))
                        {
                            return;
                        }
                        break;

                    case "textLastName":
                        if (!ValidateLastName(textLastName.Text))
                        {
                            return;
                        }
                        break;
                    case "textage":
                        if (!ValidateAge(textAge.Text))
                        {
                            return;
                        }
                        break;
                    case "textEmail":
                        if (!ValidateEmail(textEmail.Text))
                        {
                            return;
                        }
                        break;
                    case "textPhone":
                        if (!ValidatePhoneNumber(textPhone.Text))
                        {
                            return;
                        }
                        break;



                    case "textdob":
                        if (!ValidateDateOfBirth(textdob.Text))
                        {
                            return;
                        }
                        break;
                    case "textPassword":
                        if (!ValidatePassword(textPassword.Text))
                        {
                            return;
                        }
                        break;
                }
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeID", textid.Text);
                cmd.Parameters.AddWithValue("@employeeFirstName", textFirstName.Text);
                cmd.Parameters.AddWithValue("@employeeLastName", textLastName.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", textdob.Text);
                cmd.Parameters.AddWithValue("@age", textAge.Text);
                cmd.Parameters.AddWithValue("@phoneNumber", textPhone.Text);
                cmd.Parameters.AddWithValue("@email", textEmail.Text);
                cmd.Parameters.AddWithValue("@state", textState.Text);
                cmd.Parameters.AddWithValue("@city", textCity.Text);
                cmd.Parameters.AddWithValue("@password", textPassword.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully updated");
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are you sure to delete", "delete record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@employeeID", textid.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deletion successful");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ViewGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textFirstName.Clear();
            textLastName.Clear();
            textdob.Clear();
            textAge.Clear();
            textAge.Clear();
            textPhone.Clear();
            textEmail.Clear();
            textState.Clear();
            textCity.Clear();
            textid.Clear();

            textPassword.Clear();


        }

        private bool ValidateFirstName(string name)
        {

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    MessageBox.Show("Name should contain only alphabetic characters.");
                    return false;
                }
            }

            return true;
        }
        private bool ValidateLastName(string name)
        {

            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                {
                    MessageBox.Show("Name should contain only alphabetic characters.");
                    return false;
                }
            }

            return true;
        }
        private bool ValidateEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return false;
            }
            return true;
        }

        private bool ValidatePhoneNumber(string phone)
        {

            string pattern = @"^.{10}$";

            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(phone))
            {
                MessageBox.Show("Please enter a valid phone number");
                return false;
            }
            return true;
        }

        private bool ValidateDateOfBirth(string dateOfBirth)
        {
            
            if (!DateTime.TryParse(dateOfBirth, out DateTime dob))
            {
                MessageBox.Show("Please enter a valid date of birth.");
                return false;
            }
            if (dob > DateTime.Today)
            {
                MessageBox.Show("Date of birth cannot be a future date.");
                return false;
            }

            return true;
        }
        private bool ValidatePassword(string password)
        {

            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@_])[a-zA-Z\d@_]{8,}$";

            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(password))
            {
                MessageBox.Show("Password contains atleast one alphabet,number and special characters(@,_)and minimum length 8.");
                return false;
            }
            return true;
        }
        private bool ValidateAge(string age)
        {

           
            if (int.Parse(age) <19)
            {
                MessageBox.Show("age connot be less than 18");
                return false;
            }
            return true;
        }

    }
}
