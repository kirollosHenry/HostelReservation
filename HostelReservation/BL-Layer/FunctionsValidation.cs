using HostelReservation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomabaySystem.Classes
{
    internal class FunctionsValidation
    {
        #region Validation ID
        public static int ValidationID()
        {
            bool validID = false;
            int validatedID = 0;

            while (!validID)
            {
                Console.Write("Enter ID: ");
                string? userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int parsedValue))
                {
                    validatedID = parsedValue;
                    validID = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ID.");
                }
            }

            return validatedID;
        }
        #endregion

        #region checkinValidation
        public static bool CheckinValid(string date)
        {
            DateTime dateTime = DateTime.Now;
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split("/")[1]);
            int year = int.Parse(date.Split("/")[2]);
            if((year >= dateTime.Year) && (month >=dateTime.Month) && (day >= dateTime.Day))
                return true;
            return false;
        }
        public static bool CheckoutValid(string date,string checkout)
        {
            
            int day = int.Parse(date.Split('/')[0]);
            int month = int.Parse(date.Split("/")[1]);
            int year = int.Parse(date.Split("/")[2]);

            int dayOut = int.Parse(checkout.Split('/')[0]);
            int monthOut = int.Parse(checkout.Split("/")[1]);
            int yearOut = int.Parse(checkout.Split("/")[2]);
            if ((yearOut >=year ) && (monthOut >= month) && (dayOut >= day))
                return true;
            return false;
        }
        #endregion

        #region Hotel id validation
        public static bool DoesHotelExistValdition(int pk)
        {
            string connectionString = Program.PublicConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT TOP 1 1 FROM Hotel WHERE HotelId = @HotelId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HotelId", pk);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        #endregion

        #region validation the number 
        public static string GetNumericInput(string prompt)
        {
            bool flag= true;
            string? userInput;
            while (flag) 
            {
                Console.Write(prompt);
                userInput = Console.ReadLine();
                if (!IsNumeric(userInput))
                {
                    Console.WriteLine("Wrong phone the phone mustn't have any character or be more than 11 diget  ");
                }
                else if ((userInput == null))
                {
                    Console.WriteLine("Wrong phone the phone mustn't be empty  ");
                }
                else if (userInput.Length < 11)
                {
                    Console.WriteLine("Wrong phone the phone mustn't be less than 11 diget  ");
                }
                else
                {
                    flag = false;
                    return userInput;
                }
            }
            return "";
            
        }

        public static bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
        #endregion


        #region Name Validation
        public static string ValidateString()
        {
            bool validInput = false;
            string validatedString = string.Empty;

            while (!validInput)
            {
                Console.Write("Enter Name: ");
                string userInput = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(userInput) && !userInput.Any(char.IsDigit))
                {
                    validatedString = userInput;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid string without numbers or special characters.");
                }
            }

            return validatedString;
        }
        #endregion
    }
}