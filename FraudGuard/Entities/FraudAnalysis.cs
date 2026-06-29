using FraudGuard.Enums;

namespace FraudGuard.Entities {
    internal class FraudAnalysis {

        public bool IsSuspicious { get; private set; }
        public FraudRiskLevel RiskLevel { get; private set; }
        public string Reason { get; private set; }

        public FraudAnalysis(bool isSuspicious, FraudRiskLevel riskLevel, string reason) {

            ValidateRiskLevel(riskLevel);
            ValidateReason(reason);            

            IsSuspicious = isSuspicious;
            RiskLevel = riskLevel;
            Reason = reason;
        }

        public void MarkAsSuspicious() {
            IsSuspicious = true;
        }

        public void MarkAsSafe() {
            IsSuspicious = false;
        }

        private void ValidateRiskLevel(FraudRiskLevel riskLevel) {
            if (!Enum.IsDefined(typeof(FraudRiskLevel), riskLevel)) throw new ArgumentException("Risk level is invalid.");
        }

        public void UpdateRiskLevel(FraudRiskLevel newRiskLevel) {

            if (RiskLevel == newRiskLevel) return;

            ValidateRiskLevel(newRiskLevel);
            RiskLevel = newRiskLevel;
        }

        private void ValidateReason(string reason) {
            if (string.IsNullOrWhiteSpace(reason) || reason.Trim().Length < 3) throw new ArgumentException("Reason is invalid.");
        }

        public void UpdateReason(string newReason) {
            if (Reason == newReason) return;

            ValidateReason(newReason);
            Reason = newReason;
        }
    }
}
