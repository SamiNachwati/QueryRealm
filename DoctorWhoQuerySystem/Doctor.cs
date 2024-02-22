using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWhoQuerySystem
{
    internal class Doctor
    {
        public int ID { get; set; } // the ID of the Doctor
        public string Actor { get; set; } // The actor associated with the Doctor

        public Image picture { get; set; } // The photo of the doctor

        public Doctor(int ID, string actor, byte[] photo)
        {
            this.ID = ID;
            this.Actor = actor;
            MemoryStream stream = new MemoryStream(photo); // memory stream object which takes the byte array and turns the value into a stream
            picture = Image.FromStream(stream);
        }

        /// <summary>
        /// Method which returns the Actor
        /// </summary>
        /// <returns>string Actor</returns>
        public override string ToString()
        {
            return Actor;
        }
    }
}
