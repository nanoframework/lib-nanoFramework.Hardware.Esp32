//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Encapsulates ESP32 sleep functions.
    /// </summary>
    public class Sleep
    {
        /// <summary>
        /// Wakeup mode used by <see cref="EnableWakeupByMultiPins"/>.
        /// </summary>
        public enum WakeupMode
        {
            /// <summary>
            /// Wakeup when all pins are low.
            /// </summary>
            AllLow = 0,

            /// <summary>
            /// Wakeup when any pin is high.
            /// </summary>
            AnyHigh = 1
        }

        /// <summary>
        /// Sleep wakeup cause.
        /// </summary>
        public enum WakeupCause
        {
            /// <summary>
            /// In case of deep sleep, reset was not caused by exit from deep sleep.
            /// </summary>
            Undefined = 0,

            /// <summary>
            /// Wakeup caused by external signal using RTC_IO.
            /// </summary>
            Ext0 = 2,

            /// <summary>
            /// Wakeup caused by external signal using RTC_CNTL.
            /// </summary>
            Ext1,

            /// <summary>
            /// Wakeup caused by timer.
            /// </summary>
            Timer,

            /// <summary>
            ///  Wakeup caused by Touchpad.
            /// </summary>
            TouchPad,

            /// <summary>
            ///  Wakeup caused by ULP program.
            /// </summary>
            Ulp,

            /// <summary>
            /// Wakeup caused by GPIO (light sleep only).
            /// </summary>
            Gpio,

            /// <summary>
            /// Wakeup caused by UART (light sleep only).
            /// </summary>
            Uart,

            /// <summary>
            /// Wakeup caused by WIFI (light sleep only).
            /// </summary>
            Wifi,

            /// <summary>
            /// Wakeup caused by COCPU int.
            /// </summary>
            CoCpu,

            /// <summary>
            /// Wakeup caused by COCPU crash.
            /// </summary>
            CoCpuTrapTrig,

            /// <summary>
            /// Wakeup caused by BT (light sleep only).
            /// </summary>
            Bt
        }

        /// <summary>
        /// Gpio pins that can be used for wakeup.
        /// </summary>
        [Flags]
        public enum WakeupGpioPin : UInt64
        {
            /// <summary>
            /// No wake up pin.
            /// </summary>
            None = 0,

            /// <summary>
            /// Gpio Pin 1 used for wakeup.
            /// </summary>
            Pin1 = (UInt64)1 << 1,

            /// <summary>
            /// Gpio Pin 2 used for wakeup.
            /// </summary>
            Pin2 = (UInt64)1 << 2,

            /// <summary>
            /// Gpio Pin 3 used for wakeup.
            /// </summary>
            Pin3 = (UInt64)1 << 3,

            /// <summary>
            /// Gpio Pin 4 used for wakeup.
            /// </summary>
            Pin4 = (UInt64)1 << 4,

            /// <summary>
            /// Gpio Pin 5 used for wakeup.
            /// </summary>
            Pin5 = (UInt64)1 << 5,

            /// <summary>
            /// Gpio Pin 6 used for wakeup.
            /// </summary>
            Pin6 = (UInt64)1 << 6,

            /// <summary>
            /// Gpio Pin 7 used for wakeup.
            /// </summary>
            Pin7 = (UInt64)1 << 7,

            /// <summary>
            /// Gpio Pin 8 used for wakeup.
            /// </summary>
            Pin8 = (UInt64)1 << 8,

            /// <summary>
            /// Gpio Pin 9 used for wakeup.
            /// </summary>
            Pin9 = (UInt64)1 << 9,

            /// <summary>
            /// Gpio Pin 10 used for wakeup.
            /// </summary>
            Pin10 = (UInt64)1 << 10,

            /// <summary>
            /// Gpio Pin 11 used for wakeup.
            /// </summary>
            Pin11 = (UInt64)1 << 11,

            /// <summary>
            /// Gpio Pin 12 used for wakeup.
            /// </summary>
            Pin12 = (UInt64)1 << 12,

            /// <summary>
            /// Gpio Pin 13 used for wakeup.
            /// </summary>
            Pin13 = (UInt64)1 << 13,

            /// <summary>
            /// Gpio Pin 14 used for wakeup.
            /// </summary>
            Pin14 = (UInt64)1 << 14,

            /// <summary>
            /// Gpio Pin 15 used for wakeup.
            /// </summary>
            Pin15 = (UInt64)1 << 15,

            /// <summary>
            /// Gpio Pin 16 used for wakeup.
            /// </summary>
            Pin16 = (UInt64)1 << 16,

            /// <summary>
            /// Gpio Pin 17 used for wakeup.
            /// </summary>
            Pin17 = (UInt64)1 << 17,

            /// <summary>
            /// Gpio Pin 18 used for wakeup.
            /// </summary>
            Pin18 = (UInt64)1 << 18,

            /// <summary>
            /// Gpio Pin 19 used for wakeup.
            /// </summary>
            Pin19 = (UInt64)1 << 19,

            /// <summary>
            /// Gpio Pin 20 used for wakeup.
            /// </summary>
            Pin20 = (UInt64)1 << 20,

            /// <summary>
            /// Gpio Pin 21 used for wakeup.
            /// </summary>
            Pin21 = (UInt64)1 << 21,

            /// <summary>
            /// Gpio Pin 22 used for wakeup.
            /// </summary>
            Pin22 = (UInt64)1 << 22,

            /// <summary>
            /// Gpio Pin 23 used for wakeup.
            /// </summary>
            Pin23 = (UInt64)1 << 23,

            /// <summary>
            /// Gpio Pin 24 used for wakeup.
            /// </summary>
            Pin24 = (UInt64)1 << 24,

            /// <summary>
            /// Gpio Pin 25 used for wakeup.
            /// </summary>
            Pin25 = (UInt64)1 << 25,

            /// <summary>
            /// Gpio Pin 26 used for wakeup.
            /// </summary>
            Pin26 = (UInt64)1 << 26,

            /// <summary>
            /// Gpio Pin 27 used for wakeup.
            /// </summary>
            Pin27 = (UInt64)1 << 27,

            /// <summary>
            /// Gpio Pin 28 used for wakeup.
            /// </summary>
            Pin28 = (UInt64)1 << 28,

            /// <summary>
            /// Gpio Pin 29 used for wakeup.
            /// </summary>
            Pin29 = (UInt64)1 << 29,

            /// <summary>
            /// Gpio Pin 30 used for wakeup.
            /// </summary>
            Pin30 = (UInt64)1 << 30,

            /// <summary>
            /// Gpio Pin 31 used for wakeup.
            /// </summary>
            Pin31 = (UInt64)1 << 31,

            /// <summary>
            /// Gpio Pin 32 used for wakeup.
            /// </summary>
            Pin32 = (UInt64)1 << 32,

            /// <summary>
            /// Gpio Pin 33 used for wakeup.
            /// </summary>
            Pin33 = (UInt64)1 << 33,

            /// <summary>
            /// Gpio Pin 34 used for wakeup.
            /// </summary>
            Pin34 = (UInt64)1 << 34,

            /// <summary>
            /// Gpio Pin 35 used for wakeup.
            /// </summary>
            Pin35 = (UInt64)1 << 35,

            /// <summary>
            /// Gpio Pin 36 used for wakeup.
            /// </summary>
            Pin36 = (UInt64)1 << 36,

            /// <summary>
            /// Gpio Pin 37 used for wakeup.
            /// </summary>
            Pin37 = (UInt64)1 << 37,

            /// <summary>
            /// Gpio Pin 38 used for wakeup.
            /// </summary>
            Pin38 = (UInt64)1 << 38,

            /// <summary>
            /// Gpio Pin 39 used for wakeup.
            /// </summary>
            Pin39 = (UInt64)1 << 39
        }

        /// <summary>
        /// Enumeration of Touchpad numbers.
        /// </summary>
        public enum TouchPad
        {
            /// <summary>
            ///  Touchpad channel 0.
            /// </summary>
            Num0 = 0,

            /// <summary>
            /// Touchpad channel 1.
            /// </summary>
            Num1,

            /// <summary>
            /// Touchpad channel 2.
            /// </summary>
            Num2,

            /// <summary>
            /// Touchpad channel 3.
            /// </summary>
            Num3,

            /// <summary>
            /// Touchpad channel 4.
            /// </summary>
            Num4,

            /// <summary>
            /// Touchpad channel 5.
            /// </summary>
            Num5,

            /// <summary>
            /// Touchpad channel 6.
            /// </summary>
            Num6,

            /// <summary>
            /// Touchpad channel 7.
            /// </summary>
            Num7,

            /// <summary>
            /// Touchpad channel 8.
            /// </summary>
            Num8,

            /// <summary>
            /// Touchpad channel 9.
            /// </summary>
            Num9,

            /// <summary>
            /// Number returned when no Touchpad used on wakeup.
            /// </summary>
            None
        }

        /// <summary>
        /// Enable Wakeup by Timer.
        /// </summary>
        /// <param name="time">Period after which wakeup occurs.</param>
        /// <returns>returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByTimer(TimeSpan time)
        {
            UInt64 time_us = (UInt64)time.Ticks / 10;

            return (EspNativeError)NativeEnableWakeupByTimer(time_us);
        }

        /// <summary>
        /// Enable wakeup using a gpio pin.
        /// </summary>
        /// <param name="pin">GPIO number used as wakeup source. Only pins that have RTC functionality can be used. Actual pins used are implementation specific, refer to documentation for details.</param>
        /// <param name="level">Analog threshold at or above which pin causes wake up, or zero if pin is not active for wakeup.</param>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByPin(WakeupGpioPin pin, int level)
        {
            return NativeEnableWakeupByPin(pin, level);
        }

        /// <summary>
        /// Enable wakeup using multiple pins.
        /// </summary>
        /// <remarks>
        /// Only pins that are RTC connected. 
        /// </remarks>
        /// <param name="pins">Combination of pins that are enabled for wakeup.</param>
        /// <param name="mode">Logical mode used for wakeup to occur.</param>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByMultiPins(WakeupGpioPin pins, WakeupMode mode)
        {
            return NativeEnableWakeupByMultiPins(pins, mode);
        }

        /// <summary>
        /// Enable wakeup by Touchpad.
        /// </summary>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByTouchPad()
        {
            return NativeEnableWakeupByTouchPad();
        }

        /// <summary>
        /// Enter light sleep with the configured wakeup options. 
        /// </summary>
        /// <returns>Returns ESP32 native error enumeration, ESP_ERR_INVALID_STATE if Wifi or BT is not stopped.</returns>
        public static EspNativeError StartLightSleep()
        {
            return NativeStartLightSleep();
        }

        /// <summary>
        /// Enter deep sleep using configured wakeup sources. 
        /// </summary>
        /// <remarks>
        /// After a call to this method the device enters deep sleep, a wakeup source will wake the device and the execution will start as if it was a reset.
        /// After this occurs the cause can be queried using <see cref="GetWakeupCause"/>.
        /// Keep in mind that the execution WILL NOT continue after the call to this method.
        /// This call never returns.
        /// If no wakeup sources are configured then the device enters an indefinite sleep.
        /// </remarks>
        /// <seealso cref="EnableWakeupByMultiPins(WakeupGpioPin, WakeupMode)"/>
        /// <seealso cref="EnableWakeupByPin(WakeupGpioPin, int)"/>
        /// <seealso cref="EnableWakeupByTimer(TimeSpan)"/>
        /// <seealso cref="EnableWakeupByTouchPad"/>
        public static void StartDeepSleep()
        {
            NativeStartDeepSleep();

            // force an infinite sleep to allow execution engine to exit this thread and pick the reboot flags set on the call above
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        /// <summary>
        /// Get the cause for waking up.
        /// </summary>
        /// <returns>Returns the wakeup cause.</returns>
        public static WakeupCause GetWakeupCause()
        {
            return NativeGetWakeupCause();
        }

        /// <summary>
        /// Returns a combination of pins that caused the wakeup.
        /// </summary>
        /// <returns>Returns a combination of the pins that caused the wakeup.</returns>
        public static WakeupGpioPin GetWakeupGpioPin()
        {
            return NativeGetWakeupGpioPin();
        }

        /// <summary>
        /// Get the Touchpad which caused the wakeup. 
        /// </summary>
        /// <returns>Returns TouchPad number which caused the wakeup, else <see cref="WakeupGpioPin.None"/>.</returns>
        public static TouchPad GetWakeupTouchpad()
        {
            return NativeGetWakeupTouchpad();
        }

        #region extenal calls to native implementations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByTimer(UInt64 time_us);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByPin(WakeupGpioPin pin, int level);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByMultiPins(WakeupGpioPin pins, WakeupMode mode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByTouchPad();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeStartLightSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeStartDeepSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupCause NativeGetWakeupCause();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupGpioPin NativeGetWakeupGpioPin();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern TouchPad NativeGetWakeupTouchpad();

        #endregion
    }
}
