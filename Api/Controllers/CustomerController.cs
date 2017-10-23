using Model.Entities;
using Model.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    /// <summary>
    /// Api Customer
    /// </summary>
    [RoutePrefix("api")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public CustomerController(ICustomerService service)
        {
            this._service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/customer")]
        public Task<HttpResponseMessage> Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var user = _service.Get(id);

            response = Request.CreateResponse(HttpStatusCode.OK, user);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/customer_by_lastname")]
        public Task<HttpResponseMessage> GetCustomersByLastName(string lastName)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var user = _service.GetCustomersByLastName(lastName);

            response = Request.CreateResponse(HttpStatusCode.OK, user);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/customer/add")]
        public Task<HttpResponseMessage> Post([FromBody]Customer instance)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            instance = _service.Create(instance);

            response = Request.CreateResponse(HttpStatusCode.Created, instance);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);

            return tsc.Task;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("v1/customer/put")]
        public Task<HttpResponseMessage> Put([FromBody]Customer instance)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            instance = _service.Update(instance);

            response = Request.CreateResponse(HttpStatusCode.OK, instance);

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);

            return tsc.Task;
        }
    }
}
