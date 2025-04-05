//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void takeDamage() {
        Destroy(gameObject);
        GameManager gamemanager = GameObject.FindAnyObjectByType<GameManager>();
        gamemanager.checkLevelComplete();
    }


    private void OnCollisionEnter(Collision collision) {
       // Debug.Log(collision.collider.gameObject.name);
        if (collision.collider.gameObject != null) {
            Bullet bullet = collision.collider.gameObject.GetComponent<Bullet>();
            if (bullet != null) {
                takeDamage();
                Destroy(bullet.gameObject);
            }

        }
    }

    /*
    private void OnTriggerEnter(Collider other) {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet != null) {
            takeDamage();
            Destroy(bullet.gameObject);
        }


    }
    */
}
