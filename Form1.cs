using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var stream = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.Write);
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(richTextBox1.Text);
                sw.Close();
                stream.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(stream);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                stream.Close();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            
        }

        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!string.IsNullOrEmpty(richTextBox1.SelectedText))
                {
                    richTextBox1.SelectionFont=fontDialog1.Font;
                }
                else
                { 
                     richTextBox1.Font = fontDialog1.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!string.IsNullOrEmpty(richTextBox1.SelectedText))
                { 
                    richTextBox1.SelectionColor = colorDialog1.Color;
                }
                else 
                {
                    richTextBox1.ForeColor=colorDialog1.Color;
                }
             

            }
        }
    }
} 
