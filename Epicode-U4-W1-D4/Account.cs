using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Epicode_U4_W1_D4
{
    internal class Account
    {

        #region Paramethers
        public static bool Acceso { get; set; } = true;
        public static bool LoggedIn { get; set; } = false;
        private static List<Session> SessionList { get; set; } = new List<Session>();     
        
        #endregion

        #region Methods

        public static bool menu()
        {
            Console.WriteLine(string.Concat
            (
                "\n",
                "===============OPERAZIONI==============\n",
                "Scegli l’operazione da effettuare:\n",
                "1.: Login\n",
                "2.: Logout\n",
                "3.: Verifica ora e data di login\n",
                "4.: Lista degli accessi\n",
                "5.: Esci\n",
                "========================================"
            ));

            Console.Write("Scelta: ");
            int scelta;
            try { scelta = Int32.Parse(Console.ReadLine()); } 
            catch(Exception ex) { scelta = 0; }

            switch (scelta)
            {
                case 1:
                    login();
                    return true;
                case 2:
                    logout();
                    return true;
                case 3:
                    getLoginDate();
                    return true;
                case 4:
                    getSessionList();
                    return true;
                case 5:
                    Console.WriteLine("Chiusura in corso...");
                    return false;
                default:
                    Console.WriteLine("Inserire un valore valido!");
                    return true;
            }
        }

        public static void login()
        {
            if (LoggedIn)
                Console.WriteLine("Utente gia loggato");
            else
            {
                Console.Write("Inserisci l'username: ");
                string username = Console.ReadLine();
                Console.Write("\nInserisci la password:");
                string password = Console.ReadLine();

                if (User.Username == username && User.Password == password)
                {
                    LoggedIn = true;
                    SessionList.Add(new Session(User.Username));
                }
            }
        }
        public static void logout()
        {
            Console.WriteLine("Utente sloggato");
            LoggedIn = false;
        }

        #region Getter

        public static void getLoginDate()
        {
            if (LoggedIn)
                Console.WriteLine($"Ultimo login alle {SessionList[SessionList.Count - 1].Date}");
            else
                Console.WriteLine("Utente non loggato");
        }
        public static void getSessionList()
        {
            for (int i = 0; i < SessionList.Count; i++)
                Console.WriteLine($"{SessionList[i].Utente} - {SessionList[i].Date}");
        }

        #endregion


        #endregion

    }

    class Session
    {
        public string Utente { get; set; }
        public DateTime Date { get; set; }

        public Session(string username)
        {
            Utente = User.Username;
            Date = DateTime.Now;
        }
    }

    static class User
    {
        public static string Username { get; set; }
        public static string Password { get; set; }


    }
}
