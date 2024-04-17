using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    public bool movingRight;
    public bool movingLeft;
    public bool movingUp;
    public bool movingDown;

    public int playerDirection;

    public GameObject faceR;
    public GameObject faceD;
    public GameObject faceL;
    public GameObject faceU;

    public Animator playerAnimations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        


        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            moveInput.y = 0;
            rb2d.velocity = moveInput * moveSpeed;
        }
        else
        {
            moveInput.x = 0;
            rb2d.velocity = moveInput * moveSpeed;
        }


        ////moving right
        if (moveInput.x > 0)
        {
            movingRight = true;
            faceR.SetActive(true);
            faceL.SetActive(false);
            faceD.SetActive(false);
            faceU.SetActive(false);
            playerAnimations.Play("walkR");
        }
        else
        {
            movingRight = false;
        }
        ////moving left
        if (moveInput.x < 0)
        {
            movingLeft = true;
            faceR.SetActive(false);
            faceL.SetActive(true);
            faceD.SetActive(false);
            faceU.SetActive(false);
            playerAnimations.Play("walkL");
        }
        else
        {
            movingLeft = false;
        }
        ////moving up
        if (moveInput.y > 0)
        {
            movingUp = true;
            faceR.SetActive(false);
            faceL.SetActive(false);
            faceD.SetActive(false);
            faceU.SetActive(true);
            playerAnimations.Play("walkU");
        }
        else
        {
            movingUp = false;
        }
        ////moving down
        if (moveInput.y < 0)
        {
            movingDown = true;
            faceR.SetActive(false);
            faceL.SetActive(false);
            faceD.SetActive(true);
            faceU.SetActive(false);
            playerAnimations.Play("walkD");
        }
        else
        {
            movingDown = false;
        }
        if(moveInput.y == 0 && moveInput.x == 0)
        {
            playerAnimations.Play("PlayerIdle");
        }

    }
}
