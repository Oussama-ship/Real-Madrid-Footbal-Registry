using MaLibrairieClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ViewModel.Repository
{
    public class MatchViewModel : ViewModelBase
    {
        private ObservableCollection<JoueurViewModel> _listeJoueur;
        private ObservableCollection<ButViewModel> _listeButeur;
        public Match Content { get; private set; }

        public ObservableCollection<JoueurViewModel> ListeJoueur { get => _listeJoueur; set => _listeJoueur = value; }
        public ObservableCollection<ButViewModel> Buteur { get => _listeButeur; set => _listeButeur = value; }

        public MatchViewModel(Match content)
        {
            Content = content;
            _listeJoueur = new ObservableCollection<JoueurViewModel>();
            _listeButeur = new ObservableCollection<ButViewModel>();

            foreach(var j in content.LISTEJOUEUR)
            {
                _listeJoueur.Add(new JoueurViewModel(j));
            }

            foreach (var j in content.Buteur)
            {
                _listeButeur.Add(new ButViewModel(j));
            }

        }

        public string COMMENT
        {
            get { return Content.COMMENT; }
            set { 
                    Content.COMMENT = value; 
                    NotifyPropertyChanged(Content.COMMENT);
                }
        }

        public string NOMMATCH
        {
            get { return Content.NOMMATCH; }
            set { Content.NOMMATCH = value; }
        }

        public int BUTENCAISSE
        {
            get { return Content.BUTENCAISSE; }
            set { 
                   Content.BUTENCAISSE = value; 
                   NotifyPropertyChanged(Content.BUTENCAISSE.ToString());
                }
        }

        public int BUTMARQUE
        {
            get => Content.BUTMARQUE;
            set
            {
                BUTMARQUE = value;
                NotifyPropertyChanged(Content.BUTMARQUE.ToString());
            }

        }
      
        public string ARBITRE
        {
            get => Content.ARBITRE;
            set { 
                
                Content.ARBITRE = value;
                NotifyPropertyChanged(Content.ARBITRE.ToString());


            }
        }

        public string STADE
        {
            get => Content.STADE;
            set { Content.STADE = value;
                NotifyPropertyChanged(Content.STADE.ToString());
            }
        }

        public DateTime DateduMatch1 { get => Content.DateduMatch1; set
            { 
                Content.DateduMatch1 = value;
                NotifyPropertyChanged(nameof(Content.DateduMatch1.ToString));
           
            }
        }

        public bool IsWin { get => Content.IsWin; set => Content.IsWin = value; }

        public override string ToString()
        {
            return "Real madrid " + BUTMARQUE + " - " + BUTENCAISSE + " " + NOMMATCH + " le : " + DateduMatch1.ToString("dd/MM/yyyy");

        }
    }
}