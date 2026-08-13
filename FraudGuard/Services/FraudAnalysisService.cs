using FraudGuard.Entities;
using FraudGuard.Enums;
using FraudGuard.Interfaces;

namespace FraudGuard.Services {
    public class FraudAnalysisService {

        private readonly IRiskAnalysisService _riskAnalysisService;

        public FraudAnalysisService(IRiskAnalysisService riskAnalysisService) {
            _riskAnalysisService = riskAnalysisService;
        }

        public FraudAnalysis Analyze(User user, Transaction transaction) {

            FraudRiskLevel riskLevel = _riskAnalysisService.DetermineRiskLevel(user, transaction);

            bool isSuspicious = riskLevel != FraudRiskLevel.Low;

            string reason = DetermineReason(user, transaction, riskLevel);

            return new FraudAnalysis(isSuspicious, riskLevel, reason);
        }

        private string DetermineReason(User user, Transaction transaction, FraudRiskLevel riskLevel) {

            if (riskLevel == FraudRiskLevel.Low) {
                return "No suspicious behavior detected.";
            }

            if (riskLevel == FraudRiskLevel.Medium) {

                if (transaction.IsInternational(user) && transaction.IsHighValue()) {
                    return "High value international transaction.";
                }
                else if (transaction.IsInternational(user) && transaction.OccurredAtSuspiciousTime()) {
                    return "International transaction at suspicious time.";
                }
                else if (transaction.IsInternational(user)) {
                    return "International transaction.";
                }
                else if (transaction.IsHighValue() && transaction.OccurredAtSuspiciousTime()) {
                    return "High value transaction at suspicious time.";
                }
                else if (transaction.IsHighValue()) {
                    return "High value transaction.";
                }
                else {
                    return "Transaction at suspicious time.";
                }
            }

            if (riskLevel == FraudRiskLevel.High) {
                return "High value international transaction at suspicious time.";
            }

            throw new ArgumentOutOfRangeException(nameof(riskLevel), riskLevel, "Invalid risk level.");
        }

    }
}