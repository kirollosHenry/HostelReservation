using System.Data.SqlClient;
namespace HostelReservation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t \t ***** --- ***** Welcome to Soma Pay ***** --- *****");
            DBconnection.OpenConnection();
            Hotels.ShowAllHotels();
            DBconnection.CloseConnection();

            DBconnection.OpenConnection();
            Console.Write("Enter Hotel Id: ");
            int IdHotel = int.Parse(Console.ReadLine());
            Rooms.ShowAllRooms(IdHotel);
            DBconnection.CloseConnection();

            DBconnection.OpenConnection();
            Customer customer = new Customer();
            customer.CreateCustomerinDatabase();
            DBconnection.CloseConnection();
            Reservation.InsertReservation();
        }
    }
}
