using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public delegate void PlayerShootAction();
    public static event PlayerShootAction OnPlayerShoot;
    [SerializeField] private AudioSource audio;
    [SerializeField] private InputAction attack;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private float shootDelay;

    private bool _canShoot;
    private void Start()
    {
        _canShoot = true;
        attack.Enable();
        EndGameTrigger.OnWin += DisableAttack;
        Enemy.OnEnemyTouchedPlayer += DisableAttack;
    }

    private void OnDestroy()
    {
        attack.Disable();
        EndGameTrigger.OnWin -= DisableAttack;
        Enemy.OnEnemyTouchedPlayer -= DisableAttack;
    }

    private void DisableAttack()
    {
        attack.Disable();
    }
    

    private async void Update()
    {
        if (attack.WasPressedThisFrame() && _canShoot)
        {
            _canShoot = false;
            OnPlayerShoot?.Invoke();
            audio.Play();
            CreateProjectile();
            await Task.Delay(2000);
            _canShoot = true;

        }
    }

    void CreateProjectile()
    {
        GameObject obj = Instantiate(projectile, shootPosition.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.right * projectileSpeed;
    }
}
