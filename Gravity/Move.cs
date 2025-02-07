using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigidbody2;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float jump = 1f;

    [SerializeField]
    Gravity gravity;

    bool isJumping = false;
    bool duringJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    IEnumerator JumpDuration()
    {
        duringJump = true;
        yield return new WaitForSeconds(.5f);
        duringJump = false;
    }

    void Update()
    {
        isJumping = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            StartCoroutine(JumpDuration());
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rigidbody2.AddForce(gravity.actualGravity.Perpendicular1() * speed);
            rigidbody2.velocity = (gravity.actualGravity.Perpendicular1().normalized * speed);
            //rigidbody2.velocity = Quaternion.Euler(0, 0, -5) * rigidbody2.velocity;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //rigidbody2.AddForce(gravity.actualGravity.Perpendicular2() * speed);
            rigidbody2.velocity = (gravity.actualGravity.Perpendicular2().normalized * speed);
            //rigidbody2.velocity = Quaternion.Euler(0, 0, 5) * rigidbody2.velocity;

        }
        else
        {
            rigidbody2.velocity = Vector3.zero;
        }

        if (isJumping)
        {
            rigidbody2.AddForce(-gravity.actualGravity.normalized * jump, ForceMode2D.Impulse);
        }

        if (!duringJump)
        {
            rigidbody2.AddForce(gravity.actualGravity, ForceMode2D.Force);
        }

        //print(rigidbody2.velocity.magnitude);
        //rigidbody2.velocity = Vector3.ClampMagnitude(rigidbody2.velocity, 1f);

    }
}
