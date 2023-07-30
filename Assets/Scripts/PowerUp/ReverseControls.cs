using UnityEngine;

public class ReverseControls : MonoBehaviour, IPowerUp
{
    private PlayerController playerController;

    public void ActivatePowerUp(PlayerController player)
    {
        Debug.Log("ReverseController PowerUp hit");
        playerController = player;
        ReverseControlsLogic();
    }

    private void ReverseControlsLogic()
    {
        KeyCode temp = playerController.inputConfig.upKey;
        playerController.inputConfig.upKey = playerController.inputConfig.downKey;
        playerController.inputConfig.downKey = temp;
    }
}
