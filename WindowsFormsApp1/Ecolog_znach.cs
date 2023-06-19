using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Ecolog_znach : Form
    {
        string serial_number;
        public Ecolog_znach(string id)
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

        private void Ecolog_znach_Load(object sender, EventArgs e)
        {
            string a = "3 категория\n в пределах территории одного муниципального образования (численностью от 2 тыс.чел.) \nили одной внутригородской территории города федерального значения, \nс выходом вредных воздействий за пределы территории субъекта \nкритической информационной инфраструктуры\n\n" +
                "2 категория\n выход за пределы территории одного муниципального образования (численностью от 2 тыс. чел.) \nили одной внутригородской территории города федерального значения, но не за пределы территории одного субъекта Российской Федерации \nили территории города федерального значения, с выходом вредных воздействий за \nпределы территории субъекта критической информационной инфраструктуры\n\n" +
                "1 категория\n выход за пределы территории одного субъекта Российской Федерации или территории города \nфедерального значения, с выходом вредных воздействий за пределы территории \nсубъекта критической информационной инфраструктуры";
            toolTip1.SetToolTip(pictureBox2, a);

            string c = "3 категория\n более или равно 2, но менее 1000\n\n" +
                "2 категория\n более или равно 1000, но менее 5000\n\n" +
                "1 категория\n более или равно 5000";
            toolTip1.SetToolTip(pictureBox3, c);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool boolean = true;

            boolean = comboBox2.SelectedItem == null ? false : boolean;
            boolean = comboBox3.SelectedItem == null ? false : boolean;


            if (boolean)
            {
                int[] choises = { comboBox2.SelectedIndex, comboBox3.SelectedIndex };
                int choise1 = max_znach(choises);


                string a1 = return_title(choise1);



                XDocument doc = XDocument.Load("database.xml");

                var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).First();

                buff.Element("ecologznach").Attribute("value").Value = "true";
                buff.Element("ecologznach").Attribute("ecolog_1").Value = a1;
 

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

