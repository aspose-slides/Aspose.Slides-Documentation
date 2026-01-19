---
title: 使用用户定义值将幻灯片渲染为 JPEG 缩略图
type: docs
weight: 70
url: /zh/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

1. 创建 **Presentation** 类的实例。
1. 通过其 ID 或索引获取任意所需幻灯片的引用。
1. 根据用户定义的 X 和 Y 尺寸获取 X 和 Y 的缩放因子。
1. 在指定缩放比例下获取引用幻灯片的缩略图像。
1. 将缩略图像保存为任意所需的图像格式。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
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
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)