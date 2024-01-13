using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HostelReservation.DBconnection;
namespace HostelReservation
{
    internal class Rooms
    {
        #region Fields Of Room
        private int roomNumber;
        private string roomType;
        private decimal ratesRooms;
        private string roomLocation;
        private int numberBeds;
        #endregion
       
        #region Properties Of Rooms 
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

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
        public string RoomLocation
        {
            get { return roomLocation; }
            set { roomLocation = value; }
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
        #endregion
        int CustomerID;
        #region Methods Of Rooms
        public void RoomsData()
        {
            Console.Write("Enter Number Of Room: ");
            RoomNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Type Of Room: ");
            RoomType = Console.ReadLine();
            Console.Write("Enter Rates Of Room: ");
            RatesRooms = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Number Of Beds: ");
            numberBeds = int.Parse(Console.ReadLine());
            //Console.Write("Enter Location Of Room: ");
            //roomLocation = Console.ReadLine();
            Console.Write("Enter Customer ID ");
            CustomerID = int.Parse(Console.ReadLine());

        }

        public void CreateRoom()
        {
            //DBconnection.OpenConnection();
            RoomsData();
            string AddRooms = "insert into Rooms " +
              "values('" + RoomNumber + "', '" + RoomType + "', '" + RatesRooms + "', '" + NumberBeds + "', '" + CustomerID + "')";

            int ctr = DBconnection.ExecuteQueries(AddRooms);
            if (ctr > 0)
                Console.WriteLine("\nNew Room added....\n");
            else
                Console.WriteLine("error");
            //DBconnection.CloseConnection();
        }

       

        public static void ShowAllRooms(int HotelUserInput)
        {
            Console.WriteLine("\nSHOWING ALL Rooms:\n");
            string[] val;
            var table = new ConsoleTable("Number Of Beds", "Rates");
            string showAllRooms = $"select RoomBedsNumber,RoomMoney from Room where RoomStatus = 'F'  and HotelID =" + HotelUserInput ;
            SqlDataReader reader = DataReader(showAllRooms);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    val = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                    table.AddRow(val[0], val[1]);
                }
                table.Write();
                Console.WriteLine();
            }
            else
                Console.WriteLine("No Records available in the database....\n");
        }

        public void ShowRoombyNum()
        {

        }

        public void DeleteRoom()
        {

        }
        #endregion

    }
}
