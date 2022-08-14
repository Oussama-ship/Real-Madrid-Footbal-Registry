using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Win32;

namespace Real_Madrid_Football_Registry
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChangeParam : Window
    {
        public ObservableCollection<int> Police { get; set; }
        int p = 15;
        public ChangeParam()
        {
            InitializeComponent();
            Police = new ObservableCollection<int>();
            Police.Add(12);
            Police.Add(15);
            Police.Add(17);
            Police.Add(19);
            Police.Add(21);

            choxipolice.SelectedIndex = 0;

            this.DataContext = this;
        }


        public delegate void notify(object sender, MyAppParamManager e);
        public event notify SettingCompleted;

        private void OnSettingChange(MyAppParamManager e)
        {
            SettingCompleted(this, e);
        }

        private void ChangeFont(object sender, RoutedEventArgs e)
        {
            if(choxipolice.SelectedItem != null)
            p = (int)choxipolice.SelectedItem;

            System.Windows.Media.Color ground = choixcouleur.Color;
            System.Windows.Media.Color match = CouleurMatch.Color;
            System.Windows.Media.Color joueur = CouleurJoueur.Color;


            System.Drawing.Color ma = System.Drawing.Color.FromArgb(match.A, match.R, match.G, match.B);
            System.Drawing.Color jo = System.Drawing.Color.FromArgb(joueur.A, joueur.R, joueur.G, joueur.B);
            System.Drawing.Color back = System.Drawing.Color.FromArgb(ground.A, ground.R, ground.G, ground.B);
            MyAppParamManager c = new MyAppParamManager(p, back , ma , jo);
            OnSettingChange(c);


            c.recinfo();



        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
