using Leopotam.Ecs;
using UnityEngine;

internal class PauseSystem : IEcsRunSystem
{
    private EcsFilter<PauseEvent> filter;
    private RuntimeData runtimeData;
    private UI ui;
    
    public void Run()
    {
        foreach (var i in filter)
        {
            filter.GetEntity(i).Del<PauseEvent>();
            runtimeData.isPaused = !runtimeData.isPaused;
            Time.timeScale = runtimeData.isPaused ? 0f : 1f;
            ui.pauseScreen.Show(runtimeData.isPaused);
        }
    }
}