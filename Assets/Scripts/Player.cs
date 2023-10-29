using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    private float _playerSpeed = 5f;
    private float _jampForce = 5f;
    private bool _isGrounded = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == false)
        {
            PlayerJump();
        }
    }

    void PlayerJump()
    {
        _rb.AddForce(Vector3.up * _jampForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            _isGrounded = false;
        }
    }
}
