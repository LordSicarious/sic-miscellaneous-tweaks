//Transpiler for [RimWorld.InfestationCellFinder.DebugDraw]
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using HarmonyLib;

namespace InfestationNumbers {
public static class Transpiler_DebugDraw {
    // Reduces caching frequency to improve performance
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        foreach (CodeInstruction code in instructions) {
            if (code.opcode == OpCodes.Ldc_I4_8) {
                yield return new CodeInstruction(OpCodes.Ldc_I4, 300);
            } else { yield return code; }
        }
    }
}
}