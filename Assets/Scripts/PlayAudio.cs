using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip NoteSound;
    AudioSource mySource;

    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        mySource.PlayOneShot(NoteSound);
    }
}
