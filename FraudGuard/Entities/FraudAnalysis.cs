using FraudGuard.Enums;

namespace FraudGuard.Entities {
    internal class FraudAnalysis {

        public bool IsSuspicious { get; private set; }
        public FraudRiskLevel RiskLevel { get; private set; }
        public string Reason { get; private set; }

        public FraudAnalysis(bool isSuspicious, FraudRiskLevel riskLevel, string reason) { 

            if (!Enum.IsDefined(riskLevel)) throw new ArgumentException("Risk level is invalid.");

            if (string.IsNullOrWhiteSpace(reason) || reason.Trim().Length < 3) throw new ArgumentException("Reason is invalid.");

            IsSuspicious = isSuspicious;
            RiskLevel = riskLevel;
            Reason = reason;
        }
    }
}
