using UnityEngine;

public class DragScript : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    private Camera dragCam;
    public NoteSnapScript SnapScript;
    private bool PlayAudio = true;
    public bool CanPlay = false;
    public bool LastNote1 = false;
    public bool LastNote2 = false;
    public bool LastNote3 = false;

    // for audio
    public AudioClip NoteSound;
    public AudioClip NoteFinal1;
    public AudioClip NoteFinal2;
    public AudioClip NoteFinal3;

    AudioSource mySource;

    // Start is called at startup
    void Start()
    {
        // gets the dragcam so that the note drags onto the dragcam instead of the maincam
        dragCam = GameObject.FindGameObjectWithTag("DragCamera").GetComponent<Camera>();

        // for audio
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // code for dragging note
        if (dragging)
        {
            transform.position = dragCam.ScreenToWorldPoint(Input.mousePosition);
        }

        // code for snapping onto empty note
        GameObject[] emptyNotes = GameObject.FindGameObjectsWithTag("EmptyNote"); // list of objects tagged w EmptyTag since I have multiple objects with the same tag
        foreach (GameObject note in emptyNotes)
        {
            NoteSnapScript snap = note.GetComponent<NoteSnapScript>();
            if (snap.SnapToEmpty && dragging) // code that detects if the note can snap onto the emptynote
            {
                Debug.Log(note.name + "WORKSSSS");
                transform.position = snap.transform.position;
            }

            if (transform.position == snap.transform.position && PlayAudio)
            {
                AudioClip clipToPlay = NoteFinal1;
                LastNote1 = true;
                LastNote2 = false;
                LastNote3 = false;
                if (note.name == "EmptyNote1 Inv")
                {
                    clipToPlay = NoteFinal1; 
                    LastNote1 = true;
                    LastNote2 = false;
                    LastNote3 = false;
                }
                if (note.name == "EmptyNote2 Inv")
                {
                    clipToPlay = NoteFinal2;
                    LastNote2 = true;
                    LastNote3 = false;
                    LastNote1 = false;
                }
                if (note.name == "EmptyNote3 Inv")
                {
                    clipToPlay = NoteFinal3;
                    LastNote3 = true;
                    LastNote1 = false;
                    LastNote2 = false;
                }

                PlayAudio = false;
                mySource.PlayOneShot(clipToPlay);
                CanPlay = true;

            }
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition); // i tried changing camera.main to dragCam and it broke the code so im just gonna leave it like this
        dragging = true;
        PlayAudio = true;
        CanPlay = false;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
