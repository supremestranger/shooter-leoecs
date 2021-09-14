using Leopotam.Ecs;
using UnityEngine;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> filter;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref Player player = ref filter.Get1(i);
            ref PlayerInputData input = ref filter.Get2(i);
            
            float vertical = Vector3.Dot(input.moveInput.normalized, player.playerTransform.forward);
            float horizontal = Vector3.Dot(input.moveInput.normalized, player.playerTransform.right);
            player.playerAnimator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
            player.playerAnimator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
            player.playerAnimator.SetBool("Shooting", input.shootInput);
        }
    }
}