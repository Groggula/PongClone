using UnityEngine;

public class ExtraBall : MonoBehaviour, IPowerUp
{
    private SpawnManager spawnManager;
    public ParticleSystem particleEffect;

    public void ActivatePowerUp(PlayerController player = null)
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.SpawnBall();

        if (particleEffect != null)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
