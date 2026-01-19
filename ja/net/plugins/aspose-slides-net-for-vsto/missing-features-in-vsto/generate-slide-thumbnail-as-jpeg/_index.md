---
title: スライドのサムネイルを JPEG として生成
type: docs
weight: 90
url: /ja/net/generate-slide-thumbnail-as-jpeg/
---

Aspose.Slides for .NET を使用して任意のスライドのサムネイルを生成するには、次の手順を実行します:

- Presentation クラスのインスタンスを作成します。
- ID またはインデックスを使用して、目的のスライドの参照を取得します。
- 指定したスケールで、参照したスライドのサムネイル画像を取得します。
- サムネイル画像を任意の画像形式で保存します。

## **例**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **実行例のダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)

## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

詳細については、[PPT と PPTX を .NET で JPG に変換](/slides/ja/net/convert-powerpoint-to-jpg/) をご覧ください。

{{% /alert %}}