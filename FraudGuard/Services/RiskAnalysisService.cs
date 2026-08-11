using FraudGuard.Entities;
using FraudGuard.Enums;

namespace FraudGuard.Services {
    public class RiskAnalysisService {

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
