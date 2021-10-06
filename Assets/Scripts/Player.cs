using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    // Added [Serializefiled] to make these private variables visible in Insprector
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpforce = 11f;

    [SerializeField]
    private float minX, maxX;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    // Called in fixed intervals of time.
    /*private void FixedUpdate()
    {
    }*/

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        /****************************************************************************
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX + (Time.deltaTime + 1), 0f, 0f);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX - (Time.deltaTime + 1), 0f, 0f);
        }
        ****************************************************************************/
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else 
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }
    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG)) {
            SceneManager.LoadScene("Game Over Menu");
            Destroy(gameObject);
        }
    }

    // Another way to check for collisions (Check is Trigger on Collider in any one of colliding object) 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)) {
            SceneManager.LoadScene("Game Over Menu");
            Destroy(gameObject);
        }
    }
}