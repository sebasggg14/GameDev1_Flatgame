using UnityEngine;

public class NoteSnapScript : MonoBehaviour
{
    public bool SnapToEmpty = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        SnapToEmpty = true; 
    }
    void OnMouseExit()
    {
        SnapToEmpty = false;
    }
}
