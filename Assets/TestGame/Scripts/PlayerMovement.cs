using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        player.velocity = Vector3.right * moveSpeed;
        EndGameTrigger.OnWin += StopMove;
        Enemy.OnEnemyTouchedPlayer += StopMove;
    }

    private void StopMove()
    {
        player.velocity = Vector3.zero;
    }

    private void OnDestroy()
    {
        EndGameTrigger.OnWin -= StopMove;
        Enemy.OnEnemyTouchedPlayer -= StopMove;
    }
}
