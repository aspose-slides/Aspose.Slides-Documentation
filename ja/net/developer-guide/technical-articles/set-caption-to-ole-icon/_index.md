---
title: OLEアイコンにキャプションを設定する
type: docs
weight: 160
url: /ja/net/set-caption-to-ole-icon/
---

新しいプロパティ **SubstitutePictureTitle** が **IOleObjectFrame** インターフェースと **OleObjectFrame** クラスに追加されました。これにより、OLEアイコンのキャプションを取得、設定、または変更することができます。以下のコードスニペットは、Excelオブジェクトを作成し、そのキャプションを設定するサンプルを示しています。

```csharp
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    // Oleオブジェクトを追加
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.xlsx");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xlsx");

    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // 画像オブジェクトを追加
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    IPPImage image = pres.Images.AddImage(imgBuf);

    oof.SubstitutePictureFormat.Picture.Image = image;

    // OLEアイコンにキャプションを設定
    oof.SubstitutePictureTitle = "キャプションの例";
}
```