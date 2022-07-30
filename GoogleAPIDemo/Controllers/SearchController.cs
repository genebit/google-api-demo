using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoogleAPIDemo.ViewModels;
using Google.Apis.YouTube.v3;
using System.Threading.Tasks;

namespace GoogleAPIDemo.Controllers
{
    public class SearchController : Controller
    {
        public async Task<ActionResult> Run(string q)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyD4jXBCRTf3OTWF6Ip9Nnb_M0h_rWNJwgg",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = q; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<QueriesViewModel> model = new List<QueriesViewModel>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        QueriesViewModel item = new QueriesViewModel 
                        { 
                            VideoID = searchResult.Id.VideoId,
                            VideoTitle = searchResult.Snippet.Title,
                            VideoDescription = searchResult.Snippet.Description,
                            VideoThumbnailUrl = searchResult.Snippet.Thumbnails.High.Url,
                            PublishedAt = searchResult.Snippet.PublishedAt.ToString(),
                            ChannelName = searchResult.Snippet.ChannelTitle,
                            ChannelProfileImg = ""
                        };
                        model.Add(item);
                        break;
                }   
            }

            return PartialView("_QueriesFound", model);
        }
    }
}
