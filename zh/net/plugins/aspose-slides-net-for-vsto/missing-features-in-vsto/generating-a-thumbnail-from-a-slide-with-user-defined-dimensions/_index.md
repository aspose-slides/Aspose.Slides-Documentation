---
title: 使用用户定义尺寸从幻灯片生成缩略图
type: docs
weight: 100
url: /zh/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

- 创建 Presentation 类的实例。
- 通过使用 ID 或索引获取任意所需幻灯片的引用。
- 根据用户定义的 X 和 Y 尺寸获取 X 和 Y 缩放因子。
- 按指定比例获取引用幻灯片的缩略图。
- 以任意所需的图像格式保存缩略图。

## **示例**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
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
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)

## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

欲了解更多信息，请访问 [Convert Slide](/slides/zh/net/convert-slide/)。

{{% /alert %}}