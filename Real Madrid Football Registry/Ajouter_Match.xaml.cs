using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using MaLibrairieClass;
using ViewModel;
using System.Xml.Serialization;



namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Ajouter_Match : Window
    {
        private MainViewModel MVM;
        private List<Joueur> joueursList = new List<Joueur>();
        private List<Joueur> joueursEquipe = new List<Joueur>();
        private List<But> Buteur = new List<But>();
        private List<Match> MatchList = new List<Match>();
        private Match ma = new Match();
        private List<MatchBut> lmb = new List<MatchBut>();
        private List<MatchJouer> MJ = new List<MatchJouer>();
        public Ajouter_Match( MainViewModel mvm)
        {
            MVM = mvm;
            InitializeComponent();

            loadJoueur();

            if(File.Exists(@"..\..\..\..\Fichier\Match.xml"))
            {
                loadMatch();
            }

            if(File.Exists(@"..\..\..\..\Fichier\MatchJouer.xml"))
            {
                loadMatchJouer();
            }

            if(File.Exists(@"..\..\..\..\Fichier\MatchBut.xml"))
            {
                loadButeur();
            }
          

       
          
        }

        private void loadJoueur()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Joueur>));

            var path = @"..\..\..\..\Fichier\ListJoueur.xml";

            if (File.Exists(path))
            {

                StreamReader file = new System.IO.StreamReader(path);
                joueursList = (List<Joueur>)writer.Deserialize(file);
                file.Close();
                selectionjoueur.SelectedIndex = 0;
                foreach (Joueur jo in joueursList)
                {
                    selectionjoueur.Items.Add(jo.ToString());
                }
            }
        }

        private void AjouterMatch(object sender , RoutedEventArgs e)
        {
            if(adversaire.Text == null || Stade.Text == null || Arbitre.Text == null || ddm.SelectedDate == null )
            {
                MessageBox.Show("Veuillez entrer le nom de l'equipe adverse ainsi que le stade svp ");
            }
            else
            {
                String nom = adversaire.Text;
                int butEncaisse = Int32.Parse(ButEncaisse.Text);
                DateTime ladate = (DateTime)ddm.SelectedDate;
             
                List<Joueur> joueurs = new List<Joueur>();
                List<But> LesButeur = new List<But>();

                if(equipe.Items.Count < 11)
                {
                    MessageBox.Show("Il faut minimum 11 joueurs dans l'equipe pour rajouter un match");
                }
                else
                {
                   // public Match(string nomMatch, List<Joueur> listeJoueur, string commentaire  , int butEncaisse, int butMarque, string arbitre, string stade = null, List<But> buteur = null)
                    if (Comment.Text == "")
                    {
                         ma = new Match(nom, joueursEquipe , "Aucun Commentaire"  , Int32.Parse(butEncaisse.ToString()), listeButeur.Items.Count , Arbitre.Text , Stade.Text, Buteur , ladate);
                    }
                    else
                    {
                         ma = new Match(nom, joueursEquipe, Comment.Text, Int32.Parse(butEncaisse.ToString()), listeButeur.Items.Count, Arbitre.Text, Stade.Text, Buteur , ladate);
                    }

                    Console.WriteLine(ma);

                 
                        if(SaveMatch())
                         {
                             saveMatchJouer(ladate);
                             SaveButeur(ladate);
                             majUi();
                         }


                }


            }
        }

        private void FermerFenêtre(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SupprimerButeur(object sender , RoutedEventArgs e)
        {
            if(listeButeur.SelectedItem.ToString() != null)
            {
                foreach (But bu in Buteur)
                {
                    if (bu.Buteur.ToString() == listeButeur.SelectedItem.ToString())
                        Buteur.Remove(bu);
                }
                listeButeur.Items.Remove(listeButeur.SelectedItem.ToString());
            }
            
            
        }

      
        private void SupprimerJoueur(object sender, RoutedEventArgs e)
        {
            if(equipe.SelectedItem.ToString() != null)
            {
                string jo = equipe.SelectedItem.ToString();

                equipe.Items.Remove(jo);
                selectionbu.Items.Remove(jo);

                selectionjoueur.Items.Add(jo);
                selectionjoueur.SelectedIndex = 0;

                foreach (Joueur jou in joueursList)
                {
                    if (jou.ToString() == jo)
                        joueursEquipe.Remove(jou);
                }
            }
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectionjoueur.SelectedItem == null)
            {
               MessageBox.Show("Pas de joueur selectionnable");
            }
            else
            {
                string jo = selectionjoueur.SelectedItem.ToString();
                equipe.Items.Add(jo);
                selectionjoueur.Items.Remove(jo);
                selectionbu.Items.Add(jo);
                foreach (Joueur jou in joueursList)
                {
                    if (jou.ToString() == jo)
                        joueursEquipe.Add(jou);
                }
                selectionjoueur.SelectedIndex = 0;
                selectionbu.SelectedIndex = 0;
            }
          

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(minute.Text != " " && selectionbu.SelectedItem.ToString() != null)
            {
                
                Joueur jo = new Joueur();

                foreach (Joueur joueur in joueursList)
                {
                    if (selectionbu.SelectedItem.ToString() == joueur.ToString())
                        jo = joueur;
                }

                But bu = new But(jo, Int32.Parse(minute.Text));

                Buteur.Add(bu);
                listeButeur.Items.Add((string)selectionbu.SelectedItem);

                minute.Text = "";
            }
            else
            {
                MessageBox.Show("Veuillez entrer une minute pour le goal");

            }
         
        }

        public bool SaveMatch()
        {
            bool ok = false;
            foreach(Match match in MatchList)
            {
                if(estLeMeme(match , ma))
                {
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Match>));
                MatchList.Add(ma);
                StreamWriter streamWriter = new StreamWriter(@"..\..\..\..\Fichier\Match.xml");
                serializer.Serialize(streamWriter, MatchList);
                streamWriter.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Match deja existant ");
                return false;
            }
         
        }

        public bool estLeMeme(Match m1 , Match m2)
        {
            if (m1.DateduMatch1 == m2.DateduMatch1 && m1.NOMMATCH == m2.NOMMATCH)
                return true;
            else return false;
        }

        public void SaveButeur(DateTime ladate)
        {
            XmlSerializer serializerMB = new XmlSerializer(typeof(List<MatchBut>));
           
            foreach (But bu in Buteur)
            {
                foreach (Joueur jo in joueursList)
                {
                    if (bu.Buteur == jo)
                    {

                        MatchBut mb = new MatchBut(ma, bu.Buteur, bu.Minute, ladate);
                        lmb.Add(mb);

                    }

                }
                StreamWriter sw = new StreamWriter(@"..\..\..\..\Fichier\MatchBut.xml");

                serializerMB.Serialize(sw, lmb);
                sw.Close();
            }
          
        }


        public void saveMatchJouer(DateTime ladate)
        {
            XmlSerializer serializerMB = new XmlSerializer(typeof(List<MatchJouer>));

            foreach (Joueur jo in joueursEquipe)
            {
                MatchJouer mj = new MatchJouer(ma, jo, ladate);
                MJ.Add(mj);
            }
            StreamWriter sw = new StreamWriter(@"..\..\..\..\Fichier\MatchJouer.xml");

            serializerMB.Serialize(sw, MJ);
            sw.Close();
        }

        public void loadMatch()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Match>));
            StreamReader file = new System.IO.StreamReader(@"..\..\..\..\Fichier\Match.xml");
            MatchList = (List<Match>)serializer.Deserialize(file);
        }
        public void loadMatchJouer()
        {
            XmlSerializer serializerMB = new XmlSerializer(typeof(List<MatchJouer>));
            StreamReader sr = new StreamReader(@"..\..\..\..\Fichier\MatchJouer.xml");
            MJ = (List<MatchJouer>)serializerMB.Deserialize(sr);
            sr.Close();
        }

        public void loadButeur()
        {
            XmlSerializer serializerMB = new XmlSerializer(typeof(List<MatchBut>));
            StreamReader sr = new StreamReader(@"..\..\..\..\Fichier\MatchBut.xml");
            lmb = (List<MatchBut>)serializerMB.Deserialize(sr);
            sr.Close();
        }


        public void majUi()
        {
            Stade.Text = "";
            Arbitre.Text = "";
            adversaire.Text = "";
            ButEncaisse.Text = "0";
            Comment.Text = "";
            selectionbu.Items.Clear();
            selectionjoueur.Items.Clear();
            equipe.Items.Clear();
            listeButeur.Items.Clear();
            loadJoueur();
            MVM.LoadMatch();
        }
    }
}
