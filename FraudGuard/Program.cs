using FraudGuard.Entities;

User user = new User("Bianca Fernandes", Guid.NewGuid() , FraudGuard.Enums.Country.Brazil);

user.UpdateName("Bianca Oliveira");
Console.WriteLine(user.Name);

user.UpdateCountry(FraudGuard.Enums.Country.Mexico);
Console.WriteLine(user.UsualCountry);

Transaction transaction = new Transaction(Guid.NewGuid(), Guid.NewGuid(), 9800, FraudGuard.Enums.Country.Canada, DateTime.MinValue);

Console.WriteLine(transaction.IsHighValue());
Console.WriteLine(transaction.IsInternacional(user));
Console.WriteLine(transaction.OccurredAtSuspiciousTime());