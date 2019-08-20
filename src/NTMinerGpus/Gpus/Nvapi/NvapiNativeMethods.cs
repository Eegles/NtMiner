﻿using System;
using System.Runtime.InteropServices;

namespace NTMiner.Gpus.Nvapi {
    public static class NvapiNativeMethods {
        #region Delegates
        private delegate IntPtr NvQueryInterfaceDelegate(uint id);
        private delegate NvStatus NvInitializeDelegate();

        internal delegate NvStatus NvEnumPhysicalGPUsDelegate([Out] NvPhysicalGpuHandle[] physicalGpus, out int gpuCount);
        internal delegate NvStatus NvEnumTCCPhysicalGPUsDelegate([Out] NvPhysicalGpuHandle[] physicalGpus, out int gpuCount);
        internal delegate NvStatus NvGetBusIdDelegate(NvPhysicalGpuHandle physicalGpu, out int busID);
        internal delegate NvStatus NvGetTachReadingDelegate(NvPhysicalGpuHandle physicalGpu, out int value);
        internal delegate NvStatus NvGetPStatesDelegate(NvPhysicalGpuHandle physicalGpu, ref NvPStates nvPStates);

        internal delegate NvStatus NvClientPowerPoliciesGetStatusDelegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuPowerStatus status);
        internal delegate NvStatus NvClientPowerPoliciesSetStatusDelegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuPowerStatus status);

        internal delegate NvStatus NvSetGetPStateV1Delegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuPerfPstates20InfoV1 pstate);
        internal delegate NvStatus NvSetGetPStateV2Delegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuPerfPstates20InfoV2 pstate);
        internal delegate NvStatus NvGetAllClockFrequenciesV2Delegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuClockFrequenciesV2 freq);

        internal delegate NvStatus NvClientThermalPoliciesGetInfoDelegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuThermalInfo outThermalInfo);
        internal delegate NvStatus NvClientThermalPoliciesGetSetLimitDelegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuThermalLimit outThermalLimit);

        internal delegate NvStatus NvClientPowerPoliciesGetInfoDelegate(NvPhysicalGpuHandle physicalGpu, ref NvGpuPowerInfo outPowerInfo);

        internal delegate NvStatus NvGetCoolerSettingsDelegate(NvPhysicalGpuHandle physicalGpu, NvCoolerTarget targetId, ref NvCoolerSettings outCoolerInfo);
        internal delegate NvStatus NvRestoreCoolerSettingsDelegate(NvPhysicalGpuHandle physicalGpu, IntPtr pCoolerIndex, NvCoolerTarget targetId);
        internal delegate NvStatus NvSetCoolerLevelsDelegate(NvPhysicalGpuHandle physicalGpu, NvCoolerTarget coolerIndex, ref NvCoolerLevel level);

        internal delegate NvStatus NvClientFanCoolersGetInfoDelegate(NvPhysicalGpuHandle physicalGpu, PrivateFanCoolersInfoV1 info);
        internal delegate NvStatus NvClientFanCoolersGetStatusDelegate(NvPhysicalGpuHandle physicalGpu, PrivateFanCoolersStatusV1 status);
        internal delegate NvStatus NvClientFanCoolersGetControlDelegate(NvPhysicalGpuHandle physicalGpu, PrivateFanCoolersControlV1 control);
        internal delegate NvStatus NvClientFanCoolersSetControlDelegate(NvPhysicalGpuHandle physicalGpu, PrivateFanCoolersControlV1 control);

        private static readonly NvQueryInterfaceDelegate NvQueryInterface;
        private static readonly NvInitializeDelegate NvInitialize;

        internal static readonly NvEnumPhysicalGPUsDelegate NvEnumPhysicalGPUs;
        internal static readonly NvEnumTCCPhysicalGPUsDelegate NvEnumTCCPhysicalGPUs;
        internal static readonly NvGetBusIdDelegate NvGetBusID;
        internal static readonly NvGetTachReadingDelegate NvGetTachReading;
        internal static readonly NvGetPStatesDelegate NvGetPStates;

        internal static readonly NvClientPowerPoliciesGetStatusDelegate NvClientPowerPoliciesGetStatus;
        internal static readonly NvClientPowerPoliciesSetStatusDelegate NvClientPowerPoliciesSetStatus;

        internal static readonly NvSetGetPStateV1Delegate NvGetPStateV1;
        internal static readonly NvSetGetPStateV2Delegate NvGetPStateV2;
        internal static readonly NvSetGetPStateV1Delegate NvSetPStateV1;
        internal static readonly NvSetGetPStateV2Delegate NvSetPStateV2;
        internal static readonly NvGetAllClockFrequenciesV2Delegate NvGetAllClockFrequenciesV2;

        internal static readonly NvClientThermalPoliciesGetInfoDelegate NvClientThermalPoliciesGetInfo;
        internal static readonly NvClientThermalPoliciesGetSetLimitDelegate NvClientThermalPoliciesGetLimit;
        internal static readonly NvClientThermalPoliciesGetSetLimitDelegate NvClientThermalPoliciesSetLimit;

        internal static readonly NvClientPowerPoliciesGetInfoDelegate NvClientPowerPoliciesGetInfo;

        internal static readonly NvGetCoolerSettingsDelegate NvGetCoolerSettings;
        internal static readonly NvSetCoolerLevelsDelegate NvSetCoolerLevels;
        internal static readonly NvRestoreCoolerSettingsDelegate NvRestoreCoolerSettings;

        internal static readonly NvClientFanCoolersGetInfoDelegate NvClientFanCoolersGetInfo;
        internal static readonly NvClientFanCoolersGetStatusDelegate NvClientFanCoolersGetStatus;
        internal static readonly NvClientFanCoolersGetControlDelegate NvClientFanCoolersGetControl;
        internal static readonly NvClientFanCoolersSetControlDelegate NvClientFanCoolersSetControl;

        #endregion

        private static void GetDelegate<T>(uint id, out T newDelegate)
            where T : class {
            IntPtr ptr = NvQueryInterface(id);
            if (ptr != IntPtr.Zero) {
                newDelegate = Marshal.GetDelegateForFunctionPointer(ptr, typeof(T)) as T;
            }
            else {
                newDelegate = null;
            }
        }

        static NvapiNativeMethods() {
            DllImportAttribute attribute = new DllImportAttribute("nvapi64.dll");
            attribute.CallingConvention = CallingConvention.Cdecl;
            attribute.PreserveSig = true;
            attribute.EntryPoint = "nvapi_QueryInterface";
            PInvokeDelegateFactory.CreateDelegate(attribute, out NvQueryInterface);

            try {
                GetDelegate(0x0150E828, out NvInitialize);
            }
            catch (Exception e) {
                Logger.ErrorDebugLine(e);
                return;
            }

            if (NvInitialize() == NvStatus.OK) {
                GetDelegate(0x5F608315, out NvGetTachReading);
                GetDelegate(0x60DED2ED, out NvGetPStates);
                GetDelegate(0xE5AC921F, out NvEnumPhysicalGPUs);
                GetDelegate(0xD9930B07, out NvEnumTCCPhysicalGPUs);
                GetDelegate(0x1BE0B8E5, out NvGetBusID);

                GetDelegate(0x6FF81213, out NvGetPStateV1);
                GetDelegate(0x6FF81213, out NvGetPStateV2);
                GetDelegate(0x0F4DAE6B, out NvSetPStateV1);
                GetDelegate(0x0F4DAE6B, out NvSetPStateV2);
                GetDelegate(0xDCB616C3, out NvGetAllClockFrequenciesV2);

                GetDelegate(0x0D258BB5, out NvClientThermalPoliciesGetInfo);
                GetDelegate(0xE9C425A1, out NvClientThermalPoliciesGetLimit);
                GetDelegate(0x34C0B13D, out NvClientThermalPoliciesSetLimit);

                GetDelegate(0x70916171, out NvClientPowerPoliciesGetStatus);
                GetDelegate(0xAD95F5ED, out NvClientPowerPoliciesSetStatus);
                GetDelegate(0x34206D86, out NvClientPowerPoliciesGetInfo);

                GetDelegate(0xDA141340, out NvGetCoolerSettings);
                GetDelegate(0x8F6ED0FB, out NvRestoreCoolerSettings);
                GetDelegate(0x891FA0AE, out NvSetCoolerLevels);

                GetDelegate(0xFB85B01E, out NvClientFanCoolersGetInfo);
                GetDelegate(0x35AED5E8, out NvClientFanCoolersGetStatus);
                GetDelegate(0x814B209F, out NvClientFanCoolersGetControl);
                GetDelegate(0xA58971A5, out NvClientFanCoolersSetControl);
            }
        }
    }
}
