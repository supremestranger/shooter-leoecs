using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    public UI ui;

    private EcsWorld ecsWorld;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;
    
    private void Start()
    {
        ecsWorld = new EcsWorld();
        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (ecsWorld);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (updateSystems);
#endif
        updateSystems
            .Add(new PlayerInitSystem())
            .Add(new EnemyInitSystem())
            .OneFrame<TryReload>()
            .Add(new PlayerInputSystem())
            .Add(new PauseSystem())
            .Add(new PlayerRotationSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new EnemyIdleSystem())
            .Add(new EnemyFollowSystem())
            .Add(new DamageSystem())
            .Add(new EnemyDeathSystem())
            .Add(new PlayerDeathSystem())
            .Add(new WeaponShootSystem())
            .Add(new SpawnProjectileSystem())
            .Add(new ProjectileMoveSystem())
            .Add(new ProjectileHitSystem())
            .Add(new ReloadingSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(ui)
            .Inject(runtimeData);

        fixedUpdateSystems
            .Add(new PlayerMoveSystem())
            .Add(new CameraFollowSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);
        
        updateSystems.Init();
        fixedUpdateSystems.Init();
    }

    private void Update()
    {
        updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        ecsWorld.Destroy();
        updateSystems.Destroy();
    }
}