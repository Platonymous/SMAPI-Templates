using Microsoft.Xna.Framework.Input;

namespace SMAPIMod
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
