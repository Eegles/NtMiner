﻿using System;
using System.Runtime.InteropServices;
using NvU32 = System.UInt32;
using NvS32 = System.Int32;

namespace NTMiner.Gpus.Nvapi {
    internal static class NvapiConst {
        internal const int MAX_PHYSICAL_GPUS = 64;
        internal const int MAX_PSTATES_PER_GPU = 8;
        internal const int MAX_COOLER_PER_GPU = 20;
        internal const int MAX_THERMAL_SENSORS_PER_GPU = 3;
        internal const int MAX_POWER_ENTRIES_PER_GPU = 4;

        internal const int NVAPI_MAX_GPU_CLOCKS = 32;
        internal const int NVAPI_MAX_GPU_PUBLIC_CLOCKS = 32;
        internal const int NVAPI_MAX_GPU_PERF_CLOCKS = 32;
        internal const int NVAPI_MAX_GPU_PERF_VOLTAGES = 16;
        internal const int NVAPI_MAX_GPU_PERF_PSTATES = 16;
        
        internal const int NVAPI_MAX_GPU_PSTATE20_PSTATES = 16;
        internal const int NVAPI_MAX_GPU_PSTATE20_CLOCKS = 8;
        internal const int NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES = 4;

        internal const int NV_GPU_CLOCK_FREQUENCIES_CURRENT_FREQ = 0;
        internal const int NV_GPU_CLOCK_FREQUENCIES_BASE_CLOCK = 1;
        internal const int NV_GPU_CLOCK_FREQUENCIES_BOOST_CLOCK = 2;
        internal const int NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE_NUM = 3;
        internal const int NV_GPU_CLOCK_FREQUENCIES_CLOCK_TYPE = 4;

        internal const int NVAPI_MAX_COOLERS_PER_GPU = 3;
    }

