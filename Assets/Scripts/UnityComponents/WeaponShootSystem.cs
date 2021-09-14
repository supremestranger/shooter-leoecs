using Leopotam.Ecs;
using UnityEngine;

public class WeaponShootSystem : IEcsRunSystem
{
    private EcsFilter<Weapon, Shoot> filter;
    
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);

            if (Time.time >= weapon.lastTimeShot + weapon.shootInterval && weapon.currentInMagazine > 0)
            {
                weapon.lastTimeShot = Time.time;
                weapon.currentInMagazine--;
                ref var entity = ref filter.GetEntity(i);
                ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                entity.Del<Shoot>();
            }
        }
    }
}