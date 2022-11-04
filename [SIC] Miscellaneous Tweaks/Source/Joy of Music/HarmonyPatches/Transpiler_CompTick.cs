//Transpiler for [RimWorld.CompLoudspeaker.CompTick] and [RimWorld.CompLightBall.CompTick]
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace JoyOfMusic {
public static class Transpiler_CompTick {
    // Avoids turning off the building if the ritual is inactive
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) {
        List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
        int i, start = -1, end = -1;
        bool flag = false;
        for (i = 0; i < codes.Count; i++) {
            // Look for "AutoPoweredWantsOff"
            if (codes[i].opcode == OpCodes.Ldstr && codes[i].operand as string == "AutoPoweredWantsOff") {
                end = i+1;
            }
        }
        if (end > 0) {
            // Scroll back from target to find end of previous condition
            for (i = end; i >= 0; i--) {
                if (codes[i].opcode == OpCodes.Brfalse_S) {
                    flag = true;
                }
                if (flag && codes[i].opcode == OpCodes.Ldarg_0) {
                    start = i;
                }
            }
        }
        if (start < 0 || end < 0) { Log.Error("Cannot find transpiler target."); }
        else {
            Log.Message("Patching between " + codes[start].ToString() + " and " + codes[end].ToString() + ", length: " + (1+ end - start).ToString());
            codes.RemoveRange(start, 1 + end - start);
        }
        return codes;
    }
}
}