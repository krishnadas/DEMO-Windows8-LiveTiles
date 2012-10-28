using WindowsFeatureDemo.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Syndication;
using System.ComponentModel;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Notifications;

namespace WindowsFeatureDemo.DataModel
{
    public class MainPageViewModel : IMainPageViewModel, INotifyPropertyChanged
    {
        const string twitterUri = "http://search.twitter.com/search.rss?q={0}";

        private ObservableCollection<Tweet> _tweets;
        private ICommand _searchButtonClicked;
        private Visibility _progressBarVisibility;

        public MainPageViewModel()
        {
            Tag = "windows8";

            _tweets = new ObservableCollection<Tweet>();

            _searchButtonClicked = new ActionCommand((parameter) =>
            {
                DownloadTweets();
            });

            _progressBarVisibility = Visibility.Collapsed;
        }

        private async void DownloadTweets()
        {
            ProgressBarVisibility = Visibility.Visible;

            var tag = Uri.EscapeDataString(Tag);
            var uri = new Uri(String.Format(twitterUri, tag));

            var client = new SyndicationClient();

            try
            {
                var feed = await client.RetrieveFeedAsync(uri);

                _tweets.Clear();

                foreach (var item in feed.Items)
                {
                    _tweets.Add(new Tweet()
                    {
                        Message = item.Title.Text,
                        Author = item.Authors.First().NodeValue,
                        Image = new BitmapImage(new Uri(item.ElementExtensions.First(node => node.NodeName == "image_link").NodeValue)),
                        Link = new Uri(item.Links.First().NodeValue)
                    });
                }

                ProgressBarVisibility = Visibility.Collapsed;
            }
            catch (Exception e)
            {
                ProgressBarVisibility = Visibility.Collapsed;
                var errorDialog = new MessageDialog("Konnte Twitter feed nicht abrufen");
                errorDialog.ShowAsync();
            }

            UpdateLiveTile();
        }

        private void UpdateLiveTile()
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            tileUpdater.Clear();
            tileUpdater.EnableNotificationQueue(true);

            foreach (var tweet in _tweets)
            {
                var xml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideSmallImageAndText04);

                var textElements = xml.GetElementsByTagName("text");
                textElements[0].AppendChild(xml.CreateTextNode(tweet.Author));
                textElements[1].AppendChild(xml.CreateTextNode(tweet.Message));

                var imageElements = xml.GetElementsByTagName("image");
                imageElements[0].Attributes.GetNamedItem("src").NodeValue = (tweet.Image as BitmapImage).UriSource.ToString();

                var notification = new TileNotification(xml);

                tileUpdater.Update(notification);
            }
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
                return _searchButtonClicked;
            }
        }

        public Tweet SelectedTweet
        {
            get
            {
                return null;
            }

            set
            {
                App.RootFrame.Navigate(typeof(TweetPage), new TweetPageViewModel(value));
            }
        }

        public Visibility ProgressBarVisibility
        {
            get 
            {
                return _progressBarVisibility;
            }

            private set
            {
                if (value != _progressBarVisibility)
                {
                    _progressBarVisibility = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ProgressBarVisibility"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
