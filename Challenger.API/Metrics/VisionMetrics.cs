using System.Diagnostics.Metrics;

namespace Challenger.API.Metrics
{
    public static class VisionMetrics
    {
        public static readonly Meter Meter = new("Challenger.Vision", "1.0.0");
        
        public static readonly Counter<int> VisionRequests =
            Meter.CreateCounter<int>("vision_requests_total");
        
        public static readonly Histogram<double> VisionAnalysisDuration =
            Meter.CreateHistogram<double>("vision_analysis_duration_ms");
    }
}