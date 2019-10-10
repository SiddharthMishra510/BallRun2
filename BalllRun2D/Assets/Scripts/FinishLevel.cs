using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public PlayerMovement movement;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish")
        {
            movement.enabled = false;   // Disable the players movement.

            FindObjectOfType<GameManager>().CompleteLevel();
        }
    }

}