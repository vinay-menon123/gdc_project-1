using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movespeed;
    
    [SerializeField]
    private float jumpforce;
    private float horizontalAxis;
    [SerializeField]
    private GameObject groundcheck;

    [SerializeField]
    private LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //_rb.AddForce(new Vector2(movespeed,0.0f),ForceMode2D.Force);
        _rb.velocity = new Vector2(movespeed * horizontalAxis, _rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundcheck.transform.position,0.1f,groundLayer);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalAxis = context.ReadValue<float>();
        Debug.Log(horizontalAxis);
    }
     public void OnJump(InputAction.CallbackContext context)
     {
         if(context.performed && isGrounded)
         _rb.AddForce(new Vector2(0.0f,jumpforce),ForceMode2D.Impulse);
        // Debug.Log("Jump");
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.transform.tag=="enemy")
         {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
         }
     }
}
