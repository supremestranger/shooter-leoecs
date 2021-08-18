using Leopotam.Ecs;
using UnityEngine;

public class CameraFollowSystem : IEcsRunSystem
{
    private EcsFilter<Player> filter;
    private SceneData sceneData;
    private StaticData staticData;
    private Vector3 currentVelocity;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var player = ref filter.Get1(i);
            
            var currentPos = sceneData.mainCamera.transform.position;
            currentPos = Vector3.SmoothDamp(currentPos, player.playerTransform.position + staticData.followOffset, ref currentVelocity, staticData.smoothTime);
            sceneData.mainCamera.transform.position = currentPos;
        }
    }
}