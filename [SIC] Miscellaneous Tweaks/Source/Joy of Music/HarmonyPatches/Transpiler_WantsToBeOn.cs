//Transpiler for [RimWorld.CompLoudspeaker.WantsToBeOn] and [RimWorld.CompLightBall.WantsToBeOn]
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace JoyOfMusic {
public static class Transpiler_WantsToBeOn {
    // Skips the check to see if the ritual is inactive
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        yield return new CodeInstruction(OpCodes.Ldc_I4_1);
        yield return new CodeInstruction(OpCodes.Ret);
    }
}
}