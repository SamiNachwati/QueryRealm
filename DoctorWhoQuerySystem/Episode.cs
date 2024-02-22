using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWhoQuerySystem
{
    internal class Episode
    {
        public string storyID { get; set; } // value used to match companions with episodes
        public string title { get; set; } // the value representing the title of the episode
        public Episode(string storyID, string title)
        {
            this.storyID = storyID;
            this.title = title;
        }

        /// <summary>
        /// Method used to return the title of the episode
        /// </summary>
        /// <returns>string title</returns>
        public override string ToString()
        {
            return title;
        }
    }
}
