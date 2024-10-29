---
title: 根据用户定义的值将幻灯片渲染为缩略图到JPEG
type: docs
weight: 70
url: /zh/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

使用Aspose.Slides for .NET生成所需幻灯片的缩略图：

1. 创建一个**Presentation**类的实例。
1. 使用幻灯片的ID或索引获取任何所需幻灯片的引用。
1. 根据用户定义的X和Y尺寸获取X和Y缩放因子。
1. 获取引用幻灯片在指定缩放比例下的缩略图图像。
1. 将缩略图图像以任何所需的图像格式保存。

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "用户定义的缩略图.pptx";
string destFileName = filePath + "用户定义的缩略图.jpg";

//实例化代表演示文稿文件的Presentation类
using (Presentation pres = new Presentation(srcFileName))
{
    //访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    //用户定义的尺寸
    int desiredX = 1200;
    int desiredY = 800;

    //获取X和Y的缩放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //创建全尺度图像
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //将图像以JPEG格式保存到磁盘
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)