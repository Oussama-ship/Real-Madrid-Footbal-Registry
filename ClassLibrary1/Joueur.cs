using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaLibrairieClass
{
    public class Joueur 
    {

        private String _nom;
        private DateTime _age;
        private string _poste;
        private int _numero;
        private int _nbBut;
        private int _NbCarteJaune;
        private int _NbCarteRouge;
        private int _NbCleanSheat;
        private bool _estUnGardien = false;
   
        private int nbBut;
        private int nbCarteJaune;
        private int nbCarteRouge;
        private int nbCleanSheat;
        private bool estUnGardien;

     
        public Joueur()
        {
            _nom = null;
            _age = new DateTime(); 
            _poste = null;
            nbBut = 0;
            nbCarteJaune = 0;
            _numero = 0;


        }

        public Joueur(String nom , DateTime age, string poste, int numero)
        {
            _nom = nom;
            _age = age;
            _poste = poste;
            this._numero = numero;
           
        }

        public Joueur(int nbBut, int nbCarteJaune, int nbCarteRouge, int nbCleanSheat, bool estUnGardien)
        {
            this.NbBut1 = nbBut;
            this.NbCarteJaune1 = nbCarteJaune;
            this.NbCarteRouge1 = nbCarteRouge;
            this.NbCleanSheat1 = nbCleanSheat;
            this.EstUnGardien1 = estUnGardien;
        }



        public int NUMERO
        {
            get { return _numero; }
            set { _numero = value; }
        }


        public string POSTE
        {
            get { return _poste; }
            set { _poste = value; }
        }

        public DateTime AGE
        {
            get { return _age; }
            set { _age = value; }
        }

        public String NOM
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int calculAge(DateTime dt)
        {

            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dt.Year * 100 + dt.Month) * 100 + dt.Day;

            return (a - b) / 10000;

        }

        public override string ToString()
        {
            return "Nom : " + NOM + " Age  : " + calculAge(AGE) + " ANS" + " Poste : " + POSTE + " Numero :" + NUMERO;
        }

     


        public int NbBut { get => _nbBut; set => _nbBut = value; }
        public int NbCarteJaune { get => _NbCarteJaune; set => _NbCarteJaune = value; }
        public int NbCarteRouge { get => _NbCarteRouge; set => _NbCarteRouge = value; }
        public int NbCleanSheat { get => _NbCleanSheat; set => _NbCleanSheat = value; }
        public bool EstUnGardien { get => _estUnGardien; set => _estUnGardien = value; }
      
        public int NbBut1 { get => nbBut; set => nbBut = value; }
        public int NbCarteJaune1 { get => nbCarteJaune; set => nbCarteJaune = value; }
        public int NbCarteRouge1 { get => nbCarteRouge; set => nbCarteRouge = value; }
        public int NbCleanSheat1 { get => nbCleanSheat; set => nbCleanSheat = value; }
        public bool EstUnGardien1 { get => estUnGardien; set => estUnGardien = value; }
    }
}
