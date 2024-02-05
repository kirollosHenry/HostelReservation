using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection.Emit;
using ConsoleTables;



namespace HostelReservation.Classes
{
    public class Reservation : IBaseInterface
    {
        #region fields
        private int RId;
        private DateTime checkIn;
        private DateTime checkout;
        private int RoomId;
        private int CustomerId;
        #endregion

        #region property
        public int ReservationId { get { return RId; } set { RId = value; } }
        public DateTime ReservationCheckIn  {get  {return checkIn; }  set { checkIn = value;}}
        public DateTime ReservationCheckOut { get {return checkout; } set { checkout = value; }}
        public int RoomID { get {return RoomId; } set { RoomId = value; } }
        public int CustomerID { get {return CustomerId; } set { CustomerId = value; } }
        #endregion


        #region crud operation
        public void Create(object obj)
        {
            Reservation reservation = new Reservation();
            reservation = (Reservation)obj;

            Reservation re = new Reservation();
            using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
            {
                bool isConnectionOpen = (connection.State == System.Data.ConnectionState.Open);
               
                string insertQuery = "INSERT INTO Reservation VALUES (@ReservationCheckIn," +
                    " @ReservationCheckOut," +
                    " @RoomID, @CustomerID)" +
                    ";UPDATE Room SET RoomStatus = 'U' WHERE RoomID = @RoomID; ";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@ReservationCheckIn", ReservationCheckIn);
                    command.Parameters.AddWithValue("@ReservationCheckOut", ReservationCheckOut);
                    command.Parameters.AddWithValue("@RoomID", RoomID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Read(object obj) {
            using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
            {
                string selectQuery = @"
            SELECT
                Reservation.ReservationID,
                Reservation.ReservationCheckIn,
                Reservation.ReservationCheckOut,
                Reservation.RoomID,
                
                Customer.CustomerFullName
            FROM
                Reservation
            JOIN
                Customer ON Reservation.CustomerID = Customer.CustomerID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var table = new ConsoleTable("ReservationID", "CheckIn", "CheckOut", "RoomID",  "CustomerFullName");

                        while (reader.Read())
                        {
                            int reservationID = (int)reader["ReservationID"];
                            DateTime checkIn = (DateTime)reader["ReservationCheckIn"];
                            DateTime checkOut = (DateTime)reader["ReservationCheckOut"];
                            int roomID = (int)reader["RoomID"];
                            
                            string customerFullName = reader["CustomerFullName"].ToString()!;

                            table.AddRow(reservationID, checkIn, checkOut, roomID, customerFullName);
                        }

                        table.Write();
                    }
                }
            }
        }

        //public void Read(object ReadObj)
        //{
        //    Reservation reservation = new Reservation();
        //    reservation = (Reservation)ReadObj;
        //    using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
        //    {
        //        string selectQuery = "SELECT * FROM Reservation";
        //        var table = new ConsoleTable("ReservationID", "CheckIn", "CheckOut", "RoomID", "CustomerID");
        //        using (SqlCommand command = new SqlCommand(selectQuery, connection))
        //        {
        //            connection.Open();

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int reservationID = (int)reader["ReservationID"];
        //                    reservation.ReservationCheckIn = (DateTime)reader["ReservationCheckIn"];
        //                    reservation.ReservationCheckOut = (DateTime)reader["ReservationCheckOut"];
        //                    reservation.RoomID = (int)reader["RoomID"];
        //                    reservation.CustomerID = (int)reader["CustomerID"];

        //                   // Console.WriteLine($"ReservationID: {reservationID}, CheckIn: {reservation.ReservationCheckIn}, CheckOut: {reservation.ReservationCheckOut}, RoomID: {reservation.RoomID}, CustomerID: {reservation.CustomerID}");
        //                    table.AddRow(reservationID, reservation.ReservationCheckIn, reservation.ReservationCheckOut, reservation.RoomID, reservation.CustomerID);
        //                }
        //            }
        //            table.Write();
        //        }
        //    }
        //}


        public  void ReadId(int id)
        {
            using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
            {
                string selectQuery = @"
            SELECT
                Reservation.ReservationID,
                Reservation.ReservationCheckIn,
                Reservation.ReservationCheckOut,
                Reservation.RoomID,
                
                Customer.CustomerFullName
            FROM
                Reservation
            JOIN
                Customer ON Reservation.CustomerID = Customer.CustomerID and Customer.CustomerID=@customerid ";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@customerid", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var table = new ConsoleTable("ReservationID", "CheckIn", "CheckOut", "RoomID", "CustomerFullName");

                        while (reader.Read())
                        {
                            int reservationID = (int)reader["ReservationID"];
                            DateTime checkIn = (DateTime)reader["ReservationCheckIn"];
                            DateTime checkOut = (DateTime)reader["ReservationCheckOut"];
                            int roomID = (int)reader["RoomID"];

                            string customerFullName = reader["CustomerFullName"].ToString()!;

                            table.AddRow(reservationID, checkIn, checkOut, roomID, customerFullName);
                        }

                        table.Write();
                    }
                }
            }
        }

        public void Update(object UpdateObj)
        {
            Reservation reservation = new Reservation();
            reservation = (Reservation)UpdateObj;

            using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
            {
                string updateQuery = "UPDATE Reservation SET ReservationCheckIn = @NewCheckIn, ReservationCheckOut =" +
                    " @NewCheckOut, " +
                    "RoomID = @NewRoomID," +
                    " CustomerID = @NewCustomerID " +
                    "WHERE ReservationID = @ReservationID";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@NewCheckIn", ReservationCheckIn);
                    command.Parameters.AddWithValue("@NewCheckOut", ReservationCheckOut);
                    command.Parameters.AddWithValue("@NewRoomID", RoomID);
                    command.Parameters.AddWithValue("@NewCustomerID", CustomerID);
                    command.Parameters.AddWithValue("@ReservationID", reservation.ReservationId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Reservation with ID {reservation.ReservationId} updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No reservation found with ID {reservation.ReservationId}.");
                    }
                }
            }
        }


        public void Delete(object DeleteObj)
        {
            Reservation re= new Reservation();
            re= (Reservation)DeleteObj;
            using (SqlConnection connection = new SqlConnection(Program.PublicConnectionString))
            {
                string deleteQuery = "DELETE FROM Reservation WHERE ReservationID = @ReservationID";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@ReservationID", re.ReservationId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Reservation with ID {re.ReservationId} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No reservation found with ID {re.ReservationId}.");
                    }
                }
            }
        }

        #endregion
    }
}
