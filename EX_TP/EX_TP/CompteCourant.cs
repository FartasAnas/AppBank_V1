using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    class CompteCourant : Compt
    {
        private readonly MAD decouvert;
        public CompteCourant(Client c,MAD v,MAD d):base(c,v)
        {
            this.decouvert = d;
            this.typeCompt = "Courant";
        }
        public override bool debiter(MAD somme)
        {

            if (somme > 0)
            {
                if (somme < plafond)
                {
                    if (sold > somme)
                    {
                        if (this.sold - somme < this.decouvert)
                        {
                            sold -= somme;
                            Console.WriteLine("New solde de debiteur:" + sold.afficherMAD());
                            Array.Resize(ref opts, opts.Length + 1);
                            opts[opts.Length - 1] = new Operation("debiter", somme);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("solde-somme < decouvert");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("solde insufision");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("la somme est superior a le platform");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("la somme est negative");
                return false;
            }
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
            Console.WriteLine("decouvert            :" + this.decouvert.afficherMAD());
            Console.WriteLine("Les operations       :");
            for (int i = 0; i < opts.Length; i++)
            {
                opts[i].afficherOP();
            }
        }
    }
}
