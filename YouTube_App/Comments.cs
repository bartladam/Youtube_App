using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal class Comments
    {
        public string textComment { get; private set; }
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
