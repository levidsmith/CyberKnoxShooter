//2025 Levi D. Smith <developer@levidsmith.com>
using UnityEngine;

public class TitleAudio : MonoBehaviour {
    public AudioSource audioTitleVoice;
    public AudioSource audioRulesVoice;

    float fTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        fTime = 0f;
        
    }

    // Update is called once per frame
    void Update() {
        float fTimeNext = fTime + Time.deltaTime;
        Debug.Log("time: " + fTime + " Next: "+ fTimeNext);

        if (fTime < 1f && fTimeNext >= 1f) {
            Debug.Log("play title voice");
            audioTitleVoice.Play();
        }

        if (fTime < 8f && fTimeNext >= 8f) {
            audioRulesVoice.Play();
        }

        fTime = fTimeNext;


    }
}
