---
title: 向演示文稿添加形状
type: docs
weight: 30
url: /zh/net/adding-shapes-to-presentation/
---

## **VSTO**
下面是添加线形状的代码片段：

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
要向演示文稿的所选幻灯片添加一条简单的直线，请遵循以下步骤：

- 创建 Presentation 类的实例
- 使用索引获取幻灯片的引用
- 使用 Shapes 对象提供的 AddAutoShape 方法添加线类型的 AutoShape
- 将修改后的演示文稿写入 PPTX 文件

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)