using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float initialMoveSpeed = 15f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;
    private float nextActionTime = 0.0f;
    public float period = 40f;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "SpeedUp"){
            Debug.Log("Speed boost!");
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Slowing Down((");
        moveSpeed = slowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount );
        transform.Translate(0, moveAmount, 0);

 
        if (Time.time > nextActionTime) {
            nextActionTime = Time.time + period;
            moveSpeed = initialMoveSpeed;
            Debug.Log("Update");
        }
    }
}
