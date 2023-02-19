using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private bool _isSpawn;
    [SerializeField] private GameObject _prefab;

    [SerializeField] private Transform _spawnPoint;


    [SerializeField] private int gridX;
    [SerializeField] private int gridY;
    [SerializeField] private float distanceX;
    [SerializeField] private float distanceY;
    [SerializeField] private float coordY;

    private void Start()
    {
        if (_isSpawn)
            SpawnUnits();
    }

    public void SpawnUnits()
    {
        int i = 0;
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                //if (i < gridY / 2)
                //    coordY += 1f;
                //else if (i == gridY / 2)
                //    coordY = coordY;
                //else
                //    coordY -= 1f;

                Instantiate(_prefab, new Vector3(x * distanceX, coordY, y * distanceY), _prefab.transform.rotation, _spawnPoint);
                i++;
            }
        }
    }
}
