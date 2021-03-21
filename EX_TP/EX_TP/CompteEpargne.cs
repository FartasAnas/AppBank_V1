using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class CompteEpargne : Compt
    {
        private readonly double TauxInteret;
        private Operation[] operation = new Operation[0];
        public CompteEpargne(Client c,MAD v,double T): base(c,v)
        {
            if (T >= 0 && T <= 100)
            {
                this.TauxInteret = T;
            }
            else
            {
                Console.WriteLine("Erruer la valeur est inferieur a 0 ou superieur a 100");
                this.TauxInteret = 0;
            }
            this.typeCompt = "Epargne";
        }
        public MAD calculInteret()
        {
            return this.sold * (new MAD(this.TauxInteret / 100));
        }
        public void AjoutInteret()
        {
            this.sold += this.calculInteret();
            Array.Resize(ref opts, opts.Length + 1);
            opts[opts.Length-1] = new Operation("Interet ", calculInteret());
            Console.WriteLine("New solde:" + this.sold.afficherMAD());
        }
        public override void consulter()
        {
            titulaire.affiche();
            Console.WriteLine("Date de d'ouverture  :" + dateO.ToString());
            Console.WriteLine("Date de d'expiration :" + dateO.ToString());
            Console.WriteLine("Num Compte           :" + this.NumComp);
            Console.WriteLine("plafond              :" + plafond.afficherMAD());
            Console.WriteLine("sold                 :" + sold.afficherMAD());
            Console.WriteLine("type de compte       :" + this.typeCompt);
            Console.WriteLine("Taux Interet         :" + this.TauxInteret+"%");
            Console.WriteLine("Interet              :" + calculInteret().afficherMAD());
            Console.WriteLine("Les operations       :");
            for (int i = 0; i < opts.Length; i++)
            {
                opts[i].afficherOP();
            }
        }
    }
}
