using UnityEngine;
using Mirror;
using HarmonyLib;

public class SodBasicMod : ModBehaviour
{
    private void Start()
    {
        Debug.Log("[SodBasicMod] enabled");
        this.harmony.PatchAll();
    }
    
    private void OnDestroy()
    {
        Debug.Log("[SodBasicMod] disabled");
        this.harmony.UnpatchAll(this.mod.metadata.id);
    }
}

[HarmonyPatch(typeof(ZoneManager), "OnStart")]
public static class ZoneManager_OnStart_Patch
{
    [Server]
    public static void Postfix()
    {
        Debug.Log("[SodBasicMod] ZoneManager OnStart");
        if (DewNetworkManager.continueData == null)
        {
            NetworkedManagerBase<ZoneManager>.instance.CallOnReadyAfterTransition(delegate 
            {
                Debug.Log("[SodBasicMod] ZoneManager OnReadyAfterTransition");
                var player = DewPlayer.local;
                Vector3 spawnPos = Dew.GetGoodRewardPosition(player.hero.agentPosition, 2f);
                SkillTrigger target = DewResources.GetByShortTypeName<SkillTrigger>("St_C_Sneeze", default(VariantDef));
                if (target != null)
                {
                    Dew.CreateSkillTrigger<SkillTrigger>(target, spawnPos, 1, player, null);
                }
            });
        }
    }
}
