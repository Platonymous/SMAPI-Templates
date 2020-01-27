using Microsoft.Xna.Framework;
using StardewValley;
using StardewModdingAPI;
using PyTK.Types;

namespace PyTKTileAction
{
    public class ModEntry : Mod
    {
        internal Config config;
        internal ITranslationHelper i18n => Helper.Translation;

        public override void Entry(IModHelper helper)
        {
            string startingMessage = i18n.Get("template.start", new { mod = helper.ModRegistry.ModID, folder = helper.DirectoryPath });
            Monitor.Log(startingMessage, LogLevel.Trace);

            config = helper.ReadConfig<Config>();

            Helper.Events.GameLoop.GameLaunched += GameLoop_GameLaunched;
        }

        private void GameLoop_GameLaunched(object sender, StardewModdingAPI.Events.GameLaunchedEventArgs e)
        {
            TileAction tileAction = new TileAction("alert", PyTKTileAction_Action);
            tileAction.register();
        }

        private bool PyTKTileAction_Action(string key, string values, GameLocation location, Vector2 position, string layer)
        {
            HUDMessage hudMessage = new HUDMessage($"{values} (X{(int)position.X} Y{(int)position.Y})", config.messageType);
            Game1.hudMessages.Add(hudMessage);

            return true;
        }
    }
}
