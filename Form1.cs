using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Yellow; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Orange; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Yellow; }
            }
            public override Color CheckBackground
            {
                get { return Color.Yellow; }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.StudentDetails.Local;
            dataGridView1.Update();
            dataGridView1.Refresh();*/
            Application.Restart();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Detail sd = new Student_Detail(1);
            sd.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Detail sd = new Student_Detail(2);
            sd.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Detail sd = new Student_Detail(3);
            sd.Show();
        }

        //Student_InfoEntities db = new Student_InfoEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            //db.Tables.Load();
            //stude = db.Tables.Local;
        }

        private void studentDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
