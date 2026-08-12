using FraudGuard.Entities;
using FraudGuard.Enums;

namespace FraudGuard.Services {
    public class FraudAnalysisService {

        private readonly RiskAnalysisService _riskAnalysisService;

        public FraudAnalysisService(RiskAnalysisService riskAnalysisService) {
            _riskAnalysisService = riskAnalysisService;
        }

        public FraudAnalysis Analyze(User user, Transaction transaction) {

            FraudRiskLevel riskLevel = _riskAnalysisService.DetermineRiskLevel(user, transaction);

            bool isSuspicious = riskLevel != FraudRiskLevel.Low;

            string reason;

            if (isSuspicious) {

                if (riskLevel == FraudRiskLevel.High) {
                    reason = "High value international transaction at suspicious time.";
                }
                else {
                    if(transaction.IsInternacional(user) && transaction.IsHighValue()) {
                        reason = "High value international transaction.";
                    } 
                    else if(transaction.IsInternacional(user) && transaction.OccurredAtSuspiciousTime()) {
                        reason = "International transaction at suspicious time.";
                    }
                    else if(transaction.IsInternacional(user)) {
                        reason = "International transaction.";
                    }
                    else if(transaction.IsHighValue() && transaction.OccurredAtSuspiciousTime()) {
                        reason = "High value transaction at suspicious time.";
                    } 
                    else if (transaction.IsHighValue()) {
                        reason = "High value transaction.";
                    } 
                    else {
                        reason = "Transaction at suspicious time.";
                    }
                }
            } 
            else {
                reason = "No suspicious behavior detected.";
            }
            return new FraudAnalysis(isSuspicious, riskLevel, reason);
        }

    }
}