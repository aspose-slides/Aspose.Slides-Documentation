---
title: 从带有用户定义尺寸的幻灯片生成缩略图
type: docs
weight: 100
url: /zh/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

要使用 Aspose.Slides for .NET 生成所需幻灯片的缩略图：

- 创建一个表示演示文稿文件的 Presentation 类的实例。
- 通过使用幻灯片的 ID 或索引获取所需幻灯片的引用。
- 根据用户定义的 X 和 Y 尺寸获取 X 和 Y 缩放因子。
- 在指定的比例上获取引用幻灯片的缩略图像。
- 将缩略图像保存为任何所需的图像格式。
## **示例**
```cs
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    // 访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 用户定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // 创建全尺寸图像
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        // 以 JPEG 格式将图像保存到磁盘
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [创建幻灯片缩略图像](/slides/zh/net/presentation-viewer/#creating-slides-thumbnail-image)。

{{% /alert %}}