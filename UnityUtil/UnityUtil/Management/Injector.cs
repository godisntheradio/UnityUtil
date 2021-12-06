using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using UnityEngine;

namespace UnityUtil.Management
{
    public class Injector
    {
        public static void Inject<T>(T data)
        {
            var list = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (var item in list)
            {
                foreach (var component in item.GetComponentsInChildren<IInjectable<T>>(true))
                {
                    component.Inject(data);
                }
                
            }
        }
    }

    public interface IInjectable<T>
    {
        void Inject(T data);
    }
}
