using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject fogEffect;
    public PlayerController player1Controller;
    public PlayerController player2Controller;

    void Start()
    {
        player1Controller = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerController>();
        player2Controller = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerController>();
    }

    public void HandlePowerUpCollision(IPowerUp powerUp, int playerNumber)
    {
        if (playerNumber == 1)
        {
            powerUp.ActivatePowerUp(player1Controller);
        }
        else if (playerNumber == 2)
        {
            powerUp.ActivatePowerUp(player2Controller);
        }
        else
        {
            powerUp.ActivatePowerUp(null);
        }
    }
}
