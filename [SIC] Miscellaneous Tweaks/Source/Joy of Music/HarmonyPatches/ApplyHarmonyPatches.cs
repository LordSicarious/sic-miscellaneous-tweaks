using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace JoyOfMusic {
    [StaticConstructorOnStartup]
    public static class ApplyHarmonyPatches {
		// Reference to this class for patches
        static ApplyHarmonyPatches() {
			// Instantiate Harmony
			var harmony = new Harmony("sic.JoyOfMusic.thisisanid");
			Type patchType;
			MethodInfo original;
			string modified;

			//Transpiler for [RimWorld.CompLoudspeaker.CompTick]
            patchType = typeof(Transpiler_CompTick);
            original = AccessTools.Method(typeof(CompLoudspeaker), name: "CompTick");
            modified = nameof(Transpiler_CompTick.Transpiler);
            harmony.Patch(original, transpiler: new HarmonyMethod(patchType, modified));

			//Transpiler for [RimWorld.CompLoudspeaker.WantsToBeOn]
            patchType = typeof(Transpiler_WantsToBeOn);
            original = AccessTools.Method(typeof(CompLoudspeaker), name: "get_WantsToBeOn");
            modified = nameof(Transpiler_CompTick.Transpiler);
            harmony.Patch(original, transpiler: new HarmonyMethod(patchType, modified));
        }
    }
}