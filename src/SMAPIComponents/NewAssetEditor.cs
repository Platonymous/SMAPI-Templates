﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

namespace SMAPIComponents
{
    class NewAssetEditor : IAssetEditor
    {
        // Add to Entry: helper.Content.AssetEditors.Add(new SMAPIComponents.NewAssetEditor(helper));

        private IModHelper helper;

        public NewAssetEditor(IModHelper helper)
        {
            this.helper = helper;
        }
      
        public bool CanEdit<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals(@"Texture/To/Edit") || asset.AssetNameEquals(@"Data/To/Edit");
        }

        public void Edit<T>(IAssetData asset)
        {
            int index = 100;

            if (asset.AssetNameEquals(@"Texture/To/Edit"))
            {
                Texture2D image = helper.Content.Load<Texture2D>(@"MyAssets/Edit.png", ContentSource.ModFolder);
                Rectangle targetArea = Game1.getSourceRectForStandardTileSheet(asset.AsImage().Data, index, 16, 16);
                asset.AsImage().PatchImage(image, null, targetArea, PatchMode.Replace);
            }
            else if (asset.AssetNameEquals(@"Data/To/Edit"))
            {
                string newValue = "New/Values/...";
                if(asset.AsDictionary<int, string>().Data.ContainsKey(index))
                    asset.AsDictionary<int, string>().Data[index] = newValue;
                else
                    asset.AsDictionary<int, string>().Data.Add(index, newValue);
            }
        }

    }
}
