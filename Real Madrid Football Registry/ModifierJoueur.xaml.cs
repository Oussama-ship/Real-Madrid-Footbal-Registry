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
using ViewModel;
using MaLibrairieClass;
using System.Xml.Serialization;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ModifierJoueur : Window
    {
        private MainViewModel mainViewModel = new MainViewModel();
        private List<Joueur> joueur = new List<Joueur>();
        public ModifierJoueur(MainViewModel mvm)
        {
            mainViewModel = mvm;
            InitializeComponent();

            loadJoueur();

        }

        void loadJoueur()
        {
            if (File.Exists(@"..\..\..\..\Fichier\ListJoueur.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Joueur>));
                StreamReader file = new StreamReader(@"..\..\..\..\Fichier\ListJoueur.xml");
                joueur = (List<Joueur>)serializer.Deserialize(file);
                file.Close();

                foreach (Joueur j in joueur)
                {
                    selection.Items.Add(j.ToString());
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
           

            if(nom.Text == null || ddn.SelectedDate == null || poste.Text == null || numero.Text == null )
            {
                MessageBox.Show("Veuillez renseignez tout les champs svp");
            }
            else
            {

                modifJoueur();
                majUi();
             
            }
        }


        public void majUi()
        {
            mainViewModel.loadJoueur();

            selection.SelectedIndex = 0;

            nom.Text = "";
            ddn.SelectedDate = null;
            poste.Text = "";
            numero.Text = "";

            loadJoueur();
        }
       public void modifJoueur()
       {
            Joueur tmp = new Joueur();
            foreach (Joueur j in joueur)
            {
                if (j.ToString() == selection.SelectedItem.ToString())
                {
                    tmp = j;
                }
            }

            joueur.Remove(tmp);
            tmp.NOM = nom.Text;
            tmp.AGE = (DateTime)ddn.SelectedDate;
            tmp.POSTE = poste.Text;
            tmp.NUMERO = Int32.Parse(numero.Text);

            joueur.Add(tmp);


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Joueur>));
            StreamWriter SW = new StreamWriter(@"..\..\..\..\Fichier\ListJoueur.xml");
            xmlSerializer.Serialize(SW, joueur);
            SW.Close();
        }

        private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Joueur tmp = new Joueur();
            foreach (Joueur j in joueur)
            {
                if (j.ToString() == selection.SelectedItem.ToString())
                {
                    tmp = j;

                }

                nom.Text = tmp.NOM;

                poste.Text = tmp.POSTE;

                numero.Text = tmp.NUMERO.ToString();

                ddn.SelectedDate = tmp.AGE;

            }
        }
    }

}
