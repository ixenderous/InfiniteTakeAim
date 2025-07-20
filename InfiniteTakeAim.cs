using System;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using InfiniteTakeAim;

[assembly: MelonInfo(typeof(InfiniteTakeAim.InfiniteTakeAim), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace InfiniteTakeAim;

public class InfiniteTakeAim : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<InfiniteTakeAim>("InfiniteTakeAim loaded!");
    }

    public override void OnNewGameModel(GameModel result)
    {
        base.OnNewGameModel(result);

        if (!Settings.ModEnabled || !InGameData.CurrentGame.IsSandbox) return;

        foreach (var desperado in result.GetTowersWithBaseId("Desperado"))
        {
            if (desperado.tiers[1] < 3) continue;
            
            var ability = desperado.GetAbilities().Find(a => a.name == "AbilityModel_AbilityTakeAim");  
            if (ability == null) continue;
            
            var takeAimModel = ability.GetBehavior<TakeAimModel>();
            if (takeAimModel == null) continue;

            ability.cooldown = 0;
            ability.Cooldown = 0;
            ability.startOffCooldown = true;
            takeAimModel.lifespanFrames = int.MaxValue;
            
            ModHelper.Msg<InfiniteTakeAim>($"Patched Desperado: {desperado.tiers[0]}-{desperado.tiers[1]}-{desperado.tiers[2]}");
        }
    }
}