// SPDX-License-Identifier: LGPL-3.0-or-later
//
// This file is part of Fahrenheit, © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the GNU Lesser General Public License, version 3.0 or later. See COPYING, COPYING.LESSER.

namespace Fahrenheit.FFX2;

/// <summary>
///     Variable data used for the HP growth formula.<br/>
///     The formula is: `base` + `linear_mult` * level - (level^2) / (`quadratic_div` / 10)
/// </summary>
public struct StatGrowthHp {
    public byte linear_mult;
    public byte quadratic_div;
    public byte base_amount;
}

/// <summary>
///     Variable data used for the MP growth formula.<br/>
///     The formula is: `base` + (`linear_mult` / 10) * level - (level^2) / `quadratic_div`
/// </summary>
public struct StatGrowthMp {
    public byte linear_mult;
    public byte quadratic_div;
    public byte base_amount;
}

/// <summary>
///     Variable data used for the generic stat growth formula.<br/>
///     This formula is used for strength, magic, defense, magic defense,
///     agility, accuracy, evasion, and luck.<br/>
///     The formula is: `base` + (`linear_mult` / 10) * level + level / `linear_div` - (level^2 / 16) / `quadratic_div_a` / `quadratic_div_b`
/// </summary>
public struct StatGrowthGeneric {
    public byte linear_mult;
    public byte linear_div;
    public byte base_amount;
    public byte quadratic_div_a;
    public byte quadratic_div_b;
}

/// <summary>
///     The requirement and ability fields can vary depending on the context.
///     At base, requirement and ability can both be either a T_X2CommandId or T_X2AutoAbilityId.
///     For plate, requirement is strictly just the index of the gate to move through.
///     For job, a requirement of "1" makes the command require the precalculated AP count for it.
///     Creatures also have their own contexts, such as taking Level as a requirement in job where YRP do not.
/// </summary>
[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct Ability {
    public ushort requirement;
    public ushort ability;
}

[StructLayout(LayoutKind.Sequential, Size = 0xA)]
public struct StatChanges {
    public sbyte hp;
    public sbyte mp;
    public sbyte strength;
    public sbyte defense;
    public sbyte magic;
    public sbyte magic_defense;
    public sbyte agility;
    public sbyte accuracy;
    public sbyte evasion;
    public sbyte luck;
}

[StructLayout(LayoutKind.Sequential, Size = 0x4)]
public struct JobWeaponData {
    public ushort weapon_model;
    public ushort weapon_position;
}

[InlineArray(4)]
public struct JobWeapons {
    private JobWeaponData _data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public struct JobCreatureData {
    [FieldOffset(0x00)] public ExcelTextOffset       help;
    [FieldOffset(0x04)] public InlineArray2<Ability> abilities;

    [FieldOffset(0x1C)] public StatChanges stat_changes;
}

[StructLayout(LayoutKind.Sequential)]
public struct Job {
    public ExcelTextOffset name;
    public ExcelTextOffset help;
    public byte            user;
    public byte            data;
    public byte            dressphere_menu_ordering;
    public byte            icon;
    public T_X2CommandId   berserk_action;

    public StatGrowthHp growth_hp;
    public StatGrowthMp growth_mp;

    public StatGrowthGeneric growth_strength;
    public StatGrowthGeneric growth_defense;
    public StatGrowthGeneric growth_magic;
    public StatGrowthGeneric growth_magic_defense;
    public StatGrowthGeneric growth_agility;
    public StatGrowthGeneric growth_evasion;
    public StatGrowthGeneric growth_accuracy;
    public StatGrowthGeneric growth_luck;

    public InlineArray16<Ability> dressphere_abilities;

    public JobWeapons yuna_weapon_data;
    public JobWeapons rikku_weapon_data;
    public JobWeapons paine_weapon_data;

    public JobCreatureData creature_data;
}
