using MobileLab3_UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab3_UWPClient.DAL
{
    interface IArtTypeRepository
    {
        Task<List<ArtType>> GetArtTypes();
        Task<ArtType> GetArtType(int ArtTypeID);
    }
}
