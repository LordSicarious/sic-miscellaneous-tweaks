using System;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace InfestationNumbers {
    [StaticConstructorOnStartup]
    public static class ApplyHarmonyPatches {
		// Reference to this class for patches
        static ApplyHarmonyPatches() {
			// Instantiate Harmony
			var harmony = new Harmony("sic.InfestationNumbers.thisisanid");
			Type patchType;
			MethodInfo original;
			string modified;

			//Prefix for [RimWorld.BeautyDrawer.DrawBeautyAroundMouse]
            patchType = typeof(Prefix_DrawBeautyAroundMouse);
            original = AccessTools.Method(typeof(BeautyDrawer), name: "DrawBeautyAroundMouse");
            modified = nameof(Prefix_DrawBeautyAroundMouse.Patch);
            harmony.Patch(original, prefix: new HarmonyMethod(patchType, modified));

			//Transpiler for [RimWorld.InfestationCellFinder.DebugDraw]
            patchType = typeof(Transpiler_DebugDraw);
            original = AccessTools.Method(typeof(InfestationCellFinder), name: "DebugDraw");
            modified = nameof(Transpiler_DebugDraw.Transpiler);
            harmony.Patch(original, transpiler: new HarmonyMethod(patchType, modified));
        }
    }
}