using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
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
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
            
        }

        public static Image AddText(RichTextBox CompanyText, string Path, float SizeFont)
        {
            FileStream fs = new FileStream(Path, FileMode.Open);
            Image img = Image.FromStream(fs);
            fs.Close();
            int otstup = img.Width / 10 * 6;
            Font fnt = new Font("Arial", 14);
            Graphics f = CompanyText.CreateGraphics();
           

            RectangleF rectf = new RectangleF(otstup, 0, img.Width - otstup, img.Height);

            Graphics g = Graphics.FromImage(img);
            Color brushColor = Color.FromArgb(255 / 100 * 50, 0, 0, 0);
            SolidBrush brush = new SolidBrush(brushColor);
            g.FillRectangle(brush, rectf);

            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            //StringFormat format = new StringFormat()
            //{
            //    Alignment = StringAlignment.Near,
            //    LineAlignment = StringAlignment.Near
            //};
            g.DrawImage(img, 0, 0, rectf, f);

            g.Flush();

            g.Save();
            return img;
        }

        private void imgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image image1 = AddText(richTextBox1, @"d:\test\1600x900.bmp", 14);
            SaveFileDialog SVF = new SaveFileDialog();
            SVF.Filter = "RTF файлы(*.bmp)|*.bmp|Все файлы(*.*)|*.*";
            if (SVF.ShowDialog() == DialogResult.OK)
            {
                // Код по сохранению...
                string filename = SVF.FileName;
                image1.Save(filename, ImageFormat.Bmp);
            }
        }
    }
}
