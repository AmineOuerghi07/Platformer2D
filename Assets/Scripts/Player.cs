using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mouvementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float deathKick = 20f;
    Rigidbody2D rb;
    Animator animator;
    CircleCollider2D feetCollider;
    CapsuleCollider2D bodyCollider;
    bool dead = false;
    bool mouvement = true;
    [SerializeField] Vector2 playerRespawnPos;
    LevelLoader levelLoader;
    [SerializeField] GameObject pauseMenu;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    public Vector2 playerVelocity;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        feetCollider = GetComponent<CircleCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        levelLoader = FindObjectOfType<LevelLoader>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            levelLoader.LoadCheckpoint();
            mouvement = true;
        }
        //animator.SetFloat("velY", rb.velocity.y);
        Move();
        FlipSprite();
        Jump();
        StartCoroutine(Die());
        levelLoader.PauseGame();
    }

    private void Move()
    {
        if (mouvement == false) return;
        float controlThrow = Input.GetAxis("Horizontal");
        playerVelocity = new Vector2(controlThrow * mouvementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool playerHasVelocity = Mathf.Abs(controlThrow) > Mathf.Epsilon;
        if (playerHasVelocity)
        {

            //animator.SetBool("IsRunning", true);
        }
        else
        {
            //animator.SetBool("IsRunning", false);
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Jump()
    {
        if (mouvement == false) return;
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            grounded = false;
            //animator.SetBool("Jump", true);
            return;
        }
        else
        {
            grounded = true;
            //animator.SetBool("Jump", false);
        }

        if (Input.GetButtonDown("Vertical"))
        {
            rb.velocity += new Vector2(0, jumpForce);
            audioSource.PlayOneShot(clip, 0.7f);
        }


    }
    IEnumerator Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            PlayerPos.d++;
            //animator.SetTrigger("Dead");
            rb.velocity = new Vector2(rb.velocity.x, deathKick);
            mouvement = false;
            yield return new WaitForSeconds(2f);
            dead = true;
        }
    }
}
