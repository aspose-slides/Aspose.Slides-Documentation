---
title: スライドをサムネイルとしてJPEGにレンダリング
type: docs
weight: 60
url: /net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** は、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし、場合によっては、開発者がお気に入りの画像ビューアを使用してスライドを画像として表示したいことがあります。そのような場合、Aspose.Slides for .NETはスライドのサムネイル画像を生成するのに役立ちます。

Aspose.Slides for .NETを使用して、任意のスライドのサムネイルを生成するには:

1. **Presentation** クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成する
using (Presentation pres = new Presentation(srcFileName))
{
    //最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    //フルスケールの画像を作成
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //JPEG形式でディスクに画像を保存
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **サンプルコードをダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)