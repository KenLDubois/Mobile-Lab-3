using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileLab3_UWPClient.Models;

namespace MobileLab3_UWPClient.DAL
{
    class ArtworkRepository : IArtworkRepository
    {
        public Task<Artwork> GetArtwork(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artwork>> GetArtworks()
        {
            throw new NotImplementedException();
        }

        public Task<List<Artwork>> GetArtworksByArtType(int ArtTypeID)
        {
            throw new NotImplementedException();
        }
    }
}
