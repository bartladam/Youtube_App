using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    /// <summary>
    /// Website is communication with user and server
    /// </summary>
    internal class Website
    {
        /// <summary>
        /// Youtube website has URL as each web
        /// </summary>
        public string URL { get; init; }
        /// <summary>
        /// Web knows where is saved and can look into server where he finds specific video
        /// </summary>
        public Server server { private get; set; }
        public Website(string URL)
        {
            this.URL = URL;
        }
        /// <summary>
        /// What user see when he is on website
        /// </summary>
        public void WebsiteInterface()
        {
            char choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Select topic:");
                Console.WriteLine(RecommendedVideos(Console.ReadLine()));
                Console.WriteLine(@"
1 - Watch video
2 - Upload video
3 - List favorite videos
4 - end");
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        Console.Write("\nName video: ");
                        Video video = WatchVideo(Console.ReadLine());
                        if(video is not null)
                        {
                            Console.Clear();
                            Console.WriteLine("You are watching: {0}\n", video.nameVideo);
                            Console.WriteLine("Comments section:\n{0}", video.ListComments());
                            Console.WriteLine(@"
You can:
1 - Comment video
2 - Add to favorite
3 - Remove from favorite");
                            choice = Console.ReadKey().KeyChar;
                            switch (choice)
                            {
                                case '1':
                                    Console.WriteLine("\nWrite text: ");
                                    Console.WriteLine(CommentVideo(video, Console.ReadLine()));
                                    break;
                                case '2':
                                    Console.WriteLine(AddToFavorite(video));
                                    break;
                                case '3':
                                    Console.WriteLine(RemoveFromFavorite(video));
                                    break;
                            }
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.Write("Name video: ");
                        string nameVideo = Console.ReadLine();
                        Console.Write("Description video: ");
                        string description = Console.ReadLine();
                        Console.Write("Topic [news, document, funny, gamming, investment]:  ");
                        Video.topicVideo topic = (Video.topicVideo)Enum.Parse(typeof(Video.topicVideo), Console.ReadLine());
                        Console.Write("Length: ");
                        TimeSpan ts = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine(UploadVideo(nameVideo, description, topic, ts));
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Favorite videos: ");
                        for (int i = 0; i < server.favoriteVideos.Count; i++)
                        {
                            Console.WriteLine("{0}) {1}", i + 1, server.favoriteVideos[i].nameVideo);
                        }
                        break;
                }
                Console.ReadKey();
            }
            while (choice != '4');


        }
        /// <summary>
        /// Recommended Videos for best experience in web
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        private string RecommendedVideos(string topic) => server.RecommendedVideos(topic);
        /// <summary>
        /// When user wants to specific video, server give him video from database
        /// </summary>
        /// <param name="nameVideo"></param>
        /// <returns></returns>
        private Video WatchVideo(string nameVideo) => server.WatchVideo(nameVideo);

        /// <summary>
        /// New video can user upload on server
        /// </summary>
        /// <param name="nameVideo"></param>
        /// <param name="description"></param>
        /// <param name="topic"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        private string UploadVideo(string nameVideo, string description, Video.topicVideo topic, TimeSpan ts) => server.UploadVideo(new Video(nameVideo, description, topic, ts));
        /// <summary>
        /// User can comment video in comment section
        /// </summary>
        /// <param name="video"></param>
        /// <param name="textComment"></param>
        /// <returns></returns>
        private string CommentVideo(Video video, string textComment) => video.AddComment(textComment);
        /// <summary>
        /// When user likes the video, he can add to his favorite library
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        private string AddToFavorite(Video video) => server.AddToFavorite(video);
        /// <summary>
        /// When user dont't like this video anymore, he can remove it from library
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        private string RemoveFromFavorite(Video video) => server.RemoveFromFavorite(video);
       
    }
}
