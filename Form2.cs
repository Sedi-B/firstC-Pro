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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';

            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        //Database Connection

        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Database11.mdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {

            connect.Open();
            String login = "SELECT * FROM Table1 WHERE username = '"+textBox1.Text +"'and password='" +textBox2.Text +"'";
            command = new OleDbCommand(login, connect);
            OleDbDataReader reader = command.ExecuteReader();
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("PLEASE FILL IN ALL FIELDS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
               if (reader.Read() == true)
            {
                new main().ShowDialog();
                this.Hide();
                MessageBox.Show("Logged In", "Message", MessageBoxButtons.OK);

            }
            else { 
            
                MessageBox.Show("Password or Username is not found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //To clear the fields
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
            connect.Close();
        }

    }
    }

