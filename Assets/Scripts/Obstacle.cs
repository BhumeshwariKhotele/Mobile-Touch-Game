using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Obstacle : MonoBehaviour
{
    [SerializeField]
   float obstacleSpeed;
    Rigidbody2D tempRigidbody;
   

    private void Start()
    {
       
        tempRigidbody = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        StartCoroutine("Destroy");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


       if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
       transform.Rotate(new Vector3(0, 0, obstacleSpeed));
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        
        
        if (tempRigidbody.gameObject.name == "Enemy")
        {
             print("in coroutine");
            ObstacleManager.Instance.AddToPool(tempRigidbody.gameObject);
           
        }
    }
   
}

