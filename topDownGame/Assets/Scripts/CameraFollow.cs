using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;

    private void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 positionWanted = new Vector3(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionWanted, smoothSpeed);
        transform.position = smoothPosition;
    }


}
