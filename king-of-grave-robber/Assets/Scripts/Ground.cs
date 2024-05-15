using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private WorldManager worldManager;
    public Vector2 index; // 땅 개체의 World 딕셔너리에서의 index

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
        // 충돌한 개체의 콜라이더 불러옴
        Collider collider = collision.collider;

        // Player가 땅에 들어오면 땅을 확장한다.
        if (collider.tag == "Player")
        {
            if (worldManager != null)
            {
                worldManager.ExpandGround(index);
            }
        }
    }
}