    #region Enumms
    internal enum NvStatus {
        OK = 0,
        ERROR = -1,
        LIBRARY_NOT_FOUND = -2,
        NO_IMPLEMENTATION = -3,
        API_NOT_INTIALIZED = -4,
        INVALID_ARGUMENT = -5,
        NVIDIA_DEVICE_NOT_FOUND = -6,
        END_ENUMERATION = -7,
        INVALID_HANDLE = -8,
        INCOMPATIBLE_STRUCT_VERSION = -9,
        HANDLE_INVALIDATED = -10,
        OPENGL_CONTEXT_NOT_CURRENT = -11,
        NO_GL_EXPERT = -12,
        INSTRUMENTATION_DISABLED = -13,
        EXPECTED_LOGICAL_GPU_HANDLE = -100,
        EXPECTED_PHYSICAL_GPU_HANDLE = -101,
        EXPECTED_DISPLAY_HANDLE = -102,
        INVALID_COMBINATION = -103,
        NOT_SUPPORTED = -104,
        PORTID_NOT_FOUND = -105,
        EXPECTED_UNATTACHED_DISPLAY_HANDLE = -106,
        INVALID_PERF_LEVEL = -107,
        DEVICE_BUSY = -108,
        NV_PERSIST_FILE_NOT_FOUND = -109,
        PERSIST_DATA_NOT_FOUND = -110,
        EXPECTED_TV_DISPLAY = -111,
        EXPECTED_TV_DISPLAY_ON_DCONNECTOR = -112,
        NO_ACTIVE_SLI_TOPOLOGY = -113,
        SLI_RENDERING_MODE_NOTALLOWED = -114,
        EXPECTED_DIGITAL_FLAT_PANEL = -115,
        ARGUMENT_EXCEED_MAX_SIZE = -116,
        DEVICE_SWITCHING_NOT_ALLOWED = -117,
        TESTING_CLOCKS_NOT_SUPPORTED = -118,
        UNKNOWN_UNDERSCAN_CONFIG = -119,
        TIMEOUT_RECONFIGURING_GPU_TOPO = -120,
        DATA_NOT_FOUND = -121,
        EXPECTED_ANALOG_DISPLAY = -122,
        NO_VIDLINK = -123,
        REQUIRES_REBOOT = -124,
        INVALID_HYBRID_MODE = -125,
        MIXED_TARGET_TYPES = -126,
        SYSWOW64_NOT_SUPPORTED = -127,
        IMPLICIT_SET_GPU_TOPOLOGY_CHANGE_NOT_ALLOWED = -128,
        REQUEST_USER_TO_CLOSE_NON_MIGRATABLE_APPS = -129,
        OUT_OF_MEMORY = -130,
        WAS_STILL_DRAWING = -131,
        FILE_NOT_FOUND = -132,
        TOO_MANY_UNIQUE_STATE_OBJECTS = -133,
        INVALID_CALL = -134,
        D3D10_1_LIBRARY_NOT_FOUND = -135,
        FUNCTION_NOT_FOUND = -136
    }
    internal enum NvThermalController {
        NONE = 0,
        GPU_INTERNAL,
        ADM1032,
        MAX6649,
        MAX1617,
        LM99,
        LM89,
        LM64,
        ADT7473,
        SBMAX6649,
        VBIOSEVT,
        OS,
        UNKNOWN = -1,
    }
    internal enum NvThermalTarget {
        NONE = 0,
        GPU = 1,
        MEMORY = 2,
        POWER_SUPPLY = 4,
        BOARD = 8,
        ALL = 15,
        UNKNOWN = -1
    };
    internal enum NV_GPU_PUBLIC_CLOCK_ID : NvU32 {
        NVAPI_GPU_PUBLIC_CLOCK_GRAPHICS = 0,
        NVAPI_GPU_PUBLIC_CLOCK_MEMORY = 4,
        NVAPI_GPU_PUBLIC_CLOCK_PROCESSOR = 7,
        NVAPI_GPU_PUBLIC_CLOCK_VIDEO = 8,
        NVAPI_GPU_PUBLIC_CLOCK_UNDEFINED = NvapiConst.NVAPI_MAX_GPU_PUBLIC_CLOCKS,
    }
    internal enum NV_GPU_PERF_PSTATE_ID : NvU32 {
        NVAPI_GPU_PERF_PSTATE_P0 = 0,
        NVAPI_GPU_PERF_PSTATE_P1,
        NVAPI_GPU_PERF_PSTATE_P2,
        NVAPI_GPU_PERF_PSTATE_P3,
        NVAPI_GPU_PERF_PSTATE_P4,
        NVAPI_GPU_PERF_PSTATE_P5,
        NVAPI_GPU_PERF_PSTATE_P6,
        NVAPI_GPU_PERF_PSTATE_P7,
        NVAPI_GPU_PERF_PSTATE_P8,
        NVAPI_GPU_PERF_PSTATE_P9,
        NVAPI_GPU_PERF_PSTATE_P10,
        NVAPI_GPU_PERF_PSTATE_P11,
        NVAPI_GPU_PERF_PSTATE_P12,
        NVAPI_GPU_PERF_PSTATE_P13,
        NVAPI_GPU_PERF_PSTATE_P14,
        NVAPI_GPU_PERF_PSTATE_P15,
        NVAPI_GPU_PERF_PSTATE_UNDEFINED = NvapiConst.NVAPI_MAX_GPU_PERF_PSTATES,
        NVAPI_GPU_PERF_PSTATE_ALL,
    }
    internal enum NV_GPU_PERF_PSTATE20_CLOCK_TYPE_ID : NvU32 {
        NVAPI_GPU_PERF_PSTATE20_CLOCK_TYPE_SINGLE = 0,
        NVAPI_GPU_PERF_PSTATE20_CLOCK_TYPE_RANGE,
    }
    internal enum NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID : NvU32 {
        NVAPI_GPU_PERF_VOLTAGE_INFO_DOMAIN_CORE = 0,
        NVAPI_GPU_PERF_VOLTAGE_INFO_DOMAIN_UNDEFINED = NvapiConst.NVAPI_MAX_GPU_PERF_VOLTAGES,
    }
    #endregion

