---
title: 使用者自訂值將投影片渲染為 JPEG 縮圖
type: docs
weight: 70
url: /zh-hant/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
使用 Aspose.Slides for .NET 產生任何所需投影片的縮圖：

1. 建立 **Presentation** 類別的執行個體。
1. 使用投影片的 ID 或索引取得任何所需投影片的參照。
1. 根據使用者自訂的 X 與 Y 尺寸取得 X 與 Y 縮放比例。
1. 在指定的比例下取得參照投影片的縮圖影像。
1. 以任何所需的影像格式儲存縮圖。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

// 實例化代表投影片檔案的 Presentation 類別
using (Presentation pres = new Presentation(srcFileName))
{
    // 存取第一張投影片
    ISlide sld = pres.Slides[0];

    // 使用者自訂尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 取得 X 與 Y 的縮放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // 建立完整比例的影像
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        // 以 JPEG 格式將影像儲存至磁碟
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **下載範例程式碼**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)