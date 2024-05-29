using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;



[System.Serializable]

public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid) { }
}


public class AddressableInstantiator : MonoBehaviour
{

    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReferenceAudioClip assetReferenceAudioClip;
    [SerializeField] private AssetLabelReference assetLabelReference;

    private GameObject spawnGameObject;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
           /* Addressables.LoadAssetsAsync<Sprite>(assetLabelReference, (sprite) =>
            {
                Debug.Log(sprite);
            });*/


            assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation) => spawnGameObject = asyncOperation.Result;
            /*assetReferenceGameObject.LoadAssetAsync<GameObject>().Completed += 
            (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    Instantiate(asyncOperationHandle.Result);

                }
                else
                {
                    Debug.LogError("Loading Aset Failed!");
                }
            };*/
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            assetReferenceGameObject.ReleaseInstance(spawnGameObject);
        }

    }
     
  
   

}