    #region Structs
    [StructLayout(LayoutKind.Sequential)]
    internal struct NvPhysicalGpuHandle {
        private readonly IntPtr ptr;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NvPState {
        public bool Present;
        public int Percentage;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NvPStates {
        public uint Version;
        public uint Flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.MAX_PSTATES_PER_GPU)]
        public NvPState[] PStates;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NvLevel {
        public int Level;
        public int Policy;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NvSensor {
        public NvThermalController Controller;
        public uint DefaultMinTemp;
        public uint DefaultMaxTemp;
        public uint CurrentTemp;
        public NvThermalTarget Target;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct NvGPUThermalSettings {
        public uint Version;
        public uint Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.MAX_THERMAL_SENSORS_PER_GPU)]
        public NvSensor[] Sensor;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PERF_PSTATES20_PARAM_DELTA {
        public NvS32 value;
        public NvS32 mindelta;
        public NvS32 maxdelta;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct NV_GPU_SINGLE_RANGE_DATA_UNION {
        [FieldOffset(0)]
        public NvU32 freq_kHz;

        [FieldOffset(0)]
        public NvU32 minFreq_kHz;
        [FieldOffset(4)]
        public NvU32 maxFreq_kHz;
        [FieldOffset(8)]
        public NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID domainId;
        [FieldOffset(12)]
        public NvU32 minVoltage_uV;
        [FieldOffset(16)]
        public NvU32 maxVoltage_uV;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PSTATE20_CLOCK_ENTRY_V1 {
        public NV_GPU_PUBLIC_CLOCK_ID domainId;
        public NV_GPU_PERF_PSTATE20_CLOCK_TYPE_ID typeId;
        public NvU32 bIsEditable_reserved;
        public NV_GPU_PERF_PSTATES20_PARAM_DELTA freqDelta_kHz;

        /* union */
        public NV_GPU_SINGLE_RANGE_DATA_UNION data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1 {
        public NV_GPU_PERF_VOLTAGE_INFO_DOMAIN_ID domainId;
        public NvU32 bIsEditable_reserved;
        public NvU32 volt_uV;
        public NV_GPU_PERF_PSTATES20_PARAM_DELTA voltDelta_uV;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PSTATES_ARRAY_16 {
        public NV_GPU_PERF_PSTATE_ID pstateId;
        public NvU32 bIsEditable_reserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PSTATE20_CLOCKS)]
        public NV_GPU_PSTATE20_CLOCK_ENTRY_V1[] clocks;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES)]
        public NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1[] baseVoltages;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PSTATE20_V2_OV {
        public NvU32 numVoltages;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PSTATE20_BASE_VOLTAGES)]
        public NV_GPU_PSTATE20_BASE_VOLTAGE_ENTRY_V1[] voltages;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PERF_PSTATES20_INFO_V2 {
        public NvU32 version;
        public NvU32 bIsEditable_reserved;
        public NvU32 numPstates;
        public NvU32 numClocks;
        public NvU32 numBaseVoltages;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PERF_PSTATES)]
        public PSTATES_ARRAY_16[] pstates;
        public NV_GPU_PSTATE20_V2_OV ov;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NV_GPU_PERF_PSTATES20_INFO_V1 {
        public NvU32 version;
        public NvU32 bIsEditable_reserved;
        public NvU32 numPstates;
        public NvU32 numClocks;
        public NvU32 numBaseVoltages;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PERF_PSTATES)]
        public PSTATES_ARRAY_16[] pstates;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NV_GPU_CLOCK_FREQUENCIES_DOMAIN {
        public NvU32 bIsPresent_reserved;
        public NvU32 frequency;
        public NvU32 bIsPresent {
            get {
                return bIsPresent_reserved & 0x01;
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NV_GPU_CLOCK_FREQUENCIES_V2 {
        public NvU32 version;
        public NvU32 ClockType_reserved_reserved1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_GPU_PUBLIC_CLOCKS)]
        public NV_GPU_CLOCK_FREQUENCIES_DOMAIN[] domain;
        public NvU32 ClockType {
            set {
                NvU32 tmp = ClockType_reserved_reserved1 & ~(NvU32)0x03;
                tmp |= value & 0x03;
                ClockType_reserved_reserved1 = tmp;
            }
            get {
                return ClockType_reserved_reserved1 & 0x03;
            }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_THERMAL_INFO_ENTRIES {
        public NvU32 controller;
        public NvU32 unknown;
        public NvS32 min_temp;
        public NvS32 def_temp;
        public NvS32 max_temp;
        public NvU32 defaultFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_THERMAL_INFO {
        public NvU32 version;
        public NvU32 flags;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NVAPI_GPU_THERMAL_INFO_ENTRIES[] entries;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_THERMAL_LIMIT_ENTRIES {
        public NvU32 controller;
        public NvU32 value;
        public NvU32 flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_THERMAL_LIMIT {
        public NvU32 version;
        public NvU32 flags;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NVAPI_GPU_THERMAL_LIMIT_ENTRIES[] entries;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_POWER_STATUS_ENTRY {
        public NvU32 unknown1;
        public NvU32 unknown2;

        /* percent * 1000 */
        public NvU32 power;
        public NvU32 unknown4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_POWER_STATUS {
        public NvU32 version;
        public NvU32 flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NVAPI_GPU_POWER_STATUS_ENTRY[] entries;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_POWER_INFO_ENTRY {
        public NvU32 pstate;
        public NvU32 unknown1_0;
        public NvU32 unknown1_1;
        public NvU32 min_power;
        public NvU32 unknown2_0;
        public NvU32 unknown2_1;
        public NvU32 def_power;
        public NvU32 unknown3_0;
        public NvU32 unknown3_1;
        public NvU32 max_power;
        public NvU32 unknown4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_GPU_POWER_INFO {
        public NvU32 version;
        public NvU32 valid_count_reserver1_reserver2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public NVAPI_GPU_POWER_INFO_ENTRY[] entries;

        public NvU32 valid {
            get {
                return valid_count_reserver1_reserver2 & 0xff;
            }
        }
        public NvU32 count {
            get {
                return (valid_count_reserver1_reserver2 >> 8) & 0xff;
            }
        }
    }

    public enum NV_COOLER_TYPE : NvU32 {
        NVAPI_COOLER_TYPE_NONE = 0,
        NVAPI_COOLER_TYPE_FAN,
        NVAPI_COOLER_TYPE_WATER,
        NVAPI_COOLER_TYPE_LIQUID_NO2,
    }
    public enum NV_COOLER_CONTROLLER {
        NVAPI_COOLER_CONTROLLER_NONE = 0,
        NVAPI_COOLER_CONTROLLER_ADI,
        NVAPI_COOLER_CONTROLLER_INTERNAL,
    }

    public enum NV_COOLER_POLICY {
        NVAPI_COOLER_POLICY_NONE = 0,
        NVAPI_COOLER_POLICY_MANUAL = 1,                 // Manual adjustment of cooler level. Gets applied right away independent of temperature or performance level.
        NVAPI_COOLER_POLICY_PERF = 2,                   // GPU performance controls the cooler level.
        NVAPI_COOLER_POLICY_TEMPERATURE_DISCRETE = 4,   // Discrete thermal levels control the cooler level.
        NVAPI_COOLER_POLICY_TEMPERATURE_CONTINUOUS = 8, // Cooler level adjusted at continuous thermal levels.
        NVAPI_COOLER_POLICY_HYBRID = 16,                // Hybrid of performance and temperature levels.

        NVAPI_COOLER_POLICY_AUTO = 32,                  // AIMiner custom .
    }

    public enum NV_COOLER_TARGET {
        NVAPI_COOLER_TARGET_NONE = 0,
        NVAPI_COOLER_TARGET_GPU,
        NVAPI_COOLER_TARGET_MEMORY,
        NVAPI_COOLER_TARGET_POWER_SUPPLY = 4,
        NVAPI_COOLER_TARGET_ALL = 7                    // This cooler cools all of the components related to its target gpu.
    }

    public enum NV_COOLER_CONTROL {
        NVAPI_COOLER_CONTROL_NONE = 0,
        NVAPI_COOLER_CONTROL_TOGGLE,                   // ON/OFF
        NVAPI_COOLER_CONTROL_VARIABLE,                 // Suppports variable control.
    }

    public enum NV_COOLER_ACTIVITY_LEVEL {
        NVAPI_INACTIVE = 0,                             // inactive or unsupported
        NVAPI_ACTIVE = 1,                               // active and spinning in case of fan
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_COOLER_ARRAY {
        public NvU32 value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_COOLER_ITEM {
        public NV_COOLER_TYPE type;
        public NV_COOLER_CONTROLLER controller;
        public NvU32 defaultMinLevel;
        public NvU32 defaultMaxLevel;
        public NvU32 currentMinLevel;
        public NvU32 currentMaxLevel;
        public NvU32 currentLevel;
        public NV_COOLER_POLICY defaultPolicy;
        public NV_COOLER_POLICY currentPolicy;
        public NV_COOLER_TARGET target;
        public NV_COOLER_CONTROL controlType;
        public NV_COOLER_ACTIVITY_LEVEL active;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_COOLER_SETTINGS {
        public NvU32 version;
        public NvU32 count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_COOLERS_PER_GPU)]
        public NVAPI_COOLER_ITEM[] cooler;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_COOLER_LEVEL_ITEM {
        public NvU32 currentLevel;
        public NV_COOLER_POLICY currentPolicy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NVAPI_COOLER_LEVEL {
        public NvU32 version;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NvapiConst.NVAPI_MAX_COOLERS_PER_GPU)]
        public NVAPI_COOLER_LEVEL_ITEM[] coolers;
    }
    #endregion
}
