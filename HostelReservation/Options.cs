using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    enum AdminOption
    {
        Hotels = 1,
        Rooms,
        Customers,
        Reservation,
        Billing,
        Exit
    }

    enum Option
    {
        Read = 1,
        Create,
        Update,
        Delete,
        Back
    }

    enum Option2
    {
        ReadAll = 1,
        ReadByID,
        Update,
        Back
    } 
}
