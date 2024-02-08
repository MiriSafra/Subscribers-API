using AutoMapper;
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
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Subscriber.Services
{
    public class WeightWatchersService : IWeightWatchersService
    {
        readonly IWeightWatchersRepository _weightWatchersRepository;
        readonly IMapper _mapper;
        public WeightWatchersService(IWeightWatchersRepository iSubscriberRepository, IMapper mapper)
        {
            _weightWatchersRepository = iSubscriberRepository;
            _mapper = mapper;
        }

        public async Task<Generalresponse<ResponseGetCard_ID>> GetCardDetails(int id)
        {
            Generalresponse<ResponseGetCard_ID> cardDetails = await _weightWatchersRepository.GetCardDetails(id);

            if (cardDetails == null)
            {
                cardDetails.Status = "Card details not found";
            }
            else
            {
                cardDetails.Succeeded = true;
            }
            return cardDetails;
        }

        public async Task<Generalresponse<CardDTO>> Login(string password, string email)
        {
            Generalresponse<Card> response = await _weightWatchersRepository.Login(password, email);
            return _mapper.Map<Generalresponse<CardDTO>>(response);

        }

        public async Task<Generalresponse<bool>> Register(SubscriberDTO subscriberDTO, double height)
        {

            if (!IsValidEmail(subscriberDTO.Email) || !IsValidPassword(subscriberDTO.Password))
            {

                var ErrorResponse = new Generalresponse<bool>
                {
                    Response = false,
                    Succeeded = false,
                    Status = "Password is invalid," +
                    " Please make sure you meet the requirements"
                };
                return ErrorResponse;
            }
            Generalresponse<bool> response = await _weightWatchersRepository.Register(_mapper.Map<Subscribers>(subscriberDTO), height);

            return response;
        }


        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {

                var validation = new System.Net.Mail.MailAddress(email);
                return validation.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length != 8)
                return false;

            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }
    }
}
