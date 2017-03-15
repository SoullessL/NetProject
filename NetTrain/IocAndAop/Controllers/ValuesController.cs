using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IocAndAop.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/<controller>
        public async Task<HttpResponseMessage> PostFromData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Debug.WriteLine(file.Headers.ContentDisposition.FileName);
                    Debug.WriteLine("Server file path: " + file.LocalFileName);
                }

                foreach(var inputKey in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(inputKey))
                    {
                        Debug.WriteLine(string.Format("{0}: {1}", inputKey, val));
                    }
                }

                // Add cookie
                var cookie = new CookieHeaderValue("session-id", "123321");
                cookie.Expires = DateTime.Now.AddDays(10);
                cookie.Domain = Request.RequestUri.Host;
                var res = Request.CreateResponse(HttpStatusCode.OK);
                res.Headers.AddCookies(new CookieHeaderValue[] { cookie });

                return res;
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}