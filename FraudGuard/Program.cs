using FraudGuard.Entities;
using FraudGuard.Enums;
using FraudGuard.Services;

User user = new User("Bianca Fernandes", Guid.NewGuid(), FraudGuard.Enums.Country.Brazil);

RiskAnalysisService riskAnalysisService = new RiskAnalysisService();

user.UpdateName("Bianca Oliveira");
Console.WriteLine(user.Name);

user.UpdateCountry(FraudGuard.Enums.Country.Mexico);
Console.WriteLine(user.UsualCountry);

Transaction transaction = new Transaction(Guid.NewGuid(), Guid.NewGuid(), 2300, FraudGuard.Enums.Country.Brazil, DateTime.Now);

Console.WriteLine(transaction.IsHighValue());
Console.WriteLine(transaction.IsInternacional(user));
Console.WriteLine(transaction.OccurredAtSuspiciousTime());

FraudRiskLevel riskLevel = riskAnalysisService.DetermineRiskLevel(user, transaction);

Console.WriteLine(riskLevel);