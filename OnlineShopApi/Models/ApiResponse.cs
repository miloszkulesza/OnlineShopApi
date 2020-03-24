using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OnlineShopApi.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public object Content { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }
}
