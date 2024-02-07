using AutoMapper;
using Subscriber.Services;
using Subscriber.DAL;
using Subscriber.CORE.Interface;

namespace Subscriber.WebWpi.Config
{
    public static  class ConfigureServices
    {

        public static void ConfigurationService(this IServiceCollection services)
        {

            services.AddScoped<IWeightWatchersService, WeightWatchersService>();
            services.AddScoped<IWeightWatchersRepository, WeightWatchersRepository>();
            

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
