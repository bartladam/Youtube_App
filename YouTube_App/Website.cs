using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal class Website
    {
        public string URL { get; init; }
        public Server server { private get; set; }
        public Website(string URL)
        {
            this.URL = URL;
        }
        public void WebsiteInterface()
        {
            Console.WriteLine(@"
1 - watch video
2 - Upload video");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.Write("Name video: ");
                    Video watch = WatchVideo(Console.ReadLine());
                    Console.WriteLine(@"
You can:
1 - Comment video
2 - Add to favorite
3 - Remove from favorite");
                    break;
            }

        }
        private string RecommendedVideos()
        {
            return "";
        }
        private Video WatchVideo(string nameVideo)
        {
            return server.WatchVideo(nameVideo);
        }
        private string UploadVideo(string nameVideo, string description, Video.topicVideo topic, TimeSpan ts)
        {
            server.UploadVideo(new Video(nameVideo,description,topic,ts));
            return "";
        }
        private string CommentVideo(Video video, string textComment)
        {
            video.AddComment(textComment);
            return "";
        }
        private string AddToFavorite(Video video)
        {
            return server.AddToFavorite(video);
        }
        private string RemoveFromFavorite(Video video)
        {
            return server.RemoveFromFavorite(video);
        }
    }
}
