using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
namespace TransformTester
{


    public partial class Form1 : Form
    {

        private int fontSize = 12;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transform();
        }

        private void transform()
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                return;
            }

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(textBox1.Text);

                XmlDocument xslt = new XmlDocument();
                xslt.LoadXml(textBox2.Text);


                //textBox3.Text = xslt.OuterXml;
                StringBuilder outputstring = new StringBuilder();
                XmlWriter output = XmlWriter.Create(outputstring);

                XslCompiledTransform myXslTransform = new XslCompiledTransform();
                myXslTransform.Load(xslt);
                myXslTransform.Transform(doc, output);


                textBox3.Text = FormatXml(outputstring.ToString());
            }
            catch (Exception ex)
            {
                textBox3.Text = "Exception Message: " + ex.Message;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            transform();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            transform();
        }

        private string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formXMLSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = FormatXml(textBox1.Text);
        }

        private void formatTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = FormatXml(textBox2.Text);
        }


        private void formatButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = FormatXml(textBox1.Text);
        }


        private void formatButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = FormatXml(textBox2.Text);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textbox2_keydown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                textBox2.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control & e.KeyCode == Keys.D)
            {
                textBox2.Text = FormatXml(textBox2.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control & e.KeyCode == Keys.V)
            {
                textBox2.Text = FormatXml(Clipboard.GetText());
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

        }

        private void textbox1_keydown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                textBox1.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control & e.KeyCode == Keys.D)
            {
                textBox1.Text = FormatXml(textBox1.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control & e.KeyCode == Keys.V)
            {
                textBox1.Text = FormatXml(Clipboard.GetText());
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var newFont = new Font(textBox1.Font.FontFamily, fontSize + 1);
            textBox1.Font = newFont;
            textBox2.Font = newFont;
            textBox3.Font = newFont;
            fontSize++;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var newFont = new Font(textBox1.Font.FontFamily, fontSize - 1);
            textBox1.Font = newFont;
            textBox2.Font = newFont;
            textBox3.Font = newFont;
            fontSize--;
        }
    }
}
