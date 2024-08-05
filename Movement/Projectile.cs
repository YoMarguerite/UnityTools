using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 cible;
    Vector3 direction;
    public float variance;
    public float speed;
    public float distToDie;
    Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        cible = GameManager.Instance.transform.position;
        direction = (cible - transform.position).normalized;
        direction = new Vector3(
            Random.Range(direction.x - variance, direction.x + variance),
            Random.Range(direction.y - variance, direction.y + variance)).normalized;
        rigidBody.velocity = direction * speed * Time.timeScale;

        float rad = Mathf.Atan2(direction.y, direction.x);
        float angle = rad * (180/Mathf.PI);
        Quaternion rotation = Quaternion.Euler(new Vector3(0,0,angle));
        transform.rotation = rotation;
    }

    void LateUpdate()
    {
        if(Vector3.Distance(transform.position, cible) > distToDie){
            
            Destroy(this.gameObject);
        }
    }

    public void EndExplode()
    {
        Destroy(gameObject);
    }
}
