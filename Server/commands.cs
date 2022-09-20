using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace CSCore.commands
{
    public class ServerCommands : BaseScript
    {
      /*public Class1()
        {
            
        }*/
    
        
        [Command("hej")]
        public void Hej()
        {
            Debug.WriteLine("Hej med dig");
            //NotifyMessage("Jamen hej med dig");
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Virker det her eller ej");
            //NotifyMessage("Jamen hej med dig");
        }

        [Command("nut")]
        private void Nuts()
        {
            Debug.WriteLine("CUM NUT AHHH");
        }
        
    }
}
