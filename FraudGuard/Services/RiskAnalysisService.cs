using FraudGuard.Entities;
using FraudGuard.Enums;
using FraudGuard.Interfaces;

namespace FraudGuard.Services {
    public class RiskAnalysisService : IRiskAnalysisService {

        public FraudRiskLevel DetermineRiskLevel(User user, Transaction transaction) {

            if (transaction.IsHighValue() && transaction.IsInternacional(user) && transaction.OccurredAtSuspiciousTime()) {
                return FraudRiskLevel.High;
            }
            else if (transaction.IsHighValue() || transaction.IsInternacional(user) || transaction.OccurredAtSuspiciousTime()) {
                return FraudRiskLevel.Medium;
            }
            else {
                return FraudRiskLevel.Low;
            }
        }
    }
}