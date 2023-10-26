using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Abstract.Spell;
using NexusForever.Game.Spell;
using NexusForever.Game.Static.RBAC;
using NexusForever.Game.Static.Spell.Proc;
using NexusForever.WorldServer.Command.Context;

namespace NexusForever.WorldServer.Command.Handler;

[Command(Permission.Spell, "A collection of commands to manage procs.", "proc")]
public class ProcCommandCategory : CommandCategory
{
    [Command(Permission.SpellAdd, "Triggers a proc on the character", "trigger")]
    [CommandTarget(typeof(IPlayer))]
    public void HandleTrigger(ICommandContext context,
        [Parameter("Proc type to trigger")]
        uint procType)
    {
        var player = context.GetTargetOrInvoker<IPlayer>();
        player.Proc((ProcType)procType, player);
    }
}
