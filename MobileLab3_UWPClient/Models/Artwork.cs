using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab3_UWPClient.Models
{
    [DataContract]
    public class Artwork
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Finished { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public int ArtTypeID { get; set; }

        [DataMember]
        public virtual ArtType ArtType { get; set; }

        [DataMember]
        public Byte[] RowVersion { get; set; }
    }
}
