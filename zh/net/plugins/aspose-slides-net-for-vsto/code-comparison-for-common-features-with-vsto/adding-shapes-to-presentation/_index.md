---
title: 向演示文稿添加形状
type: docs
weight: 30
url: /net/adding-shapes-to-presentation/
---

## **VSTO**
以下是添加线形状的代码片段：

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤进行：

- 创建一个Presentation类的实例
- 使用索引获取幻灯片的引用
- 使用Shapes对象暴露的AddAutoShape方法添加线类型的AutoShape
- 将修改后的演示文稿写入PPTX文件

在下面给出的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

``` csharp

   //实例化表示PPTX的Presentation类

  Presentation pres = new Presentation();

  //获取第一张幻灯片

  ISlide slide = pres.Slides[0];

  //添加类型为线的自形状

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **下载运行代码**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)