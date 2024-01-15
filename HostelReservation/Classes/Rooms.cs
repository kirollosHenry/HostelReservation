using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HostelReservation.DBconnection;
namespace HostelReservation.Classes
{
    internal class Rooms
    {
        #region Fields Of Room
        private decimal ratesRooms;
        private int numberBeds;
        private char Status = 'F';
        private int hotelId;
        #endregion

        #region Properties Of Rooms 
        public decimal RatesRooms
        {
            get { return ratesRooms; }
            set
            {
                if (value > 0)
                    ratesRooms = value;
                else
                    Console.WriteLine("Can not put Rates less than 0 ");
            }
        }
        public int NumberBeds
        {
            get { return numberBeds; }
            set
            {
                if (value > 0)
                    numberBeds = value;
                else
                    Console.WriteLine("Can not put Number less than 0 ");
            }
        }
        public int HotelId
        {
            get { return hotelId; }
            set
            {
                if (value > 0)
                    hotelId = value;
                else
                    Console.WriteLine("Can not put Number less than 0 ");
            }
        }
        #endregion

        #region Methods Of Rooms
        public void RoomsData()
        {
            Console.Write("Enter Number Of Beds: ");
            numberBeds = int.Parse(Console.ReadLine());

            Console.Write("Enter Rates Of Room: ");
            RatesRooms = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Number Of Hotel to Room: ");
            HotelId = int.Parse(Console.ReadLine());
            //if (!DBconnection.CheckPkExists(HotelId))
            //    Console.WriteLine("Incorect Hotel Id");
        }

        public void CreateRoom() //Create Room In Hotel Id
        {
            RoomsData();
            string AddRooms = $"insert into Room values({numberBeds},'{Status}','{RatesRooms}',{HotelId})";

            int ctr = ExecuteQueries(AddRooms);
            if (ctr > 0)
                Console.WriteLine("\nNew Room added....\n");
            else
                Console.WriteLine("error");
        }


        public static void ShowAllRooms(int HotelUserInput) // Show All Availble rooms in Hotel Id
        {
            Console.WriteLine("\nSHOWING ALL Rooms:\n");
            string[] val;
            var table = new ConsoleTable("RoomNumber", "Number Of Beds", "Rates", "Hotel Name");
            string showAllRooms = $"Select r.RoomID,r.RoomBedsNumber,r.RoomMoney ,h.HotelName " +
                $"from Room r ,Hotel h  where h.HotelId = r.HotelID and RoomStatus = 'F'  and r.HotelID =" + HotelUserInput;
            SqlDataReader reader = DataReader(showAllRooms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    val = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                    table.AddRow(val[0], val[1], val[2] + " $", val[3]);
                }
                table.Write();
                Console.WriteLine();
            }
            else
                Console.WriteLine("No Records available in the database....\n");
        }

        public void DeleteRoomByID(int RoomId) // Delete Room By ID    
        {
            OpenConnection();
            string DeleteRoomID = $"delete from Room where RoomID = {RoomId}";
            int ctr = ExecuteQueries(DeleteRoomID);
            if (ctr > 0)
                Console.WriteLine($"\nRoom Id : {RoomId} deleted....\n");
            else
                Console.WriteLine($"\nRoom Id: {RoomId} Not Found in the database....\n");
            CloseConnection();
        }
        #endregion

    }
}
