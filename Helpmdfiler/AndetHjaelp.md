# Tic
`Tic` er det der i Lua hedder `citizen createthread`
# Commands
Den skal være i server script og så sende til client.\
Feks.
```csharp
[Command("showidentifiers", Restricted = false)]
private void OnShowIdentifiers(int source, List<object> args, string raw) {
  Player player = Players[source];
  player.TriggerEvent("chat:addMessage", new {
    args = new [] {"[Identifiers]", $"Steam: {player.Identifiers["steam"]}"}
  });
}
```