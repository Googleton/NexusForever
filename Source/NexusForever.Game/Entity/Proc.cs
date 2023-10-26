using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Spell;
using NexusForever.Game.Static.Spell.Proc;

namespace NexusForever.Game.Entity;

public class Proc : IProc
{
    public ProcType ProcType { get; }
    public uint EffectSpellId { get; }
    public uint InternalCooldown { get; }
    
    private DateTime lastTriggered = DateTime.MinValue;

    public Proc(ProcType type, uint effectSpellId, uint internalCooldown)
    {
        ProcType = type;
        EffectSpellId = effectSpellId;
        InternalCooldown = internalCooldown;
    }
    
    public void TriggerProc(IUnitEntity owner, IUnitEntity target)
    {
        // 1. Check if our cooldown is over
        if (lastTriggered + TimeSpan.FromMilliseconds(InternalCooldown) > DateTime.Now)
            return;
        
        lastTriggered = DateTime.Now;
        
        owner.CastSpell(EffectSpellId, new SpellParameters()
        {
            PrimaryTargetId = owner.Guid
        });
    }
}
