using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace CS_core.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from CS_core.Server! Hej med dig!");
            TriggerClientEvent(Player, "eventName", "Hello from server!");
            
            
        }

        
        /*[Command("ping")]
        public void HelloServer()
        {
            Debug.WriteLine("Hello from server!");
        }*/
    }
}