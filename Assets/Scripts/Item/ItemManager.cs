using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Singleton

    private static ItemManager _instance = null;
    public static ItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ItemManager not Found");
                }
            }
            return _instance;
        }
    }

    #endregion
    [SerializeField] private int locationX;
    [SerializeField] private int locationZ;
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject[] ItemList;

    float timer;



    void Update()
    {
        timer += Time.deltaTime;
        //jika objek kurang dari 10 lanjut spawn
        if (timer >= spawnDelay && this.transform.childCount <= 10)
        {
            SpawnItem();
        }
    }

    //spawn item random
    private void SpawnItem()
    {
        timer = 0f;
        Instantiate(ItemList[Random.Range(0, 2)], new Vector3(Random.Range(locationX, -locationX), 0, Random.Range(locationZ, -locationZ)), this.transform.rotation, this.gameObject.transform);
    }
}
