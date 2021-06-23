using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using UnityEngine;

namespace UnityUtil.Management
{


    public class ObjectPool
    {
        private List<GameObject> Pool;
        private GameObject ToInstantiate;
        private GameObject parent;

        private Transform Parent { get => parent.transform; }

        int LimitToPool { get; set; }
        bool InstantiateAsParent;

        public ObjectPool(GameObject toPool, GameObject parent, int limit, bool instantiateAsParent = false)
        {
            if (toPool.GetComponent<IPoolable>() == null)
            {
                Debug.LogWarning("Pool object does not implement IPoolable");
                return;
            }
            this.parent = parent;
            Pool = new List<GameObject>();
            ToInstantiate = toPool;
            LimitToPool = limit;
            InstantiateAsParent = instantiateAsParent;
            for (int i = 0; i < LimitToPool; i++)
            {
                var obj = InstantiateNewToPool();
                obj.SetActive(false);
            }
        }

        /// <summary>
        /// returns defined object 
        /// - owner position and rotation
        /// - active
        /// </summary> 
        public GameObject GetGameObjectFromPool()
        {
            if (Pool.Count > 0)
            {
                foreach (GameObject item in Pool)
                {
                    if (!item.activeSelf)
                    {
                        item.SetActive(true);
                        item.GetComponent<IPoolable>().ResetState();
                        return item;
                    }
                }

                if (Pool.Count == LimitToPool)
                    LimitToPool++;

                return InstantiateNewToPool();
            }
            else
                return InstantiateNewToPool();
        }
        public int GetActiveCount()
        {
            int active = 0;
            foreach (GameObject item in Pool)
            {
                if (item.activeSelf)
                {
                    active++;
                }
            }
            return active;
        }

        public void DeactivateAll()
        {
            foreach (GameObject item in Pool)
            {
                item.SetActive(false);
            }
        }

        private GameObject InstantiateNewToPool()
        {

            GameObject obj = InstantiateAsParent ? GameObject.Instantiate(ToInstantiate, Parent) : GameObject.Instantiate(ToInstantiate, Parent.position, Parent.rotation);
            Pool.Add(obj);
            return obj;
        }
    }

    public interface IPoolable
    {
        void ResetState();
    }
}
