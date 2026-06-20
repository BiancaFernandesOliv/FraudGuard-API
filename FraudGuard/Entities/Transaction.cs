namespace FraudGuard.Entities {
    internal class Transaction {

        public Guid TransactionId { get; private set; }
        public Guid UserId { get; private set; }
        public decimal TransactionValue { get; private set; }
        public string OriginCountry { get; private set; }
        public DateTime TransactionDateTime { get; private set; }

        public Transaction(Guid transactionId, Guid userId, decimal transactionValue, string originCountry, DateTime transactionDateTime) {
            TransactionId = transactionId;
            UserId = userId;
            TransactionValue = transactionValue;
            OriginCountry = originCountry;
            TransactionDateTime = transactionDateTime;
        }
    }
}
