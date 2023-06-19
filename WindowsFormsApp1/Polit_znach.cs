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
    public partial class Polit_znach : Form
    {
        string serial_number;
        public Polit_znach(string id)
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

        private void Polit_znach_Load(object sender, EventArgs e)
        {
            string a = "3 категория\n прекращение или нарушение функционирования органа государственной \nвласти субъекта Российской Федерации или города федерального значения\n\n" +
                "2 категория\n прекращение или нарушение функционирования федерального органа \nгосударственной власти\n\n" +
                "1 категория\n прекращение или нарушение функционирования Администрации Президента Российской Федерации,\n Правительства Российской Федерации, Федерального \nСобрания Российской Федерации, Совета Безопасности Российской Федерации, \nВерховного Суда Российской Федерации, Конституционного Суда Российской Федерации";
            toolTip1.SetToolTip(pictureBox1, a);
            string b = "3 категория\n нарушение условий договора межведомственного \nхарактера (срыв переговоров или подписания)\n\n" +
                "2 категория\n нарушение условий межправительственного договора \n(срыв переговоров или подписания)\n\n" +
                "1 категория\n нарушение условий межгосударственного договора \n(срыв переговоров или подписания)";
            toolTip1.SetToolTip(pictureBox2, b);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool boolean = true;
            boolean = comboBox1.SelectedItem == null ? false : boolean;
            boolean = comboBox2.SelectedItem == null ? false : boolean;


            if (boolean)
            {
                int[] choises = { comboBox1.SelectedIndex, comboBox2.SelectedIndex };
                int choise1 = max_znach(choises);


                string a1 = return_title(choise1);
 


                XDocument doc = XDocument.Load("database.xml");

                var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).First();

                buff.Element("politznach").Attribute("value").Value = "true";
                buff.Element("politznach").Attribute("polit_1").Value = a1;



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

