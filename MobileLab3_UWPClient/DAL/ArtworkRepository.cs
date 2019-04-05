using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MobileLab3_UWPClient.Models;
using MobileLab3_UWPClient.Utilities;

namespace MobileLab3_UWPClient.DAL
{
    class ArtworkRepository : IArtworkRepository
    {
        HttpClient client = new HttpClient();
        
        public ArtworkRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Artwork> GetArtwork(int ID)
        {
            var response = await client.GetAsync($"/api/Artworks/{ID}");
            if (response.IsSuccessStatusCode)
            {
                Artwork artwork = await response.Content.ReadAsAsync<Artwork>();
                return artwork;
            }
            else
            {
                return new Artwork();
            }
        }

        public async Task<List<Artwork>> GetArtworks()
        {
            var response = await client.GetAsync("/api/Artworks");
            if (response.IsSuccessStatusCode)
            {
                List<Artwork> artworks = await response.Content.ReadAsAsync<List<Artwork>>();
                return artworks;
            }
            else
            {
                return new List<Artwork>();
            }
        }

        public async Task<List<Artwork>> GetArtworksByArtType(int ArtTypeID)
        {
            var response = await client.GetAsync($"/api/Artworks/ArtworksByType/{ArtTypeID}");
            if (response.IsSuccessStatusCode)
            {
                List<Artwork> artworks = await response.Content.ReadAsAsync<List<Artwork>>();
                return artworks;
            }
            else
            {
                return new List<Artwork>();
            }
        }
    }
}
