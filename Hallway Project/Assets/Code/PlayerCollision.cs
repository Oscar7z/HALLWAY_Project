using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "obstacle")

        Debug.Log("We hit an Obstacle");
        movement.enabled = false;
    }
}
