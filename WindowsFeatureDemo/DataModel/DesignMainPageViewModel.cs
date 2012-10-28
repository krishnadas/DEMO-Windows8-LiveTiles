using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsFeatureDemo.DataModel
{
    public class DesignMainPageViewModel : IMainPageViewModel
    {
        private ObservableCollection<Tweet> _tweets;

        public DesignMainPageViewModel()
        {
            _tweets = new ObservableCollection<Tweet>();
            _tweets.Add(new Tweet()
            {
                Author = "Max Mustermann",
                Message = "Auch gibt es niemanden, der den Schmerz an sich liebt, sucht oder wünscht, nur, weil er Schmerz ist.",
                Image = new BitmapImage(new Uri("ms-appx:///Assets/dummy.jpg"))
            });
            _tweets.Add(new Tweet()
            {
                Author = "Martina Musterfrau",
                Message = "Aber wer hat irgend ein Recht, einen Menschen zu tadeln, der die Entscheidung trifft, eine Freude zu genießen.",
                Image = new BitmapImage(new Uri("ms-appx:///Assets/dummy.jpg"))
            });
        }

        public ObservableCollection<Tweet> Tweets
        {
            get 
            {
                return _tweets;
            }
        }

        public string Tag { get; set; }

        public ICommand SearchButtonClicked
        {
            get 
            {
                return null;
            }
        }

        public Tweet SelectedTweet { get; set; }


        public Visibility ProgressBarVisibility
        {
            get 
            {
                return Visibility.Collapsed;
            }
        }
    }
}
