using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaLibrairieClass;

namespace MaLibrairieClass
{
    [Serializable]
    public class But
    {
        Joueur buteur;
        int minute;

        public But()
        {
            buteur = null;
            minute = 0;
        }
        public But( Joueur jo  , int mi)
        {
            buteur = jo;    
            minute = mi;    
        }

        public Joueur Buteur { get => buteur; set => buteur = value; }
        public int Minute { get => minute; set => minute = value; }

        public override string ToString()
        {
            return buteur.ToString() + " " + minute.ToString();
        }
    }
}
