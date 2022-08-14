using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaLibrairieClass;

namespace MaLibrairieClass
{
    [Serializable]
    public class MatchBut
    {
        private Match _match;
        private Joueur _joueur;
        private DateTime _dateBut;
     
        private int _minute;

        public MatchBut()
        {
            _match = null;
            _joueur = null;
            _minute = 0;
        }

        public MatchBut(Match ma , Joueur  j , int mi , DateTime bu)
        {
             _match= ma;
             _joueur= j;
            _minute = mi;
            _dateBut = bu;
        }

        public int MINUTE
        {
            get { return _minute; }
            set { _minute = value; }
        }



        public override string ToString()
        {
            return _match.NOMMATCH + " " + "But Marquer a la " + _minute.ToString() + "eme miniutes" + "  Le " + _dateBut.ToString("dd/MM/yyyy");
        }


        public Match Match { get => _match; set => _match = value; }
        public Joueur Joueur { get => _joueur; set => _joueur = value; }
        public DateTime DateBut { get => _dateBut; set => _dateBut = value; }
    }
}
