using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float smooth = 5.0f;
    private Vector3 offset = new Vector3(0, 2, -5);

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * smooth);
    }
}

