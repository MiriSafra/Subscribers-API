using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.CORE.Interface
{
    public interface IWeightWatchersService
    {
        public Task<Generalresponse<bool>> Register(SubscriberDTO subscriberDTO, double height);
        public Task<Generalresponse<CardDTO>> Login(string password, string email);
        public Task<Generalresponse<ResponseGetCard_ID>> GetCardDetails(int id);
    }
}
