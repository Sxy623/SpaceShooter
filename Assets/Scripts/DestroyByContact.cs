using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boundary")) return;
        var selfTransform = transform;
        Instantiate(explosion, selfTransform.position, selfTransform.rotation);
        if (other.CompareTag("Player")) {
            var otherTransform = other.transform;
            Instantiate(playerExplosion, otherTransform.position, otherTransform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
