using MobileLab3_UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab3_UWPClient.DAL
{
    interface IArtworkRepository
    {
        Task<List<Artwork>> GetArtworks();
        Task<Artwork> GetArtwork(int ID);
        Task<List<Artwork>> GetArtworksByArtType(int ArtTypeID);
        Task AddArtwork(Artwork artToAdd);
        Task UpdateArtwork(Artwork artToUpdate);
        Task DeleteArtwork(Artwork artToDelete);
    }
}
