using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] powerup;

    public int activeBalls = 0;
    private float spawnX = 10f;
    private float spawnY = 5.5f;
    private bool stopSpawning = false;

    void Start()
    {
        SpawnBall();
        InvokeRepeating(nameof(SpawnPowerUp), 2, 2);
    }

    public void SpawnBall()
    {
        Vector3 spawnPoint = new Vector3(0, 0, 3.7f);

        Instantiate(ball, spawnPoint, Quaternion.identity);
        activeBalls++;
    }

    void SpawnPowerUp()
    {
        if (stopSpawning == false)
        {
            int randomIndex = Random.Range(0, powerup.Length);

            float randomX = Random.Range(-spawnX, spawnX);
            float randomY = Random.Range(-spawnY, spawnY);

            Vector3 spawnPoint = new Vector3(randomX, randomY, 3.7f);
            Instantiate(powerup[randomIndex], spawnPoint, Quaternion.identity);
        }
    }

    public void onBallDestroy()
    {
        activeBalls--;
        if (activeBalls < 1)
        {
            onGameOver();
        }
    }

    public void onGameOver()
    {
        stopSpawning = true;
    }
}
