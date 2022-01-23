using Leopotam.Ecs;

public class PlayerDeathSystem : IEcsRunSystem
{
    private EcsFilter<Player, DeathEvent, AnimatorRef> deadPlayers;
    private RuntimeData runtimeData;
    private UI ui;
    
    public void Run()
    {
        foreach (var i in deadPlayers)
        {
            ref var animatorRef = ref deadPlayers.Get3(i);
            
            animatorRef.animator.SetTrigger("Death");
            ui.deathScreen.Show();
            runtimeData.gameOver = true;
            
            deadPlayers.GetEntity(i).Destroy();
        }
    }
}