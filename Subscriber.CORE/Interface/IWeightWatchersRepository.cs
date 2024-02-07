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
    public interface IWeightWatchersRepository
    {
        public Task<Generalresponse<bool>> Register(Subscribers subscriber, double height);
        public Task<Generalresponse<Card>> Login(string password, string email);
        public Task<Generalresponse<ResponseGetCard_ID>> GetCardDetails(int id);
        public Task<bool> SubscriberEmailExists(string email);


    }
}
