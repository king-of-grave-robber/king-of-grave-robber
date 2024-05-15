using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // 이미 생성된 지역의 정보를 보관하는 리스트
    List<Vector2> alreadyMade = new List<Vector2>();
    private System.Random random = new System.Random();

    // 맵이 생성될 때 배치될 요소들
    public GameObject groundPrefab;                    // 땅 프리팹
    public GameObject historicalSite1Prefab;       // 유적지 1 프리팹
    public GameObject historicalSite2Prefab;       // 유적지 2 프리팹
    public GameObject historicalSite3Prefab;       // 유적지 3 프리팹
    public GameObject historicalSite4Prefab;       // 유적지 4 프리팹
    public GameObject historicalSite5Prefab;       // 유적지 5 프리팹
    public GameObject tombPrefab;                         // 무덤 프리팹
    public GameObject tree1Prefab;                         // 나무 1 프리팹
    public GameObject tree2Prefab;                        // 나무 2 프리팹
    public GameObject tree3Prefab;                       // 나무 3 프리팹
    public GameObject tree4Prefab;                      // 나무 4 프리팹

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
        int groundNumber = random.Next(50); // 땅의 종류를 랜덤하게 정한다. 

        alreadyMade.Add(vec); // 이미 생성된 지역의 배열에 해당 위치를 추가한다.

        // 지형을 생성할 위치의 transform을 지정한다.
        Transform transform = this.transform;
        transform.position = new Vector3(25 * vec.x, 0, 25 * vec.y);

        // 새로운 지형 인스턴스를 생성한다.
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
        // 25x25 크기의 한 ground를 5x5크기의 25개의 구역으로 나누고 각 구역에 배치한다.
        Vector2 groundCenter = new Vector2(vec.x * 25, vec.y * 25);

        // 지형을 생성할 위치의 transform을 지정한다.
        Transform transform = this.transform;

        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                int randomNumber = random.Next(40);

                // 무언가가 배치될 땅의 좌표 계산
                transform.position = new Vector3(groundCenter.x + i * 5, 0, groundCenter.y + j * 5);

                // 10% 확률로 나무, 10%확률로 무덤, 80% 확률로 빈땅이 배치되도록 구성
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
