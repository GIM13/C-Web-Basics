using System;

namespace SharedTrip2.ViewModels.Trips
{
    public class TripInputModel
    {
        public string StartingPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public byte Seats { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
