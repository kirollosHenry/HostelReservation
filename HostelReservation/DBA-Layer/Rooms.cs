using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace HostelReservation.Classes
{
    internal class Rooms : IBaseInterface
    {
        #region Fields Of Room
        private decimal ratesRooms;
        private int numberBeds;
        private char Status = 'A';
        private int hotelId;
        #endregion

        #region Properties Of Rooms 
        public int RoomId { get; set; }
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

        public void Create(object CreateObj)
        {
            Rooms rooms = new Rooms();
            rooms = (Rooms)CreateObj;
            rooms.RatesRooms = RatesRooms;
            rooms.numberBeds = NumberBeds;
            rooms.HotelId = HotelId;

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string addCustomerQuery = "INSERT INTO Room VALUES (@NumberBeds,'A', @RatesRoom, @HotelId); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addCustomerQuery, con))
                {
                    command.Parameters.AddWithValue("@RatesRoom", RatesRooms);
                    command.Parameters.AddWithValue("@NumberBeds", NumberBeds);
                    command.Parameters.AddWithValue("@HotelId", HotelId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Read(object ReadObj)
        {
            Rooms rooms = (Rooms)ReadObj;

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                Console.WriteLine($"\nSHOWING ALL Rooms in Hotel Number: {rooms.hotelId}\n");
                string[] val;
                var table = new ConsoleTable("RoomNumber", "Number Of Beds", "Rates", "Hotel Name");

                string showAllRooms = $"Select r.RoomID,r.RoomBedsNumber,r.RoomMoney ,h.HotelName " +
                    $"from Room r ,Hotel h  where h.HotelId = r.HotelID and RoomStatus = 'A'  and r.HotelID =" + rooms.hotelId;

                using (SqlCommand command = new SqlCommand(showAllRooms, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                val = new string[reader.FieldCount];
                                for (int i = 0; i < reader.FieldCount; i++)
                                    val[i] = Convert.ToString(reader.GetValue(i))!;
                                table.AddRow(val[0], val[1], val[2] + " $", val[3]);
                            }
                            table.Write();
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("No Records available in the database....\n");
                    }
                }
            }
        }

        public void Update(object UpdateObj)
        {
            Rooms rooms = (Rooms)UpdateObj;

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string UpdateRoom = $"Update Room set RoomBedsNumber = {rooms.NumberBeds}, RoomStatus = 'A', RoomMoney = {rooms.ratesRooms}, HotelID = {rooms.HotelId} where RoomID = {rooms.RoomId}";

                using (SqlCommand cmd = new SqlCommand(UpdateRoom, con))
                {
                    int ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                        Console.WriteLine("\nRoom id: {0} updated successfully....\n", rooms.RoomId);
                    else
                        Console.WriteLine($"\nRoom Id: {rooms.RoomId} Not Found in the database....\n");
                }
            }
        }

        public void Delete(object deleteObj)
        {
            Rooms rooms = (Rooms)deleteObj;

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                try
                {
                    string deleteQuery = $"delete from Room where RoomID = {rooms.RoomId} and HotelID = {rooms.HotelId}";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine($"\nRoom Id : {rooms.RoomId} deleted....\n");
                        else
                            Console.WriteLine($"\nRoom Id: {rooms.RoomId} Not Found in the database....\n");
                    }
                }
                catch (Exception) { Console.WriteLine("Can not Deleted Because Already Customer Reserve This Room"); }
            }
        }
        #endregion
    }
}
