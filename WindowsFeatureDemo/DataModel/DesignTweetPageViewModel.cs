using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsFeatureDemo.DataModel
{
    public class DesignTweetPageViewModel : ITweetPageViewModel
    {
        private Tweet _tweet;

        public DesignTweetPageViewModel()
        {
            _tweet = new Tweet(){
                Author = "Martina Musterfrau",
                Message = "Aber wer hat irgend ein Recht, einen Menschen zu tadeln, der die Entscheidung trifft, eine Freude zu genießen.",
                Image = new BitmapImage(new Uri("ms-appx:///Assets/dummy.jpg"))
            };
        }
    
        public Tweet Tweet
        {
	        get 
            {
                return _tweet;
            }
        }

        public ICommand BackButtonClicked
        {
	        get 
            {
                return null;
            }
        }
    }
}
