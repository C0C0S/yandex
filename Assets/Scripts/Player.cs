using UnityEngine;

public class Player : MonoBehaviour
{
    public float MouseClick;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryGetComponent<DistanceJoint2D>(out DistanceJoint2D joint))
            {
                joint.enabled = false;
                MouseClick = Time.time;

            }
        }
    }
}
