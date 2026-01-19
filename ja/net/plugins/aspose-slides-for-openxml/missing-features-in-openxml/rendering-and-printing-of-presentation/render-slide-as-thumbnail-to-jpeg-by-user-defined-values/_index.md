---
title: ユーザー定義値でスライドをサムネイルとしてJPEGにレンダリング
type: docs
weight: 70
url: /ja/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Aspose.Slides for .NET を使用して任意のスライドのサムネイルを生成するには:

1. **Presentation** クラスのインスタンスを作成します。
1. ID またはインデックスを使用して目的のスライドの参照を取得します。
1. ユーザー定義の X および Y の寸法に基づいて X と Y のスケーリング係数を取得します。
1. 指定したスケールで参照スライドのサムネイル画像を取得します。
1. サムネイル画像を任意の画像形式で保存します。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
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
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)