using UnityEngine;

public class Snatch : MonoBehaviour
{
    public Player player;
    [SerializeField] private DistanceJoint2D joint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time - player.MouseClick > 2)
        {
            joint.enabled = true;
        }
    }
}