using Leopotam.Ecs;

public class EnemyDeathSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, DeathEvent, AnimatorRef> deadEnemies;
    
    public void Run()
    {
        foreach (var i in deadEnemies)
        {
            ref var animatorRef = ref deadEnemies.Get3(i);
            
            animatorRef.animator.SetTrigger("Death");

            ref var entity = ref deadEnemies.GetEntity(i);
            entity.Destroy();
        }
    }
}