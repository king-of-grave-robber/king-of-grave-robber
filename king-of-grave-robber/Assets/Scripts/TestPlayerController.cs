using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; // �̵� �ӷ�


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� z ���� �� �ֱ�
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if ( Input.GetKey(KeyCode.DownArrow) == true)
        {
            // �Ʒ��� ����Ű �Է��� ������ ��� -z ���� �� �ֱ�
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if ( Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ������ ����Ű �Է��� ������ ��� x ���� �� �ֱ�
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� -x ���� �� �ֱ�
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            playerRigidbody.AddForce(0, 16f, 0);
        }
        */

        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed) �� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // ������ٵ��� �ӵ��� newVelocity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

}
