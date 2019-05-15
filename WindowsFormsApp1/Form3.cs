using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }
        public void GenReport()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\pl\WindowsFormsApp1\WindowsFormsApp1\project.mdf;Integrated Security=True;Connect Timeout=30");
            string query1 = "Select * from voter";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            textBox1.Text = string.Empty;
            textBox1.Text += DateTime.Now.ToString("MM/dd/yyyy")+" - "+DateTime.Now.ToString("h:mm:ss tt")+Environment.NewLine+ Environment.NewLine;
            textBox1.Text += "ID | Name | Gender | B-Day | District | Contact#" + Environment.NewLine;
            textBox1.Text += "---------------------------------------------------------------------------------------" + Environment.NewLine;
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                textBox1.Text += dtbl.Rows[i].ItemArray[0].ToString();
                textBox1.Text += " | " + dtbl.Rows[i].ItemArray[1].ToString();
                textBox1.Text += " | " + dtbl.Rows[i].ItemArray[2].ToString();
                textBox1.Text += " | " + dtbl.Rows[i].ItemArray[4].ToString();
                textBox1.Text += " " + dtbl.Rows[i].ItemArray[5].ToString();
                textBox1.Text += " " + dtbl.Rows[i].ItemArray[3].ToString();
                textBox1.Text += " | " + dtbl.Rows[i].ItemArray[6].ToString();
                textBox1.Text += " | " + dtbl.Rows[i].ItemArray[7].ToString() + Environment.NewLine;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
