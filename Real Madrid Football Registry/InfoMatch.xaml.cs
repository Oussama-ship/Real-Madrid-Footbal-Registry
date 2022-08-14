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
using System.IO;
using System.Xml.Serialization;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InfoMatch : Window
    {
        private String _nom;
        private  List<Match> MatchList = new List<Match>();
        public InfoMatch(string name)
        {
          
            InitializeComponent();
            LoadMatch();
            _nom = name;

            Match tmp = new Match();
          
            foreach(Match match in MatchList)
            {
                if(_nom == match.ToString())
                    tmp = match;
            }

            nom.Text = tmp.ToString();
            Console.Write(tmp.STADE);

            List<But> B = new List<But>();
            B = tmp.Buteur;

            foreach(But b in B)
            {
               listbu.Items.Add(b.ToString());
            }

            List<Joueur> lj = new List<Joueur>();
            lj = tmp.LISTEJOUEUR;
            foreach(Joueur joueur in lj)
            {
                listjo.Items.Add(joueur.ToString());
            }
            stade.Text = tmp.STADE;
            arbitre.Text = tmp.ARBITRE;
            if (tmp.COMMENT != null)
                comment.Text = tmp.COMMENT;
            else
                comment.Text = "Aucun commentaire ";



        }

        public void LoadMatch()
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Match>));
            if (File.Exists(@"..\..\..\..\Fichier\Match.xml"))
            {
                StreamReader file = new System.IO.StreamReader(@"..\..\..\..\Fichier\Match.xml");
                MatchList = (List<Match>)serializer.Deserialize(file);
                file.Close();
        
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
