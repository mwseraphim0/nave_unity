using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float deslocamentoLaser = 0.5f;
    [SerializeField] private float velocidadeNave = 10f;
    private Rigidbody2D playerRb;
    private float horizontalInput, verticalInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space")) {
            GameObject laser =  LaserPool.Instance.Atirar();
            laser.transform.position = transform.position + Vector3.up * deslocamentoLaser;
        }
    } 

    private void FixedUpdate() {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * velocidadeNave * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + movement);
    }
}
