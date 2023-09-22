using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        Console.Write("Name video: ");
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
                                    Console.WriteLine("Write text: ");
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
                        Console.Write("Topic: ");
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
        private string RecommendedVideos(string topic) => server.RecommendedVideos(topic);

        private Video WatchVideo(string nameVideo) => server.WatchVideo(nameVideo);

        private string UploadVideo(string nameVideo, string description, Video.topicVideo topic, TimeSpan ts) => server.UploadVideo(new Video(nameVideo, description, topic, ts));

        private string CommentVideo(Video video, string textComment) => video.AddComment(textComment);

        private string AddToFavorite(Video video) => server.AddToFavorite(video);

        private string RemoveFromFavorite(Video video) => server.RemoveFromFavorite(video);
       
    }
}
