using NexusForever.Game.Static.Spell.Proc;

namespace NexusForever.Game.Abstract.Entity;

public interface IProc
{
    ProcType ProcType { get; }
    uint EffectSpellId { get; }
    uint InternalCooldown { get; }


    void TriggerProc(IUnitEntity owner, IUnitEntity target);
}
