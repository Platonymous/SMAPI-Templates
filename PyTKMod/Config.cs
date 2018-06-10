using Microsoft.Xna.Framework.Input;

namespace PyTKMod
{
    class Config
    {
        public Keys debugKey { get; set; }

        public Config()
        {
            debugKey = Keys.J;
        }
    }
}
