using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public EcsEntity entity;
    public float meleeAttackDistance;
    public float triggerDistance;
    public float meleeAttackInterval;
    public int startHealth;
    public int damage;
}