using SharedTrip2.Services;
using SharedTrip2.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartingPoint))
            {
                return this.Error("Enter address1.");
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.Error("Enter address2.");
            }

            if (string.IsNullOrWhiteSpace(input.Description))
            {
                return this.Error("Enter description.");
            }

            if (string.IsNullOrWhiteSpace(input.DepartureTime.ToString("dd.MM.yyyy HH:mm")))
            {
                return this.Error("Enter the date in format <<dd.MM.yyyy HH:mm>>.");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }

            this.tripsService.CreateTrip(input);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetDetails(id);

            return this.View(trip);
        }
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            //if (!this.tripsService.HasAvailableSeats(tripId))
            //{
            //    return this.Error("No seats available.");
            //}

            var userId = this.GetUserId();

            //if (!this.tripsService.AddUserToTrip(userId, tripId))
            //{
            //    return this.Redirect("/Trips/Details?tripId=" + tripId);
            //}

            return this.Redirect("/Trips/All");
        }
    }
}
