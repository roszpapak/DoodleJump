using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{


    private  GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Doodle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 350f);

        }

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            Debug.Log("PAPA");
            Destroy(collision.gameObject);
            Instantiate(collision.gameObject,
            new Vector2(Random.Range(-3.89f, 0.71f), player.transform.position.y + (4.5f + Random.Range(0.5f, 1f))),
            Quaternion.identity);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            Debug.Log("PAPA");

        }
    }
}
