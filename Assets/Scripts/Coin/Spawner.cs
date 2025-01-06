using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private Coin _coinPrefab;

    private SpawnPoint[] _points;
    private bool _isWorking = true;
    private int _minValue = 0;

    private void Awake()
    {
        _points = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds time = new WaitForSeconds(_spawnTime);

        while (_isWorking)
        {
            if (_points.Length > _minValue)
            {
                SpawnPoint spawnPoint = _points[Random.Range(_minValue, _points.Length)];
                Coin coin = spawnPoint.Spawn();

                if (coin != null)
                {
                    coin.Destroyed += OnCoinDestroyed;
                }
            }

            yield return time;
        }
    }

    private void OnCoinDestroyed(Coin destroyedCoin)
    {
        Debug.Log("Монета уничтожена: " + destroyedCoin.name);
    }
}