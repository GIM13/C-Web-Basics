using SharedTrip2.Data;
using SharedTrip2.ViewModels.Trips;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip2.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrip(TripInputModel input)
        {
            var trip = new Trip
            {
                StartingPoint = input.StartingPoint,
                EndPoint = input.EndPoint,
                DepartureTime = input.DepartureTime,
                Description = input.Description,
                Seats = input.Seats,
                ImagePath = input.ImagePath
            };
            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<AllTripsModel> GetAll()
        {
            var trips = this.db.Trips
                .Select(x => new AllTripsModel
                {
                    StartPoint = x.StartingPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats
                }).ToList();

            return trips;
        }

        public TripInputModel GetDetails(string id)
        {
            var details = this.db.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripInputModel
                {
                    StartingPoint = x.StartingPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                    Description = x.Description,
                    ImagePath = x.ImagePath
                }).FirstOrDefault();

            return details;
        }
    }
}
