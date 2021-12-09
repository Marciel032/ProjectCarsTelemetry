using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarsTelemetry
{    
    [Serializable]
    public struct CarParticipantTelemetry
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool IsActive;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = (int)StructLengths.STRING_LENGTH_MAX)]
        public String Name;                                    // [ string ]

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)VectorType.VEC_MAX)]
        public float[] WorldPosition;                          // [ UNITS = World Space  X  Y  Z ]

        public float CurrentLapDistance;                       // [ UNITS = Metres ]   [ RANGE = 0.0f->... ]    [ UNSET = 0.0f ]
        public uint RacePosition;                              // [ RANGE = 1->... ]   [ UNSET = 0 ]
        public uint LapsCompleted;                             // [ RANGE = 0->... ]   [ UNSET = 0 ]
        public uint CurrentLap;                                // [ RANGE = 0->... ]   [ UNSET = 0 ]
        public SectorType CurrentSector;
    }
}
