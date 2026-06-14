---
title: 使用者自訂尺寸產生投影片縮圖
type: docs
weight: 100
url: /zh-hant/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
使用 Aspose.Slides for .NET 產生任意投影片的縮圖：

- 建立 Presentation 類別的實例。
- 使用投影片的 ID 或索引取得任意投影片的參照。
- 根據使用者定義的 X 與 Y 尺寸取得 X 與 Y 的縮放比例。
- 在指定的比例下取得參照投影片的縮圖影像。
- 將縮圖影像儲存為任意需要的影像格式。

## **範例**
```cs
//實例化代表簡報檔案的 Presentation 類別
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //存取第一張投影片
    ISlide sld = pres.Slides[0];

    //使用者自訂尺寸
    int desiredX = 1200;
    int desiredY = 800;

    //取得 X 與 Y 的縮放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //建立完整比例的影像
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //以 JPEG 格式將影像儲存至磁碟
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)

## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
如需更多資訊，請參閱 [Convert Slide](/slides/zh-hant/net/convert-slide/)。
{{% /alert %}}