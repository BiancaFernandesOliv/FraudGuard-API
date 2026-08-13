using FraudGuard.Entities;
using FraudGuard.Enums;
using FraudGuard.Services;


User user = new User("Bianca Fernandes", Guid.NewGuid(), FraudGuard.Enums.Country.Brazil);

RiskAnalysisService riskAnalysisService = new RiskAnalysisService();

/*user.UpdateName("Bianca Oliveira");
Console.WriteLine(user.Name);

user.UpdateCountry(FraudGuard.Enums.Country.Mexico);
Console.WriteLine(user.UsualCountry);

Transaction transaction = new Transaction(Guid.NewGuid(), Guid.NewGuid(), 9800, FraudGuard.Enums.Country.Brazil, DateTime.MinValue);

/*Console.WriteLine(transaction.IsHighValue());
Console.WriteLine(transaction.IsInternacional(user));
Console.WriteLine(transaction.OccurredAtSuspiciousTime());

FraudRiskLevel riskLevel = riskAnalysisService.DetermineRiskLevel(user, transaction);

Console.WriteLine(riskLevel); */

FraudAnalysisService fraudAnalysisService = new FraudAnalysisService(riskAnalysisService);

Transaction transaction2 = new Transaction(Guid.NewGuid(), Guid.NewGuid(), 9800, FraudGuard.Enums.Country.Canada, DateTime.Now);

FraudAnalysis fraudAnalysis = fraudAnalysisService.Analyze(user, transaction2);

Console.WriteLine($"Is suspicious: {fraudAnalysis.IsSuspicious}");
Console.WriteLine($"Risk level: {fraudAnalysis.RiskLevel}");
Console.WriteLine($"Reason: {fraudAnalysis.Reason}");