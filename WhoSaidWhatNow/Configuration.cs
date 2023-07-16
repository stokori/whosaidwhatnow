using System;
using System.Collections.Generic;
using System.Numerics;
using WhoSaidWhatNow.Objects;

using Dalamud.Configuration;
using Dalamud.Game.Text;
using Dalamud.Plugin;

namespace WhoSaidWhatNow
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 1;

        /// <summary>
        /// Start plugin as on by default for better UX. Improved UX outweighs performance issue for now
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Whether the chat log window should autoscroll.
        /// </summary>
        public bool Autoscroll { get; set; } = false;

        /// <summary>
        /// Player IDs that should always be tracked.
        /// </summary>
        public List<uint> AlwaysTrackedPlayers = new List<uint>();

        public string CurrentPlayer = null;

        // CHANNEL CONFIGURATION //
        //I don't feel the need to generate the linkshell ones with a for loop, this is perfectly legible
        //Channel visibility toggle
        public IDictionary<XivChatType, bool> ChannelToggles = new Dictionary<XivChatType, bool>()
        {
            { XivChatType.Say, true},
            { XivChatType.TellIncoming, true},
            { XivChatType.TellOutgoing, true},
            { XivChatType.StandardEmote, true},
            { XivChatType.CustomEmote, true},
            { XivChatType.Shout, true},
            { XivChatType.Yell, true},
            { XivChatType.Party, true},
            { XivChatType.CrossParty, true},
            { XivChatType.Alliance, true},
            { XivChatType.FreeCompany, true},
            { XivChatType.Ls1, true},
            { XivChatType.Ls2, true},
            { XivChatType.Ls3, true},
            { XivChatType.Ls4, true},
            { XivChatType.Ls5, true},
            { XivChatType.Ls6, true},
            { XivChatType.Ls7, true},
            { XivChatType.Ls8, true},
            { XivChatType.CrossLinkShell1, true},
            { XivChatType.CrossLinkShell2, true},
            { XivChatType.CrossLinkShell3, true},
            { XivChatType.CrossLinkShell4, true},
            { XivChatType.CrossLinkShell5, true},
            { XivChatType.CrossLinkShell6, true},
            { XivChatType.CrossLinkShell7, true},
            { XivChatType.CrossLinkShell8, true}
        };

        //TODO: Custom chat color values, ideally using ingame colors
        //Default chat color values
        public readonly IDictionary<XivChatType, Vector4> ChatColors = new Dictionary<XivChatType, Vector4>()
        {
            { XivChatType.Say, new Vector4(0.969f,0.969f,0.961f, 1f)},
            { XivChatType.TellIncoming, new Vector4(1f,0.784f,0.929f, 1f) },
            { XivChatType.TellOutgoing, new Vector4(1f,0.784f,0.929f, 1f) },
            { XivChatType.StandardEmote, new Vector4(0.353f,0.878f,0.725f, 1f) },
            { XivChatType.CustomEmote, new Vector4(0.353f,0.878f,0.725f, 1f) },
            { XivChatType.Shout, new Vector4(1f,0.729f,0.486f, 1f) },
            { XivChatType.Yell, new Vector4(1f, 1f, 0f, 1f) },
            { XivChatType.Party, new Vector4(0.259f,0.784f,0.859f, 1f) },
            { XivChatType.CrossParty, new Vector4(0.259f,0.784f,0.859f, 1f) },
            { XivChatType.Alliance, new Vector4(1f,0.616f,0.125f, 1f) },
            { XivChatType.FreeCompany, new Vector4(0.624f, 0.816f, 0.839f, 1f) },
            { XivChatType.Ls1, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls2, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls3, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls4, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls5, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls6, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls7, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.Ls8, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell1, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell2, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell3, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell4, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell5, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell6, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell7, new Vector4(0.863f, 0.961f, 0.431f, 1f) },
            { XivChatType.CrossLinkShell8, new Vector4(0.863f, 0.961f, 0.431f, 1f) }
        };

        //Channel format for when printing message
        public readonly IDictionary<XivChatType, string> Formats = new Dictionary<XivChatType, string>()
        {
            { XivChatType.Say, "{0}: {1}" },
            { XivChatType.TellIncoming, "{0} >> {1}" },
            { XivChatType.TellOutgoing, ">> {0}: {1}" },
            { XivChatType.StandardEmote, "{1}" },
            { XivChatType.CustomEmote, "{0} {1}" },
            { XivChatType.Shout, "{0} shouts: {1}" },
            { XivChatType.Yell, "{0} yells: {1}" },
            { XivChatType.Party, "({0}) {1}" },
            { XivChatType.CrossParty, "({0}) {1}" },
            { XivChatType.Alliance, "(({0})) {1}" },
            { XivChatType.FreeCompany, "[FC]<{0}> {1}" },
            { XivChatType.Ls1, "[LS1]<{0}> {1}"},
            { XivChatType.Ls2, "[LS2]<{0}> {1}"},
            { XivChatType.Ls3, "[LS3]<{0}> {1}"},
            { XivChatType.Ls4, "[LS4]<{0}> {1}"},
            { XivChatType.Ls5, "[LS5]<{0}> {1}"},
            { XivChatType.Ls6, "[LS6]<{0}> {1}"},
            { XivChatType.Ls7, "[LS7]<{0}> {1}"},
            { XivChatType.Ls8, "[LS8]<{0}> {1}"},
            { XivChatType.CrossLinkShell1, "[CWLS1]<{0}> {1}"},
            { XivChatType.CrossLinkShell2, "[CWLS2]<{0}> {1}"},
            { XivChatType.CrossLinkShell3, "[CWLS3]<{0}> {1}"},
            { XivChatType.CrossLinkShell4, "[CWLS4]<{0}> {1}"},
            { XivChatType.CrossLinkShell5, "[CWLS5]<{0}> {1}"},
            { XivChatType.CrossLinkShell6, "[CWLS6]<{0}> {1}"},
            { XivChatType.CrossLinkShell7, "[CWLS7]<{0}> {1}"},
            { XivChatType.CrossLinkShell8, "[CWLS8]<{0}> {1}"}
        };

        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private DalamudPluginInterface? PluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            PluginInterface = pluginInterface;
        }

        public void Save()
        {
            PluginInterface!.SavePluginConfig(this);
        }
    }
}
