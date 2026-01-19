---
title: 将图片框添加到演示文稿
type: docs
weight: 50
url: /zh/net/add-picture-frame-to-presentation/
---

## **VSTO**
以下是向 VSTO 演示文稿添加图片的代码：

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
要向幻灯片添加简单的图片框，请按照以下步骤操作：

1. 创建 Presentation 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 通过向与 Presentation 对象关联的 Images 集合中添加图像来创建 Image 对象，以填充 Shape。  
4. 计算图像的宽度和高度。  
5. 使用引用幻灯片的 Shapes 对象提供的 AddPictureFrame 方法，根据图像的宽度和高度创建 PictureFrame。  
6. 将包含图片的图片框添加到幻灯片。  
7. 将修改后的演示文稿写入 PPTX 文件。  

以下示例实现了上述步骤。

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)