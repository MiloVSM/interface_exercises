using System;
using System.Diagnostics;
using System.Globalization;
using Interfaces_ex02.Entities;
using Interfaces_ex02.Services;

namespace Interfaces_ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract Value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int installmentsAmount = int.Parse(Console.ReadLine());

            Contract newContract = new Contract(contractNumber, contractDate, contractValue);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(newContract, installmentsAmount);

            Console.WriteLine("Installments:");
            foreach(Installment i in newContract.Installments)
            {
                Console.WriteLine(i);
            }

        }
    }
}