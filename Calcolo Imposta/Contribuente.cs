using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolo_Imposta
{
    public class Contribuente
    { 
        private string nome;
        private string cognome;
        private string dataNascita;
        private string codiceFiscale;
        private string sesso;
        private string comuneResidenza;
        private double redditoAnnuale;
        private double imposta;
        private string redAnn;

        public string Nome { get; set; }
        public string Cognome { get; set;}
        public string DataNascita { get; set;}
        public string CodiceFiscale { get; set;}
        public string Sesso { get; set;}
        public string ComuneResidenza {  get; set;}
        public double RedditoAnnuale { get; set;}
        public double Imposta { get; set;}
        public string RedAnn { get; set;}


        public Contribuente(string nome, string cognome, string dataNascita, string codiceFiscale, string sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public Contribuente() { }

        public void CreaContribuente()      // metodo per creare un nuovo contribuente
        {
            Console.WriteLine("Inserisci i seguienti dati per calcolare l'imposta da versare:");
            
            Console.WriteLine("Inserisci nome: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Inserisci cognome: ");
            Cognome = Console.ReadLine();


            do     // Ciclo per controllare che la data sia scritta in questo formato (dd/mm/yyyy)
            {
                Console.WriteLine("Inserisci data di nascita: (dd/mm/yyyy)");
                DataNascita = Console.ReadLine();
            }
            while (CheckDataDiNascita());

            Console.WriteLine("Inserisci codice fiscale: ");
            CodiceFiscale = Console.ReadLine();

            do      // ciclo per controllate che l'utente inserisce una delle opzione di Sesso
            {
                Console.WriteLine("Inserisci il sesso (M/F):");
                Sesso = Console.ReadLine().ToUpper();

                if (Sesso != null && Sesso != "")
                {
                    if (Sesso != "M" && Sesso != "F")
                    {
                        Console.WriteLine("Scelta non valida, riprovare");
                    }
                }
                else
                {
                    Console.WriteLine("Scelta non valida, riprovare");
                }
            } while (Sesso != "M" && Sesso != "F");

            Console.WriteLine("Inserisci comune di residenza: ");
            ComuneResidenza = Console.ReadLine();

            do
            {
                Console.WriteLine("Inserisci reddito annuale: ");
                RedditoAnnuale = Convert.ToDouble(Console.ReadLine());
                
            }
            while (CheckReddito(RedAnn));
        }

        public bool CheckDataDiNascita()        // metodo per controllare che la data siua scritta in questo formato (dd/mm/yyyy)
        {
            string valori = "0123456789";
            if(DataNascita != null && DataNascita != "")
            {
                for (int i = 0;  i < DataNascita.Length;  i++)
                {
                    if (!DataNascita[i].ToString().Contains(valori) && !DataNascita[2].ToString().Contains("/") && !DataNascita[5].ToString().Contains("/"))
                    {
                        Console.WriteLine("Data di nascita non corretta, riprovare");
                        return true;
                    }
                }
                return false;
            }
            else
            {
                Console.WriteLine("Data di nascita non corretta, riprovare");
                return true;
            }
        }
        
        public bool CheckReddito(string RedAnn) // metodo per calcolare il reddito (da controllare incongruenze)
        {
            string valori = "0123456789";
            if (RedAnn != null && RedAnn != "")
            {
                for (int i = 0; i < RedAnn.Length; i++)
                {
                    if (!RedAnn[i].ToString().Contains(valori))
                    {
                        //Console.WriteLine("Reddito non corretto, riprovare");
                        return false;
                    }
                }
                RedditoAnnuale = Convert.ToDouble(RedAnn);
                return true;
            }
            else
            {
                //Console.WriteLine("Reddito non corretto, riprovare");
                return false;
            }

        }

        public void CalcoloImposta()    // metodo che calcola l'imposta da versare in base al reddito annuo
        {
            if(RedditoAnnuale > 0 && RedditoAnnuale <= 15000)
            {
                Imposta = RedditoAnnuale * 23 / 100;
            }
            else if(RedditoAnnuale >= 15001 && RedditoAnnuale <= 28000)
            {
                Imposta = 3450 + ((RedditoAnnuale - 15000) * 27 / 100);
            }
            else if (RedditoAnnuale >= 28001 && RedditoAnnuale <= 55000)
            {
                Imposta = 6960 + ((RedditoAnnuale - 28000) * 38 / 100);
            }
            else if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
            {
                Imposta = 17220 + ((RedditoAnnuale - 55000) * 41 / 100);
            }
            else if (RedditoAnnuale >= 75001)
            {
                Imposta = 25420 + ((RedditoAnnuale - 75000) * 43 / 100);
            }
            else
            {
                Console.WriteLine("Reddito annuale errato");
            }

        }

    }
}
