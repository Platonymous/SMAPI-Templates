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

            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        }

        private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            e.Button.TryGetKeyboard(out Keys keyPressed);

            if (keyPressed.Equals(config.debugKey))
                Monitor.Log($"Debug Key pressed", LogLevel.Info);
        }
    }
}
