[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Hardware.Esp32&metric=alert_status)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Hardware.Esp32) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Hardware.Esp32&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Hardware.Esp32) [![NuGet](https://img.shields.io/nuget/dt/nanoFramework.Hardware.Esp32.svg?label=NuGet&style=flat&logo=nuget)]() [![#yourfirstpr](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](https://github.com/nanoframework/Home/blob/main/CONTRIBUTING.md) [![Discord](https://img.shields.io/discord/478725473862549535.svg?logo=discord&logoColor=white&label=Discord&color=7289DA)](https://discord.gg/gCyBu8T)

![nanoFramework logo](https://raw.githubusercontent.com/nanoframework/Home/main/resources/logo/nanoFramework-repo-logo.png)

-----

### Welcome to the .NET **nanoFramework** nanoFramework.Hardware.Esp32 Library repository

## Build status

| Component | Build Status | NuGet Package |
|:-|---|---|
| nanoFramework.Hardware.Esp32 | [![Build Status](https://dev.azure.com/nanoframework/nanoFramework.Hardware.Esp32/_apis/build/status/nanoFramework.Hardware.Esp32?repoName=nanoframework%2FnanoFramework.Hardware.Esp32&branchName=main)](https://dev.azure.com/nanoframework/nanoFramework.Hardware.Esp32/_build/latest?definitionId=11&repoName=nanoframework%2FnanoFramework.Hardware.Esp32&branchName=main) | [![NuGet](https://img.shields.io/nuget/v/nanoFramework.Hardware.Esp32.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.Hardware.Esp32/)  |

## Touch Pad essentials

This section will give you essential elements about how to use Touch Pad pins on ESP32 and ESP32-S2.

### Touch Pad vs GPIO pins

Touch Pad pins numbering is different from GPIO pin. You can check which GPIO pins correspond to which GPIO pin using the following:

```csharp
const int TouchPadNumber = 5;
var pinNum = TouchPad.GetGpioNumberFromTouchNumber(TouchPadNumber);
Console.WriteLine($"Pad {TouchPadNumber} is GPIO{pinNum}");
```

The pin numbering is different on ESP32 and S2. There are 10 valid touch pad on ESP32 (0 to 9) and 13 on S2 (1 to 13).

In this example touch pad 5 will be GPIO 12 on ESP32 and GPIO 5 on S2.

### Basic usage ESP32

On ESP32, if you touch the sensor, the values will be lower, so you have to set a threshold that is lower than the calibration data:

```csharp
TouchPad touchpad = new(TouchPadNumber);
Console.WriteLine($"Calibrating touch pad {touchpad.TouchPadNumber}, DO NOT TOUCH it during the process.");
var calib = touchpad.GetCalibrationData();
Console.WriteLine($"calib: {calib} vs Calibration {touchpad.CalibrationData}");
// On ESP32: Setup a threshold, usually 2/3 or 80% is a good value.
touchpad.Threshold = (uint)(touchpad.CalibrationData * 2 / 3);
touchpad.ValueChanged += TouchpadValueChanged;

Thread.Sleep(Timeout.Infinite);

private static void TouchpadValueChanged(object sender, TouchPadEventArgs e)
{
    Console.WriteLine($"Touchpad {e.PadNumber} is {(e.Touched ? "touched" : "not touched")}");
}
```

### Basic usage S2

On S2, if you touch the sensor, the values will be higher, so you have to set a threshold that is higher than the calibration data and set trigger mode as above:

```csharp
TouchPad touchpad = new(TouchPadNumber);
Console.WriteLine($"Calibrating touch pad {touchpad.TouchPadNumber}, DO NOT TOUCH it during the process.");
var calib = touchpad.GetCalibrationData();
Console.WriteLine($"calib: {calib} vs Calibration {touchpad.CalibrationData}");
// On S2/S3, the actual read values will be higher, so let's use 20% more
TouchPad.TouchTriggerMode = TouchTriggerMode.AboveThreshold;
touchpad.Threshold = (uint)(touchpad.CalibrationData * 1.2);

touchpad.ValueChanged += TouchpadValueChanged;

Thread.Sleep(Timeout.Infinite);

private static void TouchpadValueChanged(object sender, TouchPadEventArgs e)
{
    Console.WriteLine($"Touchpad {e.PadNumber} is {(e.Touched ? "touched" : "not touched")}");
}
```

### Other features

You have quite a lot of other features available, filters, some specific denoising. You can check the sample repository for more details.

## Sleep mode

You can wake up your ESP32 or ESP32-S2 by touch.

### Sleep modes on ESP32

ESP32 can be woke up by 1 or 2 touch pad. Here is how to do it with 1:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep1, thresholdCoefficient: 80);
```

And with 2 pads:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep1, PadForSleep2);
```

Note that the coefficient can be adjusted by doing couple of tests, there is default value of 80 that seems to work in all cases. The coefficient represent a percentage value.

### Sleep modes on S2

S2 can only be woke up with 1 touch pad. It is recommended to do tests to find the best coefficient:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep, thresholdCoefficient: 90);
```

## Feedback and documentation

For documentation, providing feedback, issues and finding out how to contribute please refer to the [Home repo](https://github.com/nanoframework/Home).

Join our Discord community [here](https://discord.gg/gCyBu8T).

## Credits

The list of contributors to this project can be found at [CONTRIBUTORS](https://github.com/nanoframework/Home/blob/main/CONTRIBUTORS.md).

## License

The **nanoFramework** Class Libraries are licensed under the [MIT license](LICENSE.md).

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behaviour in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
