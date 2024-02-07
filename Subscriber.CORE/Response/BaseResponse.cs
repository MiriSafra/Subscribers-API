using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Response
{
    public class BaseResponse
    {
        public bool Succeeded { get; set; }
        public string Status { get; set; }
        public BaseResponse()
        {
            Succeeded = false;
        }
    }
}
