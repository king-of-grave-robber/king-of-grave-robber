using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private WorldManager worldManager;
    public Vector2 index; // �� ��ü�� World ��ųʸ������� index

    // Start is called before the first frame update
    void Start()
    {
        worldManager = FindObjectOfType<WorldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collision)
    {
        // �浹�� ��ü�� �ݶ��̴� �ҷ���
        Collider collider = collision.collider;

        // Player�� ���� ������ ���� Ȯ���Ѵ�.
        if (collider.tag == "Player")
        {
            if (worldManager != null)
            {
                worldManager.ExpandGround(index);
            }
        }
    }
}
