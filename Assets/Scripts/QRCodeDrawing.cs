
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZXing;
using ZXing.QrCode;

public class QRCodeDrawing : MonoBehaviour
{
    public RawImage QRCode;
    public Button DrawButton;
    public TMP_InputField inputField;
    //public string QRCodeText = "http://www.pccu3.edu.tw";
    //IBarcodeWriter<Color32[]> barcodeWriter;

    void Start()
    {
        DrawButton.onClick.AddListener(() => DrawQRCode(inputField.text));
    }

    private static Color32[] GenerateQRCode(string str, int width, int height)
    {
        /*
        ZXing.QrCode.QrCodeEncodingOptions options = new ZXing.QrCode.QrCodeEncodingOptions();
        options.CharacterSet = "UTF-8";
        options.Width = width;
        options.Height = height;
        options.Margin = 1;

        ZXing.Rendering.IBarcodeRenderer<Color32[]> renderer = null;
        //barcodeWriter = new ZXing.BarcodeWriter{Format = BarcodeFormat.QR_CODE, Options = options};
        //barcodeWriter = new ZXing.BarcodeWriter<Color32[]>{Format = BarcodeFormat.QR_CODE, Options = options, Renderer = new ZXing.Rendering.BitmapRenderer()};
        barcodeWriter = new ZXing.BarcodeWriter<Color32[]>{
            Format = BarcodeFormat.QR_CODE, 
            Options = options,
            Renderer = renderer
        };

        Color32[] color32data = barcodeWriter.Write(str);
        return color32data;
        */
        var writer = new BarcodeWriter {
            Format = BarcodeFormat.QR_CODE,
            Options = new ZXing.QrCode.QrCodeEncodingOptions {
                Height = height,
                Width = width
            }
        };
        return writer.Write(str);
    }

    Texture2D ShowQRCode(string str, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        Color32[] colors = GenerateQRCode(str, width, height);
        texture.SetPixels32(colors);
        texture.Apply();
        return texture;
    }

    void DrawQRCode(string str)
    {
        Texture2D texture = ShowQRCode(str, 256, 256);
        QRCode.texture = texture;
    }
}
