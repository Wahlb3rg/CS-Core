# Triggering events

## Triggering local events

```cs
TriggerEvent("eventName", eventParam1, eventParam2);
```

## Triggering server events

```cs
TriggerServerEvent("eventName", eventParam1, eventParam2);
```

## Triggering client events

Method one. Trigger an event directly on a client source.
```cs
player.TriggerEvent("eventName", eventParam1, eventParam2);
```

Method two. Trigger an event for everyone on the server.
```cs
TriggerClientEvent("eventName", eventParam1, eventParam2); // Note you do not need to specify a target of -1.
```
Method three. Again, triggering an event directly on a client source (like method one),
but using the TriggerClientEvent native function instead.
```cs
TriggerClientEvent(player, "eventName", eventParam1, eventParam2);
```

# Listening for events

In C#, you use the [FromSource] attribute, as seen in the example below.

Usually in the constructor of a class that inherits BaseScript, but can be done anywhere in a BaseScript.
```cs
EventHandlers["eventName"] += new Action<string, bool>(TargetFunction);
```

Create a function to handle the event somewhere else in your code, or use a lambda.
```cs
private void TargetFunction(string param1, bool param2)
{
    // Code that gets executed once the event is triggered goes here.
}
```

Using source (on the server) works as follows:

constructor code
```cs
EventHandlers["netEventName"] += new Action<Player, string, bool>(TargetFunction);
```


Create a function to handle the event somewhere else in your code, or use a lambda.
```cs
private void TargetFunction([FromSource] Player source, string param1, bool param2)
{
    // Code that gets executed once the event is triggered goes here.
    // The variable 'source' contains a reference to the player that triggered the event.
}
```