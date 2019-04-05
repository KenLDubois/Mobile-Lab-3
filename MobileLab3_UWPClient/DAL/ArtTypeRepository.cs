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
    public class ArtTypeRepository : IArtTypeRepository
    {
        HttpClient client = new HttpClient();

        public ArtTypeRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ArtType> GetArtType(int ArtTypeID)
        {
            var response = await client.GetAsync($"/api/ArtTypes/{ArtTypeID}");
            if (response.IsSuccessStatusCode)
            {
                ArtType artType = await response.Content.ReadAsAsync<ArtType>();
                return artType;
            }
            else
            {
                return new ArtType();
            }
        }

        public async Task<List<ArtType>> GetArtTypes()
        {
            var response = await client.GetAsync("/api/ArtTypes");
            if (response.IsSuccessStatusCode)
            {
                List<ArtType> artTypes = await response.Content.ReadAsAsync<List<ArtType>>();
                return artTypes;
            }
            else
            {
                return new List<ArtType>();
            }
        }
    }
}
