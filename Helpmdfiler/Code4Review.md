# Server

En måde at læse userdata på

```lua
RegisterNetEvent('qb-multicharacter:server:loadUserData', function(cData)
    local src = source
    if QBCore.Player.Login(src, cData.citizenid) then
        repeat
            Wait(10)
        until hasDonePreloading[src]
        print('^2[qb-core]^7 '..GetPlayerName(src)..' (Citizen ID: '..cData.citizenid..') has succesfully loaded!')
        QBCore.Commands.Refresh(src)
        loadHouseData(src)
        TriggerClientEvent('apartments:client:setupSpawnUI', src, cData)
        TriggerEvent("qb-log:server:CreateLog", "joinleave", "Loaded", "green", "**".. GetPlayerName(src) .. "** ("..(QBCore.Functions.GetIdentifier(src, 'discord') or 'undefined') .." |  ||"  ..(QBCore.Functions.GetIdentifier(src, 'ip') or 'undefined') ..  "|| | " ..(QBCore.Functions.GetIdentifier(src, 'license') or 'undefined') .." | " ..cData.citizenid.." | "..src..") loaded..")
    end
end)
```

Command funktion som kunne være nice atr bruge

```lua
function QBCore.Commands.Add(name, help, arguments, argsrequired, callback, permission, ...)
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
```
mere command ting ting

```lua
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
```
Database shit 

```csharp
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        using IDbConnection connection =
            new SqlConnection("Server=localhost,11433;User=sa;Password=Pass123!;Database=basics;");
        
        var people = 
            await connection.QueryAsync<Person>("select * from People");

        foreach (var person in people)
        {
            Console.WriteLine($"Hello from {person.Name}");
        }
        
        var name = "Steve Rogers";
        var count = 
            await connection
                .ExecuteAsync(
                    @"insert People(Name) values (@name)",
                    new { name });


        Console.WriteLine($"Inserted {count} rows.");
        
        var removed =
            await connection.ExecuteAsync(
                "delete from People where Name = @name",
                new {name}
            );

        Console.WriteLine($"Removed {removed} rows.");
    }
}

```
# Client

# Ved ikke om det er Client eller Server
Tror at den er client men er ikke helt sikker det er det card der kommer før man joiner kan bruges til char selctor :pog:

```lua
AddEventHandler('playerConnecting', function(name, skr, d)
    d.defer()
    Wait(50)
    -- badly serialized JSON in a string, from the Adaptive Cards designer
    d.presentCard([==[{"type":"AdaptiveCard","body":[{"type":"TextBlock","size":"ExtraLarge","weight":"Bolder","text":"Server password?!"},{"type":"TextBlock","text":"That's right, motherfucker! You have to enter a goddamn PASSWORD to connect to this server...","wrap":true},{"type":"Input.Text","id":"password","title":"","placeholder":"better enter one now"},{"type":"Image","url":"http://images.amcnetworks.com/ifccenter.com/wp-content/uploads/2019/04/pulpfic_1280.jpg","altText":""},{"type":"ActionSet","actions":[{"type":"Action.Submit","title":"Sure..."},{"type":"Action.ShowCard","title":"YOU WISH!!!!!!","card":{"type":"AdaptiveCard","body":[{"type":"Image","url":"https://i.imgur.com/YjMR0E6.jpg","altText":""}],"$schema":"http://adaptivecards.io/schemas/adaptive-card.json"}}]}],"$schema":"http://adaptivecards.io/schemas/adaptive-card.json","version":"1.0"}]==],
        function(data, rawData)
            -- you can chain cards, this is just the example adaptive card in the designer
            d.presentCard([==[{"type":"AdaptiveCard","body":[{"type":"Container","items":[{"type":"TextBlock","size":"Medium","weight":"Bolder","text":"Publish Adaptive Card schema"},{"type":"ColumnSet","columns":[{"type":"Column","items":[{"type":"Image","style":"Person","url":"https://pbs.twimg.com/profile_images/3647943215/d7f12830b3c17a5a9e4afcc370e3a37e_400x400.jpeg","size":"Small"}],"width":"auto"},{"type":"Column","items":[{"type":"TextBlock","weight":"Bolder","text":"Matt Hidinger","wrap":true},{"type":"TextBlock","spacing":"None","text":"Created {{DATE(2017-02-14T06:08:39Z,SHORT)}}","isSubtle":true,"wrap":true}],"width":"stretch"}]}]},{"type":"Container","items":[{"type":"TextBlock","text":"Now that we have defined the main rules and features of the format, we need to produce a schema and publish it to GitHub. The schema will be the starting point of our reference documentation.","wrap":true},{"type":"FactSet","facts":[{"title":"Board:","value":"Adaptive Card"},{"title":"List:","value":"Backlog"},{"title":"Assigned to:","value":"Matt Hidinger"},{"title":"Due date:","value":"Not set"}]}]}],"actions":[{"type":"Action.ShowCard","title":"Set due date","card":{"type":"AdaptiveCard","body":[{"type":"Input.Date","id":"dueDate"},{"type":"Input.Text","id":"comment","placeholder":"Add a comment","isMultiline":true}],"actions":[{"type":"Action.Submit","title":"OK","url":"http://adaptivecards.io"}],"$schema":"http://adaptivecards.io/schemas/adaptive-card.json"}},{"type":"Action.Submit","title":"View","url":"http://adaptivecards.io"}],"$schema":"http://adaptivecards.io/schemas/adaptive-card.json","version":"1.0"}]==],
                function(_, rawData2)
                    -- normally you'd check the password, also submit button IDs are sent as submitId
                    -- we're lazy so just reject everyone and tell them the password
                    d.done('you suck actually for entering the password: ' .. data.password .. ' and data like ' .. rawData2)
                end)
        end)
end)
—
```