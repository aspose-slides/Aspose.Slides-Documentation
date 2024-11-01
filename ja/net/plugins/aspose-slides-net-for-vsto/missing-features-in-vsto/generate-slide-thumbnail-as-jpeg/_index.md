---
title: スライドのサムネイルをJPEGとして生成
type: docs
weight: 90
url: /ja/net/generate-slide-thumbnail-as-jpeg/
---

Aspose.Slides for .NETを使用して、任意のスライドのサムネイルを生成するには:

- Presentationクラスのインスタンスを作成します。
- IDまたはインデックスを使用して、任意のスライドの参照を取得します。
- 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
- 任意の形式でサムネイル画像を保存します。
## **例**
```cs
//プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    //フルスケールの画像を作成
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //JPEG形式でディスクに画像を保存
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **実行例のダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードのダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[スライドサムネイル画像の作成](/slides/ja/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage)をご覧ください。

{{% /alert %}}