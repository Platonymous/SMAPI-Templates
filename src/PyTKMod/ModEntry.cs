using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using StardewModdingAPI;
using PyTK.Extensions;
using PyTK.CustomElementHandler;
using System.Collections.Generic;
using System.Linq;

namespace PyTKMod
{
    public class ModEntry : Mod
    {
        internal Config config;
        internal List<CustomObjectData> customObjects;
        internal ITranslationHelper i18n => Helper.Translation;

        public override void Entry(IModHelper helper)
        {
            string startingMessage = i18n.Get("template.start", new { mod = helper.ModRegistry.ModID, folder = helper.DirectoryPath });
            Monitor.Log(startingMessage,LogLevel.Trace);

            config = helper.ReadConfig<Config>();

            initExample();
        }

        private void initExample()
        {
            int opalIndex = Game1.objectInformation.getIndexByName("Opal");
            Rectangle opalSourceRectangle = Game1.getSourceRectForStandardTileSheet(Game1.objectSpriteSheet, opalIndex, 16, 16);
            Texture2D pillTexture = Game1.objectSpriteSheet.getArea(opalSourceRectangle).setSaturation(0);

            customObjects = new List<CustomObjectData>();
            customObjects.AddRange(new[] {
                CustomObjectData.newObject("PyTKMod.RedPill", pillTexture, Color.Red, i18n.Get("template.redpill.name"), i18n.Get("template.redpill.description"), edibility:50),
                CustomObjectData.newObject("PyTKMod.BluePill", pillTexture, Color.Blue, i18n.Get("template.bluepill.name"), i18n.Get("template.bluepill.description"), edibility: 50)
            });

            config.debugKey.onPressed(() =>
            {
                if (!Context.IsWorldReady)
                    return;

                Game1.activeClickableMenu = new ItemGrabMenu(customObjects.Select(o => o.getObject()).ToList());
            });
        }
    }
}
