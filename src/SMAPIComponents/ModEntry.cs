using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace SMAPIComponents
{
    public class ModEntry : Mod
    {
        internal static Config config;

        public override void Entry(IModHelper helper)
        {
            Monitor.Log($"Started {helper.ModRegistry.ModID} from folder: {helper.DirectoryPath}");

            config = helper.ReadConfig<Config>();

            InputEvents.ButtonPressed += InputEvents_ButtonPressed;
        }

        private void InputEvents_ButtonPressed(object sender, EventArgsInput e)
        {
            e.Button.TryGetKeyboard(out Keys keyPressed);

            if (keyPressed.Equals(config.debugKey))
                Monitor.Log($"Debug Key pressed", LogLevel.Info);
        }
    }
}
