using MaLibrairieClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Repository;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace ViewModel
{
    [Serializable]
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<JoueurViewModel> joueurs = new ObservableCollection<JoueurViewModel>();
        ObservableCollection<MatchViewModel> matches = new ObservableCollection<MatchViewModel>();
        private MatchViewModel currentMatch;
        private JoueurViewModel currentJoueur;

        public ObservableCollection<JoueurViewModel> Joueurs
        {
            get => joueurs;
            set
            {
                joueurs = value;
                NotifyPropertyChanged(nameof(Joueurs));
            }
        }
        public ObservableCollection<MatchViewModel> Matches
        {
            get => matches;
            set
            {
                matches = value;
                NotifyPropertyChanged(nameof(Matches));
            }
        }
        public MatchViewModel CurrentMatch
        {
            get => currentMatch; 
            set
            {
                currentMatch = value;
                NotifyPropertyChanged(nameof(CurrentMatch));
            }
        }
        public JoueurViewModel CurrentJoueur { get => currentJoueur; 
            set
            {
                currentJoueur = value;
                NotifyPropertyChanged(nameof(currentJoueur));
            }
        }


        public void loadJoueur()
        {
            joueurs.Clear(); 
            List<Joueur> joueursList = new List<Joueur>();
            XmlSerializer writer = new XmlSerializer(typeof(List<Joueur>));


            var path = @"..\..\..\..\Fichier\ListJoueur.xml";

            if (File.Exists(path))
            {

                 StreamReader sr  = new StreamReader(path);
                 joueursList = (List<Joueur>)writer.Deserialize(sr);
                 sr.Close();

                foreach (Joueur jo in joueursList)
                {
                    joueurs.Add(new JoueurViewModel(jo));

                }
            }


        }

        public void LoadMatch()
        {
            matches.Clear();
            List<Match> MatchList = new List<Match>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Match>));
            if(File.Exists(@"..\..\..\..\Fichier\Match.xml"))
            {
                StreamReader file = new System.IO.StreamReader(@"..\..\..\..\Fichier\Match.xml");
                MatchList = (List<Match>)serializer.Deserialize(file);
                file.Close();

                foreach (Match match in MatchList)
                {
                    MatchViewModel matcheuse = new MatchViewModel(match);
                    Matches.Add(matcheuse);
                }
            }
           
        }

        public MainViewModel()
        {

            

            List<Joueur> joueursList = new List<Joueur>();

            List<But> Buteur = new List<But>();


         
         

            loadJoueur();

            LoadMatch();
        

        }
    }
}
