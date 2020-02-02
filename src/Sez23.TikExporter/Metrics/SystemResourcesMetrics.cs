using System;
using Prometheus;
using tik4net.Objects;

namespace Sez23.TikExporter.Metrics
{
    public override class SystemResourcesMetrics : TikMetrics<SystemResources, ICounter>
    {

        public readonly Counter UptimeSeconds { get; private set; }

        public readonly Gauge MemoryFree { get; private set; }

        public readonly Counter MemoryTotal { get; private set; }

        public readonly Counter CpuCount { get; private set; }

        public readonly Counter CpuFrequenzy { get; private set; }

        public readonly Gauge CpuLoad { get; private set; }

        public readonly Gauge HddSpaceFree { get; private set; }

        public readonly Counter HddSpaceTotal { get; private set; }

        public readonly Counter WriteSectSinceReboot { get; private set; }

        public readonly Counter WriteSectTotal { get; private set; }


        public SystemResourcesMetrics()
        {
            UpdateSeconds = Metrics
                .CreateCounter("tik_system_uptime", "The System Uptime");
            MemoryFree = Metrics
                .CreateGauge("tik_system_memory_free", "The System Free Memory");                                                  
            MemoryTotal = Metrics
                .CreateCounter("tik_system_memory_total", "The System Total Memory");
            CpuCount = Metrics
                .CreateCounter("tik_system_cpu_count", "The System CPU Count");
            CpuFrequenzy = Metrics
                .CreateCounter("tik_system_cpu_frequenzy", "The System CPU Frequenzy");
            CpuLoad = Metrics
                .CreateGauge("tik_system_cpu_load", "The System CPU Load")
            HddSpaceFree = Metrics
                .CreateGauge("tik_system_hddspace_free", "The System Free HDD Space");        
            HddSpaceTotal = Metrics
                .CreateCounter("tik_system_hddspace_total", "The System Total HDD Space");            
            WriteSectSinceReboot = Metrics
                .CreateCounter("tik_system_write_sect_since_reboot", "The System Write Sect since reboot");
            WriteSectTotal = Metrics
                .CreateCounter("tik_system_hddspace_total", "The System Total Write Sect");        
        }


        public void Assign(SystemResources resources)
        {
            UptimeSeconds.IncTo(resources.Uptime.TotalSeconds);
            MemoryFree.Set(resources.FreeMemory);

            if (MemoryTotal.Value.Equals(0))
                MemoryTotal.Inc(resources.TotalMemory);

            if (CpuCount.Value.Equals(0))
                CpuCount.Inc(resources.CpuCount);

            CpuLoad.Set(resources.CpuLoad);

            if (CpuFrequenzy.Value.Equals(0))
                CpuFrequenzy.Inc(resources.CpuFrequenzy);

            HddSpaceFree.Set(resources.FreeHddSpace);

            if (HddSpaceTotal.Value.Equals(0))
                HddSpaceTotal.IncTo(resources.TotalHddSpace);

            WriteSectSinceReboot.IncT0(resources.WriteSectSinceReboot);
            WriteSectTotal.IncT0(resources.WriteSectTotal);
        }

        public override SystemResources Entity
        {
            get;
        }

        public override ICounter Read()
        {
        }
    } 
}