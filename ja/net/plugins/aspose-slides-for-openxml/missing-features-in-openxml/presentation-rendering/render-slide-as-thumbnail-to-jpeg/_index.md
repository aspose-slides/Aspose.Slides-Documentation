---
title: スライドをサムネイルとしてJPEGにレンダリング
type: docs
weight: 60
url: /ja/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** はスライドを含むプレゼンテーション ファイルの作成に使用されます。これらのスライドは Microsoft PowerPoint でプレゼンテーション ファイルを開くことで表示できます。しかし、開発者が好きな画像ビューアでスライドを画像として表示したい場合もあります。そのようなケースでは、Aspose.Slides for .NET がスライドのサムネイル画像の生成を支援します。

Aspose.Slides for .NET を使用して任意のスライドのサムネイルを生成する手順:

1. **Presentation** クラスのインスタンスを作成します。
1. ID またはインデックスを使用して目的のスライドの参照を取得します。
1. 指定したスケールで参照したスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します
using (Presentation pres = new Presentation(srcFileName))
{
    //最初のスライドにアクセスします
    ISlide sld = pres.Slides[0];

    //フルスケールの画像を作成します
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //画像を JPEG 形式でディスクに保存します
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)