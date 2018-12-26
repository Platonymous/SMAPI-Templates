using StardewModdingAPI;

namespace SMAPIComponents
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
