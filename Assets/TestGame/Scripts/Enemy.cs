using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public delegate void EnemyTouchAction();
    public static event EnemyTouchAction OnEnemyTouchedPlayer;
    [SerializeField] private MeshRenderer renderer;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource audio;
    
    [SerializeField] private float speed;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Projectile"))
        {
            Destroy(col.gameObject);
            EnemyDeath();
        }
        else if (col.CompareTag("Player"))
        {
            OnEnemyTouchedPlayer?.Invoke();
        }
    }

    private async void EnemyDeath()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        renderer.enabled = false;
        explosion.SetActive(true);
        audio.Play();
        await Task.Delay(1000); //particles time
        Destroy(gameObject);
    }

    private void Stop()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        OnEnemyTouchedPlayer += Stop;
    }
    
    private void OnDestroy()
    {
        OnEnemyTouchedPlayer -= Stop;
    }
}