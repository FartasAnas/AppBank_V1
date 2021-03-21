using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX_TP
{
    abstract class Compt
    {
        protected readonly int NumComp;
        protected static int cpt=0;
        protected readonly Client titulaire;
        protected MAD sold;
        protected static MAD plafond=new MAD(99999);
        protected string typeCompt;
        protected Operation[] opts = new Operation[0];
        protected DateTime dateO = DateTime.Now;
        protected DateTime dateE = DateTime.Now.AddDays(5);

        public Compt(Client c,MAD v)
        {
            this.NumComp = ++Compt.cpt;
            this.titulaire=c;
            this.sold = v;
            this.typeCompt = "Normal";
        }
        public virtual bool crediter(MAD somme)
        {
            if (somme > 0)
            {
                sold += somme;
                Console.WriteLine("New solde de crediteur:"+ sold.afficherMAD());        
                Array.Resize(ref opts, opts.Length + 1);
                opts[opts.Length - 1] = new Operation("crediter", somme);
                return true;
            }
            else
            {
                Console.WriteLine("la somme est negative");
            }
            return false;
        }
        public virtual bool debiter(MAD somme)
        {

            if (somme > 0)
            {
                if (somme < plafond)
                {
                    if (sold > somme)
                    {
                        sold -= somme;
                        Console.WriteLine("New solde de debiteur:"+ sold.afficherMAD());
                        Array.Resize(ref opts, opts.Length + 1);
                        opts[opts.Length - 1] = new Operation("debiter", somme);
                        return true;
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
        public virtual bool verser(Compt c,MAD somme)
        {
            if (this.debiter(somme) == true)
            {
                if (c.crediter(somme) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual void consulter()
        {
            titulaire.affiche();
            Console.WriteLine("Date de d'ouverture  :" + dateO.ToString());
            Console.WriteLine("Date de d'expiration :" + dateO.ToString());
            Console.WriteLine("Num Compte           :"+this.NumComp);
            Console.WriteLine("plafond              :" + plafond.afficherMAD());
            Console.WriteLine("sold                 :" + sold.afficherMAD());
            Console.WriteLine("type de compte       :"+ this.typeCompt);
            Console.WriteLine("Les operations       :");
            for (int i=0;i<opts.Length;i++)
            {
                opts[i].afficherOP();
            }
        }

    }
}
