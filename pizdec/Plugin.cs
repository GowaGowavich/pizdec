using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.Extensions;
using Exiled.Events.Handlers;
using InventorySystem;
using PlayerRoles;
using PluginAPI.Roles;

namespace pizdec
{
    public class Plugin: Plugin<Config>
    {
        public override string Name => "Бродкаст момент";
        public override string Author => "Григорий Лепин";
        public override string Prefix => "queres";
        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Player.Spawned += Player_Spawned;
            Exiled.Events.Handlers.Warhead.Detonated += Warhead_Detonated;
        }

        private void Player_Spawned(Exiled.Events.EventArgs.Player.SpawnedEventArgs ev)
        {
            if (ev.Player.Role.Type is RoleTypeId.Scientist)
            {
                ev.Player.AddAmmo(AmmoType.Nato9, 100);
                ev.Player.AddItem(ItemType.SCP500);
                ev.Player.Health = 500;
                Log.Info("hui");
            }
        }

        private void Warhead_Detonated()
        {

            foreach(Exiled.API.Features.Player Player in Exiled.API.Features.Player.List)
            {
                Player.Kill("Умер от радиации");
            }
        }
    }
}
