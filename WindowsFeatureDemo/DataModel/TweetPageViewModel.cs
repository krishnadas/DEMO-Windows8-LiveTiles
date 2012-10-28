using WindowsFeatureDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFeatureDemo.DataModel
{
    public class TweetPageViewModel : ITweetPageViewModel
    {
        private Tweet _tweet;
        private ICommand _backButtonClicked;

        public TweetPageViewModel(Tweet tweet)
        {
            _tweet = tweet;
            _backButtonClicked = new ActionCommand((parameter) =>
            {
                App.RootFrame.GoBack();
            });
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
                return _backButtonClicked;
            }
        }
    }
}
