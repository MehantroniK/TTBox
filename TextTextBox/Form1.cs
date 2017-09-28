using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Якимов Семён. Все права защищены. 2017");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "RTF файлы(*.rtf)|*.rtf|Все файлы(*.*)|*.*";
            
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                string filename = OPF.FileName;
                richTextBox1.LoadFile(filename);
            }
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SVF = new SaveFileDialog();
            SVF.Filter = "RTF файлы(*.rtf)|*.rtf|Все файлы(*.*)|*.*";
            if (SVF.ShowDialog() == DialogResult.OK)
            {
                // Код по сохранению...
                string filename = SVF.FileName;
                richTextBox1.SaveFile(filename);
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText.
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
