// SPDX-License-Identifier: LGPL-3.0-or-later
//
// This file is part of Fahrenheit, © 2023-2026 The Fahrenheit contributors.
// It is licensed to you under the GNU Lesser General Public License, version 3.0 or later. See COPYING, COPYING.LESSER.

namespace Fahrenheit.FFX2;

/// <summary>
///     Commands deal 4x damage to the respective fiend type when these flags are set.
/// </summary>
[Flags]
public enum Species : ushort {
    NONE    = 0,
    MACHINA = 1 << 0,
    MECH    = 1 << 1,
    LIZARD  = 1 << 2,
    ELEMENT = 1 << 3,
    DRAKE   = 1 << 4,
    DEVIL   = 1 << 5, // Imps and Evil Eyes
    FLAN    = 1 << 6,
    WOLF    = 1 << 7,
    WING    = 1 << 8, // Birds and Wasps
    HELM    = 1 << 9,
}

public static partial class FhEnumExt {
    extension(Species flags) {
        public bool machina {
            get { return flags.HasFlag(Species.MACHINA); }
            set { if (value) flags |= Species.MACHINA; else flags &= ~Species.MACHINA; }
        }

        public bool mech {
            get { return flags.HasFlag(Species.MECH); }
            set { if (value) flags |= Species.MECH; else flags &= ~Species.MECH; }
        }

        public bool lizard {
            get { return flags.HasFlag(Species.LIZARD); }
            set { if (value) flags |= Species.LIZARD; else flags &= ~Species.LIZARD; }
        }

        public bool element {
            get { return flags.HasFlag(Species.ELEMENT); }
            set { if (value) flags |= Species.ELEMENT; else flags &= ~Species.ELEMENT; }
        }

        public bool drake {
            get { return flags.HasFlag(Species.DRAKE); }
            set { if (value) flags |= Species.DRAKE; else flags &= ~Species.DRAKE; }
        }

        public bool devil {
            get { return flags.HasFlag(Species.DEVIL); }
            set { if (value) flags |= Species.DEVIL; else flags &= ~Species.DEVIL; }
        }

        public bool flan {
            get { return flags.HasFlag(Species.FLAN); }
            set { if (value) flags |= Species.FLAN; else flags &= ~Species.FLAN; }
        }

        public bool wolf {
            get { return flags.HasFlag(Species.WOLF); }
            set { if (value) flags |= Species.WOLF; else flags &= ~Species.WOLF; }
        }

        public bool wing {
            get { return flags.HasFlag(Species.WING); }
            set { if (value) flags |= Species.WING; else flags &= ~Species.WING; }
        }

        public bool helm {
            get { return flags.HasFlag(Species.HELM); }
            set { if (value) flags |= Species.HELM; else flags &= ~Species.HELM; }
        }
    }
}
