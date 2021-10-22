using Leopotam.Ecs;
using UnityEngine;

public class PlayerRotationSystem : IEcsRunSystem
{
    private EcsFilter<Player> filter;
    private SceneData sceneData;
    private RuntimeData runtimeData;

    public void Run()
    {
        if (runtimeData.isPaused) return;
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);

            Plane playerPlane = new Plane(Vector3.up, player.playerTransform.position);
            Ray ray = sceneData.mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!playerPlane.Raycast(ray, out var hitDistance)) continue;

            player.playerTransform.forward = ray.GetPoint(hitDistance) - player.playerTransform.position;
        }
    }
}