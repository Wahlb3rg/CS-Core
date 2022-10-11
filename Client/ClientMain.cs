using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace CSCoreClient
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Spawn.SpawnPlayer("S_M_Y_MARINE_01", 0.916756f, 528.485f, 174.628f, 0f);
            Debug.WriteLine("Hi from CSCore.Client!");
        }

        [Tick]
        public Task OnTick()
        {
            //DrawRect(0.5f, 0.5f, 0.5f, 0.5f, 255, 255, 255, 150);

            return Task.FromResult(0);
        }
         
        
        
    }
}