using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OtherBehavior : MonoBehaviour
{
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = this.spawnPoint.position;
            GetComponent<Animator>().SetBool("disappear", true);
        }
    }
}
