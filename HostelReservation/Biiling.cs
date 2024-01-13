using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostelReservation
{
    internal class Billing
    {
        #region Fields Of billing
        private int billingid;
        private decimal roomcharge;
        private decimal miscCharges;
        private int creditcardno;
        private char paymentdate;
        private int customerid;
        #endregion

        #region Properties Of billing
        //public int Billingid
        //{
        //    get { return billingid; }
        //    set { billingid = value; }
        //}

        //public decimal Roomcharge
        //{
        //    get { return roomcharge; }
        //    set { roomcharge = value; }
        //}

        //public decimal MiscCharge
        //{
        //    get { return miscCharges; }
        //    set
        //    {
        //        if (value > 0)
        //            miscCharges = value;
        //        else
        //            Console.WriteLine("Can not put Rates less than 0 ");
        //    }
        //}
        //public int Creditcardno
        //{
        //    get { return creditcardno; }
        //    set { creditcardno = value; }
        //}
        //public int paymentdate
        //{
        //    get { return paymentdate; }
        //    set
        //    {
        //        if (value > 0)
        //            paymentdate = value;
        //        else
        //            Console.WriteLine("Can not put Number less than 0 ");
        //    }

        #endregion

        #region Methods Of billing
        // public void billingData()
        //{
        //    Console.Write("Enter billing id: ");
        //    Billingid = int.Parse(Console.ReadLine());
        //    Console.Write("Enter room charge: ");
        //    roomcharge = Console.ReadLine();
        //    Console.Write("Enter misc charge: ");
        //    MiscCharges = decimal.Parse(Console.ReadLine());
        //    Console.Write("Enter credit card no: ");
        //    creditcardno = int.Parse(Console.ReadLine());
        //    Console.Write("Enter payment date: ");
        //    paymentdate = int.Parse(Console.ReadLine());
        //    Console.Write("Enter Customer ID ");
        //    CustomerID = int.Parse(Console.ReadLine());
        //}
        #endregion
    }

}
