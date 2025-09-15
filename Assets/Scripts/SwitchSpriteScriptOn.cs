using UnityEngine;

public class SwitchSpriteScript : MonoBehaviour
{
    public CameraMove cam;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.ActiveTransition == true)
        {
            Debug.Log("ActiveTransition TRUE");
            spriteRenderer.enabled = false;
        }
        if (cam.ActiveTransition == false)
        {
            spriteRenderer.enabled = true;
        }
    }
}
