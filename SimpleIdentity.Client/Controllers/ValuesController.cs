using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace SimpleIdentity.Client.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize]
        public IEnumerable<string> Get()
        {
            return Request.GetOwinContext().Authentication.User.Claims.Select(x => x.Subject.Name);
        }

    }
}
