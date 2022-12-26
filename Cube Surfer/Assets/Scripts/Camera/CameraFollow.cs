using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;

    private Vector3 newPosition;
    private Vector3 offset;

    [SerializeField] private float lerpValue;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, PlayerTransform.position.y, PlayerTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
