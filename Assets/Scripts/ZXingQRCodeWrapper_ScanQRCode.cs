using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class ZXingQRCodeWrapper_ScanQRCode : MonoBehaviour
{
    public RawImage cameraTextrue;
    public Text text;
    public Button scanningbutton;
    private WebCamTexture webCamTexture;
    IBarcodeReader barcodeReader;
    void Start()
    {
        scanningbutton.onClick.AddListener(ScanningButtonClick);
    }

    bool isScanning = false;
    float interval = 0.5f;
    void ScanningButtonClick()
    {
        DeviceInit();
        isScanning = true;
    }

    void DeviceInit()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        string deviceName = devices[0].name;
        webCamTexture = new WebCamTexture(deviceName,100,100);
        cameraTextrue.texture = webCamTexture;
        webCamTexture.Play();

        barcodeReader = new BarcodeReader();
    }
    void Update()
    {
        if(isScanning)
        {
            interval += Time.deltaTime;
            if(interval >= 3)
            {
                interval = 0;
                ScanQRCode();
            }
        }
    }

    //Color32[] data;
    void ScanQRCode()
    {
        //data = webCamTexture.GetPixels32();
        var snap = new Texture2D(webCamTexture.width, webCamTexture.height, TextureFormat.ARGB32, false);
        snap.SetPixels32(webCamTexture.GetPixels32());
        Result result = barcodeReader.Decode(snap.GetRawTextureData(), webCamTexture.width, webCamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);

        if(result != null)
        {
            text.text = result.Text;

            isScanning = false;
            webCamTexture.Stop();
        }
    }
    
}
