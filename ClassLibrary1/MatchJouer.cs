using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaLibrairieClass;

namespace MaLibrairieClass
{
    public class MatchJouer
    {
        private Match Match;
        private Joueur _joueur;
        DateTime _date;
        
        public MatchJouer()
        {
            Match = null;
            _joueur = null;
            Date = DateTime.MinValue;
        }

        public MatchJouer(Match ma , Joueur jo , DateTime dt)
        {
            Match = ma;    
            _joueur = jo;   
            Date = dt;
        }

        public  Joueur JOUEUR
        {
            get { return _joueur; }
            set { _joueur = value; }
        }


        public Match MATCH
        {
            get { return Match; }
            set { Match = value; }
        }

        public DateTime Date { get => _date; set => _date = value; }

        public override string ToString()
        {
            return Match.NOMMATCH + " le  : " + _date.ToString() ;
        }
    }
}
