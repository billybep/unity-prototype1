using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private Vector3 offset = new Vector3(0, 5, -7);

    // LateUpdate useful to calculate camera to follow player
    void LateUpdate()
    {
        // Offset the camera behind the player
        transform.position = player.transform.position + offset;
    }
}
