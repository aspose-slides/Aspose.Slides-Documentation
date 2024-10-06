---
title: ユーザー定義の値を使用してスライドをJPEGのサムネイルとしてレンダリングする
type: docs
weight: 70
url: /ja/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Aspose.Slides for .NETを使用して任意のスライドのサムネイルを生成するには：

1. **Presentation**クラスのインスタンスを作成します。
1. スライドのIDまたはインデックスを使用して、任意のスライドの参照を取得します。
1. ユーザー定義のXおよびY次元に基づいてXおよびYスケーリングファクターを取得します。
1. 指定されたスケールで参照されたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
using (Presentation pres = new Presentation(srcFileName))
{
    //最初のスライドにアクセス
    ISlide sld = pres.Slides[0];

    //ユーザー定義の次元
    int desiredX = 1200;
    int desiredY = 800;

    //XおよびYのスケール値を取得
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //フルスケールの画像を作成
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //JPEG形式でディスクに画像を保存
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)