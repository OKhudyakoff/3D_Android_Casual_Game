using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab { get; private set; }
    public bool autoExpand { get; private set; }
    public Transform container { get; private set; }

    private List<T> pool;

    public PoolMono(T prefab, int count, Transform container, bool autoExpand = false)
    {
        this.prefab = prefab;
        this.container = container;
        this.autoExpand = autoExpand;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.pool = new List<T>(count);

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActivityDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActivityDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if(!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement(bool vision)
    {
        if(this.HasFreeElement(out var element))
        {
            element.gameObject.SetActive(vision);
            return element;
        }

        if(this.autoExpand)
        {
            return this.CreateObject(true);
        }

        throw new Exception($"There is no free element of type {typeof(T)}");
    }
}
