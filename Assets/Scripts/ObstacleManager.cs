using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject Obstacles;
    public GameObject currentObstacle;
    float Xposition = 2.2f;
    float Yposition = 8.0f;
    ScoreManager scoreboard;

    Stack<GameObject> ObstaclePool = new Stack<GameObject>();

    private static ObstacleManager instance;


    public static ObstacleManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = GameObject.FindObjectOfType<ObstacleManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        //  ObstacleManager.Instance.
        //  SpawnObstacle();
        scoreboard = GameObject.Find("ScoreBoard").GetComponent<ScoreManager>();
        InvokeRepeating("SpawnObstacle", 1.0f, 2.0f);
    }

    void CreateObstacle()
    {
        ObstaclePool.Push(Obstacles);
        ObstaclePool.Peek().SetActive(false);
        ObstaclePool.Peek().name = "Enemy";
        print("in OBSTACLE create");
    }

    
    public void AddToPool(GameObject obstacleTemp)
    {
        ObstaclePool.Push(obstacleTemp);
        ObstaclePool.Peek().SetActive(false);
        print("in ADD POOL");
    }


    public void SpawnObstacle()
    {
        if(ObstaclePool.Count==0)
        {
            CreateObstacle();
        }
        GameObject temp = ObstaclePool.Pop();
        temp.SetActive(true);
        float RandomX = Random.Range(-Xposition, Xposition);
        Vector2 spawnPos = new Vector2(RandomX, Yposition);
        temp.transform.position = spawnPos;
        currentObstacle = temp;
        scoreboard.Increment(5);
        print("in OBSTACLE SPAWN");
    }

}
