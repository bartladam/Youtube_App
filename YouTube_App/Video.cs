using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal class Video
    {
        public string nameVideo { get; private set; }
        public string description { get; private set; }
        public enum topicVideo {document,funny, gamming,news,investment}
        public topicVideo topic { get; private set; }
        public TimeSpan ts { get; private set; }
        public string URL { get; init; }
        public List<Comments> comments { get; set; }
        public Video(string nameVideo, string description, topicVideo topic, TimeSpan ts )
        {
            this.nameVideo = nameVideo;
            this.description = description;
            this.topic = topic;
            this.ts = ts;
            URL = "https://www.youtube.com/watch?";
            comments = new List<Comments>();
        }
        public string AddComment(string text)
        {
            comments.Add(new Comments(text));
            return string.Format("Comment added below video");
        }
        public string ListComments()
        {
            string AllComments = "";
            foreach (Comments item in comments)
            {
                AllComments += item + "\n";
            }
            return AllComments;
        }

    }
}
