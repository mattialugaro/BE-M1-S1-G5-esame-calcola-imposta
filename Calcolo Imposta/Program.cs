using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcolo_Imposta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // soluzione per stampare il simbolo Euro
            Contribuente contribuente = new Contribuente();     
            contribuente.CreaContribuente();                    // metodo per creare nuovo contribuente
            contribuente.CalcoloImposta();                      // metodo per calcolare l'imposta da versare
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine("Contribuente: " + contribuente.Nome + " " + contribuente.Cognome);
            Console.WriteLine("Nato il: " + contribuente.DataNascita + " " + (contribuente.Sesso));
            Console.WriteLine("Residente a: " + contribuente.ComuneResidenza);
            Console.WriteLine("Codice fiscale: " + contribuente.CodiceFiscale);
            Console.WriteLine("Reddito dichiarato: " + contribuente.RedditoAnnuale);
            Console.WriteLine("Imposta da versare: \u20AC" + contribuente.Imposta);         // simbolo Euro \u20AC
            Console.ReadLine();
        }
    }
}
