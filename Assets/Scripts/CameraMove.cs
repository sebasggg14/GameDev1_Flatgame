using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float ySpeed = 0f;
    float xSpeed = 0f;
    public bool ActiveTransition = false;
    Vector3 initialPos;

    bool goLeft = true;
    bool goDown = true;
    bool goUp = true;
    bool goRight = true;

    AudioSource mySource;

    public AudioClip Crumple;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPos = transform.position;
        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position; // fetches the position from the transform component. Vector means coordinates & direction in x, y, & z.
        currentPos.y += ySpeed * Time.deltaTime;
        currentPos.x += xSpeed * Time.deltaTime;
        
        // UP MOVEMENT
        if (Input.GetKey(KeyCode.UpArrow) && ActiveTransition == false && goUp)
        {
            initialPos = currentPos;
            mySource.PlayOneShot(Crumple);
            ActiveTransition = true;
            ySpeed = 10f;
        }

        if (ActiveTransition == true && currentPos.y > initialPos.y + 10f)
        {
            ySpeed = 0f;
            currentPos.y = initialPos.y + 10f;
            ActiveTransition = false;
        }

        // DOWN MOVEMENT
        if (Input.GetKey(KeyCode.DownArrow) && ActiveTransition == false && goDown)
        {
            initialPos = currentPos;
            mySource.PlayOneShot(Crumple);
            ActiveTransition = true;
            ySpeed = -10f;
        }

        if (ActiveTransition == true && currentPos.y < initialPos.y - 10f)
        {
            ySpeed = 0f;
            currentPos.y = initialPos.y - 10f;
            ActiveTransition = false;
        }

        // LEFT MOVEMENT
        if (Input.GetKey(KeyCode.LeftArrow) && ActiveTransition == false && goLeft)
        {
            initialPos = currentPos;
            mySource.PlayOneShot(Crumple);
            ActiveTransition = true;
            xSpeed = -10f;
        }

        if (ActiveTransition == true && currentPos.x < initialPos.x - 18f)
        {
            xSpeed = 0f;
            currentPos.x = initialPos.x - 18f;
            ActiveTransition = false;
        }

        // RIGHT MOVEMENT
        if (Input.GetKey(KeyCode.RightArrow) && ActiveTransition == false && goRight)
        {
            initialPos = currentPos;
            mySource.PlayOneShot(Crumple);
            ActiveTransition = true;
            xSpeed = 10f;

        }

        if (ActiveTransition == true && currentPos.x > initialPos.x + 18f)
        {
            xSpeed = 0f;
            currentPos.x = initialPos.x + 18f;
            ActiveTransition = false;
        }

        transform.position = currentPos; // sets the transformation to the vector3 
    }

    // BOUNDS 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goLeft = false;
            Debug.Log("hit left border");
        }
        if (collision.CompareTag("down"))
        {
            goDown = false;
            Debug.Log("hit left border");
        }
        if (collision.CompareTag("up"))
        {
            goUp = false;
            Debug.Log("hit left border");
        }
        if (collision.CompareTag("right"))
        {
            goRight = false;
            Debug.Log("hit left border");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goLeft = true;
        }
        if (collision.CompareTag("up"))
        {
            goUp = true;
        }
        if (collision.CompareTag("right"))
        {
            goRight = true;
        }
        if (collision.CompareTag("down"))
        {
            goDown = true;
        }
    }
}