using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsApp
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
              
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';

            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Database Connection

        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Database11.mdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("PLEASE FILL IN ALL FIELDS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (textBox2.Text == textBox3.Text)
            {

                connect.Open();
                String register = "INSERT INTO Table1 VALUES ('" + textBox1.Text + "','" + textBox2.Text +"' )";
                command=new OleDbCommand(register,connect);
                command.ExecuteNonQuery();
                connect.Close();

                //To clear the fields
                textBox1.Text  =string.Empty;
                textBox2.Text = string.Empty;   
                textBox3.Text = string.Empty;

                
                MessageBox.Show("Registered", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password is Incorrect ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
