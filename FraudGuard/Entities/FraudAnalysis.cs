namespace FraudGuard.Entities {
    internal class FraudAnalysis {

        public bool IsSuspicious { get; private set; }
        public string RiskLevel { get; private set; }
        public string Reason { get; private set; }
        public string Teste { get; private set; }

        public FraudAnalysis(bool isSuspicious, string riskLevel, string reason, string teste) { 
            IsSuspicious = isSuspicious;
            RiskLevel = riskLevel;
            Reason = reason;
            Teste = teste;
        }

      
    }
}
