using System;

namespace UaiseCoin.Model
{
    public class Transaction
    {
        public Guid Sender { get; private set; }
        public Guid Receiver { get; private set; }
        public decimal Amount { get; private set; }

        public Transaction(Guid sender, Guid receiver, decimal amount)
        {
            Sender = sender;
            Receiver = receiver;
            Amount = amount;
        }
    }
}