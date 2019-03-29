using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab3_UWPClient.Models
{
    [DataContract(IsReference = true)]
    public class ArtType
    {
        public ArtType()
        {
            this.Artworks = new HashSet<Artwork>();
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Type { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
