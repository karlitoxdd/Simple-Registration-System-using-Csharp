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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            label5.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\pl\WindowsFormsApp1\WindowsFormsApp1\project.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from users where username='"+userText.Text.Trim()+"' and password = '"+passText.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {   
                if(dtbl.Rows[0].Field<int>(2) == 1)
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();
                    f1.label8.Text = "Admin";
                }
                else
                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.Show();
                    f1.label8.Text = "User";
                    f1.button2.Enabled = false;
                    f1.button3.Enabled = false;
                    f1.button4.Enabled = false;
                }
                
                
            }
            else
            {
                MessageBox.Show("Invalid Username and Password!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
