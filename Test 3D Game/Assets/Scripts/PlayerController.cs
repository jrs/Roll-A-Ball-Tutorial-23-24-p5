using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public GameObject WinText;

    public float Speed = 10f;
    
    private float _horizontalInput;
    private float _forwardInput;

    private int _count;

    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _count = 0;
        CountText.text = "Count: " + _count.ToString();
        WinText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        _playerRigidbody.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            CountText.text = "Count: " + _count.ToString();

            if(_count >= 8)
            {
                WinText.gameObject.SetActive(true);
            }
        }
    }
}