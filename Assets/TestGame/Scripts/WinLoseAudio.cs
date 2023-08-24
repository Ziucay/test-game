using UnityEngine;

public class WinLoseAudio : MonoBehaviour
{
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        Enemy.OnEnemyTouchedPlayer += PlayLoseClip;
        EndGameTrigger.OnWin += PlayWinClip;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyTouchedPlayer -= PlayLoseClip;
        EndGameTrigger.OnWin -= PlayWinClip;
    }

    private void PlayWinClip()
    {
        audio.loop = false;
        audio.clip = winClip;
        audio.Play();
    }
    
    private void PlayLoseClip()
    {
        audio.loop = false;
        audio.clip = loseClip;
        audio.Play();
    }
    
}
