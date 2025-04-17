using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speed;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject Ninja;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        if(horizontal != 0)
        {
            anim.SetBool("Runing", true);
        }
        else
        {
            anim.SetBool("Runing", false);
        }
        if(horizontal < 0)
        {
            Ninja.transform.localScale = new Vector2(-1.5f, 1.5f);
            Debug.Log("Left");
        }
        else if (horizontal > 0)
        {
            Ninja.transform.localScale = new Vector2(1.5f, 1.5f);
            Debug.Log("Right");
        }
    }
}
