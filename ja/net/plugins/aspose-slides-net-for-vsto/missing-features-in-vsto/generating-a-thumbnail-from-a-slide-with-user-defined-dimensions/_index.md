---
title: ユーザー定義の寸法を持つスライドからサムネイルを生成する
type: docs
weight: 100
url: /net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Aspose.Slides for .NETを使用して、任意のスライドのサムネイルを生成するには:

- Presentationクラスのインスタンスを作成します。
- IDまたはインデックスを使用して、任意のスライドの参照を取得します。
- ユーザー定義のXおよびY寸法に基づいて、XおよびYスケーリングファクターを取得します。
- 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
- 任意の画像フォーマットでサムネイル画像を保存します。
## **例**
```cs
//プレゼンテーションファイルを表すPresentationクラスをインスタンス化します
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    //ユーザー定義の寸法
    int desiredX = 1200;
    int desiredY = 800;

    //XおよびYのスケーリング値を取得します
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //フルスケールの画像を作成します
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //JPEG形式でディスクに画像を保存します
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **実行例をダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **サンプルコードをダウンロード**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

詳細については、[スライドのサムネイル画像の作成](/slides/net/presentation-viewer/#creating-slides-thumbnail-image)をご覧ください。

{{% /alert %}}