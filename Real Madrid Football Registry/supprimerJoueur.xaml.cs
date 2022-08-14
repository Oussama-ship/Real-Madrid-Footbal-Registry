using MaLibrairieClass;
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
using ViewModel;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SupprimerJoueur : Window
    {

        private MainViewModel mvm;
        private List<Joueur> tmp = new List<Joueur>();
        public SupprimerJoueur(MainViewModel M)
        {
            
            InitializeComponent();
            LoadFile();
            mvm = M;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            supprimerJoueur();
             mvm.loadJoueur();

        }

       private void LoadFile()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Joueur>));
            if (File.Exists(@"..\..\..\..\Fichier\ListJoueur.xml"))
            {
                StreamReader Rfile = new StreamReader(@"..\..\..\..\Fichier\ListJoueur.xml");
                tmp = (List<Joueur>)Serializer.Deserialize(Rfile);
                Rfile.Close();

                foreach (Joueur joueur in tmp)
                {

                    ListeJo.Items.Add(joueur.ToString());
                }

                ListeJo.SelectedIndex = 0;
            }
            else
            {
                ListeJo.Items.Add("Aucun joueur dispo");
            }
        }

        public void supprimerJoueur()
        {
            string todelete = ListeJo.SelectedItem.ToString();
            Joueur cible = new Joueur();
            foreach (Joueur joueur in tmp)
            {
                if (joueur.ToString() == todelete)
                {

                    cible = joueur;
                }
            }

            tmp.Remove(cible);

            XmlSerializer Serializer = new XmlSerializer(typeof(List<Joueur>));

            StreamWriter wr = new StreamWriter(@"..\..\..\..\Fichier\ListJoueur.xml");


            Serializer.Serialize(wr, tmp);

            wr.Close();


            ListeJo.Items.Remove(todelete);
            ListeJo.SelectedIndex = 0;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
