using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float moveSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, moveSpeed*Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -moveSpeed*Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Floor")
            Debug.Log("tag Floor Collision!");
        if(other.gameObject.tag == "Ceil")
        {
            Debug.Log("tag Ceil Collision!");
            GameObject[] allFloor = GameObject.FindGameObjectsWithTag("Floor");
            foreach(GameObject floor in allFloor)
            {
                floor.GetComponent<BoxCollider2D>().enabled = false;
            }
                
        }
            
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "DeathZone")
            Debug.Log("GameOver!");
    }
}
