using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace CSCore.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from CSCore.Server!");
        }


        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Vi prøver lige igen igen");
            //NotifyMessage("Jamen hej med dig");
        }
    }
}
