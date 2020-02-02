using System;

namespace Sez23.TikExporter.Metrics
{
    public interface ITikMetrics<TEntity, TMetric>
    {
        TEntity Entity
        {
            get;
        }

        TMetric Read();
    } 
}