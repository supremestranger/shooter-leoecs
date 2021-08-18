using System;
using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;

    private EcsWorld ecsWorld;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;

    private void Start()
    {
        ecsWorld = new EcsWorld();
        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerRotationSystem())
            .Add(new PlayerAnimationSystem())
            .Inject(configuration)
            .Inject(sceneData)
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