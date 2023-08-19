using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Roles;
using PlayerRoles;
using System;
using System.Linq;

namespace pizdec
{
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class gasmask : ICommand
    {
        public string Command => "emp";

        public string[] Aliases => new string[] { };

        public string Description => "Отключи всё";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            string name = string.Join(" ", arguments);
            var pidor = Player.Get(sender);
            pidor.DisplayNickname = name;
            response = $"Имя изменилось на {name}";
            return true;
        }
    }
}

