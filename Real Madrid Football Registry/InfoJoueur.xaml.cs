using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using MaLibrairieClass;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class infoJoueur : Window
    {
        private List<Joueur> jo = new List<Joueur>();
        private List<MatchBut>Mb = new List<MatchBut>();
        private List<MatchJouer> MJ = new List<MatchJouer>();
        private String name;
        public infoJoueur(string n)
        {
            
            name = n;
            InitializeComponent();
            if (File.Exists(@"..\..\..\..\Fichier\ListJoueur.xml"))
            {
                loadJoueur();
            }

            if (File.Exists(@"..\..\..\..\Fichier\MatchBut.xml"))
            {
                loadButeur();
            }

            if(File.Exists(@"..\..\..\..\Fichier\MatchJouer.xml"))
            {
                loadMatchJouer();
            }

            setUi();

         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void loadJoueur()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Joueur>));
            StreamReader Rfile = new StreamReader(@"..\..\..\..\Fichier\ListJoueur.xml");
            jo = (List<Joueur>)Serializer.Deserialize(Rfile);
            Rfile.Close();
        }

        public void loadButeur()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(List<MatchBut>));
            StreamReader Rfile = new StreamReader(@"..\..\..\..\Fichier\MatchBut.xml");
            Mb = (List<MatchBut>)Serializer.Deserialize(Rfile);
            Rfile.Close();
        }

        public void loadMatchJouer()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(List<MatchJouer>));
            StreamReader Rfile = new StreamReader(@"..\..\..\..\Fichier\MatchJouer.xml");
            MJ = (List<MatchJouer>)Serializer.Deserialize(Rfile);   
            Rfile.Close();
        }

        public void setUi()
        {
            Joueur tmp = new Joueur();
            if(jo != null)
            {
                foreach (Joueur joueur in jo)
                {
                    if (name == joueur.ToString())
                        tmp = joueur;
                }
            }else
            {
                MessageBox.Show("Pas de fichier Joueur à lire !!!");
            }

            nom.Text = tmp.NOM;
            poste.Text = tmp.POSTE;
            DateTime dr = tmp.AGE;
            ddn.Text = dr.ToString("dd-MM-yyyy");
            numero.Text = tmp.NUMERO.ToString();

            if(Mb != null)
            {
                foreach (MatchBut matchBut in Mb)
                {
                    if (tmp.ToString() == matchBut.Joueur.ToString())
                        ListBut.Items.Add(matchBut.ToString());
                }
            }
            else
            {
                ListBut.Items.Add("Aucun but marquer :( ");
            }

            if (MJ != null)
            {
                foreach (MatchJouer matchJouer in MJ)
                {
                    if (tmp.ToString() == matchJouer.JOUEUR.ToString())
                        ListJoueur.Items.Add(matchJouer.ToString());
                }
            }
            else
                ListJoueur.Items.Add("Aucun match de jouer :(");

            nbbut.Text = ListBut.Items.Count.ToString();
        }
    }
}
