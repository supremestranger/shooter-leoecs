using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<Player>();
        ref var inputData = ref playerEntity.Get<PlayerInputData>(); 

        GameObject playerGO = Object.Instantiate(staticData.playerPrefab, sceneData.playerSpawnPoint.position,
            Quaternion.identity);
        player.playerTransform = playerGO.transform;
        player.playerAnimator = playerGO.GetComponent<Animator>();
        player.playerRigidbody = playerGO.GetComponent<Rigidbody>();
        player.playerSpeed = staticData.playerSpeed;
    }
}