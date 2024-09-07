using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500f;
    public float boost = 1000f;
    private bool isMoving;
    private float originalSpeed;
    private int score = 0;
    void Start()
    {
        originalSpeed = speed;
    }
    void Update()
    {
        
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) && isMoving == true)
        {
            speed = boost;
        }else
        {
            speed = originalSpeed;
        }
        
        isMoving = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
        }
        score++;
        Debug.Log($"Score: {score}");
    }
}
