using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start() {
        var gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) { 
            Debug.Log("Cannot find 'GameController' script.");   
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;

        if (explosion != null) {
            var selfTransform = transform;
            Instantiate(explosion, selfTransform.position, selfTransform.rotation);
        }

        if (other.CompareTag("Player")) {
            var otherTransform = other.transform;
            Instantiate(playerExplosion, otherTransform.position, otherTransform.rotation);
            gameController.GameOver();
        }
        
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
