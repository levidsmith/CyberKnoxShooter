//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class Ship : MonoBehaviour {

    float fVel;
    float fRotate;
    float fVelRotate;
    float fSpeed;

    public GameObject BulletPrefab;
    public GameObject objLevel;
    float fShootCooldown;
    float fMaxShootCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        fShootCooldown = 0f;
        fSpeed = 20f;
        fVel = 0f;
        fRotate = 0f;
        fVelRotate = 0f;
        fShootCooldown = 0;
        fMaxShootCooldown = 0.25f;
        
    }

    // Update is called once per frame
    void Update() {

        if (objLevel == null) {
            objLevel = GameObject.Find("Level");
        }

        //        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f));
        float fRotateSpeed = 90f;
        fRotate += Input.GetAxis("Horizontal") * fRotateSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, fRotate, 0f);
        //transform.Translate(new Vector3(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime));

        
        fVel = Input.GetAxis("Vertical") * fSpeed * Time.deltaTime;
        transform.position = transform.TransformPoint(0f, 0f, fVel);

        float xBounds, zBounds;
        float x, z; 
        xBounds = 32f;
        zBounds = 32;

        x = transform.position.x;
        z = transform.position.z;
        if (x > xBounds) {
            x -= 2 * xBounds;
        } else if (x < -xBounds) {
            x += 2 * xBounds;
        }
        if (z > zBounds) {
            z -= 2 * zBounds;
        } else if (z < -zBounds) {
            z += 2 * zBounds;
        }

        transform.position = new Vector3(x, 0f, z);





        if (fShootCooldown > 0f) {
            fShootCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            if (fShootCooldown <= 0f) {
                shoot();
            }

        }


    }

    private void shoot() {
        Bullet bullet = Instantiate(BulletPrefab, transform.TransformPoint(new Vector3(0f, 0f, 1f)), Quaternion.identity).GetComponent<Bullet>();
        bullet.transform.eulerAngles = transform.eulerAngles;
        bullet.transform.SetParent(objLevel.transform);
        fShootCooldown = fMaxShootCooldown;


    }
}
