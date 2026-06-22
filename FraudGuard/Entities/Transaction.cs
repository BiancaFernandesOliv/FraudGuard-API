using FraudGuard.Enums;

namespace FraudGuard.Entities {
    internal class Transaction {

        public Guid TransactionId { get; private set; }
        public Guid UserId { get; private set; }
        public decimal TransactionValue { get; private set; }
        public Country OriginCountry { get; private set; }
        public DateTime TransactionDateTime { get; private set; }

        public Transaction(Guid transactionId, Guid userId, decimal transactionValue, Country originCountry, DateTime transactionDateTime) {

            if (transactionId == Guid.Empty) throw new ArgumentException("Transaction id is invalid.");

            if (userId == Guid.Empty) throw new ArgumentException("User id is invalid.");

            if (transactionValue <= 0) throw new ArgumentException("Transaction value must be greater than zero.");

            if (!Enum.IsDefined(typeof(Country), originCountry)) throw new ArgumentException("Origin country is invalid.");

            if (transactionDateTime > DateTime.Now) throw new ArgumentException("Transaction date cannot be later than the current date!");

            TransactionId = transactionId;
            UserId = userId;
            TransactionValue = transactionValue;
            OriginCountry = originCountry;
            TransactionDateTime = transactionDateTime;
        }
    }
}
