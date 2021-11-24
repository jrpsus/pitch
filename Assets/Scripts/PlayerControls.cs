using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    bool isPaused = false;
    public AudioSource source;
    public AudioClip jump;
    public AudioClip dead;
    public AudioClip nextlevel;

    private Rigidbody rb;

    private float movementX;
    private float movementY;
    public float jumpForce;
    public int level = 1;
    public int collectables = 0;
    private bool canJump = false;
    private Vector3 spawnVector = new Vector3(0f, 1.4f, -4f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        if (transform.position.y <= -1)
        {
            transform.position = spawnVector;
            rb.velocity = Vector3.zero;
            source.PlayOneShot(dead);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canJump)
        {
            Vector3 forceVector = Vector3.up * jumpForce;
            rb.AddForce(forceVector);
            source.PlayOneShot(jump);
            canJump = false;
        }
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            transform.position = spawnVector;
            rb.velocity = Vector3.zero;
            source.PlayOneShot(dead);
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if (collision.gameObject.tag == "Door")
        {
            source.PlayOneShot(nextlevel);
            if (collision.gameObject.name == "Door 1")
            {
                level = 2;
                spawnVector.x = -30.5f;
                spawnVector.y = 10f;
                spawnVector.z = -2.7f;
            }
            if (collision.gameObject.name == "Door 2")
            {
                level = 3;
                spawnVector.x = 72f;
                spawnVector.y = 14f;
                spawnVector.z = 21.7f;
            }
            if (collision.gameObject.name == "Door 3")
            {
                level = 4;
                spawnVector.x = 67f;
                spawnVector.y = 43f;
                spawnVector.z = 147.5f;
            }
            if (collision.gameObject.name == "Door 4")
            {
                level = 5;
                spawnVector.x = 73.7f;
                spawnVector.y = 2f;
                spawnVector.z = 1458f;
            }
            if (collision.gameObject.name == "Door 5")
            {
                level = 6;
                spawnVector.x = -184.2f;
                spawnVector.y = 92f;
                spawnVector.z = 1441f;
            }
            if (collision.gameObject.name == "Door 6" && collectables == 4)
            {
                ExitToMenu();
            }
            transform.position = spawnVector;
            rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.tag == "Bouncy")
        {
            rb.velocity = Vector3.up * 15;
            source.PlayOneShot(jump);
        }
        if (collision.gameObject.tag == "Collectable")
        {
            source.PlayOneShot(nextlevel);
            collectables += 1;
            Destroy(collision.gameObject);
            transform.position = spawnVector;
        }
    }
    public void StartOver()
    {
        level = 1;
        collectables = 0;
        spawnVector.x = 0f;
        spawnVector.y = 1.4f;
        spawnVector.z = -4f;
        transform.position = spawnVector;
        rb.velocity = Vector3.zero;
    }
    public void ExitToMenu()
    {
        StartOver();
        SceneManager.LoadScene("Start Menu");
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            Time.timeScale = 1.0f;
        }
        else
        {
            //pause
            Time.timeScale = 0.0f;
        }
        isPaused = !isPaused;
    }
}
