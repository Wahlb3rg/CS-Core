using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace CSCore.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Hi from CSCore.Client!");
        }

        [Tick]
        public Task OnTick()
        {
            //DrawRect(0.5f, 0.5f, 0.5f, 0.5f, 255, 255, 255, 150);

            return Task.FromResult(0);
        }
         public void NotifyMessage(string message)
        {
            BeginTextCommandDisplayHelp("STRING");
            AddTextComponentSubstringPlayerName(message);
            EndTextCommandDisplayHelp(0, false, true, -1);
        }
        
        [Command("teste")]
        public void Tets()
        {
            /*BeginTextCommandThefeedPost("STRING");
            AddTextComponentSubstringPlayerName("String ding ding");
            EndTextCommandThefeedPostTicker(true, false);*/

            NotifyMessage("~g~Given weapons with ~INPUT_VEH_DUCK~");
        }
    }
}

/*
 QBCore.Commands.Add('car', Lang:t("command.car.help"), {{ name = Lang:t("command.car.params.model.name"), help = Lang:t("command.car.params.model.help") }}, true, function(source, args)
    TriggerClientEvent('QBCore:Command:SpawnVehicle', source, args[1])
end, 'admin')
QBCore.Commands.Add('dv', Lang:t("command.dv.help"), {}, false, function(source)
    TriggerClientEvent('QBCore:Command:DeleteVehicle', source)
end, 'admin')
*/