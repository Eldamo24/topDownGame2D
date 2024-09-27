using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float zOffset;
    [SerializeField] private float smooth;

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 positionWanted = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.position.z + zOffset);
        transform.position = Vector3.Lerp(transform.position, positionWanted, smooth);
    }


}
