using Leopotam.Ecs;
using UnityEngine;

public class EnemyFollowSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, Follow, AnimatorRef> followingEnemies;
    private RuntimeData runtimeData;
    private EcsWorld ecsWorld;
        
    public void Run()
    {
        foreach (var i in followingEnemies)
        {
            ref var enemy = ref followingEnemies.Get1(i);
            ref var follow = ref followingEnemies.Get2(i);
            ref var animatorRef = ref followingEnemies.Get3(i);

            // при работе с сущностями нужно всегда сначала удостовериться, не уничтожены ли они
            if (!follow.target.IsAlive())
            {
                ref var entity = ref followingEnemies.GetEntity(i);
                animatorRef.animator.SetBool("Running", false);
                entity.Del<Follow>();
                continue;
            }
            
            ref var transformRef = ref follow.target.Get<TransformRef>();
            var targetPos = transformRef.transform.position;
            enemy.navMeshAgent.SetDestination(targetPos);
            var direction = (targetPos - enemy.transform.position).normalized;
            direction.y = 0f;
            enemy.transform.forward = direction;

            if ((enemy.transform.position - transformRef.transform.position).sqrMagnitude <
                enemy.meleeAttackDistance * enemy.meleeAttackDistance && Time.time >= follow.nextAttackTime)
            {
                follow.nextAttackTime = Time.time + enemy.meleeAttackInterval;
                animatorRef.animator.SetTrigger("Attack");
                ref var e = ref ecsWorld.NewEntity().Get<DamageEvent>();
                e.target = follow.target;
                e.value = enemy.damage;
            }
        }
    }
}