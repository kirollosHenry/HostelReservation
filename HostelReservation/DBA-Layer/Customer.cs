using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace HostelReservation.Classes
{
    internal class Customer : IBaseInterface
    {
        //fields
        private int id;
        //private static int nextId = 1;
        private string? fullName;
        private string ?city;
        private string ?phonenumber;

        //props
        public int ID { get { return id; } set { id = value; } }

        public string? FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        public string? City
        {
            get { return city; }
            set { city = value; }
        }
        public string? Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }


        //method
        //public static int Generateid()
        //{
        //    return nextId++;
        //}
       
        public void Create(object CreateObj)
        {
            Customer customer = new Customer();
            customer = (Customer)CreateObj;


            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string addCustomerQuery = "INSERT INTO Customer  VALUES (@FullName, @City, @Phonenumber); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(addCustomerQuery, con))
                {
                    command.Parameters.AddWithValue("@FullName", customer.FullName);
                    command.Parameters.AddWithValue("@City", customer.City);
                    command.Parameters.AddWithValue("@Phonenumber", customer.phonenumber);

                    int customerId = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("Customer ID: " + customerId);
                    
                }
            }
        }

        public void Read(object ReadObj)
        {
            string[] val;
            var table = new ConsoleTable("Customer ID", "Customer Name","City" ,"Phone Number");
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string selectCustoers = "select *from Customer";
                using (SqlCommand command = new SqlCommand(selectCustoers, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            val = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                                val[i] = Convert.ToString(reader.GetValue(i))!;
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
            string[] val;
            var table = new ConsoleTable("Customer ID", "Customer Name", "City", "Phone Number");
            Customer customer = new Customer();
            customer = (Customer)UpdateObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string updateCustomer = $"update Customer set CustomerFullName='{customer.FullName}',CustomerCity='{customer.City}',CustomerPhone='{customer.Phonenumber}' where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(updateCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Updated successfull");
                    reader.Close();
                }
                
                string select = $"select * from Customer where CustomerId = {customer.ID}";
                using (SqlCommand command1 = new SqlCommand(select, con))
                {
                    SqlDataReader sqlDataReader = command1.ExecuteReader();
                    if (sqlDataReader.HasRows) { 
                        while (sqlDataReader.Read())
                        {
                            val = new string[sqlDataReader.FieldCount];
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                                val[i] = Convert.ToString(sqlDataReader.GetValue(i))!;
                            table.AddRow(val[0], val[1], val[2], val[3]);
                        }
                        table.Write();
                        Console.WriteLine();
                    }
                    else { Console.WriteLine("not updated"); }
                }
                con.Close();
            }
        }



        public void Delete(object DeleteObj)
        {
            Customer customer = new Customer();
            customer = (Customer)DeleteObj;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string deleteCustomer = $"delete from Customer where CustomerId={customer.ID}";
                using (SqlCommand command = new SqlCommand(deleteCustomer, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("**********Deleted successfull");
                }
                con.Close();
            }
        }


    }
}
