---
title: 生成幻灯片缩略图作为JPEG
type: docs
weight: 90
url: /net/generate-slide-thumbnail-as-jpeg/
---

要使用Aspose.Slides for .NET生成所需幻灯片的缩略图：

- 创建Presentation类的实例。
- 通过使用其ID或索引获取所需幻灯片的引用。
- 在指定的缩放比例下获取所引用幻灯片的缩略图像。
- 以任何所需的图像格式保存缩略图像。
## **示例**
```cs
//实例化Presentation类，该类代表演示文稿文件
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    //创建全尺寸图像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //将图像以JPEG格式保存到磁盘
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Slide Thumbnail to JPEG/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

欲了解更多详细信息，请访问 [创建幻灯片缩略图像](/slides/net/presentation-viewer/#presentationviewer-creatingslidesthumbnailimage)。

{{% /alert %}}