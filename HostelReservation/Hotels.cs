using ConsoleTables;
using System.Data.SqlClient;
using static HotelsClass.DBconnection;
namespace HotelseOOP
{

    public class Hotels
    {
       
        private static int HoteslID;
        private static string City;
        private static int Code;
        private static long phoneNumber;
       
        private static void InputHotelsInfo() 
        {

            Console.Write("Enter Hotels ID: ");
            HoteslID = int.Parse(Console.ReadLine());
            Console.Write("Enter Hotels City: ");
            City = Console.ReadLine();
            Console.Write("Enter Code of hotels : ");
            Code = int.Parse(Console.ReadLine());

            Console.Write("Enter Phone Number: ");
            phoneNumber = int.Parse(Console.ReadLine());

        }

        public static void AddHotels() 
        {
            OpenConnection();
            InputHotelsInfo();//InputHotelsInfo()
            string addHotelsQuery = "insert into Hotels ([hotel id], zipcode, city, [phone number]) " +
               "values('" + HoteslID + "', '" + Code + "', " +
               "'" + City + "', '" + phoneNumber + "')";

            int ctr = ExecuteQueries(addHotelsQuery);
            if (ctr > 0)
                Console.WriteLine("\nNew Hotel added....\n"); 
            CloseConnection();
        }

        public static void DeleteHotelByID(int HoteslID) 
        {

            OpenConnection();
            string deleteHotelbyId = "delete from Hotels where [hotel id] = '" + HoteslID + "'";
            int ctr = ExecuteQueries(deleteHotelbyId);
            if (ctr > 0)
                Console.WriteLine("\nHotel id: {0} deleted....\n", HoteslID);
            else
                Console.WriteLine("\nHotel id: {0} available in the database....\n", HoteslID);
            CloseConnection();
        }

        
        public static void ShowHotelsCount()
        {
            Console.WriteLine("Available Hotels: {0}\n", CountRecords().ToString());
        }

        public static void ShowAllHotels()
        {
            OpenConnection();
            Console.WriteLine("\nSHOWING ALL Hotels:\n");
            string[] val;
            var table = new ConsoleTable("[hotel id]", "zipcode", "City","[phone number]");
            string showAllHotels = "select [hotel id], zipcode, City, [phone number] from Hotels";
            SqlDataReader reader = DataReader(showAllHotels);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    val = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                    table.AddRow(val[0], val[1], val[2], val[3]);
                }
                table.Write();
                Console.WriteLine();
            }
            else
                Console.WriteLine("No Records available in the database....\n");
            CloseConnection();
        }

        public static void UpdateHotelsByID(int HotelsID) 
        {
            if (CheckPkExists(HotelsID))
            {
                GetHotelsDetails(HotelsID);
                InputHotelsInfo();
                OpenConnection();
                string updateHotelsbyId = "update Hotels set City = '" + City + "', zipcode = " +
                             "'" + Code + "',[phone number] = '" + phoneNumber + "' where [hotel id] = '" + HotelsID + "'";
                ExecuteQueries(updateHotelsbyId);
                Console.WriteLine("\nHotels id: {0} updated sucessfully....\n", HotelsID);
                CloseConnection();
            }
            else
                Console.WriteLine("\nHotels id: {0} does not exist in database....\n", HotelsID);
        }

        public static void GetHotelsDetails(int HotelsID)
        {
            OpenConnection();
            string[] val;
            string getBookDetails = "select [hotel id], City, zipcode, [phone number] FROM Hotels where [hotel id] = " +
                         "'" + HotelsID + "'";
            SqlDataReader reader = DataReader(getBookDetails);
            if (reader.HasRows)
            {
                val = new string[reader.FieldCount];
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        val[i] = Convert.ToString(reader.GetValue(i));
                }
                Console.WriteLine("\nCity: {0}", val[0]);
                Console.WriteLine("Code: {0}", val[1]);
                Console.WriteLine("PhoneNumber No.: {0}", val[2]);
                Console.WriteLine("Name No.: {0}", val[3]);

            }
            else
                Console.WriteLine("\nHotels id: {0} not availabe in the database....\n", HotelsID);
            CloseConnection();
        }

        public static int GetHotelsID()
        {
            Console.Write("Enter ID: ");
            int HotelsID = int.Parse(Console.ReadLine());
            return HotelsID;
        }

       
        



    }
}
