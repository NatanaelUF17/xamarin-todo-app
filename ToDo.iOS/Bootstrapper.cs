using System;
namespace ToDo.iOS
{
    public class Bootstrapper : ToDo.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}
