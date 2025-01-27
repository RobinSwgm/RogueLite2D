using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private float horizontalInput;

    private float horizontalMovement;
    private float verticalMovement;

    private Animator animator;

    private bool ifAllowedToMove;

    [SerializeField]
    private GameObject particlesystem;

    [Header("Walking")]
    [SerializeField] private float movingSpeed = 5f;
    private bool ableToRun;

    [Header("Jump")]
    private float jumpPower = 5f;
    private bool isJumpPressed = false;

    [Header("Coins")]
    public CoinManager coinManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        particlesystem.SetActive(false);
        ifAllowedToMove = true;

    }

    private void Update()
    {
        if (ifAllowedToMove == true)
        {


            rb.linearVelocity = new Vector2(horizontalMovement * movingSpeed, rb.linearVelocity.y);
            if (ableToRun == true)
            {
                Debug.Log("on Ground");
                if (horizontalMovement != 0)
                {
                    animator.SetBool("isRunning", true);
                }
                else if (horizontalMovement == 0)
                {
                    animator.SetBool("isRunning", false);
                }


            }

            //flip character
            if (horizontalMovement < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontalMovement > 0)
            {
                spriteRenderer.flipX = true;
            }
            //

            isJumpPressed = Input.GetButtonDown("Jump");

            if (isJumpPressed && ableToRun == true)
            {
                // the cube moves up the y axis at a rate of 10 units per second
                rb.linearVelocity = new Vector3(0, jumpPower, 0);
                Debug.Log("jump");
            }
        }
        if (OpenChestAnim.startParticles == true)
        {
            animator.SetBool("isRunning", false);
            ifAllowedToMove = false;
            particlesystem.SetActive(true);
            StartCoroutine(LoadNextScene());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            ableToRun = true;
        }
        else
        {
            ableToRun = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        ableToRun = false;
    }

    //reads value on the x axis -1,0,1
    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("End");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            other.gameObject.SetActive(false);
            coinManager.coinCount++;

        }
    }



}
