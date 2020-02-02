using System;
using tik4net.Objects;

namespace Sez23.TikExporter.Metrics
{
    public abstract class TikMetrics<TEntity, TMetric> : ITikMetrics<TEntity, TMetric>
    {

        public abstract TEntity Entity
        {
            get;
        }


        public abstract TMetric Read()
        {
            return null;
        }
    } 
}