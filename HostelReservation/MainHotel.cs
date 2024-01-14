//using System;
//using HotelseOOP;
//using static System.Console;
//using static HotelseOOP.Hotels;

//namespace ReservationOOP
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            do
//            {
//                Write("Enter your operation: \n");
//                Console.WriteLine("1: for Add New Hotel Details\n" + "2: for Delete hotel record\n" + "3: for Hotel Details\n" +
//                    "4: for count of hotels\n"+"5: for Show all Hotels\n" + "6: for Ubdate Hotel Record\n" + "7: for Clear\n"+"8: for exit ");
//                int op1 = int.Parse(ReadLine());

//                switch (op1)
//                {
//                    case 1:
//                        WriteLine("\nADD Hotels:");
//                        AddHotels();
//                        break;
//                    case 2:
//                        WriteLine("\nDELETE Hotel: ");
//                        DoDeletehotel();
//                        break;
//                    case 3:
//                        WriteLine("\nHotel DETAILs: ");
//                        GetHotelsDetails(GetHotelsID());
//                        break;
//                    case 4:
//                        WriteLine("\nHotels COUNT: ");
//                        ShowHotelsCount();
//                        break;
//                    case 5:
//                        ShowAllHotels();
//                        break;
//                    case 7:
//                        Clear();
//                        break;
//                    case 6:
//                        WriteLine("\nUPDATE Hotel RECORD:\n");
//                        UpdateHotelsByID(GetHotelsID());
//                        break;
//                    case 8:
                        
//                        return;
//                        break;
                    
//                    default:
//                        WriteLine("Invalid operation. Enter again....");
//                        break;
//                }

//            } while (true);
//        }

        

//        static void DoDeletehotel()
//        {
//            WriteLine("\nDELETE Hotel: ");
//            do
//            {
//                Write("Enter your operation: \n");
//                Console.WriteLine("1: for Delete hotels by Id\n"+"2: for Exit ");
//                int op2 = int.Parse(ReadLine());

//                switch (op2)
//                {
//                    case 1:
//                        WriteLine("\nDELETE Hotels BY ID:\n");
//                        DeleteHotelByID(GetHotelsID());
//                        break;
//                    case 2:
//                        return;
//                    default:
//                        WriteLine("Invalid operation. Enter again....");
//                        break;
//                }

//            } while (true);
//        }
//    }
//}
