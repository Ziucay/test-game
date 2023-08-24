using Spine.Unity;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation animation;
    private void Start()
    {
        Enemy.OnEnemyTouchedPlayer += Cheer;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyTouchedPlayer -= Cheer;
    }

    private void Cheer()
    {
        animation.AnimationState.AddEmptyAnimation(1, 0.2f, 0f);
        animation.AnimationState.AddAnimation(0, "win", true, 0);
    }
}
