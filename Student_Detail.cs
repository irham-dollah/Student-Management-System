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

namespace Student_Management_System
{
    public partial class Student_Detail : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Am\source\repos\Student Management System\Student_Info.mdf;Integrated Security=True;Connect Timeout=30;");
        public Student_Detail(int x)
        {
            InitializeComponent();
            if (x == 1)
            {
                button2.Visible = false;
                button3.Visible = false;
            }else if (x == 2)
            {
                button1.Visible = false;
                button3.Visible = false;
            }
            else
            {
                button2.Visible = false;
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text) ||
                String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill in all details", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand sc = new SqlCommand("INSERT into studentTable values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
                    sc.ExecuteNonQuery();
                    MessageBox.Show("Student Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Student already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBoxes();
                }   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
                String.IsNullOrEmpty(textBox2.Text) ||
                String.IsNullOrEmpty(textBox3.Text) ||
                String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please fill in all details", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from studentTable where student_id like @studentID", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@studentID", textBox1.Text);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        SqlCommand sc = new SqlCommand("UPDATE studentTable SET Student_Name= '" + textBox2.Text + "', Address='" + textBox3.Text + "', Class='" + textBox4.Text + "' WHERE Student_ID='" + textBox1.Text + "'", con);
                        sc.ExecuteNonQuery();
                        MessageBox.Show("Student Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearTextBoxes();
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("The student not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxes();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill in the Student ID", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from studentTable where student_id like @studentID", con))
                {
                    con.Open();
                    sqlCommand.Parameters.AddWithValue("@studentID", textBox1.Text);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        SqlCommand sc = new SqlCommand("DELETE studentTable WHERE Student_ID='" + textBox1.Text + "'", con);
                        if (MessageBox.Show("Confirm Delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            sc.ExecuteNonQuery();
                            MessageBox.Show("Item Deleted", "Success");
                            ClearTextBoxes();
                        }
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("The student not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearTextBoxes();
                    }
                }
            }
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
