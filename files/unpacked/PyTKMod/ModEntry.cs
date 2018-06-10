using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using StardewModdingAPI;
using PyTK.Extensions;
using PyTK.CustomElementHandler;
using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$
{
    public class ModEntry : Mod
    {
        internal static Config config;
        internal static List<CustomObjectData> customObjects;

        public override void Entry(IModHelper helper)
        {
            Monitor.Log($"Started {helper.ModRegistry.ModID} from folder: {helper.DirectoryPath}");

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
                CustomObjectData.newObject("$safeprojectname$.RedPill", pillTexture, Color.Red, "Red Pill", "Take the red pill", edibility:50),
                CustomObjectData.newObject("$safeprojectname$.BluePill", pillTexture, Color.Blue, "Blue Pill", "Take the blue pill", edibility: 50)
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
