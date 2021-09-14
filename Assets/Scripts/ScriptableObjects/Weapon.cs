using Leopotam.Ecs;
using UnityEngine;

public struct Weapon
{
    public EcsEntity owner;
    public GameObject projectilePrefab;
    public Transform projectileSocket;
    public float reloadDuration;
    public float lastTimeShot;
    public float projectileSpeed;
    public float shootInterval;
    public float projectileRadius;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;
}