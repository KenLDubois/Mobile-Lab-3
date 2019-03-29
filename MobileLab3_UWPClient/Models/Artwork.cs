using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab3_UWPClient.Models
{
    public class Artwork
    {
        public int ID { get; set; }

        //public string Summary
        //{
        //    get
        //    {
        //        return Name + " - " + Finished.ToShortDateString();
        //    }
        //}


        public string Name { get; set; }

        public DateTime Finished { get; set; }

        public string Description { get; set; }


        public decimal Value { get; set; }

        public int ArtTypeID { get; set; }

        public virtual ArtType ArtType { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
