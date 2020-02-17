using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_MSP_Razvan2
{
    // clasa abstracta, interfata pentru crearea
    // tipurilor concrete de pizza
    public abstract class Pizza
    {
        public abstract string Denumire { get; }
        public abstract string Ingrediente { get; }
        public abstract int Cantitate { get; }
    }

    //implementarea tipurilor concrete de pizza
    public class Capriciosa : Pizza
    {
        private string denumire, ingrediente;
        private int cantitate;

        public Capriciosa()
        {
            denumire = "Capriciosa";
            ingrediente = "bacon, masline, mozarella, sos rosii, cascaval";
            cantitate = 500;
        }
        public override string Denumire
        {
            get { return denumire; }
        }

        public override string Ingrediente
        {
            get { return ingrediente; }
        }

        public override int Cantitate
        {
            get { return cantitate; }
        }
    }
    public class Quatro_Staggioni : Pizza
    {
        private string denumire, ingrediente;
        private int cantitate;

        public Quatro_Staggioni()
        {
            denumire = "Quatro Staggioni";
            ingrediente = "mozarella, sunca, salam, ciuperci, masline";
            cantitate = 610;
        }
        public override string Denumire
        {
            get { return denumire; }
        }

        public override string Ingrediente
        {
            get { return ingrediente; }
        }

        public override int Cantitate
        {
            get { return cantitate; }
        }
    }
    public class Hawai : Pizza
    {
        private string denumire, ingrediente;
        private int cantitate;

        public Hawai()
        {
            denumire = "Hawai";
            ingrediente = "ananas, mozarella, sunca, masline, oregano, rosii";
            cantitate = 400;
        }
        public override string Denumire
        {
            get { return denumire; }
        }

        public override string Ingrediente
        {
            get { return ingrediente; }
        }

        public override int Cantitate
        {
            get { return cantitate; }
        }
    }
    public class Carnivora : Pizza
    {
        private string denumire, ingrediente;
        private int cantitate;

        public Carnivora()
        {
            denumire = "Carnivora";
            ingrediente = "mozarella, salam, sunca, masline, ardei, bacon, carnati";
            cantitate = 700;
        }
        public override string Denumire
        {
            get { return denumire; }
        }

        public override string Ingrediente
        {
            get { return ingrediente; }
        }

        public override int Cantitate
        {
            get { return cantitate; }
        }
    }

    //clasa care implementeaza magazinul (folosim Singleton)
    public class Magazin
    {
        private static Magazin instanta = null;
        private Magazin() { }
        public static Magazin GetInstance
        {
            get
            {
                if (instanta == null)
                {
                    instanta = new Magazin();
                }
                return instanta;
            }
        }
        public Pizza Preparare(string Tip_Pizza)
        {
            switch (Tip_Pizza)
            {
                case "Capriciosa":
                    return new Capriciosa();
                case "Quatro Staggioni":
                    return new Quatro_Staggioni();
                case "Hawai":
                    return new Hawai();
                case "Carnivora":
                    return new Carnivora();
                default:
                    return new Carnivora();
            }
        }
    }

    //interfata pentru crearea strategiilor de oferte
    public abstract class Oferta
    {
        public abstract string Anunt { get; }
    }

    //ofertele concrete
    public class oferta_luni : Oferta
    {
        public string anunt = "1 pizza + 1 gratis";
        public override string Anunt
        {
            get { return anunt; }
        }
    }
    public class oferta_miercuri : Oferta
    {
        public string anunt = "2 capriciosa + 1 hawai gratis";
        public override string Anunt
        {
            get { return anunt; }
        }
    }
    public class oferta_joi : Oferta
    {
        public string anunt = "2 pizza + 1 gratis";
        public override string Anunt
        {
            get { return anunt; }
        }
    }
    public class oferta_duminica : Oferta
    {
        public string anunt = "1 pizza + 1 carnivora gratis";
        public override string Anunt
        {
            get { return anunt; }
        }
    }

    /* clasa care va selecta o anumita oferta, in functie de
    ziua saptamanii */
    public class Oferta_Azi
    {
        private DayOfWeek ziua = DateTime.Today.DayOfWeek;
        public Oferta oferta 
        { 
            get 
            {
                switch (ziua)
                {
                    case DayOfWeek.Monday:
                        return new oferta_luni();
                        break;
                    case DayOfWeek.Wednesday:
                        return new oferta_miercuri();
                        break;
                    case DayOfWeek.Tuesday:
                        return new oferta_joi();
                        break;
                    case DayOfWeek.Sunday:
                        return new oferta_duminica();
                        break;
                    default:
                        return null;
                }
            } 
        }
}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
