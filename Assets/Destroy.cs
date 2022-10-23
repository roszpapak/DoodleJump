using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject player;
    public GameObject platformPrefab;
    public GameObject platformCloneParent;
    private GameObject myPlat;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myPlat = (GameObject)Instantiate(platformPrefab,
            new Vector2(Random.Range(-3.89f, 0.71f), player.transform.position.y + (5f + Random.Range(0.5f, 1f))),
            Quaternion.identity, platformCloneParent.transform);
        if (collision.gameObject.name == "Platform")
        {
            collision.gameObject.SetActive(false);

        }else 
            Destroy(collision.gameObject);



    }
}
