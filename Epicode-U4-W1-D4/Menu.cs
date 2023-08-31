using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Epicode_U4_W1_D4
{
    internal class Menu
    {

        public static bool acceso = true;
        public static List<Prodotto> ProdottiList {get; set;} = new List<Prodotto>();
        private static List<Prodotto> Conto { get; set; } = new List<Prodotto>();

        public static void menu()
        {

            //Costruzione del menu
            Console.WriteLine("================== MENU ================\n");
            for (int i = 0; i < ProdottiList.Count; i++)
                Console.WriteLine($"{i + 1}:  {ProdottiList[i].Nome} ({String.Format("{0:C}", ProdottiList[i].Prezzo.ToString())})");
            Console.WriteLine($"{ProdottiList.Count + 1}:  Conto");
            Console.WriteLine("========================================");
            Console.Write("Scelta: ");

            //Scelta del menu
            int scelta;
            try { scelta = Int32.Parse(Console.ReadLine()); }
            catch (Exception ex) { scelta = 0; }
            Console.WriteLine("");
            //Condizioni
            if (scelta == 0 || scelta > ProdottiList.Count + 1)
                Console.WriteLine("Inserire valore valido");
            else if (scelta == ProdottiList.Count + 1)
                getConto();
            else
                addToConto(scelta);
        }
        public static void getConto() 
        {
            double totale = 0;
            Console.WriteLine("\n\n\n================ PRODOTTI ==============\n");
            for (int i = 0; i < Conto.Count; i++)
            {
                Console.WriteLine($"{i + 1}:  {Conto[i].Nome} ({String.Format("{0:C}", Conto[i].Prezzo.ToString())})");
                totale += Conto[i].Prezzo;
            }
            Console.WriteLine($"\n Il tuo totale con servizio a tavolo e' {totale + 3}");
            Console.WriteLine("========================================");
            acceso = false;
        }
        public static void addToConto(int scelta) 
        {
            Conto.Add(ProdottiList[scelta-1]);
        }
    }

    class Prodotto
    {
        public string Nome { get; set; }
        public double Prezzo { get; set; }
        public Prodotto(string nome, double prezzo) 
        { 
            Nome = nome;
            Prezzo = prezzo;
        }
    }
}
