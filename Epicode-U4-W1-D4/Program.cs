using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Epicode_U4_W1_D4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region ES. 0
            Menu.ProdottiList.Add(new Prodotto("Coca Cola 150 ml", 2.5));
            Menu.ProdottiList.Add(new Prodotto("Insalata di pollo", 5.20));
            Menu.ProdottiList.Add(new Prodotto("Pizza Margherita", 10.00));
            Menu.ProdottiList.Add(new Prodotto("Pizza 4 Formaggi", 12.00));
            Menu.ProdottiList.Add(new Prodotto("Pz patatine frittte", 3.50));
            Menu.ProdottiList.Add(new Prodotto("Insalata di riso", 8.00));


            while (Menu.acceso)
                Menu.menu();


            #endregion

            #region ES. 1

            User.Username = "alessio";
            User.Password = "password";

            while (Account.Acceso && !Menu.acceso)
                Account.Acceso = Account.menu();

            #endregion

        }
    }
}
