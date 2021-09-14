using UnityEngine;

public class WeaponSettings : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSocket;
    public float reloadDuration;
    public float projectileSpeed;
    public float projectileRadius;
    public float shootInterval;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;
}