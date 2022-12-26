using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private StackController stackController;
    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        stackController = FindObjectOfType<StackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = !isStack;
                stackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }

            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                stackController.DecreaseBlock(gameObject);
            }
        }
    }
    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
