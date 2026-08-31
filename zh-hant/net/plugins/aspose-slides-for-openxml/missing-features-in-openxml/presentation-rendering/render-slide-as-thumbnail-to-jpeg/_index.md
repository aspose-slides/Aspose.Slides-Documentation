---
title: 以 JPEG 格式渲染投影片為縮圖
type: docs
weight: 60
url: /zh-hant/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** 用於建立包含投影片的簡報檔案。這些投影片可以透過使用 Microsoft PowerPoint 開啟簡報檔案來檢視。但有時開發人員可能需要使用他們喜愛的影像檢視器將投影片以影像形式檢視。在此情況下，Aspose.Slides for .NET 可協助您產生投影片的縮圖影像。

使用 Aspose.Slides for .NET 產生任意指定投影片的縮圖方法如下：

1. 建立 **Presentation** 類別的實例。
1. 使用投影片的 ID 或索引取得任意指定投影片的參考。
1. 在指定的比例下取得參考投影片的縮圖影像。
1. 將縮圖影像儲存為任意您想要的影像格式。

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation(srcFileName))
{
    //存取第一張投影片
    ISlide sld = pres.Slides[0];

    //建立完整比例的影像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //以 JPEG 格式將影像儲存至磁碟
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)