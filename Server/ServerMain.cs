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
        
        /*RegisterCommand("ping", new Action<int, List<object>, string>((source, args, rawCommand) =>
        {
            if (source > 0) // it's a player.
            {
                // Create a message object.
                dynamic messageObject = new ExpandoObject();
                // Set the message object args (message author, message content)
                messageObject.args = new string[] { GetPlayerName(source.ToString()), "PONG!" };
                // Set the message color (r, g, b)
                messageObject.color = new int[] { 5, 255, 255 };

                // Trigger the client event with the message object on all clients.
                TriggerClientEvent("chat:addMessage", messageObject);
            }
            // It's not a player, so it's the server console, a RCON client, or a resource.
            else
            {
                Debug.WriteLine("This command was executed by the server console, RCON client, or a resource.");
            }
        }), false /*This command is also not restricted, anyone can use it.*/ );*/

        
        // Connect til databse
        /*public static void TestConnection()
        {
            try 
            {
                using(MySqlConnection connection = new MySqlConnection(connStr))
            {
                Debug.WriteLine("Connecting to MySQL Database...");
                connection.Open();

                if(connection.State == ConnectionState.Open) 
                {
                    Debug.WriteLine("DATABASE: Connected to MySQL Server.");
                }
            }
            }
            catch(Exception ex) 
            {
                Debug.WriteLine($"[EXCEPTION - TestConnection] {ex.Message}");
                Debug.WriteLine($"[EXCEPTION - TestConnection] {ex.StackTrace}");
            }
        }*/
    }
}

/*function QBCore.Commands.Add(name, help, arguments, argsrequired, callback, permission, ...)
    local restricted = true -- Default to restricted for all commands
    if not permission then permission = 'user' end -- some commands don't pass permission level
    if permission == 'user' then restricted = false end -- allow all users to use command

    RegisterCommand(name, function(source, args, rawCommand) -- Register command within fivem
        if argsrequired and #args < #arguments then
            return TriggerClientEvent('chat:addMessage', source, {
                color = {255, 0, 0},
                multiline = true,
                args = {"System", Lang:t("error.missing_args2")}
            })
        end
        callback(source, args, rawCommand)
    end, restricted)

    local extraPerms = ... and table.pack(...) or nil
    if extraPerms then
        extraPerms[extraPerms.n + 1] = permission -- The `n` field is the number of arguments in the packed table
        extraPerms.n += 1
        permission = extraPerms
        for i = 1, permission.n do
            if not QBCore.Commands.IgnoreList[permission[i]] then -- only create aces for extra perm levels
                ExecuteCommand(('add_ace qbcore.%s command.%s allow'):format(permission[i], name))
            end
        end
        permission.n = nil
    else
        permission = tostring(permission:lower())
        if not QBCore.Commands.IgnoreList[permission] then -- only create aces for extra perm levels
            ExecuteCommand(('add_ace qbcore.%s command.%s allow'):format(permission, name))
        end
    end

    QBCore.Commands.List[name:lower()] = {
        name = name:lower(),
        permission = permission,
        help = help,
        arguments = arguments,
        argsrequired = argsrequired,
        callback = callback
    }
end

function QBCore.Commands.Refresh(source)
    local src = source
    local Player = QBCore.Functions.GetPlayer(src)
    local suggestions = {}
    if Player then
        for command, info in pairs(QBCore.Commands.List) do
            local hasPerm = IsPlayerAceAllowed(tostring(src), 'command.'..command)
            if hasPerm then
                suggestions[#suggestions + 1] = {
                    name = '/' .. command,
                    help = info.help,
                    params = info.arguments
                }
            else
                TriggerClientEvent('chat:removeSuggestion', src, '/'..command)
            end
        end
        TriggerClientEvent('chat:addSuggestions', src, suggestions)
    end
end 
