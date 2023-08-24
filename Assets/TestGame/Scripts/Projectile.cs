using System.Threading.Tasks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private async void Start()
    {
        await Task.Delay(10000);
        
        Destroy(gameObject);
    }
}
