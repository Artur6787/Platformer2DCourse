using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    public Coin Spawn()
    {
        if (_coinPrefab != null)
        {
            Coin coin = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
            return coin;
        }

        return null;
    }

    public void SetTemplate(Coin newCoin)
    {
        _coinPrefab = newCoin;
    }
}