using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap03_02
{
    public partial class Form1 : Form
    {
        private string currentFileName;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            richTextBox.Font = new Font("Tahoma", 14);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.LoadFile(openFileDialog.FileName);
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
            if (string.IsNullOrEmpty(currentFileName))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    currentFileName = saveFileDialog.FileName;
                    MessageBox.Show("File saved successfully!");
                }
            }
            else
            {
                richTextBox.SaveFile(currentFileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("File saved successfully!");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {   
            richTextBox.Clear();
            richTextBox.Font = new Font("Tahoma", 14);
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Files (*.rtf)|*.rtf";
            if (string.IsNullOrEmpty(currentFileName))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    currentFileName = saveFileDialog.FileName;
                    MessageBox.Show("File saved successfully!");
                }
            }
            else
            {
                richTextBox.SaveFile(currentFileName, RichTextBoxStreamType.RichText);
                MessageBox.Show("File saved successfully!");
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold;
                richTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic;
                richTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox.SelectionFont != null)
            {
                Font currentFont = richTextBox.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline;
                richTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string selectedFont = toolStripComboBox1.SelectedItem.ToString();
            richTextBox.Font = new Font(selectedFont, richTextBox.Font.Size);
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            int selectedSize = int.Parse(toolStripComboBox2.SelectedItem.ToString());
            richTextBox.Font = new Font(richTextBox.Font.Name, selectedSize);

        }

    }
}
