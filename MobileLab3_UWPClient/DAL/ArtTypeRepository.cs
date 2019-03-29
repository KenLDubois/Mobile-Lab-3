using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileLab3_UWPClient.Models;

namespace MobileLab3_UWPClient.DAL
{
    public class ArtTypeRepository : IArtTypeRepository
    {
        public Task<ArtType> GetArtType(int ArtTypeID)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArtType>> GetArtTypes()
        {
            throw new NotImplementedException();
        }
    }
}
