---
title: 如何在 .NET 中创建 Hello World 演示文稿
linktitle: Hello World 演示文稿
type: docs
weight: 10
url: /zh/net/how-to-create-hello-world-presentation-document/
keywords:
- 迁移
- 你好世界
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
- description: "使用 Aspose.Slides 在 .NET 中通过旧版和现代 API 创建 Hello World PowerPoint PPT、PPTX 和 ODP 演示文稿的简易指南。"
---

{{% alert color="primary" %}} 
全新发布了 [Aspose.Slides for .NET API](/slides/zh/net/)，该产品现在能够从头生成 PowerPoint 文档并编辑现有文档。
{{% /alert %}} 
## **对旧版代码的支持**
要使用在 13.x 之前的 Aspose.Slides for .NET 版本中开发的旧版代码，您需要对代码进行一些小修改，代码即可像以前一样工作。旧版 Aspose.Slides for .NET 中位于 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间的所有类现在已合并到单一的 Aspose.Slides 命名空间。请查看下面的简单代码片段，了解如何在旧的 Aspose.Slides API 中创建 Hello World 演示文稿，并按照步骤迁移到新的合并 API。
## **旧版 Aspose.Slides for .NET 方法**
```c#
//实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();

//创建一个 License 对象
License license = new License();

//设置 Aspose.Slides for .NET 的许可证以避免评估限制
license.SetLicense("Aspose.Slides.lic");

//向演示文稿添加一个空幻灯片并获取该空幻灯片的引用
//该空幻灯片
Slide slide = pres.AddEmptySlide();

//向幻灯片添加一个矩形 (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隐藏矩形的线条
rect.LineFormat.ShowLines = false;

//向矩形添加文本框，默认文本为 "Hello World"
rect.AddTextFrame("Hello World");

//删除演示文稿的第一张幻灯片，该幻灯片始终由
//Aspose.Slides for .NET 在创建演示文稿时默认添加
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```


## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
// 实例化演示文稿
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
