using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace VaccineApp
{
    public partial class Form1 : Form
    {
        
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-BC5OBUO;Initial Catalog=Vaccine;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtSurname.Text == "" || txtName.Text == "" || txtProvince.Text == "" || cbGender.Text == "")
            {
                MessageBox.Show("Please Fill out all fields");
            }
            else
            {
                cnn.Open();
                SqlCommand command = new SqlCommand("insert into Peoples(ID_Number, Surname, Name, Gender, Province) values(@id, @surname, @name, @gender, @province)", cnn);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@surname", txtSurname.Text);
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@gender", cbGender.Text);
                command.Parameters.AddWithValue("@province", txtProvince.Text);
                command.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("You have Registered for your Vaccine");
                txtID.Text = "";
                txtName.Text = "";
                txtSurname.Text = "";
                txtProvince.Text = "";
                cbGender.Text = "";
            }
            

        }

    }
}
