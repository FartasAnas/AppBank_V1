using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX_TP;

namespace EX_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("Anas", "Fartas", "test add 1");
            Client c2 = new Client("Hajib", "Diae", "test add 2");

            CompteCourant cc = new CompteCourant(c1,new MAD(10000),new MAD(500));  
            CompteEpargne ce = new CompteEpargne(c2, new MAD(10000), 25);


            Console.WriteLine("-------------------------Les operation-------------------------------");
            Console.WriteLine("test crediter 500 a compte courant  :");
                cc.crediter(new MAD(500));
            Console.WriteLine("");
            Console.WriteLine("test debiter 9600 depuis compte courant  :");
                cc.debiter(new MAD(9600));
            Console.WriteLine("");
            Console.WriteLine("test ajouter interet a le compte epargne  :");
                ce.AjoutInteret();
            Console.WriteLine("");
            Console.WriteLine("test verser depuis compte epargne vers le compte courant:");
                ce.verser(cc, new MAD(1000));



            Console.WriteLine("------------------------------l'Affichage--------------------------");
            cc.consulter();
            Console.WriteLine("------------------------------------");
            ce.consulter();

            Console.ReadKey();
        }
    }
}