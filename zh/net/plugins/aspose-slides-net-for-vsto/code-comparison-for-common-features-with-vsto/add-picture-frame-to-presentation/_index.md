---
title: 添加图片框到演示文稿
type: docs
weight: 50
url: /net/add-picture-frame-to-presentation/
---

## **VSTO**
下面是将图片添加到VSTO演示文稿的代码：

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
要在您的幻灯片上添加简单的图片框，请按照以下步骤操作：

1. 创建一个Presentation类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 通过将图像添加到与Presentation对象相关联的Images集合中来创建一个Image对象，该图像将用于填充形状。
1. 计算图像的宽度和高度。
1. 根据图像的宽度和高度，使用与引用幻灯片关联的Shapes对象所公开的AddPictureFrame方法创建一个PictureFrame。
1. 将图片框（包含图片）添加到幻灯片。
1. 将修改后的演示文稿写入PPTX文件。

上述步骤在下面的示例中实现。

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //实例化表示PPTX的Presentation类

  Presentation pres = new Presentation();

  //获取第一张幻灯片

  ISlide sld = pres.Slides[0];

  //实例化ImageEx类

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //添加具有相应高度和宽度的图片框

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **下载运行代码**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)