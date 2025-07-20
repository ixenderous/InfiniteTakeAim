using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

namespace InfiniteTakeAim;

public class Settings : ModSettings
{
    public static readonly ModSettingBool ModEnabled = new(true)
    {
        description = "Must be enabled when joining a match to take effect."
    };
}