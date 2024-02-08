using Azure;
using Microsoft.EntityFrameworkCore;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface;
using Subscriber.CORE.Response;
using Subscriber.Data;
using Subscriber.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.DAL
{
    public class WeightWatchersRepository : IWeightWatchersRepository
    {
        readonly WeightWatchersContext _weightWatchersContext;
        public WeightWatchersRepository(WeightWatchersContext weightWatchersContext)
        {
            _weightWatchersContext = weightWatchersContext;
        }
        public async Task<Generalresponse<ResponseGetCard_ID>> GetCardDetails(int id)
        {
            try
            {
                Generalresponse<ResponseGetCard_ID> response = new Generalresponse<ResponseGetCard_ID>();
                Card card = _weightWatchersContext.Cards.Where(p => p.Id == id).FirstOrDefault();
                if (card != null)
                {
                    Subscribers subscriber = _weightWatchersContext.Subscribers.Where(p => p.Id == card.SubscriberId).FirstOrDefault();
                    if (subscriber != null)
                    {
                        response.Succeeded = true;
                        response.Status = "Succeeded";
                        response.Response = new ResponseGetCard_ID();
                        response.Response.Id = id;
                        response.Response.Height = card.Height;
                        response.Response.Weight = card.Weight;
                        response.Response.BMI = card.BMI;
                        response.Response.FirstName = subscriber.FirstName;
                        response.Response.LastName = subscriber.LastName;
                    }
                    else
                    {
                        response.Succeeded = false;
                        response.Status = "failed";
                    }
                }
                else
                {
                    response.Succeeded = false;
                    response.Status = "failed";
                }


                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("Get card Failed.");
            }
        }

        public async Task<Generalresponse<Card>> Login(string password, string email)
        {
            try
            {
                Subscribers subscribers = _weightWatchersContext.Subscribers.Where(p => p.Email == email && p.Password == password).FirstOrDefault();
                Generalresponse<Card> response = new Generalresponse<Card>();

                if (subscribers != null)
                {
                    response.Response = _weightWatchersContext.Cards.Where(c => c.Id == subscribers.Id).FirstOrDefault();
                    response.Succeeded = true;
                    response.Status = "Succeeded";
                }
                else
                {
                    response.Response = null;
                    response.Status = "The email address or password  does not exist.";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(" Error 401, Login Failed");
            }

        }

        public async Task<Generalresponse<bool>> Register(Subscribers subscriber, double height)
        {
            try
            {
                Generalresponse<bool> response = new Generalresponse<bool>();

                if (await SubscriberEmailExists(subscriber.Email))
                {
                    response.Response = false;
                    response.Succeeded = false;
                    response.Status = "Email already exists";
                    return response;
                }
                else
                {
                    var createdSubscriber = await _weightWatchersContext.Subscribers.AddAsync(subscriber);
                    await _weightWatchersContext.SaveChangesAsync();
                    var defaultCard = new Card
                    {
                        SubscriberId = createdSubscriber.Entity.Id,
                        OpenDate = DateTime.Now,
                        UpDate = DateTime.Now,
                        BMI = 0,
                        Height = height
                    };
                   await _weightWatchersContext.Cards.AddAsync(defaultCard);
                    await _weightWatchersContext.SaveChangesAsync();
               
               
                    response.Succeeded = true;
                    response.Response = true;
                    response.Status = " added successfuly";
                }
            
                  
                
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("Register Failed");
            }

        }
        public async Task<bool> SubscriberEmailExists(string email)
        {
            return await _weightWatchersContext.Subscribers.AnyAsync(s => s.Email == email);
        }


    }
}
