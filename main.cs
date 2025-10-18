using UnityEngine;
using Mirror;
using HarmonyLib;

public class SodBasicMod : ModBehaviour
{
    private void Start()
    {
        Debug.Log("[SodBasicMod] enabled");
    }
    
    private void OnDestroy()
    {
        Debug.Log("[SodBasicMod] disabled");
    }
}

[HarmonyPatch(typeof(GameManager), "OnStartServer")]
public static class GameManager_OnStartServer_Patch
{
    public static void Postfix()
    {
        if (DewNetworkManager.continueData == null)
        {
            NetworkedManagerBase<ZoneManager>.instance.CallOnReadyAfterTransition(delegate 
            {
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
