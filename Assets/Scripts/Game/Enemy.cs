//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class Enemy : MonoBehaviour {
    // public bool isAlive;
    public AudioSource soundHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        //        isAlive = false;

        //should clean this up later
        soundHit = GameObject.Find("SoundEffects/SoundBoxHit").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void takeDamage() {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        GameManager gamemanager = GameObject.FindAnyObjectByType<GameManager>();
        soundHit.Play();
       // gamemanager.checkLevelComplete();
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

    public void setAlive(bool b) {
  //      isAlive = b;
        if (b) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
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
