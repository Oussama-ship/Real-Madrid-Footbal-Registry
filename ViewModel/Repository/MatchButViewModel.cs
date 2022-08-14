using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaLibrairieClass;

namespace ViewModel.Repository
{
    public class MatchButViewModel : ViewModelBase
    {

        public MatchBut content;
        public MatchButViewModel()
        {
            content = null;
        }

        public MatchButViewModel(MatchBut bu)
        {
            content = bu;
        }

        public int MINUTE
        {
            get { return content.MINUTE; }
            set
            {
                content.MINUTE = value;
                NotifyPropertyChanged(nameof(content.MINUTE));

            }
        }



        public override string ToString()
        {
            return Match.NOMMATCH  + MINUTE.ToString();
        }


        public Match Match
        {
            get => content.Match;

            set
            {
                content.Match = value;
                NotifyPropertyChanged(nameof(content.Match));
            }
        
        
        }

        public DateTime DateBut { get => content.DateBut;
            
            set {
                
                content.DateBut = value;
                NotifyPropertyChanged(nameof(content.DateBut));
            
            
            } 
        }


    }
}
