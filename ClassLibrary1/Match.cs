using System.Collections.ObjectModel;

namespace MaLibrairieClass
{
    [Serializable]
    public class Match
    {
        private string _nomMatch;
        private List<Joueur> _listeJoueur;
        private string _commentaire;
        private int _butEncaisse;
        private int _butMarque;
        private string _arbitre;
        private string _stade;
        private bool isWin;
        private List<But> _buteur;
        private DateTime _datematch;


        public Match()
        {
            this._nomMatch = null;
            this._listeJoueur = new List<Joueur>();
            this._buteur = new List<But>();

        }

        public Match(string nomMatch, List<Joueur> listeJoueur, List<But> listeButeur, string commentaire)
        {
            _nomMatch = nomMatch;
            _listeJoueur = listeJoueur;
            _buteur = listeButeur;
            _commentaire = commentaire;
        }

        public Match(string nomMatch, List<Joueur> listeJoueur, string commentaire  , int butEncaisse, int butMarque, string arbitre, string stade , List<But> buteur  , DateTime dt)
        {
            _nomMatch = nomMatch;
            _listeJoueur = listeJoueur;
            _commentaire = commentaire;
            _butEncaisse = butEncaisse;
            _butMarque = butMarque;
            _arbitre = arbitre;
            _stade = stade;
            _buteur = buteur;
            _datematch = dt;


        }
        public Match(string nomMatch, List<Joueur> listeJoueur, string commentaire
            , int butEncaisse, int butMarque, string arbitre, string stade = null, List<But> buteur = null)
        {
            _nomMatch = nomMatch;
            _listeJoueur = listeJoueur;
            _commentaire = commentaire;
            _butEncaisse = butEncaisse;
            _butMarque = butMarque;
            _arbitre = arbitre;
            _stade = stade;
            _buteur = buteur;
        }

        public Match(string nomMatch, List<Joueur> listeJoueur, string commentaire
            , int butEncaisse, int butMarque, string arbitre, string stade, List<But> buteur, bool isWin)
        {
            _nomMatch = nomMatch;
            _listeJoueur = listeJoueur;
            _commentaire = commentaire;
            _butEncaisse = butEncaisse;
            _butMarque = butMarque;
            this._arbitre = arbitre;
            this._stade = stade;
            this.Buteur = buteur;
            this.IsWin = isWin;
        }

        public string COMMENT
        {
            get { return _commentaire; }
            set { _commentaire = value; }
        }
      

        public List<Joueur> LISTEJOUEUR
        {
            get { return _listeJoueur; }
            set { _listeJoueur = value; }
        }


        public String NOMMATCH
        {
            get { return _nomMatch; }
            set { _nomMatch = value; }
        }

        public int BUTENCAISSE
        {
            get { return _butEncaisse; }
            set { _butEncaisse = value; }
        }

        public int BUTMARQUE { get => _butMarque; 
                               set => _butMarque = value; }

        public String ARBITRE
        {
            get => _arbitre;
            set { _arbitre = value; }    
        }

        public String STADE
        {
            get => _stade;   
            set { _stade = value; }
        }

        public List<But> Buteur { get => _buteur; set => _buteur = value; }
        public string Commentaire { get; }
        public List<Joueur> ListeButeur { get; }
        public bool IsWin { get => isWin; set => isWin = value; }
        public DateTime DateduMatch1 { get => _datematch; set => _datematch = value; }

        public override string ToString()
        {
            return "Real madrid " + BUTMARQUE + " - " + BUTENCAISSE + " " + NOMMATCH + " le : " + DateduMatch1.ToString("dd/MM/yyyy");

        }
    }
}