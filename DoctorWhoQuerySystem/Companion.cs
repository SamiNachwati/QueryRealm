using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWhoQuerySystem
{
    /// <summary>
    /// Class used to create Companion objects based on the recieved information from the COMPANION table 
    /// </summary>
    internal class Companion
    {
        public string name { get; set; } // value used to obtain the name of the companion
        public string actor { get; set; }   // value used to obtain the actor of the companion
        public int doctorID { get; set; } // the value used to match the doctor with the companion
        public string storyID { get; set; } // the value used to match episode with the companion

        public Companion(string name, string actor, int doctorID, string storyID)
        {
            this.name = name;
            this.actor = actor;
            this.doctorID = doctorID;
            this.storyID = storyID;
        }

        /// <summary>
        /// Method used to return the name of the Companion
        /// </summary>
        /// <returns>string name</returns>
        public override string ToString()
        {
            return name;
        }
    }
}
