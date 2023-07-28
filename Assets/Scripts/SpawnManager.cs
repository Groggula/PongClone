using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] powerup;

    void Start()
    {
        //SpawnBall();
        InvokeRepeating("SpawnBall", 1, 2);
    }

    void SpawnBall()
    {
        Vector3 spawnPoint = new Vector3(0, 0, 3.7f);

        Instantiate(ball, spawnPoint, Quaternion.identity);
    }
}
