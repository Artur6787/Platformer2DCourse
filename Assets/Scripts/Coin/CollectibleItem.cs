using System;
using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    public event Action<CollectibleItem> Collected;
    public event Action<CollectibleItem> Destroyed;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Movement movement))
        {
            Collected?.Invoke(this);
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
