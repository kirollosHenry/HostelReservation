using System.Data.SqlClient;
namespace HostelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t \t \t \t  ***** --- ***** --- ***** --- ***** Welcome to Soma Pay ***** --- ***** --- ***** --- *****");
           
            DBconnection.OpenConnection();
            Hotels.ShowAllHotels();
            DBconnection.CloseConnection();

            Console.Write("Enter Hotel Id: ");
            int IdHotel = int.Parse(Console.ReadLine());    // Check User Ibput Correct Hotel Id
            if(DBconnection.CheckPkExists(IdHotel))
            {
                DBconnection.OpenConnection();
                Rooms.ShowAllRooms(IdHotel);
            }
            else
                Console.WriteLine("Incorect Hotel Id");
            DBconnection.CloseConnection();

            DBconnection.OpenConnection();
            Customer customer = new Customer();
            customer.CreateCustomerinDatabase();
            DBconnection.CloseConnection();
        }
    }
}
