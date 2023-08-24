using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public delegate void GameWinAction();
    public static event GameWinAction OnWin;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            OnWin?.Invoke();
    }
}
