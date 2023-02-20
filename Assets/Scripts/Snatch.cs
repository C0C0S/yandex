using UnityEngine;

public class Snatch : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError(collision);
        
        if (TryGetComponent<DistanceJoint2D>(out DistanceJoint2D joint) && Time.time - player.MouseClick > 2)
        {
            joint.enabled = true;
        }
    }
}