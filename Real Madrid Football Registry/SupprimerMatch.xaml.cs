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
using MaLibrairieClass;
using System.Xml.Serialization;
using System.IO;
using ViewModel;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SupprimerMatch : Window
    {
        private List<Match> MatchList = new List<Match>();
        private List<MatchBut> MB = new List<MatchBut>();
        private List<MatchJouer> MJ = new List<MatchJouer>();
        private MainViewModel MVM;
        public SupprimerMatch(MainViewModel mvvm)
        {
            InitializeComponent();
            MVM = mvvm;
            loadMatch();
            loadButeur();
            loadMatchJouer();
        }

        public void loadMatch()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Match>));
            StreamReader file = new System.IO.StreamReader(@"..\..\..\..\Fichier\Match.xml");
            MatchList = (List<Match>)serializer.Deserialize(file);

            foreach(Match ma in MatchList)
            {
                ListeMatch.Items.Add(ma.ToString());
            }

            ListeMatch.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            supprimerMatch();

            MVM.LoadMatch();
        }

        public void supprimerMatch()
        {
            string todelete = ListeMatch.SelectedItem.ToString();
            Match cible = new Match();
            List<MatchJouer> MJCIBLE = new List<MatchJouer>();
            List<MatchBut> matchbutcible = new List<MatchBut>();
            foreach (Match match in MatchList)
            {
                if (match.ToString() == todelete)
                {

                    cible = match;
                }
            }

            if(MB.Count > 0)
            {
                foreach(MatchBut matchBut in MB)
                {
                    if(cible.ToString() == matchBut.Match.ToString())
                    {
                        matchbutcible.Add(matchBut);
                    }
                }
                
                foreach(MatchBut matchBut in matchbutcible)
                {
                    MB.Remove(matchBut);
                }
                XmlSerializer recmatchbut = new XmlSerializer(typeof(List<MatchBut>));
                StreamWriter SW = new StreamWriter(@"..\..\..\..\Fichier\MatchBut.xml");
                recmatchbut.Serialize(SW, MB);
                SW.Close();

            }

            foreach(MatchJouer matchJouer in MJ)
            {
                if(matchJouer.MATCH.ToString() == cible.ToString())
                {
                    MJCIBLE.Add(matchJouer);
                }

            }

            foreach(MatchJouer matchJouer1 in MJCIBLE)
            {
                MJ.Remove(matchJouer1);
            }

            XmlSerializer recmatchjouer = new XmlSerializer(typeof(List<MatchJouer>));
            StreamWriter SWR = new StreamWriter(@"..\..\..\..\Fichier\MatchJouer.xml");
            recmatchjouer.Serialize(SWR, MJ);
            SWR.Close();



            MatchList.Remove(cible);

            XmlSerializer Serializer = new XmlSerializer(typeof(List<Match>));

            StreamWriter wr = new StreamWriter(@"..\..\..\..\Fichier\Match.xml");


            Serializer.Serialize(wr, MatchList);

            wr.Close();


            ListeMatch.Items.Remove(todelete);
            ListeMatch.SelectedIndex = 0;

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
            MB = (List<MatchBut>)serializerMB.Deserialize(sr);
            sr.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
