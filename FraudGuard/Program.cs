using FraudGuard.Entities;
using FraudGuard.Enums;
using FraudGuard.Interfaces;
using FraudGuard.Services;

User user = new User("Bianca Fernandes", Guid.NewGuid(), Country.Brazil);

Transaction transaction = new Transaction(Guid.NewGuid(), user.Id, 9800, Country.Canada, DateTime.Now);

IRiskAnalysisService riskAnalysisService = new RiskAnalysisService();

FraudAnalysisService fraudAnalysisService = new FraudAnalysisService(riskAnalysisService);

FraudAnalysis fraudAnalysis = fraudAnalysisService.Analyze(user, transaction);

Console.WriteLine($"Is suspicious: {fraudAnalysis.IsSuspicious}");
Console.WriteLine($"Risk level: {fraudAnalysis.RiskLevel}");
Console.WriteLine($"Reason: {fraudAnalysis.Reason}");