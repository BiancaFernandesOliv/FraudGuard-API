using FraudGuard.Entities;
using FraudGuard.Enums;

namespace FraudGuard.Interfaces {
    public interface IRiskAnalysisService {

        FraudRiskLevel DetermineRiskLevel(User user, Transaction transaction);
    }
}
