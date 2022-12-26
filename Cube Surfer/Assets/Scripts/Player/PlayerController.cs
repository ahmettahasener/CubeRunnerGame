using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardMoveSpeed;
    [SerializeField] private float horizontalMoveSpeed;
    [SerializeField] private float horizontalBound;
    public bool gameFinish;

    private float newPositionX;
    // Start is called before the first frame update
    void Start()
    {
        gameFinish = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerHorizontalInput();
        PlayerForwardMove();
        PlayerHorizontalMove();
    }

    private void PlayerHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalInput = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalInput = 0;
        }
    }

    private void PlayerForwardMove()
    {
        transform.Translate(Vector3.down * forwardMoveSpeed * Time.fixedDeltaTime);
    }


    private void PlayerHorizontalMove()
    {
        newPositionX = transform.position.x + horizontalInput * Time.fixedDeltaTime * horizontalMoveSpeed;
        //if (transform.position.x == horizontalBound)
        //{
        //    gameObject.transform.position = new Vector3(newPositionX, -horizontalBound, horizontalBound);
        //}
        //else if (transform.position.x == -horizontalBound)
        //{
        //    gameObject.transform.position = new Vector3(-newPositionX, -horizontalBound, horizontalBound);
        //}
        newPositionX = Mathf.Clamp(newPositionX, -horizontalBound, horizontalBound);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            horizontalInput = 0;
            forwardMoveSpeed = 0;
            gameFinish = true;
        }
    }
}
