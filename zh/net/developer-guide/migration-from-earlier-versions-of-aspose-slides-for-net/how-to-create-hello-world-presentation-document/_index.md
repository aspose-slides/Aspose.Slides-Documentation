---
title: 如何创建 Hello World 演示文档
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

新的 [Aspose.Slides for .NET API](/slides/net/) 已发布，现此单一产品支持从零开始生成 PowerPoint 文档并编辑现有文档的能力。

{{% /alert %}} 
## **对旧代码的支持**
为了使用在 Aspose.Slides for .NET 13.x 之前版本开发的旧代码，您需要对代码进行一些小更改，代码将如之前一样工作。所有来自于旧 Aspose.Slides for .NET 的 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间中的类现在已合并到单一的 Aspose.Slides 命名空间中。请查看以下简单代码片段，了解如何使用旧版 Aspose.Slides API 创建 Hello World 演示文档，并按照步骤说明如何迁移到新的合并 API。
## **旧版 Aspose.Slides for .NET 方法**
```c#
//实例化代表 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();

//创建 License 对象
License license = new License();

//设置 Aspose.Slides for .NET 的许可证以避免评估限制
license.SetLicense("Aspose.Slides.lic");

//向演示文稿中添加一个空白幻灯片并获取该空幻灯片的引用
Slide slide = pres.AddEmptySlide();

//向幻灯片添加一个矩形 (X=2400, Y=1800, Width=1000 & Height=500)
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隐藏矩形的边框线
rect.LineFormat.ShowLines = false;

//向矩形添加一个文本框，默认文本为“Hello World”
rect.AddTextFrame("Hello World");

//移除演示文稿的第一张幻灯片，此幻灯片是由
//Aspose.Slides for .NET 默认添加的
pres.Slides.RemoveAt(0);

//将演示文稿写入 PPT 文件
pres.Write("C:\\hello.ppt");
```



## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
// 实例化 Presentation
Presentation pres = new Presentation();

// 获取第一张幻灯片
ISlide sld = (ISlide)pres.Slides[0];

// 添加一个矩形类型的 AutoShape
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 向矩形添加 ITextFrame
ashp.AddTextFrame("Hello World");

// 将文本颜色更改为黑色（默认是白色）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 将矩形的线条颜色更改为白色
ashp.ShapeStyle.LineColor.Color = Color.White;

// 移除形状中的任何填充格式
ashp.FillFormat.FillType = FillType.NoFill;

// 将演示文稿保存到磁盘
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```