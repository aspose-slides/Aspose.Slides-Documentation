---
title: 将幻灯片渲染为 JPEG 缩略图
type: docs
weight: 60
url: /zh/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** 用于创建包含幻灯片的演示文稿文件。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿文件来查看。但有时，开发人员可能需要使用自己喜欢的图像查看器将幻灯片以图像形式查看。在这种情况下，Aspose.Slides for .NET 可帮助您生成幻灯片的缩略图图像。

要使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

1. 创建 **Presentation** 类的实例。  
1. 使用幻灯片的 ID 或索引获取所需幻灯片的引用。  
1. 按指定比例获取引用幻灯片的缩略图图像。  
1. 将缩略图图像保存为任意所需的图像格式。  

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)