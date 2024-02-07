using AutoMapper;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Response;
using Subscriber.Data.Entities;

namespace Subscriber.WebWpi.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CardDTO, Card>().ReverseMap();
            CreateMap<SubscriberDTO,Subscribers>().ReverseMap();
            CreateMap<Generalresponse<Card>, Generalresponse<CardDTO>>();
        }
    }
}
