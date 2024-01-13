using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    internal class Reservation
    {
        private DateOnly reservationCheckIn;
        private DateOnly reservationCheckOut;
        public void read()
        {
            reservationCheckIn = new DateOnly();
        }

    }
}
