using Spine.Unity;
using UnityEngine;

public class PlayerAnimChangeOnEvent : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation animation;

    private void Start()
    {
        EndGameTrigger.OnWin += Idle;
        PlayerShoot.OnPlayerShoot += Shoot;
        Enemy.OnEnemyTouchedPlayer += Loose;
    }


    private void OnDestroy()
    {
        EndGameTrigger.OnWin -= Idle;
        PlayerShoot.OnPlayerShoot -= Shoot;
        Enemy.OnEnemyTouchedPlayer -= Loose;
    }
    
    private void Shoot()
    {
        animation.AnimationState.AddAnimation(1, "shoot", false, 0);
        animation.AnimationState.AddEmptyAnimation(1, 0f, 1f);
        Run();
    }

    private void Idle()
    {
        animation.AnimationState.AddEmptyAnimation(1, 0.2f, 0f);
        animation.AnimationState.SetAnimation(0, "idle", true);
    }

    private void Run()
    {
        animation.AnimationState.AddAnimation(0, "run", true, 0);
    }

    private void Loose()
    {
        animation.AnimationState.AddEmptyAnimation(1, 0.2f, 0f);
        animation.AnimationState.SetAnimation(0, "loose", false);
    }
}
