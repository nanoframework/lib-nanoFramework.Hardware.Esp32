﻿// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// ESP32 filter setting class.
    /// </summary>
    public class Esp32FilterSetting : IFilterSetting
    {
        private uint _period;
        private IFilterSetting.FilterType _type = IFilterSetting.FilterType.Esp32;

        /// <summary>
        /// The period in milliseconds for the filtering.
        /// </summary>
        public uint Period
        {
            get => _period;
            set
            {
                _period = value;
            }
        }

        /// <inheritdoc/>
        public IFilterSetting.FilterType Type => _type;
    }
}
