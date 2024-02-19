using Interfaces_ex02.Entities;

namespace Interfaces_ex02.Services
{
    internal class ContractService
    {
        private IOnlinePaymentService _OnlinePaymentService;
        public ContractService (IOnlinePaymentService onlinePaymentService)
        {
            _OnlinePaymentService = onlinePaymentService;
        }
        
        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime installmentDate = contract.Date.AddMonths(i);
                double simpleInterest = basicQuota + _OnlinePaymentService.Interest(basicQuota, i);
                double paymentFee = simpleInterest + _OnlinePaymentService.PaymentFee(simpleInterest);
                contract.Installments.Add(new Installment(installmentDate, paymentFee));
            }
        }
    }
}
