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
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Econom_znach : Form
    {
        string serial_number;
        public Econom_znach(string id)
        {
            InitializeComponent();
            serial_number = id;
        }
        int max_znach(int[] arr)
        {
            int result = arr.Max();
            return result;
        }
        string return_title(int a)
        {
            string result = "";

            switch (a)
            {
                case 0:
                    {
                        result = "Категория не присвоена";
                        break;
                    }
                case 1:
                    {
                        result = "3 категория";
                        break;
                    }
                case 2:
                    {
                        result = "2 категория";
                        break;
                    }
                case 3:
                    {
                        result = "1 категория";
                        break;
                    }
            }


            return result;
        }
        private void Econom_znach_Load(object sender, EventArgs e)
        {
            string a = "3 категория\n более или равно 1, но менее или равно 10\n\n" +
            "2 категория\n более 10, но менее или равно 20\n\n" +
            "1 категория\n более 20";
            toolTip1.SetToolTip(pictureBox1, a);
            string b = "3 категория\n более 0,0003, но менее или равно 0,0006\n\n" +
                "2 категория\n более 0,0006, но менее или равно 0,001\n\n" +
                "1 категория\n более 0,001";
            toolTip1.SetToolTip(pictureBox2, b);
            string с = "3 категория\n менее или равно 70\n\n" +
            "2 категория\n более 70, но менее или равно 120\n\n" +
            "1 категория\n более 120";
            toolTip1.SetToolTip(pictureBox3, с);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool boolean = true;
            boolean = comboBox1.SelectedItem == null ? false : boolean;
            boolean = comboBox2.SelectedItem == null ? false : boolean;
            boolean = comboBox3.SelectedItem == null ? false : boolean;


            if (boolean)
            {
                int[] choises = { comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex };
                int choise1 = max_znach(choises);




                string a1 = return_title(choise1);



                XDocument doc = XDocument.Load("database.xml");

                var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).First();

                buff.Element("economznach").Attribute("value").Value = "true";
                buff.Element("economznach").Attribute("econom_1").Value = a1;



                doc.Save("database.xml");

                Form1 Form1 = new Form1();
                Form1.Show();

                this.Close();

            }
            else { MessageBox.Show("Необходимо заполнить все поля", ""); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();

            this.Close();
        }
    }
}

