using System;
using System.Linq;

namespace DKC2_Entrance_Randomizer.Constants;

internal static class BossLevelCodes
{
    public const byte CrowsNest = 0x09;
    public const byte KleeversKiln = 0x0d;
    public const byte KudgelsKontest = 0x21;
    public const byte KingZing = 0x60;
    public const byte KreepyKrow = 0x61;
    public const byte KRool = 0x63;

    public static bool IsBossLevel(byte levelCode)
        => new byte[] {
            BossLevelCodes.CrowsNest,
            BossLevelCodes.KleeversKiln,
            BossLevelCodes.KudgelsKontest,
            BossLevelCodes.KingZing,
            BossLevelCodes.KreepyKrow,
            BossLevelCodes.KRool
        }.Contains(levelCode);
}
