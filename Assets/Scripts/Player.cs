using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float _playerSpeed = 5f;

    private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 7.0f;
    private bool _isGrounded = false;
    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;  // Assign the layer of the platforms in the inspector.

    public float playerHealth = 100;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody not found on the player.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horiInput = Input.GetAxis("Horizontal");
        transform.Translate (new Vector3(1, 0, 0) * horiInput * _playerSpeed * Time.deltaTime);
        if (transform.position.x > 1.8f)
        {
            transform.position = new Vector3(1.8f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -1.8f)
        {
            transform.position = new Vector3(-1.8f, transform.position.y, transform.position.z);
        }

        //if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        //}

        // Check if the player is grounded
        //_isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayer);

        if(_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }


    }

    //private void OnDrawGizmos()
    //{
    //    // Visualize the ground check ray in the editor
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundCheckDistance);
    //}
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = false;
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }

}
