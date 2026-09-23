// SPDX-License-Identifier: LGPL-3.0-or-later
//
// This file is part of Fahrenheit, © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the GNU Lesser General Public License, version 3.0 or later. See COPYING, COPYING.LESSER.

// ffx2/master/jppc/battle/kernel/accessory.h
// Switch release of FFX/X-2 HD

namespace Fahrenheit.FFX2;

[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x30)]
public struct AccessoryCreatureData {
    [FieldOffset(0x00)] public ExcelTextOffset       help_offset;
    [FieldOffset(0x04)] public InlineArray2<Ability> abilities;

    [FieldOffset(0x1D)] public byte   feed_amount;
    [FieldOffset(0x1E)] public ushort ability_to_learn;
}

[StructLayout(LayoutKind.Sequential)]
public struct Accessory {
    public ExcelTextOffset name_offset;
    public ExcelTextOffset help_offset;

    public byte ext_data;
    public byte equip;
    public byte user;
    public byte icon;
    public byte seq;

    public byte reserve;

    public StatChanges stat_changes;

    public InlineArray2<Ability> abilities;

    public uint price;

    public AccessoryCreatureData creature_data;
}
