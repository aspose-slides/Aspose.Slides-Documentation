---
title: 通过用户定义的数值将幻灯片渲染为 JPEG 缩略图
type: docs
weight: 70
url: /zh/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
要使用 Aspose.Slides for .NET 生成任意所需幻灯片的缩略图：

1. 创建 **Presentation** 类的实例。
1. 使用幻灯片的 ID 或索引获取所需幻灯片的引用。
1. 根据用户定义的 X 和 Y 尺寸获取 X 和 Y 缩放系数。
1. 按指定比例获取引用幻灯片的缩略图像。
1. 将缩略图像保存为任意所需的图像格式。

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//实例化表示演示文件的 Presentation 类
using (Presentation pres = new Presentation(srcFileName))
{
    //访问第一张幻灯片
    ISlide sld = pres.Slides[0];

    //用户自定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    //获取 X 和 Y 的缩放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //创建完整比例的图像
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //将图像以 JPEG 格式保存到磁盘
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)