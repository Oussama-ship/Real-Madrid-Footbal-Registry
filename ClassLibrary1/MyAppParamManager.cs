using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MaLibrairieClass
{
    public class MyAppParamManager
    {
        public int FontSize { get; set; }
        public Color BackColor { get; set; }

        public Color listColor1 { get; set; }

        public Color listColor2 { get; set; }

        public MyAppParamManager(int size, Color color , Color co , Color c)
        {

            FontSize = size;
            BackColor = color;
            listColor1 = co;
            listColor2 = c; 

        }

        public void recinfo()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software");
            RegistryKey key2 = rk.CreateSubKey("RealMadridFootBallRegistry");
            key2.SetValue("Police", FontSize.ToString());
            key2.SetValue("CouleurFond", BackColor.A.ToString() + "/" + BackColor.R.ToString() + "/" + BackColor.G.ToString() + "/" + BackColor.B.ToString());
            key2.SetValue("Joueur", listColor2.A.ToString() + "/" + listColor2.R.ToString() + "/" + listColor2.G.ToString() + "/" + listColor2.B.ToString());
            key2.SetValue("Match", listColor1.A.ToString() + "/" + listColor1.R.ToString() + "/" + listColor1.G.ToString() + "/" + listColor1.B.ToString());

            
        }

      


    }
}
