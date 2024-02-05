using HostelReservation;
using HostelReservation.Classes;
using SomabaySystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomabaySystem.Admin_VS_Receptionist
{
    internal class Admin
    {
        public void AdminOptions()
        {
            Console.WriteLine("How can I help you today?");
            Console.WriteLine();

            Console.WriteLine("1..Hotels");
            Console.WriteLine("2..Rooms");
            Console.WriteLine("3..Customers");
            Console.WriteLine("4..Reservations");
            Console.WriteLine("5..Billing");
            Console.WriteLine("6..Exit");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            AdminOption adminOption = (AdminOption)int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("*** -- *** -- ***");
            switch (adminOption)
            {
                case AdminOption.Hotels:
                    HotelDisplay();
                    break;

                case AdminOption.Rooms:
                    RoomDisplay();
                    break;

                case AdminOption.Customers:
                    CustomerDisplay();
                    break;

                case AdminOption.Reservation:
                    ReservationDisplay();
                    break;

                case AdminOption.Billing:
                    BillingDisplay();
                    break;

                case AdminOption.Exit:
                    Console.Clear();
                    Welcome welcome = new Welcome();
                    welcome.WelcomeMethod();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    break;
            }
        }

        void HotelDisplay()
        {
            Console.WriteLine("Welcome to Hotels: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Hotels.");
            Console.WriteLine("2..Create New Hotel.");
            Console.WriteLine("3..Update Hotel.");
            Console.WriteLine("4..Delete Hotel");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option hotelOption = (Option)int.Parse(Console.ReadLine());
            Console.WriteLine("*** -- *** -- ***");
            switch (hotelOption)
            {
                case Option.Read:
                    function.SelectHotels();
                    Console.WriteLine("\n");
                    HotelDisplay();
                    break;

                case Option.Create:
                    function.CreateHotels();
                    Console.WriteLine("\n");
                    HotelDisplay();
                    break;

                case Option.Update:
                    function.UpdateeHotels();
                    Console.WriteLine("\n");
                    HotelDisplay();
                    break;

                case Option.Delete:
                    function.deleteeHotels();
                    Console.WriteLine("\n");
                    HotelDisplay();
                    break;

                case Option.Back:
                    AdminOptions();
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    break;
            }
        }

        void RoomDisplay()
        {
            Console.WriteLine("Welcome to Rooms: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Rooms.");
            Console.WriteLine("2..Create New Room.");
            Console.WriteLine("3..Update Room.");
            Console.WriteLine("4..Delete Room");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option roomOption = (Option)int.Parse(Console.ReadLine());
            Console.WriteLine("*** -- *** -- ***");

            switch (roomOption)
            {
                case Option.Read:
                    function.ReadroomOperation();
                    Console.WriteLine("\n");
                    RoomDisplay();
                    break;

                case Option.Create:
                    function.CreateRoomOperation();
                    Console.WriteLine("\n");
                    RoomDisplay();
                    break;

                case Option.Update:
                    function.UpdateRoomOperation();
                    Console.WriteLine("\n");
                    RoomDisplay();
                    break;

                case Option.Delete:
                    function.DeleteRoomOpertion();
                    Console.WriteLine("\n");
                    RoomDisplay();
                    break;

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

            }
        }

        void CustomerDisplay()
        {
            Console.WriteLine("Welcome to Customers: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Customers.");
            Console.WriteLine("2..Create New Customer.");
            Console.WriteLine("3..Update Customers.");
            Console.WriteLine("4..Delete Customers");
            Console.WriteLine("5..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option CustomerOption = (Option)int.Parse(Console.ReadLine());
            Console.WriteLine("*** -- *** -- ***");
            switch (CustomerOption)
            {
                case Option.Read:
                    function.SelectCustomer();
                    Console.WriteLine("\n");
                    CustomerDisplay();
                    break;

                case Option.Create:
                    function.CreateCustomer();
                    Console.WriteLine("\n");
                    CustomerDisplay();
                    break;

                case Option.Update:
                    function.UpdateCustomer();
                    Console.WriteLine("\n");
                    CustomerDisplay();
                    break;

                case Option.Delete:
                    function.DeleteCustomer();
                    Console.WriteLine("\n");
                    CustomerDisplay();
                    break;

                case Option.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }

        void ReservationDisplay()
        {
            Console.WriteLine("Welcome to Reservations: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Reservations.");
            Console.WriteLine("2..Show Reservation By ID .");
            Console.WriteLine("3..Update Reservation");
            Console.WriteLine("4..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option2 ReservationOption = (Option2)int.Parse(Console.ReadLine()!);
            Console.WriteLine("*** -- *** -- ***");
            switch (ReservationOption)
            {
                case Option2.ReadAll:
                    function.SelectReservation();
                    Console.WriteLine("\n");
                    ReservationDisplay();
                    break;

                case Option2.ReadByID:
                    function.SelectResverationId();
                    Console.WriteLine("\n");
                    ReservationDisplay();
                    break;

                case Option2.Update:
                    function.UpdateReservation();
                    Console.WriteLine("\n");
                    ReservationDisplay();
                    break;

                case Option2.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }

        void BillingDisplay()
        {
            Console.WriteLine("Welcome to Billing: ");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.WriteLine("1..Show All Billings.");
            Console.WriteLine("2..Show Billing By ID");
            Console.WriteLine("3..Update Billings.");
            Console.WriteLine("4..Back..");
            Console.WriteLine("*** -- *** -- ***");
            Console.WriteLine();
            Console.Write("Your Chooice: ");
            Function function = new Function();
            Option2 BillingOption = (Option2)int.Parse(Console.ReadLine());
            Console.WriteLine("*** -- *** -- ***");
            switch (BillingOption)
            {
                case Option2.ReadAll:
                    function.SelectAllBilling();
                    Console.WriteLine("\n");
                    BillingDisplay();
                    break;

                case Option2.ReadByID:
                    int Id = FunctionsValidation.ValidationID();
                    function.selectbilling(Id);
                    Console.WriteLine("\n");
                    BillingDisplay();
                    break;

                case Option2.Update:
                    int IdUpdate = FunctionsValidation.ValidationID();
                    function.updatebilling(IdUpdate);
                    Console.WriteLine("\n");
                    BillingDisplay();
                    break;

                case Option2.Back:
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Try Again");
                    AdminOptions();
                    Console.WriteLine("*** -- *** -- ***");
                    break;
            }
        }
    }
}
