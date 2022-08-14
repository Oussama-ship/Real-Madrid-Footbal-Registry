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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaLibrairieClass;
using System.IO;
using System.Xml.Serialization;
using ViewModel;
using System.Text.RegularExpressions;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AjouterJoueur : Window
    {
        private MainViewModel mvm;
        private List<Joueur> tmp = new List<Joueur>();


        public AjouterJoueur(MainViewModel Mvm)
        {
            mvm = Mvm;
            if (File.Exists(@"..\..\..\..\Fichier\ListJoueur.xml"))
                loadJoueur();
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex rg = new Regex(@"\d");
         


            if (String.IsNullOrEmpty(nom.Text) || String.IsNullOrEmpty(poste.Text) || ddn.SelectedDate == null)
            {
                MessageBox.Show("Veuillez entrer tout les champs");
            }
            else
            {

                string nomjou = nom.Text;
                
                DateTime dat = (DateTime)ddn.SelectedDate;

                
                string po = poste.Text;

                if(rg.IsMatch(numero.Text))
                {
                    int num = Int32.Parse(numero.Text);
                  
                    saveJoueur(num);
                    nom.Text = "";
                    poste.Text = "";
                    ddn.SelectedDate = null;
                    numero.Text = "";
                    mvm.loadJoueur();
 
                
                }
                else
                {
                    MessageBox.Show("Le numero doit être un nombre !");
                }
                
          

            }
        }

        public void loadJoueur()
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(List<Joueur>));
            StreamReader Rfile = new StreamReader(@"..\..\..\..\Fichier\ListJoueur.xml");
            tmp = (List<Joueur>)Serializer.Deserialize(Rfile);
            Rfile.Close();
        }

        public void saveJoueur(int num)
        {
            bool ok = false;
            Joueur newJoueur = new Joueur(nom.Text, (DateTime)ddn.SelectedDate, poste.Text, num);
            if(tmp.Count > 1)
            {
                foreach(Joueur jo in tmp)
                {
                    if(estLeMeme(jo, newJoueur))
                    {
                        ok = true;
                        break;
                    }
                 
                }
            }

            if (!ok)
            {
                tmp.Add(newJoueur);
                XmlSerializer Serializer = new XmlSerializer(typeof(List<Joueur>));
                StreamWriter Wfile = new StreamWriter(@"..\..\..\..\Fichier\ListJoueur.xml");
                Serializer.Serialize(Wfile, tmp);
                Wfile.Close();
            }
            else
                MessageBox.Show("Joueur deja existant ");
          
        }

        public bool estLeMeme(Joueur jo, Joueur jo2)
        {
            if (jo.AGE == jo2.AGE && jo.NOM == jo2.NOM)
                return true;
            else return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
