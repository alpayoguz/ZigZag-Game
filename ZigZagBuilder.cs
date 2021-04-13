using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagBuilder : MonoBehaviour
{
    private List<GameObject> Tiles;  // Burada bu listeyi oluşturmamızın sebebi tüm karoları en baştan belirlemek. Yani sonradan oluşturmayacağız. Önceden belirlediğimiz karoları buradan çekip kullanacağız.

    [SerializeField] 
    private GameObject tilePrefab;

    [SerializeField]
    private GameObject ball;

    private Vector3 nextDirection = Vector3.right / 2 ;
    void Start()
    {
        Tiles = new List<GameObject>() { Instantiate(tilePrefab, new Vector3(2.75f, 0.25f, 2.25f), Quaternion.identity) };

        for(int i = 0; i < 29; i++ )
        {
            AddTile();
        }
     
    }

    private void AddTile()
    {
        Color tileColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        nextDirection = Random.Range(0, 2) == 1 ? Vector3.right / 2 : Vector3.forward / 2;

        if(Tiles.Count < 30)
        {
            Tiles.Add(Instantiate(tilePrefab, Tiles[Tiles.Count - 1].transform.position + nextDirection, Quaternion.identity));
            Tiles[Tiles.Count - 1].GetComponent<MeshRenderer>().material.color = tileColor;
        }

        //if(Random.Range(0, 2) == 1)
        //{
        //    nextDirection = Vector3.right;
        //}
        //else
        //{
        //    nextDirection = Vector3.forward;
        //}

        // Bu kısım yukarı da ki, tek satırlık yer ile aynı

        else
        {
            Tiles[0].transform.position = Tiles[Tiles.Count - 1].transform.position + nextDirection;
            Tiles[0].GetComponent<MeshRenderer>().material.color = tileColor;
            Tiles.Add(Tiles[0]);
            Tiles.RemoveAt(0);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Tiles[(Tiles.Count - 1) / 2 ].transform.position, ball.transform.position) < 2)
        {
            AddTile();
        }
    }
}
