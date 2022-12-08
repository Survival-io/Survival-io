using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, turnSpeed;
    [SerializeField] private Rigidbody rb;

    private GameObject playerGameObject;

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        /*Vector3 cameraDirection = canvasTransform.position - cam.transform.position;
        canvasTransform.rotation = Quaternion.LookRotation(cameraDirection);    // Enemy damage text lookRotation to every frame*/

        Vector3 direction = (playerGameObject.transform.position - transform.position).normalized;
        Quaternion rotationGoal = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation
    }

    private void FixedUpdate()
    {
        moveEnemy();
    }

    private void moveEnemy(/*Vector3 direction*/)   // Enemy straight move by rotation 
    {
        // rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            EventManager.enemyAttackAnimation.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger finish.");
        if (other.gameObject.tag == "Player")
        {
            EventManager.enemyMovementAnimation.Invoke();
        }
    }
}