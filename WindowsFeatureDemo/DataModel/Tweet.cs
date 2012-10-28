using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace WindowsFeatureDemo.DataModel
{
    public class Tweet
    {
        public string Message { get; set; }
        public string Author { get; set; }
        public ImageSource Image { get; set; }
        public Uri Link { get; set; }
    }
}
