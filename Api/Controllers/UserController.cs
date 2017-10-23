using Core.Interfaces;
using Model.Entities;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    /// <summary>
    /// Api Todo
    /// </summary>
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        private readonly IService<User> _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public UserController(IService<User> service)
        {
            this._service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/user")]
        public Task<HttpResponseMessage> GetUser(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var user = _service.Get(id);

            response = Request.CreateResponse(HttpStatusCode.OK);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
    }
}
