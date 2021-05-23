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
using System.Xml;
using System.Xml.Serialization;

namespace EXAM
{
    public partial class Form1 : Form
    {
        List<Element> elements;
        public Form1()
        {
            elements = new List<Element>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            elements.Add(new Element() { Age = Convert.ToInt32(textBox1.Text), Discription = textBox2.Text, Name = textBox3.Text });
            UpdateList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Element>));
            using (Stream fStream = new FileStream("test.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, elements);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Element>));
            using (Stream fStream = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                if (fStream.Length != 0)
                    using (XmlReader reader = XmlReader.Create(fStream))
                    {
                        elements = (List<Element>)serializer.Deserialize(reader);
                    }
            }
            UpdateList();
        }

        private void UpdateList()
        {
            dataGridView1.DataSource = elements.ToList();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var request = from p in elements where p.Name == textBox4.Text orderby p.Age select p ;

            dataGridView1.DataSource = request.ToList();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var request = elements.Where(p => p.Name == textBox4.Text).OrderBy(p => p.Age).GroupBy(p => p.Discription).ToList();

            List<Element> forForm = new List<Element>();
            foreach (IGrouping<string, Element> g in request)
            {
                forForm.Add(new Element { Name = g.Key });
                foreach (var p in g)
                    forForm.Add(p);
            }
            dataGridView1.DataSource = forForm.ToList();
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
