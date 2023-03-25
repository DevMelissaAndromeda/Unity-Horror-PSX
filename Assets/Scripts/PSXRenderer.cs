using System;
using UnityEngine;
using UnityEngine.UI;



public sealed class PSXRenderer : MonoBehaviour
{
    [SerializeField] RenderTexture PSXRenderTexture;
    [SerializeField] CanvasScaler canvasScaler;

    readonly UInt16 defaultWidth = 240;
    readonly UInt16 defaultHeight = 240;



    readonly Func<float, float, float> GetAspectRatio = (width, height) 
        => width / height;

    readonly Func<float, float, UInt16> ExtendAspectRation = (defaultValue, aspectRatio) 
        => (UInt16)(defaultValue * aspectRatio);



    void Awake()
    {
        PSXRenderTexture.Release();
            if (Screen.width > Screen.height)
                PSXRenderTexture.width = ExtendAspectRation(
                    defaultWidth, 
                    GetAspectRatio(Screen.width, Screen.height)
                );
            else
                PSXRenderTexture.height = ExtendAspectRation(
                    defaultHeight, 
                    GetAspectRatio(Screen.width, Screen.height)
                );
        PSXRenderTexture.Create();


        canvasScaler.referenceResolution = new Vector2(
            PSXRenderTexture.width, 
            PSXRenderTexture.height
        );
    }



#if UNITY_EDITOR
    void OnApplicationQuit()
    {
        PSXRenderTexture.Release();
            PSXRenderTexture.width = defaultWidth;
            PSXRenderTexture.height = defaultHeight;
        PSXRenderTexture.Create();
    }
#endif
}
