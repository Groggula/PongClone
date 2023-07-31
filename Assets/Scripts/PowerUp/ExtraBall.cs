using UnityEngine;

public class ExtraBall : MonoBehaviour, IPowerUp
{
    public ParticleSystem particleEffect;
    public AudioClip onDestroy;

    private SpawnManager spawnManager;
    private AudioSource sfxAudio;

    public void ActivatePowerUp(PlayerController player = null)
    {
        GameObject sfxGameObject = GameObject.Find("SFX");

        if (sfxGameObject != null)
        {
            sfxAudio = sfxGameObject.GetComponent<AudioSource>();
        }


        spawnManager = FindObjectOfType<SpawnManager>();
        spawnManager.SpawnBall();

        if (particleEffect != null)
        {
            Instantiate(particleEffect, transform.position, Quaternion.identity);
        }

        if (sfxAudio != null && onDestroy != null)
        {
            sfxAudio.clip = onDestroy;
            sfxAudio.Play();
        }
        Destroy(gameObject);
    }
}
