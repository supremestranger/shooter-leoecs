using Leopotam.Ecs;

public class DamageSystem : IEcsRunSystem
{
    private EcsFilter<DamageEvent> damageEvents;
    
    public void Run()
    {
        foreach (var i in damageEvents)
        {
            ref var e = ref damageEvents.Get1(i);
            ref var health = ref e.target.Get<Health>();

            health.value -= e.value;

            // если таргет мертв
            if (health.value <= 0)
            {
                e.target.Get<DeathEvent>();
            }

            damageEvents.GetEntity(i).Destroy();
        }
    }
}