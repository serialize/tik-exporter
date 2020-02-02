using System;
using Prometheus;
using tik4net.Objects;

namespace Sez23.TikExporter.Metrics
{
    public override class SystemIdentityMetrics : TikMetrics<SystemIdentity, ICounter>
    {
        public override SystemIdentity Entity
        {
            get;
        }

        public override ICounter Read()
        {

            var counter =  Metrics.CreateCounter("tik_system_identity", 
                                                 "The System Identity.",
                                                 new CounterConfiguration
                                                 {
                                                     SuppressInitialValue = true,
                                                     LabelNames = new[] { Entity.Name }
                                                 });

            counter.WithLabels(Entity.Name).Inc();
            return counter;
        }
    } 
}