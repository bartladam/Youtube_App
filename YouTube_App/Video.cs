using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    /// <summary>
    /// Each user can upload video on server, or watchs videos
    /// </summary>
    internal class Video
    {
        /// <summary>
        /// User better find video by name
        /// </summary>
        public string nameVideo { get; private set; }
        /// <summary>
        /// This is important for kids. Is content this video for kids or no
        /// </summary>
        public string description { get; private set; }
        /// <summary>
        /// Video could have different topics. Each user prefer some topic more than others
        /// </summary>
        public enum topicVideo {document,funny, gamming,news,investment}
        public topicVideo topic { get; private set; }
        /// <summary>
        /// How length video is
        /// </summary>
        public TimeSpan ts { get; private set; }
        /// <summary>
        ///  Each video has specific URL
        /// </summary>
        public string URL { get; init; }
        /// <summary>
        /// One video has a lot of comments. 
        /// </summary>
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
        /// <summary>
        /// We can add comment below video
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string AddComment(string text)
        {
            comments.Add(new Comments(text));
            return string.Format("Comment added below video");
        }
        /// <summary>
        /// For all users is shown section with comments
        /// </summary>
        /// <returns></returns>
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
