using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DemozoneZLuisBot.Controllers
{
    public class FileController : ApiController
    {
        [HttpGet]
        public async Task<string> Get(string typeFile)
        {
            
            return "Tous les fichiers " + typeFile;
        }
    }
}
