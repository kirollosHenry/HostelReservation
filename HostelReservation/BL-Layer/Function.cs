using ConsoleTables;
using SomabaySystem.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation.Classes
{
    public class Function
    {
        #region customer functions

        public void CreateCustomer()
        {
            Customer customer = new Customer();
            
            customer.FullName = FunctionsValidation.ValidateString();
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine()!;
            //Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = FunctionsValidation.GetNumericInput("Enter Customer Phone Number:");
            customer.Create(customer);
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            //return customer;
        }
        public void SelectCustomer()
        {
            Customer customer = new Customer();
            customer.Read(customer);
        }
        public void UpdateCustomer()
        {
            Customer customer = new Customer();
            //Console.WriteLine("enter the customer Id ");
            customer.ID = FunctionsValidation.ValidationID();
            Console.Write("Enter Customer Name: ");
            customer.FullName = Console.ReadLine()!;
            Console.Write("Enter Customer City: ");
            customer.City = Console.ReadLine()!;
            //Console.Write("Enter Customer Phone Number: ");
            customer.Phonenumber = FunctionsValidation.GetNumericInput("Enter Customer Phone Number: ");
            customer.Update(customer);
        }
        public void DeleteCustomer()
        {
            Customer customer = new Customer();
            //Console.WriteLine("enter the customer id ");
            customer.ID = FunctionsValidation.ValidationID();
            customer.Delete(customer);
        }


        #endregion

        #region Rooms Functions
        public void CreateRoomOperation()
        {
            Rooms rooms = new Rooms();
            Console.Write("Enter Number Of Beds: ");
            rooms.NumberBeds = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Rates Of Room: ");
            rooms.RatesRooms = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Number Of Hotel: ");
            rooms.HotelId = FunctionsValidation.ValidationID();
            if(FunctionsValidation.DoesHotelExistValdition(rooms.HotelId))
            {
                rooms.Create(rooms);
                Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
            }
            else
                Console.WriteLine("\n*** -- ** Un Succusfully. Try Again ** -- ***\n");
        }

        public void ReadroomOperation()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = FunctionsValidation.ValidationID();
            if (FunctionsValidation.DoesHotelExistValdition(room.HotelId))
            {
                room.Read(room);
                Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
            }
            else
                Console.WriteLine("\n*** -- ** Un Succusfully. Try Again ** -- ***\n");
        }

        public void DeleteRoomOpertion()
        {
            Rooms room = new Rooms();
            Console.Write("Enter Hotel Number: ");
            room.HotelId = FunctionsValidation.ValidationID();
            if (FunctionsValidation.DoesHotelExistValdition(room.HotelId))
            {
                Console.Write("Enter Room Number: ");
                room.RoomId = FunctionsValidation.ValidationID();
                room.Delete(room);
                Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
            }
            else
                Console.WriteLine("\n*** -- ** Un Succusfully. Try Again ** -- ***\n");
        }

        public void UpdateRoomOperation()
        {
            Rooms room = new Rooms();

            Console.Write("Enter Hotel Number: ");
            room.HotelId = FunctionsValidation.ValidationID();
            if (FunctionsValidation.DoesHotelExistValdition(room.HotelId))
            {
                Console.Write("Enter Room Number: ");
                room.RoomId = FunctionsValidation.ValidationID();
                Console.Write("Enter Number Of Beds: ");
                room.NumberBeds = int.Parse(Console.ReadLine()!);
                Console.Write("Enter Rates Of Room: ");
                room.RatesRooms = decimal.Parse(Console.ReadLine()!);
                room.Update(room);

                Console.WriteLine("\n*** -- ** Succusfully ** -- ***\n");
            }
            else
                Console.WriteLine("\n*** -- ** Un Succusfully. Try Again ** -- ***\n");
        }
        #endregion

        #region Hotel Functionss
        public void CreateHotels()
        {
            Hotels h = new Hotels();

            Console.Write("Enter Hotel Name: ");
            h.Name = Console.ReadLine()!;
            Console.Write("Enter ZipCode of hotels : ");
            h.ZipCode = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Phone Number: ");
            h.PhoneNumber = Console.ReadLine()!;
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            h.Create(h);
        }

        public void SelectHotels()
        {
            Hotels hotels = new Hotels();
            hotels.Read(hotels);
        }

        public void UpdateeHotels()
        {
            Hotels H = new Hotels();
            Console.WriteLine("Enter The Hotel Id");
            H.ID = FunctionsValidation.ValidationID();

            FunctionsValidation.ValidationID();
            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                Console.WriteLine("Enter The Hotel name");
                H.Name = Console.ReadLine()!;
                Console.WriteLine("enter the hotel phone");
                H.PhoneNumber = Console.ReadLine()!;
                Console.WriteLine("enter the hotel zipcode");
                H.ZipCode = int.Parse(Console.ReadLine()!);
                H.Update(H);
            }
            else { Console.WriteLine("NOT existed"); }


        }

        public void deleteeHotels()
        {
            Hotels H = new Hotels();
            Console.WriteLine("Enter Hotels ID to delete it: ");
            H.ID = int.Parse(Console.ReadLine()!);
            if (FunctionsValidation.DoesHotelExistValdition(H.ID))
            {
                H.Delete(H);
                Console.WriteLine("Deleted Succefully");
            }
            else { Console.WriteLine("NOT existed"); }

        }

        #endregion

        #region Reservation Function
        public Reservation createReservation(int RoomId)
        {
            Reservation R = new Reservation();
            R.RoomID = RoomId;
            Console.Write("Enter Customer Id ");
            R.CustomerID = FunctionsValidation.ValidationID();
            string checkIn;        
             do
            {
                Console.Write("Enter CheckIn ");
                checkIn = Console.ReadLine()!;
            }
            while (!FunctionsValidation.CheckinValid(checkIn));
            if (DateTime.TryParse(checkIn, out DateTime dateValue))
                R.ReservationCheckIn = dateValue;
            string checkout;
            do
            {
                 
                Console.Write("Enter Checkout ");
                checkout = Console.ReadLine()!;
            }
            while (!FunctionsValidation.CheckoutValid(checkIn,checkout));
            
            if (DateTime.TryParse(checkout, out DateTime dateValue1))
                R.ReservationCheckOut = dateValue1;
            R.Create(R);
            Console.WriteLine(" *** -- Saved Sucessfuly -- ***");
            return R;
        }

        public void SelectReservation() //select all data from reservation and customer name 
        {
            Reservation Res = new Reservation();
            Res.Read(Res);
        }

        public void SelectResverationId()  //this function to get data for reservation for specicific  customer id 
        {
            Reservation re = new Reservation();
            Console.WriteLine("Enter the customer id ");
            int id = int.Parse(Console.ReadLine()!);
            re.ReadId(id);
        }

        public void UpdateReservation()
        {
            Reservation R = new Reservation();
            Console.WriteLine("Enter The reservation Id");
            R.ReservationId = int.Parse(Console.ReadLine()!);
            FunctionsValidation.ValidationID();
            Console.WriteLine("Enter The roome Id ");
            R.RoomID = int.Parse(Console.ReadLine()!);
            FunctionsValidation.ValidationID();
            Console.WriteLine("Enter check in ");
            string? s = Console.ReadLine();
            FunctionsValidation.CheckinValid(s!);

            Console.WriteLine("Enter The check out");
            string checkout = Console.ReadLine()!;
            FunctionsValidation.CheckoutValid(s!, checkout);
            Console.WriteLine("enter the hotel phone");
            R.CustomerID = int.Parse(Console.ReadLine()!);
            Console.WriteLine("enter the hotel zipcode");
            

        }
        #endregion

        #region Billing
        public void CreateBilling(Reservation obj)
        {
            decimal money;
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();

                string select = $"select RoomMoney from Room WHERE RoomID={obj.RoomID}";

                using (SqlCommand command = new SqlCommand(select, con))
                {
                    money = Convert.ToDecimal(command.ExecuteScalar());


                }
            }
            int numberofdays = obj.ReservationCheckOut.Day - obj.ReservationCheckIn.Day;
            decimal total = money * numberofdays;
            Console.WriteLine($"total Money = {total}");
            Console.WriteLine("Enter the amount of money you will ");
            decimal paied = decimal.Parse(Console.ReadLine()!);
            decimal deposit = total - paied;
            Console.WriteLine($" deposit ={deposit}");
            Bill bill = new Bill(obj.CustomerID, numberofdays, money, deposit);
            bill.Create(bill);
            string[] val;
            var table = new ConsoleTable("Billing ID", "Customer ID", "DaysNumber", "Room charge", "Deposit");

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string selectCustoers = $"select *from Billing where CustomerID={bill.CustomerId}";
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

        public void selectbilling(int id)
        {
            string[] val;
            var table = new ConsoleTable("Billing ID", "Customer ID", "DaysNumber", "Room charge", "Deposit");

            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string selectCustoers = $"select *from Billing where CustomerID={id}";
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
                            table.AddRow(val[0], val[1], val[2], val[3], val[4]);
                        }
                        table.Write();
                        Console.WriteLine();
                        Console.WriteLine("you have to pay your bill\n1)pay\n2)call 122");
                        int choice=int.Parse(Console.ReadLine()!);
                        switch (choice)
                        {
                            case 1:updatebilling(id);
                                Console.WriteLine(" paied suucessfully");
                                    break;
                            case 2: 
                                Console.Clear();
                                Console.WriteLine("\n \t \t \t *** -- Police is Calling -- ***\n");
                                break;
                        }
                                
                        }
                    else { Console.WriteLine("WE WISH TO VISIT US SOON ");  }
                }
                con.Close();
                Console.ReadKey();
            }

        }

        public void updatebilling(int id)
        {
            using (SqlConnection con = new SqlConnection(Program.PublicConnectionString))
            {
                con.Open();
                string query = $"update Billing set Deposit=0 where CustomerID={id};" +
                    $"UPDATE Room SET RoomStatus = 'U' from Customer C,Reservation Res,Room R WHERE C.CustomerId = Res.CustomerID and Res.RoomID = R.RoomID and C.CustomerId = {id};";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SelectAllBilling()
        {
            Console.WriteLine("****** -- All Billing -- *****");
            Bill bill = new Bill(0,0,0,0);
            bill.Read(bill);
        }

    }
}
        #endregion


