using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    enum CustomerOption
    {
        create=1,
        update,
        showall,
        showbyid,
        delete,
        exit
    }
    enum RoomOption
    {
        CreateRoom=1,
        UpdateRoom,
        ShowAllRooms,
        ShowRoomByNum,
        DeleteRoom,
        Exit
    }
}
