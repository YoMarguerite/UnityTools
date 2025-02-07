using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody2D rigidbody2;

    [SerializeField]
    Transform pointGravity;

    [SerializeField]
    [Range(0f, 10000f)]
    float strength;

    public Vector2 actualGravity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        actualGravity = (pointGravity.position - transform.position).normalized * strength;
        //rigidbody2.AddForce(actualGravity);
    }
}
