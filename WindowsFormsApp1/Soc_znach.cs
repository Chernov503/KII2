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
    public partial class Soc_znach : Form
    {
        string serial_number_;
        public Soc_znach(string serial_number)
        {
            InitializeComponent();
            serial_number_ = serial_number;
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

        private void Soc_znach_Load(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Hide();

            string a = "3 категория\n Более или равно 1, но менее или равно 50\n\n2 категория\n Более 50, но менее или равно 500\n\n1 категория\n Более 500";
            toolTip1.SetToolTip(pictureBox1, a);

            string b = "3 категория\n в пределах территории одного муниципального образования\n (численностью от 2 тыс. человек) или одной внутригородской\n территории города федерального значения\n" +
                "\n2 категория\n выход за пределы территории одного муниципального образования\n (численностью от 2 тыс. человек) или одной внутригородской\n территории города федерального значения,\n но не за пределы территории одного субъекта Российской Федерации\n или территории города федерального значения" +
                "\n\n1 категория\n выход за пределы территории одного субъекта Российской Федерации\n или территории города федерального значения";
            toolTip1.SetToolTip(pictureBox2, b);

            string c = "3 категория\n более или равно 2, но менее 1000\n\n2 категория\n более или равно 1000, но менее 5000\n\n1 категория\n более или равно 5000";
            toolTip1.SetToolTip(pictureBox3, c);

            string d = "3 категория\n в пределах территории одного муниципального образования (численностью от 2 тыс.человек)\n или одной внутригородской территории города федерального значения\n\n" +
                "2 категория\n выход за пределы территории одного муниципального образования (численностью от 2 тыс. человек)\n или одной внутригородской территории города федерального значения,\n но не за пределы территории одного субъекта Российской Федерации\n или территории города федерального значения\n\n" +
                "1 категория\n выход за пределы территории одного субъекта Российской Федерации или территории города\n федерального значения";
            toolTip1.SetToolTip(pictureBox4, d);

            string f = "3 категория\n более или равно 2, но менее 1000\n\n" +
                "2 категория\n более или равно 1000, но менее 5000\n\n" +
                "1 категория\n более или равно 5000";
            toolTip1.SetToolTip(pictureBox5, f);

            string g = "3 категория\n более или равно 3, но менее 1000\n\n" +
            "2 категория\n более или равно 1000, но менее 5000\n\n" +
            "1 категория\n более или равно 5000";
            toolTip1.SetToolTip(pictureBox6, g);

            string a1 = "3 категория\n менее или равно 24, но более 12\n\n" +
            "2 категория\n менее или равно 12, но более 6\n\n" +
            "1 категория\n менее или равно 6";
            toolTip1.SetToolTip(pictureBox7, a1);

            string a2 = "3 категория\n менее или равно 30\n\n" +
            "2 категория\n более 30, но менее или равно 70\n\n" +
            "1 категория\n более 70";
            toolTip1.SetToolTip(pictureBox8, a2);



        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool boolean = true;
            boolean = comboBox1.SelectedItem == null ? false : boolean;
            boolean = comboBox2.SelectedItem == null ? false : boolean;
            boolean = comboBox3.SelectedItem == null ? false : boolean;
            boolean = comboBox4.SelectedItem == null ? false : boolean;
            boolean = comboBox5.SelectedItem == null ? false : boolean;
            boolean = comboBox6.SelectedItem == null ? false : boolean;
            boolean = comboBox7.SelectedItem == null ? false : boolean;
            boolean = comboBox8.SelectedItem == null ? false : boolean;

            if (boolean)
            {
                int[] choises = { comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox3.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex, comboBox6.SelectedIndex, comboBox7.SelectedIndex, comboBox8.SelectedIndex };
                int choise1 = max_znach(choises);

                string a1 = return_title(choise1);
   


                XDocument doc = XDocument.Load("database.xml");

                var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number_).First();

                buff.Element("socznach").Attribute("value").Value = "true";
                buff.Element("socznach").Attribute("soc_1").Value = a1;


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
