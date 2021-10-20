using Leopotam.Ecs;
using UnityEngine;

public class CameraFollowSystem : IEcsRunSystem
{
    private EcsFilter<Player> filter;
    private SceneData sceneData;
    private StaticData staticData;
    // Хранение лишних данных в системах - не всегда хорошая идея. Но если вы уверены, что больше они нигде не понадобятся, это допустимо.
    private Vector3 currentVelocity; // это поле нужно для работы метода Vector3.SmoothDamp

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
