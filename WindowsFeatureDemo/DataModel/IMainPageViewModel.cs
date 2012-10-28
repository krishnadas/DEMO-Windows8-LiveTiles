using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace WindowsFeatureDemo.DataModel
{
    interface IMainPageViewModel
    {
        ObservableCollection<Tweet> Tweets { get; }
        string Tag { get; set; }
        ICommand SearchButtonClicked { get; }
        Tweet SelectedTweet { get; set; }
        Visibility ProgressBarVisibility { get; }
    }
}
