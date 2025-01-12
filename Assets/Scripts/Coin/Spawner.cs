using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private bool _isWorking = true;

    private void Start()
    {
        if (_coinPrefab == null)
        {
            Debug.LogError("Coin prefab is not assigned in the inspector!");
            return;
        }

        if (_spawnPoints.Count == 0)
        {
            Debug.LogError("No spawn points assigned in the inspector!");
            return;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds time = new WaitForSeconds(_spawnTime);

        while (_isWorking)
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                Coin coin = Instantiate(_coinPrefab, spawnPoint.transform.position, Quaternion.identity);
                coin.Destroyed += OnCoinDestroyed;
            }

            yield return time;
        }
    }

    private void OnCoinDestroyed(CollectibleItem destroyedCoin)
    {
        Debug.Log("Монета уничтожена: " + destroyedCoin.name);
    }
}