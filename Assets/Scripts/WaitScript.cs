using UnityEngine;
using System.Collections;

public class WaitScript : MonoBehaviour
{
    public bool EndOfTimer = false;
    
    AudioSource mySource;

    public AudioClip YippeeEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySource = GetComponent<AudioSource>();
        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(180f);
        EndOfTimer = true;
        mySource.PlayOneShot(YippeeEnd);
        yield return new WaitForSeconds(3f);
        mySource.PlayOneShot(YippeeEnd);
        yield return new WaitForSeconds(3f);
        mySource.PlayOneShot(YippeeEnd);

    }
}
