---
title: ユーザー定義のサイズでスライドからサムネイルを生成する
type: docs
weight: 100
url: /ja/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Aspose.Slides for .NET を使用して任意のスライドのサムネイルを生成するには：

- Presentation クラスのインスタンスを作成します。
- スライドの ID またはインデックスを使用して、任意のスライドの参照を取得します。
- ユーザー定義の X および Y の寸法に基づいて、X と Y のスケーリング係数を取得します。
- 指定したスケールで参照されたスライドのサムネイル画像を取得します。
- サムネイル画像を任意の画像形式で保存します。
## **例**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **実行サンプルのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
詳細については、[スライド変換](/slides/ja/net/convert-slide/) をご覧ください。
{{% /alert %}}