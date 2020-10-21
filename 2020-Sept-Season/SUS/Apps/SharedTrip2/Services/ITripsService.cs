using SharedTrip2.Data;
using SharedTrip2.ViewModels.Trips;
using System.Collections.Generic;

namespace SharedTrip2.Services
{
    public interface ITripsService
    {
        void CreateTrip(TripInputModel input);

        IEnumerable<AllTripsModel> GetAll();

        TripInputModel GetDetails(string id);
    }
}
