using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal class Server
    {
        public List<Video> videos { get; private set; }
        public List<Video> favoriteVideos { get; private set; }
        private Website web { get; init; }
        public Server(Website website)
        {
            website.server = this;
            this.web = website;
            videos = new List<Video>();
            favoriteVideos = new List<Video>();
        }
        public Website RequestedWeb() => web;

        public string UploadVideo(Video video)
        {
            videos.Add(video);
            return string.Format("Video uploaded");
        }
        public Video WatchVideo(string nameVideo)
        {
            foreach (Video item in videos)
            {
                if(item.nameVideo.Equals(nameVideo))
                    return item;
            }
            return null;
        }
        public string AddToFavorite(Video video)
        {
            favoriteVideos.Add(video);
            return string.Format("Added to your favorite");
        }
        public string RemoveFromFavorite(Video video)
        {
            if(favoriteVideos.Contains(video))
            {
                favoriteVideos.Remove(video);
                return string.Format("Removed to your favorite");
            }
            return string.Format("Video isn't in your favorite");
        }
    }
}
