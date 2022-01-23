using Leopotam.Ecs;
using UnityEngine;

public class EnemyInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;

    public void Init()
    {
        foreach (var enemyView in Object.FindObjectsOfType<EnemyView>())
        {
            var enemyEntity = ecsWorld.NewEntity();

            ref var enemy = ref enemyEntity.Get<Enemy>();
            ref var health = ref enemyEntity.Get<Health>();
            ref var animatorRef = ref enemyEntity.Get<AnimatorRef>();

            enemyEntity.Get<Idle>();

            health.value = enemyView.startHealth;
            enemy.damage = enemyView.damage;
            enemy.meleeAttackDistance = enemyView.meleeAttackDistance;
            enemy.navMeshAgent = enemyView.navMeshAgent;
            enemy.transform = enemyView.transform;
            enemy.meleeAttackInterval = enemyView.meleeAttackInterval;
            enemy.triggerDistance = enemyView.triggerDistance;
            animatorRef.animator = enemyView.animator;

            enemyView.entity = enemyEntity;
        }
    }
}