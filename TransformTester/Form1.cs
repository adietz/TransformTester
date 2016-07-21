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
            catch
            {
                return;
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
    }
}
