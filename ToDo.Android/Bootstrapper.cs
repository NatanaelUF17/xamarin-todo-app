using System;
namespace ToDo.Droid
{
    public class Bootstrapper : ToDo.Bootstrapper
    {
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}
