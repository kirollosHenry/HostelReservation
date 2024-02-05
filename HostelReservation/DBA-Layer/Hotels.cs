using ConsoleTables;
using System.Data.SqlClient;
namespace HostelReservation.Classes
{

    public class Hotels : IBaseInterface
    {
        #region Fields
        private static int HotelId;
        private static string? HotelName;
        private static string? HotelPhone;
        private static int HotelZipCode;
        #endregion

        #region Property of Hotel
        public int ID { get { return HotelId; } set { HotelId = value; } }
        public string Name { get { return HotelName!; } set { HotelName = value; } }
        public int ZipCode { get { return HotelZipCode; } set { HotelZipCode = value; } }
        public string PhoneNumber { get { return HotelPhone!; } set { HotelPhone = value; } }
        #endregion


        #region Crud Function
        public void Create(object CreateObj)
        {
            Hotels hotels = new Hotels();
            hotels = (Hotels)CreateObj;


            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string addhotelQuery = "INSERT INTO Hotel  VALUES (@HotelName, @HotelPhone, @HotelZipCode); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addhotelQuery, con))
                {
                    command.Parameters.AddWithValue("@HotelName", hotels.Name);
                    command.Parameters.AddWithValue("@HotelPhone", hotels.PhoneNumber);
                    command.Parameters.AddWithValue("@HotelZipCode", hotels.ZipCode);

                    int hotelsId = Convert.ToInt32(command.ExecuteScalar());

                }
            }
        }

        public void Read(object ReadObj)
        {
            string[] val;
            var table = new ConsoleTable("Hotel ID", "Hotel Name", "Phone Number", "ZipCode");
            string showAllHotels = "select * from Hotel";
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(showAllHotels, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
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
                    else { Console.WriteLine("NO rows existed"); }
                }
                con.Close();
            }
        }

        public void Update(object UpdateObj)
        {

            Hotels hotel = new Hotels();
            hotel = (Hotels)UpdateObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string updatehotel = $"update Hotel set HotelName='{hotel.Name}',HotelPhone='{hotel.PhoneNumber}',HotelZipCode='{hotel.ZipCode}' where HotelId={hotel.ID}";
                using (SqlCommand command = new SqlCommand(updatehotel, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("***Updated successfull******");
                    reader.Close();
                }

                con.Close();
            }
        }

        public void Delete(object DeleteObj)
        {

            Hotels hotel = new Hotels();
            hotel = (Hotels)DeleteObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string deletehotel = $"delete from Hotel where HotelId={hotel.ID}";
                using (SqlCommand command = new SqlCommand(deletehotel, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("****Deleted successfull******");
                }
                con.Close();
            }

        }
        #endregion 
    }
}
