using UnityEngine;
using System.Collections;

public class PlayArrow : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;

    private DragScript ScriptRef; 

    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject NoteFinal;

    private PlayAudio playAudio1;
    private PlayAudio playAudio2;
    private PlayAudio playAudio3;
    private PlayAudio playAudio4;
    private PlayAudio playAudioFinal;

    private AudioSource noteSource1;
    private AudioSource noteSource2;
    private AudioSource noteSource3;
    private AudioSource noteSource4;
    private AudioSource noteSourceFinal;


    AudioSource mySource;
    public AudioClip YippeeClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScriptRef = GameObject.Find("DraggingNote").GetComponent<DragScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        playAudio1 = Note1.GetComponent<PlayAudio>();
        noteSource1 = Note1.GetComponent<AudioSource>();

        playAudio2 = Note2.GetComponent<PlayAudio>();
        noteSource2 = Note2.GetComponent<AudioSource>();

        playAudio3 = Note3.GetComponent<PlayAudio>();
        noteSource3 = Note3.GetComponent<AudioSource>();

        playAudio4 = Note4.GetComponent<PlayAudio>();
        noteSource4 = Note4.GetComponent<AudioSource>();

        playAudioFinal = NoteFinal.GetComponent<PlayAudio>();
        noteSourceFinal = NoteFinal.GetComponent<AudioSource>();

        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptRef.CanPlay == true)
        {
            spriteRenderer.enabled = true;
        }
        if (ScriptRef.CanPlay == false)
        {
            spriteRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        StartCoroutine(PlayMusicNotes());
    }

    IEnumerator PlayMusicNotes()
    {
        Debug.Log("play clicked");
        noteSource1.PlayOneShot(playAudio1.NoteSound);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("second play");
        noteSource2.PlayOneShot(playAudio2.NoteSound);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("third play");
        noteSource3.PlayOneShot(playAudio3.NoteSound);
        yield return new WaitForSeconds(0.8f);
        Debug.Log("fourth play");
        noteSource4.PlayOneShot(playAudio4.NoteSound);
        yield return new WaitForSeconds(0.8f);

        // determines the final note 
        if (ScriptRef.LastNote1)
        {
            Debug.Log("Final Note from LastNote1");
            noteSourceFinal.PlayOneShot(ScriptRef.NoteFinal1);
        }
        else if (ScriptRef.LastNote2)
        {
            Debug.Log("Final Note from LastNote2");
            noteSourceFinal.PlayOneShot(ScriptRef.NoteFinal2);
        }
        else if (ScriptRef.LastNote3)
        {
            Debug.Log("Final Note from LastNote3");
            noteSourceFinal.PlayOneShot(ScriptRef.NoteFinal3);
        }

        yield return new WaitForSeconds(1f);
        mySource.PlayOneShot(YippeeClip);


    }
}