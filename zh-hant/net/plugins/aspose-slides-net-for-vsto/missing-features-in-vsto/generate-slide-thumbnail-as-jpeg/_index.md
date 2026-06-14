---
title: 產生投影片縮圖為 JPEG
type: docs
weight: 90
url: /zh-hant/net/generate-slide-thumbnail-as-jpeg/
---
使用 Aspose.Slides for .NET 產生任意投影片的縮圖：

- 建立 Presentation 類別的實例。
- 使用投影片的 ID 或索引取得任意投影片的參照。
- 在指定的比例下取得參照投影片的縮圖影像。
- 將縮圖影像儲存為任意想要的影像格式。
## **範例**
```cs
//實例化代表投影片檔案的 Presentation 類別
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //取得第一張投影片
    ISlide sld = pres.Slides[0];

    //建立完整比例的影像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //將影像以 JPEG 格式儲存至磁碟
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **下載執行範例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **下載範例程式碼**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
更多詳細資訊，請參閱 [將 PPT 與 PPTX 轉換為 JPG (.NET)](/slides/zh-hant/net/convert-powerpoint-to-jpg/)。
{{% /alert %}}