using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    /// <summary>
    /// User can comment video
    /// </summary>
    internal class Comments
    {
        /// <summary>
        /// Comments need to contain text to share with the community.
        /// </summary>
        public string textComment { get; private set; }
        /// <summary>
        /// Other users in the community can see the date when the user published this comment.
        /// </summary>
        public DateTime timeSharedComment { get; private set; }
        public Comments(string textComment)
        {
            this.textComment = textComment;
            this.timeSharedComment = DateTime.Now;
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n", timeSharedComment.ToShortDateString(), textComment);
        }

    }
}
