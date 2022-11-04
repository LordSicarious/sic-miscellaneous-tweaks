//Prefix for [RimWorld.BeautyDrawer.DrawBeautyAroundMouse]
using System;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
using Verse;
using RimWorld;
using UnityEngine;

namespace InfestationNumbers {
public static class Prefix_DrawBeautyAroundMouse {
    private static MethodInfo   m_GetScoreAt = AccessTools.Method(typeof(InfestationCellFinder), "GetScoreAt");

    // Replaces the whole colour system with just drawing the actual scores
    public static bool Patch() {
        if (DebugViewSettings.drawInfestationChance) {
            Map map = Find.CurrentMap;
            BeautyUtility.FillBeautyRelevantCells(UI.MouseCell(), map);
            for (int i = 0; i < BeautyUtility.beautyRelevantCells.Count; i++) {
                IntVec3 pos = BeautyUtility.beautyRelevantCells[i];
                float score = (float)m_GetScoreAt.Invoke(null, new object[]{pos,map});
                if (score >= 7.5f) {
                    GenMapUI.DrawThingLabel((Vector3)GenMapUI.LabelDrawPosFor(pos), score.ToString("0.##"), Color.white);
                }
            }
            return false;
        }
        return true;
    }
}
}