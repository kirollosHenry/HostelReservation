using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConsoleTables;



namespace HostelReservation.Classes
{
    class Bill: IBaseInterface
    {
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public int DaysNumber { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal Deposit { get; set; }

        public Bill(/*int billingId,*/ int customerId, int daysNumber, decimal roomCharge, decimal deposit)
        {
            // BillingId = billingId;
            CustomerId = customerId;
            DaysNumber = daysNumber;
            RoomCharge = roomCharge;
            Deposit = deposit;
        }
       

        public void Create(object CreateObj)
        {
            Bill bill=(Bill)CreateObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                    string query = "INSERT INTO Billing (CustomerId, DaysNumber, RoomCharge, Deposit) VALUES (@CustomerId, @DaysNumber, @RoomCharge, @Deposit)";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@DaysNumber", DaysNumber);
                        command.Parameters.AddWithValue("@RoomCharge", RoomCharge);
                        command.Parameters.AddWithValue("@Deposit", Deposit);
                        command.ExecuteNonQuery();
                    }
                }
            }
        
        public void Read(object ReadObj)
        {
            string[] val;
            var table = new ConsoleTable("Billing ID", "Customer ID", "DaysNumber", "Room charge","Deposit");
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string selectCustoers = "select *from Billing";
                using (SqlCommand command = new SqlCommand(selectCustoers, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            val = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                                val[i] = Convert.ToString(reader.GetValue(i));
                            table.AddRow(val[0], val[1], val[2], val[3], val[4]);
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
            Bill bill = (Bill)UpdateObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string query = "UPDATE Billing SET CustomerId = @CustomerId, DaysNumber = @DaysNumber, RoomCharge = @RoomCharge, Deposit = @Deposit WHERE BillingId = @BillingId";
                using (SqlCommand command = new SqlCommand(query, con))
                {

                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@DaysNumber", DaysNumber);
                    command.Parameters.AddWithValue("@RoomCharge", RoomCharge);
                    command.Parameters.AddWithValue("@Deposit", Deposit);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(object DeleteObj)
        {
            Bill bill = (Bill)DeleteObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string query = "DELETE FROM Bill WHERE BillingId = @BillingId";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@BillingId", BillingId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

