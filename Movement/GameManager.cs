using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject Instance;
    public float speed;
    public float slideSpeed;
    public Camera myCamera;

    public float topSpace;
    public float bottomSpace;
    public float leftSpace;
    public float rightSpace;

    Rigidbody2D rigidBody;
    Animator animator;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (myCamera == null){
            myCamera = Camera.main;
        }
        Instance = this.gameObject;
        speed = speed + PlayerPrefs.GetInt("speed", 0);
    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = myCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y,5));
            var step =  speed * Time.timeScale;
            rigidBody.velocity = (touchPos - transform.position).normalized * step;

            transform.localScale = new Vector3(Mathf.Sign(rigidBody.velocity.x), 1, 1);

            PreventOutOffScreen();

            animator.SetBool("walk", true);
            if (rigidBody.velocity.magnitude < slideSpeed)
            {
                animator.SetBool("slide", false);
            }
            else
            {
                animator.SetBool("slide", true);
            }
        }
        else
        {
            PreventOutOffScreen();
            animator.SetBool("walk", false);
            animator.SetBool("slide", false);
        }
    }

    void PreventOutOffScreen()
    {
        Vector2 position = myCamera.WorldToScreenPoint(transform.position);
        Rect rect = GetComponent<SpriteRenderer>().sprite.textureRect;


        if ((position.x - leftSpace < 0 && rigidBody.velocity.x < 0) ||
            (position.x + rightSpace > myCamera.pixelWidth && rigidBody.velocity.x > 0))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if ((position.y - bottomSpace < 0 && rigidBody.velocity.y < 0) || 
            (position.y + topSpace > myCamera.pixelHeight && rigidBody.velocity.y > 0))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }
    }
}
