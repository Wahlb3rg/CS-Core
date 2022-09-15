using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace CS_core.Client
{
    public class ClientMain : BaseScript
    {
        
        public ClientMain()
        {
            //Piss("test");
            Debug.WriteLine("Hi from CS_core.Client! Det er mig der er en ændring");
        }

        [Command("teste")]
        public void Tets()
        {
            /*BeginTextCommandThefeedPost("STRING");
            AddTextComponentSubstringPlayerName("String ding ding");
            EndTextCommandThefeedPostTicker(true, false);*/

            NotifyMessage("Det her er lige en test så nu skal jeg se hvad der sker. Ding ding");
        }

        private void NotifyMessage(string message)
        {
            BeginTextCommandDisplayHelp("STRING");
            AddTextComponentSubstringPlayerName(message);
            EndTextCommandDisplayHelp(0, false, true, -1);
            
            /* Help texts support text formatting, check out https://docs.fivem.net/docs/game-references/text-formatting/
            AddTextEntry('HelpMsg', 'Press ~INPUT_CONTEXT~ to do something.');

            BeginTextCommandDisplayHelp('HelpMsg');
            EndTextCommandDisplayHelp(0, false, true, -1);*/
        }

        [Tick]
        public Task OnTick()
        {
            DrawRect(0.05f, 0.05f, 0.05f, 0.5f, 255, 0, 0, 255);
            return Task.FromResult(0);
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
 
/* Citizen.CreateThread(function()
    local h_key = 74
    local x_key = 73
    while true do
        Citizen.Wait(1)
        if IsControlJustReleased(1,  h_key --[[ H key ]]) then
            giveWeapon("weapon_pistol")
            giveWeapon("weapon_knife")
            alert("~b~Given weapons with ~INPUT_VEH_HEADLIGHT~")

        elseif IsControlJustReleased(1,  x_key --[[ X key ]]) then
            giveWeapon("weapon_combatmg")
            alert("~g~Given weapons with ~INPUT_VEH_DUCK~")
        end
    end
end)*/
