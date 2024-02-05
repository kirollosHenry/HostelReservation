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
    internal class Reseption
    {
        Hotels hotel=new Hotels();
        Rooms room=new Rooms();
        Customer customer=new Customer();
        Reservation reservation=new Reservation();
        Function function=new Function();
        public void ReseptionOptions()
        {
            Console.Clear();
            Console.WriteLine("How can I help you today?");
            Console.WriteLine(" 1 checkin \n 2 checkout");
            int choice=int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:Checkin(); ReseptionOptions(); break;
                case 2:Checkout(); ReseptionOptions(); break;
                default:
                    Console.Clear();
                    ReseptionOptions();
                    break;
            }

        }
        public void Checkin()
        {
            function.SelectHotels();
            function.ReadroomOperation();
            Console.Write("Enter Room Number: ");
            room.RoomId= FunctionsValidation.ValidationID();
            function.CreateCustomer();
            reservation=function.createReservation(room.RoomId);
            function.CreateBilling(reservation);
            //function.billing finction to create;
            // function to show bill after create
            Console.WriteLine("****checkin successfully  Welcome To Our Hotel");
            Console.ReadKey();

        }
        public void Checkout()
        {
            int id=FunctionsValidation.ValidationID();
            function.selectbilling(id);
        }














    }
}
