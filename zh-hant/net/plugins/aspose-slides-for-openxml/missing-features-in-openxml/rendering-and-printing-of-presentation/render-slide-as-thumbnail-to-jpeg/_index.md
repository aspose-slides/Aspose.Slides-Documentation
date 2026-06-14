---
title: 將投影片渲染為 JPEG 縮圖
type: docs
weight: 60
url: /zh-hant/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** 用於建立包含投影片的簡報檔案。這些投影片可透過使用 Microsoft PowerPoint 開啟簡報檔案來檢視。但有時開發人員可能需要使用他們喜愛的圖像檢視器將投影片以圖像的形式檢視。在此情況下，Aspose.Slides for .NET 可協助您產生投影片的縮圖圖像。

使用 Aspose.Slides for .NET 產生任意投影片縮圖的步驟如下：

1. 建立 **Presentation** 類別的實例。
1. 使用投影片的 ID 或索引取得任意投影片的參考。
1. 以指定的比例取得參考投影片的縮圖圖像。
1. 將縮圖圖像儲存為任意所需的圖像格式。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

// 實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation(srcFileName))
{
    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 建立全尺寸影像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // 將影像以 JPEG 格式儲存至磁碟
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)