using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleAPIDemo.ViewModels
{
    public class QueriesViewModel
    {
        public string VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string VideoThumbnailUrl { get; set; }
        public string PublishedAt { get; set; }
        public string ChannelName { get; set; }
        public string ChannelProfileImg { get; set; }
    }
}