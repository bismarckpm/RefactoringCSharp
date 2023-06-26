using System.Collections.Generic;

namespace CSharpRefactorings.DiscountManager.Refactored
{
    public class DiscountManager
    {
        private readonly int m_MaxLoyaltyDiscount;
        private readonly IDictionary<Customer, decimal> m_CustomerDiscounts;
        private const decimal zeroPercent = 0;
        private const decimal tenPercent = 0.1M;
        private const decimal thirtyPercent = 0.3M;
        private const decimal fiftyPercent = 0.5M;

        public DiscountManager() : this(
            new Dictionary<Customer, decimal>
            {
                {Customer.NotRegistered, zeroPercent},
                {Customer.SimpleCustomer, tenPercent},
                {Customer.ValuableCustomer, thirtyPercent},
                {Customer.MostValuableCustomer, fiftyPercent}
            }, 5)
        {
        }

        public DiscountManager(IDictionary<Customer, decimal> customerDiscounts, int maxLoyaltyDiscount)
        {
            m_CustomerDiscounts = customerDiscounts;
            m_MaxLoyaltyDiscount = maxLoyaltyDiscount;
        }

        public decimal ApplyDiscount(decimal price, Customer customer, int loyaltyInYears)
        {
            decimal priceAfterDiscount = ApplyCustomerDiscount(price, customer);
            return ApplyLoyaltyDiscount(priceAfterDiscount, loyaltyInYears);
        }

        private decimal ApplyCustomerDiscount(decimal price, Customer customer)
        {
            if (!m_CustomerDiscounts.ContainsKey(customer)) return price;
            return price - m_CustomerDiscounts[customer] * price;
        }

        private decimal ApplyLoyaltyDiscount(decimal price, int loyalty)
        {
            decimal discount = loyalty > m_MaxLoyaltyDiscount ? (decimal)m_MaxLoyaltyDiscount / 100 : (decimal)loyalty / 100;
            return price - discount * price;
        }
    }
}
