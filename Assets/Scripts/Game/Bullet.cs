//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class Bullet : MonoBehaviour {
    public Rigidbody rigidbody;
    float fLifetime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        fLifetime = 5f;
        
    }

    // Update is called once per frame
    void Update() {

        rigidbody.linearVelocity = transform.forward * 40f;
        fLifetime -= Time.deltaTime;
        if (fLifetime <= 0f) {
            Destroy(gameObject);
        }

        
        
    }
}
