using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] powerup;

    public int activeBalls = 0;
    private float spawnX = 11f;
    private float spawnY = 6.5f;
    private bool stopSpawning = false;
    private GameManager gameManager;

    private float ballSpawnTimer = 1f;
    private float powerupSpawnMinDelay = 2f;
    private float powerupSpawnMaxDelay = 5f;
    private float powerupSpawnTimer = 3f;

    private bool hasSpawnedInitialBall = false;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!hasSpawnedInitialBall && gameManager.isGameStarted)
        {
            if (ballSpawnTimer <= 0f)
            {
                hasSpawnedInitialBall = true;
                SpawnBall();
            }

            ballSpawnTimer -= Time.deltaTime;
        }

        if (gameManager.isGameStarted)
        {
            if (powerupSpawnTimer <= 0f)
            {
                SpawnPowerUp();
                powerupSpawnTimer = Random.Range(powerupSpawnMinDelay, powerupSpawnMaxDelay);
            }

            powerupSpawnTimer -= Time.deltaTime;
        }
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
        gameManager.ShowRestartButton();
    }
}
