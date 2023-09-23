using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    /// <summary>
    /// On server we have saved webpage and all videos
    /// </summary>
    internal class Server
    {
        /// <summary>
        /// Server is saving all uploaded videos
        /// </summary>
        public List<Video> videos { get; private set; }
        /// <summary>
        /// Server is saving user favorite library with songs
        /// </summary>
        public List<Video> favoriteVideos { get; private set; }
        /// <summary>
        /// Server is saving web. Web is used on communication between user and server
        /// </summary>
        private Website web { get; init; }
        public Server(Website website)
        {
            website.server = this;
            this.web = website;
            videos = new List<Video>();
            favoriteVideos = new List<Video>();
        }
        /// <summary>
        /// When user send request for show website, server give back web
        /// </summary>
        /// <returns></returns>
        public Website RequestedWeb() => web;

        /// <summary>
        /// User via web send request for upload video
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public string UploadVideo(Video video)
        {
            videos.Add(video);
            return string.Format("Video uploaded");
        }
        /// <summary>
        /// User wants open specific youtube video and server have to find this video in his database
        /// </summary>
        /// <param name="nameVideo"></param>
        /// <returns></returns>
        public Video WatchVideo(string nameVideo)
        {
            foreach (Video item in videos)
            {
                if(item.nameVideo.ToLower().Equals(nameVideo.ToLower()))
                    return item;
            }
            return null;
        }
        /// <summary>
        /// User wants to add video to his favorite library
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public string AddToFavorite(Video video)
        {
            favoriteVideos.Add(video);
            return string.Format("Added to your favorite");
        }
        /// <summary>
        /// User wants to remove video from his favorite library
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public string RemoveFromFavorite(Video video)
        {
            if(favoriteVideos.Contains(video))
            {
                favoriteVideos.Remove(video);
                return string.Format("Removed to your favorite");
            }
            return string.Format("Video isn't in your favorite");
        }
        /// <summary>
        /// Youtube app shows recommended videos for you. Videos that could interest you
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public string RecommendedVideos(string topic)
        {
            string listVideos = ""; 
            var videoTopic = from i in videos
                             where (i.topic.ToString().Equals(topic.ToLower()))
                             select i;
            foreach (var item in videoTopic)
            {
                listVideos += string.Format("name: {0}, topic: {1} |", item.nameVideo, item.topic);
            }
            if (listVideos is "")
                return string.Format("Youtube don't have videos in this topic yet.");
            return listVideos;
        }
    }
}
