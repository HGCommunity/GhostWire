using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using Steamworks;

namespace ghostwire;

public static class PluginInfo {
    public const string GUID = "dev.hgcommunity.ghostwire";
    public const string NAME = "GhostWire";
    public const string VERSION = "1.0.0";
}

[BepInPlugin(PluginInfo.GUID, PluginInfo.NAME, PluginInfo.VERSION)]
public class Patch : BaseUnityPlugin
{
    private static ConfigEntry<bool> enabled;
    private static ConfigEntry<string> realtimeAppId;
    private static ConfigEntry<string> voiceAppId;
    private readonly Harmony harmony = new Harmony(PluginInfo.GUID);
    
    private void Awake()
    {
        try {
            Logger.LogInfo($"Plugin{PluginInfo.GUID} is loaded!");
            
            enabled = Config.Bind("Enabled", "enabled", true);
            realtimeAppId = Config.Bind("Realtime App Id", "realtimeAppId", "CHANGE_ME");
            voiceAppId = Config.Bind("Voice App Id", "voiceAppId", "CHANGE_ME");
            Logger.LogInfo($"Plugin {PluginInfo.GUID} configurations created/loaded!");

            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.GUID} has patched stuff!");
        } catch {
            Logger.LogError("Something went wrong!");
        }
    }

    [HarmonyPatch(typeof(SteamClient), "Init")]
    public class ChangeAppId
    {
        [HarmonyPrefix]
        public static bool Prefix(ref uint appid)
        {
            if (enabled.Value == true) appid = 480;
            return true;
        }
    }

    [HarmonyPatch(typeof(NetworkConnect), "CreateLobby")]
    private static class NetworkConnectPatch {
        [HarmonyPrefix]
        private static void Prefix() {
            if (enabled.Value == true) {
                PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = realtimeAppId.Value;
                PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = voiceAppId.Value;
            }
        }
    }
    
    
    [HarmonyPatch(typeof(LoadBalancingPeer), nameof(LoadBalancingPeer.OpAuthenticate))]
    public class BadLNLAuthPatch
    {
        public static void Prefix(ref AuthenticationValues authValues)
        {
            if (enabled.Value == true) 
            {
                authValues.AuthType = CustomAuthenticationType.None;
            }
        }
    }
}