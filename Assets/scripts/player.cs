using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float walkForce = 10f;

    private int score = 0;
    private float startTime;

    private float movementRL;
    private float movementU;
    private Rigidbody mybody;

    public string GameOverScene = "gameOverMenu";
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string JUMP_ANIMATION = "jump";
    private string GROUND_TAG = "Ground";
  

    // public AudioClip bgSound;
    public AudioClip jump;
    public AudioSource sound;

    private bool isGrounded;
    

    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
        sound = GetComponent<AudioSource>();
    }

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }
    
void PlayerMovement()
{
    float movementRL = Input.GetAxisRaw("Horizontal");

    if (movementRL != 0)
    {
        
        Vector3 movement = new Vector3(movementRL, 0f, 0f) * walkForce * Time.deltaTime;
        transform.position += movement;
        

        // Set the rotation of the player when moving right or left
        if (movementRL > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            transform.rotation = Quaternion.Euler(0, 100, 0); 
        }
        else if (movementRL < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            transform.rotation = Quaternion.Euler(0, -100, 0);
        }
    }
    else
    {
        anim.SetBool(WALK_ANIMATION, false);
        
       
    }
}



    void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))&& isGrounded )// && isGrounded
        {
      
             sound.PlayOneShot(jump, 1f);
            anim.SetBool(JUMP_ANIMATION, true);
            isGrounded = false;
            mybody.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool(JUMP_ANIMATION, false);
            
        }

        if (collision.gameObject.CompareTag("Monsters"))
        {
            SoundManager soundManager = FindObjectOfType<SoundManager>();

            if (soundManager != null)
            {
                soundManager.PlayGameOverSound();
            }

            Debug.Log("gone");
            Destroy(gameObject);
            float timeElapsed = Time.time - startTime;
            score = Mathf.RoundToInt(timeElapsed);
            Debug.Log("Your score is: " + score);

            // SceneManager.LoadScene(GameOverScene);
        }
    }


}
