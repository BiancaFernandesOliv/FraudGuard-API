namespace FraudGuard.Entities {
    internal class FraudAnalysis {

        public bool IsSuspicious { get; private set; }
        public string RiskLevel { get; private set; }
        public string Reason { get; private set; }

        public FraudAnalysis(bool isSuspicious, string riskLevel, string reason) { 

            if (string.IsNullOrEmpty(riskLevel)) throw new ArgumentException("Risk level is invalid.");

            if (string.IsNullOrEmpty(reason)) throw new ArgumentException("Reason is invalid.");

            IsSuspicious = isSuspicious;
            RiskLevel = riskLevel;
            Reason = reason;
        }
    }
}
