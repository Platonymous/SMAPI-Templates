using StardewModdingAPI;

namespace SMAPIMod
{
    class Config
    {
        public SButton debugKey { get; set; }

        public Config()
        {
            debugKey = SButton.J;
        }
    }
}
