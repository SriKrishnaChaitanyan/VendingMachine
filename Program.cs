using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            double InitialAmount = 0.0;
            double TotalAmount = 0.0;
            double FinalAmount = 0.0;

            string SelectedProductDesc = "";
            int Coins = 0;
            int SelectedProduct = 0;

            Amount objAmount = new Amount(10);
            InitialAmount = objAmount.GetInitialAmount();

            Console.WriteLine("Initial Amount is : {0}", InitialAmount);

            Console.WriteLine("Insert Coins (Nickels = 1 / Dimes = 2 / Quarters = 3)");
            Coins = Convert.ToInt16(Console.ReadLine());

            TotalAmount = objAmount.CalculateTotalAmount(Coins);
            Console.WriteLine("Total Amount is {0}", TotalAmount);

            Console.WriteLine("Select a Product ( Cola = 1 / Chips = 2 / Candy = 3 )");
            SelectedProduct = Convert.ToInt16(Console.ReadLine());

            Product objProduct = new Product();
            SelectedProductDesc = objProduct.GetProduct(SelectedProduct);
            Console.WriteLine(SelectedProductDesc);

            FinalAmount = Convert.ToDouble(objAmount.GetFinalAmount(SelectedProduct));
            Console.WriteLine("The Final Amount is : {0}", FinalAmount);

            Console.ReadLine();

        }
    }

    public class Product
    {
        private double _ProductTypeCola;
        private double _ProductTypeChips;
        private double _ProductTypeCandy;

        public Product()
        {
            _ProductTypeCola = 1.00;
            _ProductTypeChips = 0.50;
            _ProductTypeCandy = 0.65;
        }
        public string GetProduct(int SelectedProduct)
        {
            string _ProductDesc = "";

            if (SelectedProduct == 1)
            {
                _ProductDesc = "Selected Product is Cola and the Cost is : " + _ProductTypeCola;
            }
            else if (SelectedProduct == 2)
            {
                _ProductDesc = "Selected Product is Chips and the Cost is : " + _ProductTypeChips;
            }
            else if (SelectedProduct == 3)
            {
                _ProductDesc = "Selected Product is Candy and the Cost is : " + _ProductTypeCandy;
            }

            return _ProductDesc;
        }
    }
    public class Amount
    {
        private double _Initialamount;
        private double _TotalAmount;
        private double _FinalAmount;

        public Amount()
        {
            _Initialamount = 0.00;
        }
        public Amount(double Amount)
        {
            _Initialamount = Convert.ToDouble(Amount);
        }
        public void InsertAmount(double Amount)
        {
            _Initialamount = _Initialamount + Convert.ToDouble(Amount);
        }
        public double GetInitialAmount()
        {
            return Convert.ToDouble(_Initialamount);
        }
        public double CalculateTotalAmount(int Coins)
        {
            if (Coins == 1)
                _TotalAmount = _Initialamount + (1.0 * (1.0 / 20));
            else if (Coins == 2)
                _TotalAmount = _Initialamount + (1.0 * (1.0 / 10));
            else if (Coins == 3)
                _TotalAmount = _Initialamount + (1.0 * (1.0 / 4));
            else
            {
                _TotalAmount = _Initialamount;
            }
            return _TotalAmount;
        }
        public double GetFinalAmount(int ProductType)
        {
            if (ProductType == 1)
                _FinalAmount = _TotalAmount - 1.00;
            if (ProductType == 2)
                _FinalAmount = _TotalAmount - 0.50;
            if (ProductType == 3)
                _FinalAmount = _TotalAmount - 0.65;

            return _FinalAmount;
        }
    }
}
