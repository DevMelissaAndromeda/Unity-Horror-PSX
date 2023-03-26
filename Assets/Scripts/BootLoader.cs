using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public sealed class BootLoader : MonoBehaviour
{
    [SerializeField] AssetReference PSXRenderer;
    [SerializeField] AssetReference MainMenu;


    void Awake()
    {
        Addressables.LoadAssetAsync<GameObject>(PSXRenderer).Completed += 
            (asyncOperationHandle) 
            => Instantiate(asyncOperationHandle.Result
        );

        Addressables.LoadAssetAsync<GameObject>(MainMenu).Completed +=
            (asyncOperationHandle)
            => Instantiate(asyncOperationHandle.Result
        );
    }
}
