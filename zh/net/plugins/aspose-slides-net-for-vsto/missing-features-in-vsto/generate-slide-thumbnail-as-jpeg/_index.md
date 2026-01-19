---
title: 生成幻灯片缩略图为 JPEG
type: docs
weight: 90
url: /zh/net/generate-slide-thumbnail-as-jpeg/
---

使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

- 创建 Presentation 类的实例。
- 通过使用幻灯片的 ID 或索引获取所需幻灯片的引用。
- 在指定比例下获取引用幻灯片的缩略图。
- 将缩略图以任意所需的图像格式保存。
## **示例**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

如需了解更多信息，请访问[在 .NET 中将 PPT 和 PPTX 转换为 JPG](/slides/zh/net/convert-powerpoint-to-jpg/)。

{{% /alert %}}