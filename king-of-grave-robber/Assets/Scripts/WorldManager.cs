using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // �̹� ������ ������ ������ �����ϴ� ����Ʈ
    List<Vector2> alreadyMade = new List<Vector2>();
    private System.Random random = new System.Random();

    // ���� ������ �� ��ġ�� ��ҵ�
    public GameObject groundPrefab;                    // �� ������
    public GameObject historicalSite1Prefab;       // ������ 1 ������
    public GameObject historicalSite2Prefab;       // ������ 2 ������
    public GameObject historicalSite3Prefab;       // ������ 3 ������
    public GameObject historicalSite4Prefab;       // ������ 4 ������
    public GameObject historicalSite5Prefab;       // ������ 5 ������
    public GameObject tombPrefab;                         // ���� ������
    public GameObject tree1Prefab;                         // ���� 1 ������
    public GameObject tree2Prefab;                        // ���� 2 ������
    public GameObject tree3Prefab;                       // ���� 3 ������
    public GameObject tree4Prefab;                      // ���� 4 ������

    // Start is called before the first frame update
    void Start()
    {
        Vector2 vec = new Vector2(0, 0);
        alreadyMade.Add(vec);

        Transform transform = this.transform;
        transform.position = new Vector3(vec.x, 0, vec.y);

        Instantiate(groundPrefab, transform.position, transform.rotation);
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Expand the ground if need
    public void ExpandGround(Vector2 vec)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Vector2 newVec = new Vector2(vec.x + i, vec.y + j);
                if (!alreadyMade.Contains(newVec))
                {
                    makeGround(newVec);
                }
            }
        }
    }

    // Make the ground if not made
    void makeGround(Vector2 vec)
    {
        int groundNumber = random.Next(50); // ���� ������ �����ϰ� ���Ѵ�. 

        alreadyMade.Add(vec); // �̹� ������ ������ �迭�� �ش� ��ġ�� �߰��Ѵ�.

        // ������ ������ ��ġ�� transform�� �����Ѵ�.
        Transform transform = this.transform;
        transform.position = new Vector3(25 * vec.x, 0, 25 * vec.y);

        // ���ο� ���� �ν��Ͻ��� �����Ѵ�.
        GameObject newGround;

        if (groundNumber == 0)
        {
            newGround = Instantiate(historicalSite1Prefab, transform.position, transform.rotation);
        }
        else if (groundNumber == 1)
        {
            newGround = Instantiate(historicalSite2Prefab, transform.position, transform.rotation);
        }
        else if (groundNumber == 2)
        {
            newGround = Instantiate(historicalSite3Prefab, transform.position, transform.rotation);
        }
        else if (groundNumber == 3)
        {
            newGround = Instantiate(historicalSite4Prefab, transform.position, transform.rotation);
        }
        else if (groundNumber == 4)
        {
            newGround = Instantiate(historicalSite5Prefab, transform.position, transform.rotation);
        }
        else
        {
            newGround = Instantiate(groundPrefab, transform.position, transform.rotation);
            decorateGround(vec);
        }

    Ground ground = newGround.GetComponent<Ground>();
    ground.index = vec;    
     }

    // decorate ground if need
    void decorateGround(Vector2 vec)
    {
        // 25x25 ũ���� �� ground�� 5x5ũ���� 25���� �������� ������ �� ������ ��ġ�Ѵ�.
        Vector2 groundCenter = new Vector2(vec.x * 25, vec.y * 25);

        // ������ ������ ��ġ�� transform�� �����Ѵ�.
        Transform transform = this.transform;

        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                int randomNumber = random.Next(40);

                // ���𰡰� ��ġ�� ���� ��ǥ ���
                transform.position = new Vector3(groundCenter.x + i * 5, 0, groundCenter.y + j * 5);

                // 10% Ȯ���� ����, 10%Ȯ���� ����, 80% Ȯ���� ���� ��ġ�ǵ��� ����
                if (randomNumber < 4)
                {
                    if (randomNumber == 1) 
                    { 
                        Instantiate(tree1Prefab, transform.position, transform.rotation); 
                    } 
                    else if (randomNumber == 2) 
                    {
                        Instantiate(tree2Prefab, transform.position, transform.rotation);
                    } 
                    else if (randomNumber == 3)
                    {
                        Instantiate(tree3Prefab, transform.position, transform.rotation);
                    }
                    else
                    {
                        Instantiate(tree4Prefab, transform.position, transform.rotation);
                    }
                    
                }
                else if (randomNumber < 8)
                {
                    Instantiate(tombPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
