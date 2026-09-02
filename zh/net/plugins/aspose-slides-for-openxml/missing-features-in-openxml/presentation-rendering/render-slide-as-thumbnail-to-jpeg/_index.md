---
title: 将幻灯片渲染为 JPEG 缩略图
type: docs
weight: 60
url: /zh/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文件进行查看。但有时，开发人员可能需要使用他们喜欢的图像查看器将幻灯片查看为图像。在这种情况下，Aspose.Slides for .NET 可帮助您生成幻灯片的缩略图图像。

使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

1. 创建 **Presentation** 类的实例。
1. 使用其 ID 或索引获取任意所需幻灯片的引用。
1. 在指定的比例上获取引用幻灯片的缩略图像。
1. 将缩略图像保存为任意所需的图像格式。

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation(srcFileName))
{
    //访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    //创建全比例图像
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //以 JPEG 格式将图像保存到磁盘
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)