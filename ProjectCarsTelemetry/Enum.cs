using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCarsTelemetry
{
    public enum StructLengths
    {
        STRING_LENGTH_MAX = 64,
        NUM_PARTICIPANTS = 64
    }

    public enum VectorType
    {
        VEC_X,
        VEC_Y,
        VEC_Z,
        //-------------
        VEC_MAX
    }

    public enum TyresType: uint
    {
        TYRE_FRONT_LEFT,
        TYRE_FRONT_RIGHT,
        TYRE_REAR_LEFT,
        TYRE_REAR_RIGHT,
        //--------------
        TYRE_MAX
    }

    public enum GameType: uint
    {
        GAME_EXITED,
        GAME_FRONT_END,
        GAME_INGAME_PLAYING,
        GAME_INGAME_PAUSED,
        //-------------
        GAME_MAX
    };

    public enum SessionType: uint
    {
        SESSION_INVALID = 0,
        SESSION_PRACTICE,
        SESSION_TEST,
        SESSION_QUALIFY,
        SESSION_FORMATION_LAP,
        SESSION_RACE,
        SESSION_TIME_ATTACK,
        //-------------
        SESSION_MAX
    };

    public enum RaceStateType: uint
    {
        RACESTATE_INVALID,
        RACESTATE_NOT_STARTED,
        RACESTATE_RACING,
        RACESTATE_FINISHED,
        RACESTATE_DISQUALIFIED,
        RACESTATE_RETIRED,
        RACESTATE_DNF,
        //-------------
        RACESTATE_MAX
    };

    public enum SectorType: uint
    {
        SECTOR_INVALID,
        SECTOR_START,
        SECTOR_SECTOR1,
        SECTOR_SECTOR2,
        SECTOR_FINISH,
        SECTOR_STOP,
        //-------------
        SECTOR_MAX
    };

    public enum FlagColourType: uint
    {
        FLAG_COLOUR_NONE,       // Not used for actual flags, only for some query functions
        FLAG_COLOUR_GREEN,          // End of danger zone, or race started
        FLAG_COLOUR_BLUE,           // Faster car wants to overtake the participant
        FLAG_COLOUR_WHITE,          // Approaching a slow car
        FLAG_COLOUR_YELLOW,         // Danger on the racing surface itself
        FLAG_COLOUR_DOUBLE_YELLOW,  // Danger that wholly or partly blocks the racing surface
        FLAG_COLOUR_BLACK,          // Participant disqualified
        FLAG_COLOUR_CHEQUERED,      // Chequered flag
                                    //-------------
        FLAG_COLOUR_MAX
    };

    public enum FlagReasonType: uint
    {
        FLAG_REASON_NONE,
        FLAG_REASON_SOLO_CRASH,
        FLAG_REASON_VEHICLE_CRASH,
        FLAG_REASON_VEHICLE_OBSTRUCTION,
        //-------------
        FLAG_REASON_MAX
    };

    public enum PitModeType: uint
    {
        PIT_MODE_NONE = 0,
        PIT_MODE_DRIVING_INTO_PITS,
        PIT_MODE_IN_PIT,
        PIT_MODE_DRIVING_OUT_OF_PITS,
        PIT_MODE_IN_GARAGE,
        //-------------
        PIT_MODE_MAX
    };

    public enum PitSchedule: uint
    {
        PIT_SCHEDULE_NONE = 0,        // Nothing scheduled
        PIT_SCHEDULE_STANDARD,        // Used for standard pit sequence
        PIT_SCHEDULE_DRIVE_THROUGH,   // Used for drive-through penalty
        PIT_SCHEDULE_STOP_GO,         // Used for stop-go penalty
                                      //-------------
        PIT_SCHEDULE_MAX
    };

    // (Type#9) Car Flags (to be used with 'CarFlags')
    [Flags]
    public enum CarFlagType: uint
    {
        CAR_HEADLIGHT = (1 << 0),
        CAR_ENGINE_ACTIVE = (1 << 1),
        CAR_ENGINE_WARNING = (1 << 2),
        CAR_SPEED_LIMITER = (1 << 3),
        CAR_ABS = (1 << 4),
        CAR_HANDBRAKE = (1 << 5),
    };

    // (Type#10) Tyre Flags (to be used with 'TyreFlags')
    [Flags]
    public enum TyreFlagType : uint
    {
        TYRE_ATTACHED = (1 << 0),
        TYRE_INFLATED = (1 << 1),
        TYRE_IS_ON_GROUND = (1 << 2),
    };

    public enum TerrainType: uint
    {
        TERRAIN_ROAD = 0,
        TERRAIN_LOW_GRIP_ROAD,
        TERRAIN_BUMPY_ROAD1,
        TERRAIN_BUMPY_ROAD2,
        TERRAIN_BUMPY_ROAD3,
        TERRAIN_MARBLES,
        TERRAIN_GRASSY_BERMS,
        TERRAIN_GRASS,
        TERRAIN_GRAVEL,
        TERRAIN_BUMPY_GRAVEL,
        TERRAIN_RUMBLE_STRIPS,
        TERRAIN_DRAINS,
        TERRAIN_TYREWALLS,
        TERRAIN_CEMENTWALLS,
        TERRAIN_GUARDRAILS,
        TERRAIN_SAND,
        TERRAIN_BUMPY_SAND,
        TERRAIN_DIRT,
        TERRAIN_BUMPY_DIRT,
        TERRAIN_DIRT_ROAD,
        TERRAIN_BUMPY_DIRT_ROAD,
        TERRAIN_PAVEMENT,
        TERRAIN_DIRT_BANK,
        TERRAIN_WOOD,
        TERRAIN_DRY_VERGE,
        TERRAIN_EXIT_RUMBLE_STRIPS,
        TERRAIN_GRASSCRETE,
        TERRAIN_LONG_GRASS,
        TERRAIN_SLOPE_GRASS,
        TERRAIN_COBBLES,
        TERRAIN_SAND_ROAD,
        TERRAIN_BAKED_CLAY,
        TERRAIN_ASTROTURF,
        TERRAIN_SNOWHALF,
        TERRAIN_SNOWFULL,
        //-------------
        TERRAIN_MAX
    };

    public enum CrashDamageType: uint
    {
        CRASH_DAMAGE_NONE = 0,
        CRASH_DAMAGE_OFFTRACK,
        CRASH_DAMAGE_LARGE_PROP,
        CRASH_DAMAGE_SPINNING,
        CRASH_DAMAGE_ROLLING,
        //-------------
        CRASH_MAX
    };
}
