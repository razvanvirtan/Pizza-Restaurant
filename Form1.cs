using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_MSP_Razvan2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.SetSelected(0, true);

            Oferta_Azi oferta_azi;

            oferta_azi = new Oferta_Azi();
            textBox2.Text = "OFERTA ZILEI    " + oferta_azi.oferta.Anunt;
        }
        private void comanda_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Pizza pizza = null;
            switch(listBox1.SelectedItem.ToString())
            {
                case "Capriciosa":
                    pizza = Magazin.GetInstance.Preparare("Capriciosa");
                    break;
                case "Quatro staggioni":
                    pizza = Magazin.GetInstance.Preparare("Quatro staggioni");
                    break;
                case "Hawai":
                    pizza = Magazin.GetInstance.Preparare("Hawai");
                    break;
                case "Carnivora":
                    pizza = Magazin.GetInstance.Preparare("Carnivora");
                    break;
            }
            listBox2.Items.Insert(0, pizza.Denumire);
            listBox2.Items.Insert(1, pizza.Cantitate.ToString());
            listBox2.Items.Insert(2, pizza.Ingrediente);
        }
    }
}
