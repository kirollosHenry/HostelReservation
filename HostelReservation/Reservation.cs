using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace HostelReservation
{
    public  class Reservation
    {
        private DateOnly reservationCheckIn;
        private DateOnly reservationCheckOut;
        public static void InsertReservation()
        {   
                Console.WriteLine("Enter reservation details:");

                Console.Write("Room ID: ");
                int roomID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Customer ID: ");
                int customerID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Check-in date (yyyy-mm-dd): ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-out date (yyyy-mm-dd): ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=Somabay;Integrated Security=True"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Reservation VALUES (@ReservationCheckIn, @ReservationCheckOut, @RoomID, @CustomerID) " +
                    ";UPDATE Room SET RoomStatus = 't' WHERE RoomID = "+ roomID + "; ";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationCheckIn", checkInDate);
                    command.Parameters.AddWithValue("@ReservationCheckOut", checkOutDate);
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
