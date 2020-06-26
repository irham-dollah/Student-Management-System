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
using System.Diagnostics;

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
            //InitializeComponent();
            //menuStrip1.Renderer = new MyRenderer();
            //db.StudentTables.Load();
            //studentTableBindingSource.DataSource = db.StudentTables.Local;
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

        Student_DetailEntities db = new Student_DetailEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            db.StudentTables.Load();
            studentTableBindingSource.DataSource = db.StudentTables.Local;
        }

    }
}
