using UnityEngine;

public class characterControllerScript : MonoBehaviour
{
    private Animator animator;
    public float movementSpeed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isLeft", true);
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isLeft", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isForward", true);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector3.forward * movementSpeed * 2 * Time.deltaTime);
                    animator.SetBool("isRunning", true);
                    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space)) 
                    {
                        animator.SetBool("isJumping", true);
                    }
                    else
                    {
                        animator.SetBool("isJumping", false);
                    }
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }
            }
            else
            {
                animator.SetBool("isForward", false);
                animator.SetBool("isRunning", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isBackward", true);
                transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isBackward", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isRight", true);
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isRight", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
            animator.SetBool("isBackward", false);
            animator.SetBool("isForward", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouching", true);
        }
        else
        {
            animator.SetBool("isCrouching", false);
        }
    }
}
