using System;
using System.Windows;
using ViewModel;
using Microsoft.Win32;
using System.Windows.Media;
using MaLibrairieClass;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        private AjouterJoueur ajout;
        private SupprimerJoueur supprimerJoueur;
        private ModifierJoueur modifierJoueur;
        private MainViewModel mvm =  new MainViewModel();
        private Ajouter_Match Ajouter_Match;
        private infoJoueur ij;
        private InfoMatch ifm;
        private SupprimerMatch SM;
        private ChangeParam PR ;
     


        public MainWindow()
        {
            InitializeComponent();
            loadRecInfo();
            this.DataContext = mvm;

       
        }

        public void loadRecInfo()
        {

            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software");
            RegistryKey key2 = rk.CreateSubKey("RealMadridFootBallRegistry");
             
            string back = key2.GetValue("CouleurFond" ,"255/0/0/255").ToString();
            string Jo = key2.GetValue("Joueur" , "255/235/241/221").ToString();
            string ma = key2.GetValue("Match" , "255/75/172/198").ToString();
            int po = Int32.Parse(key2.GetValue("Police","12").ToString());

            

            string[] bacl = back.Split("/");
            string[] jol = Jo.Split("/");
            string[] mal = ma.Split("/");

            int o = Byte.Parse(bacl.GetValue(0).ToString());

            Color backgrounde = System.Windows.Media.Color.FromArgb(Byte.Parse(bacl.GetValue(0).ToString()), Byte.Parse(bacl.GetValue(1).ToString()), Byte.Parse(bacl.GetValue(2).ToString()) ,Byte.Parse(bacl.GetValue(3).ToString()));
            Color joueurliste = System.Windows.Media.Color.FromArgb(Byte.Parse(jol.GetValue(0).ToString()), Byte.Parse(jol.GetValue(1).ToString()), Byte.Parse(jol.GetValue(2).ToString()), Byte.Parse(jol.GetValue(3).ToString()));
            Color match = System.Windows.Media.Color.FromArgb(Byte.Parse(mal.GetValue(0).ToString()), Byte.Parse(mal.GetValue(1).ToString()), Byte.Parse(mal.GetValue(2).ToString()), Byte.Parse(mal.GetValue(3).ToString()));

            Brush background = new SolidColorBrush(backgrounde);
            Brush matchcoul = new SolidColorBrush(match);
            Brush matchjo = new SolidColorBrush(joueurliste);


            this.FontSize = po;

            this.Background = background;
            this.list.Background = matchcoul;
            this.list2.Background = matchjo;




        }

        void settingChangedobject(object sender, MyAppParamManager o)
        {

            Color coma = System.Windows.Media.Color.FromArgb(o.listColor1.A, o.listColor1.R, o.listColor1.G, o.listColor1.B);
            Color cojo = System.Windows.Media.Color.FromArgb(o.listColor2.A, o.listColor2.R, o.listColor2.G, o.listColor2.B);
            Color co = System.Windows.Media.Color.FromArgb(o.BackColor.A, o.BackColor.R, o.BackColor.G, o.BackColor.B);
            Brush back = new SolidColorBrush(co);
            Brush matchcoul = new SolidColorBrush(coma);
            Brush matchjo = new SolidColorBrush(cojo);
            this.Background = back;
            list.Background = matchcoul;
            list2.Background = matchjo;
            FontSize = o.FontSize;

            

        }



        private void Ajouterjoueur_MenuItem_Click(object sender , EventArgs e)
        {
          
            ajout = new AjouterJoueur(mvm);
            ajout.ShowDialog();
            
        }

        private void SupprimerJoueur_MenuItem_Click(object sender , EventArgs  e)
        {
            if(list2.Items.Count == 0)
                MessageBox.Show("Aucun Joueur a supprimer", "Attention !!!");
            else
            {
                supprimerJoueur = new SupprimerJoueur(mvm);
                supprimerJoueur.ShowDialog();
            }
            
        }

      

        private void ModifierJoueur_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (list2.Items.Count == 0)
                MessageBox.Show("Aucun Joueur a modifier", "Attention !!!");
            else
            {
                modifierJoueur = new ModifierJoueur(mvm);
                modifierJoueur.ShowDialog();
            }

        }

        private void AjouterMatch_Button_Click(object sender, RoutedEventArgs e)
        {
            if(list2.Items.Count < 11)
            {
                MessageBox.Show("Pas Assez de joueur pour ajouter un match ", "Attention !!!");
            }
            else
            {
                Ajouter_Match = new Ajouter_Match(mvm);

                Ajouter_Match.ShowDialog();
            }
           
         

        }

        private void infoJoueur(Object sender , RoutedEventArgs e)
        {
            if (list2.SelectedItem.ToString() != null)
            {
                ij = new infoJoueur(list2.SelectedItem.ToString());
                ij.ShowDialog();
            }
         

        }

        private void infoMatch(object sender , RoutedEventArgs e)
        {

            if(list.SelectedItem.ToString() != null)
            {
                ifm = new InfoMatch(list.SelectedItem.ToString());
                ifm.ShowDialog();
            }
       

        }

        private void SupprimerMatch(object sender, RoutedEventArgs e)
        {
            if(list.Items.Count < 1)
            {
                MessageBox.Show("Il n'y a pas de match a supprimer !", "Attention");
            }
            else
            {
                SM = new SupprimerMatch(mvm);
                SM.ShowDialog();
            }
        }

        private void ChangeCouleur(object sender, RoutedEventArgs e)
        {
            PR = new ChangeParam();
            PR.SettingCompleted += settingChangedobject;
            PR.ShowDialog();
            
           
        }

        private void EXIT(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
