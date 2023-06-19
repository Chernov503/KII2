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

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        void Listbox_update() // обновляет список объектов
        {
            listBox1.Items.Clear();
            XDocument doc = XDocument.Load("database.xml");
            var buff = doc.Root.Elements("object").ToList();

            foreach (var el in buff)
            {
                listBox1.Items.Add(el.Attribute("serial_number").Value + " " + el.Attribute("name").Value);
            }
        }

        void info_window_update(string serial_number) // Обновляет список характеристик выбранного объекта
        {

            XDocument doc = XDocument.Load("database.xml");

            var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).First()
                .Elements().ToList();

            label11.Text = buff[0].Attribute("soc_1").Value;    label11.Text = label11.Text == "" ? "Категория не присвоена" : label11.Text;
            label12.Text = buff[1].Attribute("polit_1").Value;  label12.Text = label12.Text == "" ? "Категория не присвоена" : label12.Text;
            label13.Text = buff[2].Attribute("econom_1").Value; label13.Text = label13.Text == "" ? "Категория не присвоена" : label13.Text;
            label14.Text = buff[3].Attribute("ecolog_1").Value; label14.Text = label14.Text == "" ? "Категория не присвоена" : label14.Text;
            label15.Text = buff[4].Attribute("gos_1").Value;    label15.Text = label15.Text == "" ? "Категория не присвоена" : label15.Text;

        }

        bool serial_number_check(string serial_number) // Проверяет существует ли уже такой ИД в базе
        {
            bool result = false;

            XDocument doc = XDocument.Load("database.xml");
            var buff = doc.Root.Elements("object").Where(x => x.Attribute("serial_number").Value == serial_number).ToList();
            result = buff.Count() > 0 ? false : true;

            return result;
        }

        void Object_create(string name, string adress, string naznachenie, string serial_number) // создает элемент объекта в базе .xml
        {
            bool C_signal = serial_number_check(serial_number);
            if (!C_signal) { MessageBox.Show("Объект с таким идентификационным номером уже существует", "Ошибка"); }
            else
            {

                XDocument doc = XDocument.Load("database.xml");



                XElement object_ = new XElement("object"); doc.Root.Add(object_);

                XAttribute name_ = new XAttribute("name", name); object_.Add(name_);
                XAttribute adress_ = new XAttribute("adress", adress); object_.Add(adress_);
                XAttribute naznachenie_ = new XAttribute("naznachenie", naznachenie); object_.Add(naznachenie_);
                XAttribute serial_number_ = new XAttribute("serial_number", serial_number); object_.Add(serial_number_);

                XElement soc_ = new XElement("socznach"); object_.Add(soc_);
                XAttribute soc_value_ = new XAttribute("value", "false"); soc_.Add(soc_value_);
                XAttribute soc_title = new XAttribute("title", "Социальная значимость"); soc_.Add(soc_title);
                XAttribute soc_1_ = new XAttribute("soc_1", ""); soc_.Add(soc_1_);


                XElement polit_ = new XElement("politznach"); object_.Add(polit_);
                XAttribute polit_title = new XAttribute("title", "Политическая значимость"); polit_.Add(polit_title);
                XAttribute polit_value_ = new XAttribute("value", "false"); polit_.Add(polit_value_);
                XAttribute polit_1_ = new XAttribute("polit_1", ""); polit_.Add(polit_1_);

                XElement econom_ = new XElement("economznach"); object_.Add(econom_);
                XAttribute econom_title = new XAttribute("title", "Экономическая значимость"); econom_.Add(econom_title);
                XAttribute econom_value_ = new XAttribute("value", "false"); econom_.Add(econom_value_);
                XAttribute econom_1_ = new XAttribute("econom_1", ""); econom_.Add(econom_1_);


                XElement ecolog_ = new XElement("ecologznach"); object_.Add(ecolog_);
                XAttribute ecolog_title = new XAttribute("title", "Экологическая значимость"); ecolog_.Add(ecolog_title);
                XAttribute ecolog_value_ = new XAttribute("value", "false"); ecolog_.Add(ecolog_value_);
                XAttribute ecolog_1_ = new XAttribute("ecolog_1", ""); ecolog_.Add(ecolog_1_);

                XElement gos_ = new XElement("gosznach"); object_.Add(gos_);
                XAttribute gos_title = new XAttribute("title", "Значимость для обеспечения обороны страны, безопасности государства и правопорядка"); gos_.Add(gos_title);
                XAttribute gos_value_ = new XAttribute("value", "false"); gos_.Add(gos_value_);
                XAttribute gos_1_ = new XAttribute("gos_1", ""); gos_.Add(gos_1_);


                doc.Save("database.xml");


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button3.Enabled = true;
                panel1.Enabled = true;



            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button3.Enabled = false;
                panel1.Enabled = false;

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int choise = 0;
                choise = checkBox1.Checked ? 1 : choise;
                choise = checkBox2.Checked ? 2 : choise;
                choise = checkBox3.Checked ? 3 : choise;
                choise = checkBox4.Checked ? 4 : choise;
                choise = checkBox5.Checked ? 5 : choise;

                XDocument doc = XDocument.Load("database.xml");

                var id_ = listBox1.SelectedItem.ToString().Split(' ');
                string serial_number = id_[0];



                switch (choise)
                {
                    case 1:
                        {
                            Soc_znach Soc_znach = new Soc_znach(serial_number);
                            Soc_znach.Show();
                            this.Hide();

                            break;
                        }
                    case 2:
                        {
                            Polit_znach Polit_znach = new Polit_znach(serial_number);
                            Polit_znach.Show();
                            this.Hide();
                            break;
                        }
                    case 3:
                        {
                            Econom_znach Econom_znach = new Econom_znach(serial_number);
                            Econom_znach.Show();
                            this.Hide();
                            break;
                        }
                    case 4:
                        {
                            Ecolog_znach Ecolog_znach = new Ecolog_znach(serial_number);
                            Ecolog_znach.Show();
                            this.Hide();
                            break;
                        }
                    case 5:
                        {
                            Gos_znach Gos_znach = new Gos_znach(serial_number);
                            Gos_znach.Show();
                            this.Hide();
                            break;
                        }

                }

            }
            catch { MessageBox.Show("Необходимо выбрать строку в списке оборудования", "Ошибка"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            XDocument doc = XDocument.Load("database.xml");

            Listbox_update();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button3.Enabled = false;
            panel1.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool boolean = textBox4.Text.Contains(' ') ? false : true;
            if (boolean == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    Object_create(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    Listbox_update();
                }
                else { MessageBox.Show("Заполните все поля", "Ошибка"); }
            }
            else { MessageBox.Show("Поле серийного номера должно быть заполнено без пробелов", "Ошибка"); }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XDocument doc = XDocument.Load("database.xml");

                var id_ = listBox1.SelectedItem.ToString().Split(' ');
                string id = id_[0];
                info_window_update(id);
                textBox6.Text = "Адрес: " + doc.Root.Elements("object").First(x => x.Attribute("serial_number").Value == id).Attribute("adress").Value;
                textBox6.Text += Environment.NewLine + Environment.NewLine + "Назначение: " + doc.Root.Elements("object").First(x => x.Attribute("serial_number").Value == id).Attribute("naznachenie").Value;


                panel2.Enabled = false;
                panel3.Enabled = false;
            }
            catch { listBox1.SelectedItem = null;
                panel2.Enabled = true;
                panel3.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            panel3.Enabled = true;
            Listbox_update();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                var buff = listBox1.Items[i].ToString().Split(' ');
                if (buff[0] == textBox5.Text) { listBox1.SelectedIndex = i; }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Вы действительно хотите удалить запись?",
           "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                var id_ = listBox1.SelectedItem.ToString().Split(' ');
                string serial_number = id_[0];

                XDocument doc = XDocument.Load("database.xml");
                if (listBox1.SelectedItem != null)
                {

                    var object_ = doc.Root.Elements("object").First(x => x.Attribute("serial_number").Value == serial_number);
                    object_.Remove();
                    doc.Save("database.xml");
                    Listbox_update();
                }
                else
                {
                    MessageBox.Show("вы не выбрали запись");
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
