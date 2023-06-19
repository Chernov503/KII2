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
    public partial class Gos_znach : Form
    {
        string serial_number;
        public Gos_znach(string id)
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

        private void Gos_znach_Load(object sender, EventArgs e)
        {
            string b = "3 категория\n прекращение или нарушение функционирования пункта управления или ситуационного \nцентра органа государственной власти субъекта Российской \nФедерации или города федерального значения\n" +
            "\n2 категория\n прекращение или нарушение функционирования пункта управления или ситуационного центра \nфедерального органа государственной власти или \nгосударственной корпорации" +
            "\n\n1 категория\n прекращение или нарушение функционирования пункта управления государством или \nситуационного центра Администрации Президента Российской \nФедерации, Правительства Российской Федерации, Федерального Собрания Российской \nФедерации, Совета Безопасности Российской Федерации, Верховного Суда \nРоссийской Федерации, Конституционного Суда Российской Федерации";
            toolTip1.SetToolTip(pictureBox6, b);
            
            string d = "3 категория\n более 0, но менее или равно 10\n\n" +
                "2 категория\n более 10, но менее или равно 15\n\n" +
                "1 категория\n более 15";
            toolTip1.SetToolTip(pictureBox1, d);

            string f = "3 категория\n более 0, но менее или равно 10\n\n" +
                "2 категория\n более 10, но менее или равно 40\n\n" +
                "1 категория\n более 40";
            toolTip1.SetToolTip(pictureBox2, f);
            string a = "3 категория\n менее или равно 4, но более 2\n\n" +
            "2 категория\n менее или равно 2, но более 1\n\n" +
            "1 категория\n менее или равно 1";
            toolTip1.SetToolTip(pictureBox3, a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool boolean = true;
            boolean = comboBox1.SelectedItem == null ? false : boolean;
            boolean = comboBox2.SelectedItem == null ? false : boolean;
            boolean = comboBox3.SelectedItem == null ? false : boolean;
            boolean = comboBox4.SelectedItem == null ? false : boolean;


            if (boolean)
            {
                int[] choises = { comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex };
                int choise1 = max_znach(choises);
                int r = 0;

                string a1 = return_title(choise1);




                XDocument doc = XDocument.Load("database.xml");

                var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).First();

                buff.Element("gosznach").Attribute("value").Value = "true";
                buff.Element("gosznach").Attribute("gos_1").Value = a1;



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
