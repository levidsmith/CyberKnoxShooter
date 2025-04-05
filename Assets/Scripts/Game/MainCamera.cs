//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class MainCamera : MonoBehaviour {
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Ship ship = GameObject.FindAnyObjectByType<Ship>();
        if (ship != null) {
            transform.position = ship.transform.position + new Vector3(0f, 25f, 0f);
        }
        
    }
}
