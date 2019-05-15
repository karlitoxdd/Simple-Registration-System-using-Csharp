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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\pl\WindowsFormsApp1\WindowsFormsApp1\project.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        
       
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into voter values('"+textBox2.Text+"','"+comboBox1.Text+"','"+comboBox4.Text+ "','" + comboBox2.Text + "','" + comboBox3.Text + "'" +
                ",'" + comboBox5.Text + "','" + textBox6.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Voter Added successfully");
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from voter";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disp_data();
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update voter set Name = '" + textBox2.Text + "' ,Gender = '" + comboBox1.Text + "' ,Birth_Year = '" + comboBox4.Text + "' ,Birth_Month = '" + comboBox2.Text + "' ,Birth_Day = '" + comboBox3.Text + "' ,District = '"+comboBox5.Text+"' ,Contact_Number = '"+textBox6.Text+"' where Voters_ID = '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Voter Record Updated Successfully");
           
        }




    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, " ^[0-9]"))
            {
                textBox1.Text = " ";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, " ^[0-9]"))
            {
                textBox2.Text = " ";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {  if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, " ^[0-9]"))
            {
                textBox6.Text = " ";
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            { 
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                comboBox4.Text = row.Cells[3].Value.ToString();
                comboBox2.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
                comboBox5.Text = row.Cells[6].Value.ToString();
                textBox6.Text = row.Cells[7].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from voter where Voters_ID = '"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Voter Record Deleted Successfully");

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = "Select Gender";
            comboBox4.Text = "Select Year";
            comboBox2.Text = "Select Month";
            comboBox3.Text ="Select Day";
            comboBox5.Text = "Select District";
            textBox6.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 rep = new Form3();
            rep.Show();
            rep.GenReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
