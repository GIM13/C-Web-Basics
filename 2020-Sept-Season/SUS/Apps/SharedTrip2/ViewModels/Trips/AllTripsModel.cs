using SharedTrip2.Data;
using System;

namespace SharedTrip2.ViewModels.Trips
{
    public class AllTripsModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public byte Seats { get; set; }

        public TripInputModel Details { get; set; }
    }
}
