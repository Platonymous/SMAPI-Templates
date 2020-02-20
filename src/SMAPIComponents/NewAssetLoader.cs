using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using xTile;

namespace SMAPIComponents
{
    class NewAssetLoader : IAssetLoader
    {
        // Add to Entry: helper.Content.AssetLoaders.Add(new SMAPIComponents.NewAssetLoader(helper));

        private IModHelper helper;

        public NewAssetLoader(IModHelper helper)
        {
            this.helper = helper;
        }

        public bool CanLoad<T>(IAssetInfo asset)
        {
            return asset.AssetNameEquals(@"Texture/To/Replace") || asset.AssetNameEquals(@"Map/To/Replace");
        }

        public T Load<T>(IAssetInfo asset)
        {
            if (asset.AssetNameEquals(@"Texture/To/Replace"))
                return (T)(object)helper.Content.Load<Texture2D>(@"MyAssets/ReplacementTexture.png", ContentSource.ModFolder);
            else if (asset.AssetNameEquals(@"Map/To/Replace"))
                return (T)(object)helper.Content.Load<Map>(@"MyAssets/ReplacementMap.tbin", ContentSource.ModFolder);

            return (T)(object)null;
        }
    }
}
