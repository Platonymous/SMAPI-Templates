using StardewModdingAPI;

namespace PyTKMod
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
