using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxText.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBoxText.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "save | *.rtf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBoxText.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBoxText.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBoxText.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionFont = new Font(this.richTextBoxText.SelectionFont, this.richTextBoxText.SelectionFont.Style^FontStyle.Bold);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionFont = new Font(this.richTextBoxText.SelectionFont, this.richTextBoxText.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBoxText.SelectionFont = new Font(this.richTextBoxText.SelectionFont, this.richTextBoxText.SelectionFont.Style ^ FontStyle.Underline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData("https://en.wikipedia.org/wiki/Main_Page");
            var str = Encoding.Default.GetString(bytes);
            File.WriteAllText("site.txt", str);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            float currentZoom = richTextBoxText.ZoomFactor;

            richTextBoxText.ZoomFactor = currentZoom + 0.1f;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            float currentZoom = richTextBoxText.ZoomFactor;

            if (currentZoom > 0.1f)
                richTextBoxText.ZoomFactor = currentZoom - 0.1f;
        }
    }
}