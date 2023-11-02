using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float _playerSpeed = 5f;

    private Rigidbody _rb;
    [SerializeField] private float _jumpForce = 4.0f;
    private bool _isGrounded = false;
    //[SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer;  // Assign the layer of the platforms in the inspector.

    public float playerLives = 3;
    public float score = 0;

    private SpawnManager _spawnManager;
    void Start()
    {
        _spawnManager = FindAnyObjectByType<SpawnManager>();
        if(_spawnManager ==  null)
        {
            Debug.LogError("SpawnManager not found");
        }

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


        if(_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }


    }

   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = true;
        }

        if(other.gameObject.tag == "Heart")
        {
            Destroy(other.gameObject);
            IncreaseLives();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            _isGrounded = false;
        }
    }

    public void TakeDamage()
    {
        playerLives -- ;

        if(playerLives <= 2)
        {
            _spawnManager.StartHeartSpawning();
        }

        if(playerLives > 2)
        {
            _spawnManager.StopHeartSpawning();
            
        }

        if (playerLives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void Score()
    {
        score += 10;
    }

    public void IncreaseLives()
    {
        playerLives ++;
    }
}
