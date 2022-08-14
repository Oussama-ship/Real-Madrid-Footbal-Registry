using MaLibrairieClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Repository
{
    public class JoueurViewModel : ViewModelBase
    {

        private List<Match> MatchMarque;

        public Joueur Content { get; }

        public JoueurViewModel()
        {
            Content = null;
        }

        public JoueurViewModel(Joueur content)
        {
            Content = content;
        }

        public JoueurViewModel(string nom, DateTime age, string poste, int numero)
        {
            Content = new Joueur(nom, age, poste, numero);
        }

        public JoueurViewModel(string nom, DateTime age, int nbBut, int nbCarteJaune, int nbCarteRouge, int nbCleanSheat, bool estUnGardien)
        {
            Content = new Joueur(nbBut , nbCarteJaune , nbCarteRouge , nbCleanSheat , estUnGardien);
        }

        public int NUMERO
        {
            get 
            { return Content.NUMERO; }
            set {
                    Content.NUMERO = value;
                    NotifyPropertyChanged(nameof(NUMERO));
            
                }
        }


        public string POSTE
        {
            get { return Content.POSTE; }
            set { 
                 Content.POSTE = value;
                 NotifyPropertyChanged(nameof(POSTE));
            }
        }

        public DateTime AGE
        {
            get { return Content.AGE; }
            set { 
                Content.AGE = value;
                NotifyPropertyChanged(nameof(AGE));
            }
        
        }

        public string NOM
        {
            get { return Content.NOM; }
            set {
                    Content.NOM = value;
                    NotifyPropertyChanged(nameof(NOM));
            }
        }

        public override string ToString()
        {
            return "Nom : " +  NOM   + " Age  : " + calculAge(AGE) + " ANS" + " Poste : "+  POSTE + " Numero :" + NUMERO;
        }

        public int calculAge( DateTime dt)
        {
          
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dt.Year * 100 + dt.Month) * 100 + dt.Day;

            return (a - b) / 10000;

        }

    }
}
