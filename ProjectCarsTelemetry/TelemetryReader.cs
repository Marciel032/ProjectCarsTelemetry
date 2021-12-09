using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectCarsTelemetry
{
    public delegate void OnTelemetryRead(Telemetry telemetry);
    public class TelemetryReader
    {
        private Timer sharedMemoryRetryTimer;
        private Timer telemetryReadTimer;
        private MemoryMappedFile telemetryMemory;
        private readonly string mapName;

        public event OnTelemetryRead OnTelemetryRead;

        public TelemetryReader(string mapName = "Local\\$pcars$")
        {
            this.mapName = mapName;
            sharedMemoryRetryTimer = new Timer(2000);
            sharedMemoryRetryTimer.AutoReset = true;
            sharedMemoryRetryTimer.Elapsed += sharedMemoryRetryTimer_Elapsed;

            telemetryReadTimer = new Timer();
            telemetryReadTimer.AutoReset = true;
            telemetryReadTimer.Elapsed += TelemetryReadTimer_Elapsed;
            telemetryReadTimer.Interval = 10;
        }        

        public void Start()
        {
            sharedMemoryRetryTimer.Start();
        }

        public void Stop()
        {
            sharedMemoryRetryTimer.Stop();
            telemetryReadTimer.Stop();
        }

        private void sharedMemoryRetryTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                telemetryMemory = MemoryMappedFile.OpenExisting(mapName);

                telemetryReadTimer.Start();
                ProcessTelemetry();

                sharedMemoryRetryTimer.Stop();
            }
            catch (FileNotFoundException)
            {
                telemetryReadTimer.Stop();
            }
        }

        private void TelemetryReadTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (telemetryMemory == null)
                return;

            ProcessTelemetry();
        }

        private void ProcessTelemetry()
        {
            if (telemetryMemory == null)
                return;

            using (var stream = telemetryMemory.CreateViewStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    var size = Marshal.SizeOf(typeof(Telemetry));
                    var bytes = reader.ReadBytes(size);
                    var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                    try
                    {
                        var telemetry = (Telemetry)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Telemetry));
                        OnTelemetryRead?.Invoke(telemetry);
                    }
                    finally
                    {
                        handle.Free();
                    }                    
                }
            }
        }

    }
}
