using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaLibrairieClass;

namespace ViewModel.Repository
{
    public class ButViewModel : ViewModelBase
    {
        public But content;
        
        public ButViewModel(But bu)
        {
            content = bu;   
        }
        public Joueur Buteur { get => content.Buteur; set { content.Buteur = value; NotifyPropertyChanged(nameof(content.Buteur)); } }
        public int Minute { get => content.Minute; 
            set {
                content.Minute = value;
                NotifyPropertyChanged(nameof(content.Minute)); 
            
            }  
        }

        public override string ToString()
        {
            return Buteur.ToString() + " " + Minute.ToString();
        }

    }
}
