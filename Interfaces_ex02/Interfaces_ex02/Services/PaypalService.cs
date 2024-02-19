using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_ex02.Services
{
    internal class PaypalService : IOnlinePaymentService
    {

        private const double MonthlyInterest = 0.01;
        private const double PaymentInterest = 0.02;

        public double Interest(double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }

        public double PaymentFee(double amount)
        {
            return PaymentInterest * amount;
        }
    }
}
