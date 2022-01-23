using Leopotam.Ecs;
using UnityEngine;

public class EnemyIdleSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, AnimatorRef, Idle> calmEnemies;
    private RuntimeData runtimeData;
    
    public void Run()
    {
        foreach (var i in calmEnemies)
        {
            ref var enemy = ref calmEnemies.Get1(i);
            ref var player = ref runtimeData.playerEntity.Get<Player>();
            ref var animatorRef = ref calmEnemies.Get2(i);

            if ((enemy.transform.position - player.playerTransform.position).sqrMagnitude <= enemy.triggerDistance * enemy.triggerDistance)
            {
                ref var entity = ref calmEnemies.GetEntity(i);
                entity.Del<Idle>();
                ref var follow = ref entity.Get<Follow>();
                follow.target = runtimeData.playerEntity;
                animatorRef.animator.SetBool("Running", true);
            }
        }
    }
}