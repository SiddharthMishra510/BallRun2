using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;      // A variable that allows us to offset the position (x, y, z)
    public float lockY;
    private float upDist;
    private Vector3 vec;

    void Update()
    {
        upDist = player.position.y - lockY;
        vec = new Vector3(0, -upDist, 0);
        if (player.position.y <= lockY)
            transform.position = player.position + offset;
        else
            transform.position = player.position + offset + vec;
    }
}
