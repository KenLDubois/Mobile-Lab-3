﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MobileLab3_APIHost.Models
{
    [DataContract]
    public class ArtType
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Display(Name = "Art Type")]
        [Required(ErrorMessage = "You cannot leave the art type name black.")]
        [StringLength(25, ErrorMessage = "Art type cannot be more than 25 characters long.")]
        public string Type { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}
