using Microsoft.EntityFrameworkCore;
using SharedTrip2.Data;
using SharedTrip2.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SharedTrip2
{

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ITripsService, TripsService>();
        }
    }
}
