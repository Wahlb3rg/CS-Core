fx_version 'bodacious'
game 'gta5'

author 'Wahlb3rg'
version '1.0.0'

fxdk_watch_command 'dotnet' {'watch', '--project', 'Client/CS-Core.Client.csproj', 'publish', '--configuration', 'Release'}
fxdk_watch_command 'dotnet' {'watch', '--project', 'Server/CS-Core.Server.csproj', 'publish', '--configuration', 'Release'}

file 'Client/bin/Release/**/publish/*.dll'

client_script 'Client/bin/Release/**/publish/*.net.dll'
server_script {
    'Server/bin/Release/**/publish/*.net.dll',
    --Den skal route til mit script med server ting ting'@oxmysql/lib/MySQL.lua',
    }
    
dependency 'CDatabase'