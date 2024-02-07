using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Response
{
    public class Generalresponse<T>:BaseResponse
    {
        public T Response { get; set; }
    }
}
