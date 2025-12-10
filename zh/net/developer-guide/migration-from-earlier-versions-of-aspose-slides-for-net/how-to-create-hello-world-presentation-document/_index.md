---
title: 如何在 .NET 中创建 Hello World 演示文稿
linktitle: Hello World 演示文稿
type: docs
weight: 10
url: /zh/net/how-to-create-hello-world-presentation-document/
keywords:
- 迁移
- Hello World
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
- description: "使用 Aspose.Slides 在 .NET 中创建 Hello World PowerPoint PPT、PPTX 和 ODP 演示文稿，使用传统和现代 API，提供一份简明指南。"
---

{{% alert color="primary" %}} 

全新发布的 [Aspose.Slides for .NET API](/slides/zh/net/) 现在能够从零生成 PowerPoint 文档并编辑已有文档。

{{% /alert %}} 
## **对旧代码的支持**
要使用 Aspose.Slides for .NET 13.x 之前版本开发的旧代码，需要对代码进行少量修改，随后代码即可像以前一样工作。旧版 Aspose.Slides for .NET 中位于 Aspose.Slide 和 Aspose.Slides.Pptx 命名空间下的所有类现已合并到单一的 Aspose.Slides 命名空间。请查看下面的简单代码片段，了解如何在旧版 Aspose.Slides API 中创建 Hello World 演示文稿，并按照步骤将其迁移到新的合并 API。
## **旧版 Aspose.Slides for .NET 方法**
```c#
//实例化一个表示 PPT 文件的 Presentation 对象
Presentation pres = new Presentation();

//创建 License 对象
License license = new License();

//设置 Aspose.Slides for .NET 的许可证以避免评估限制
license.SetLicense("Aspose.Slides.lic");

//向演示文稿添加空幻灯片并获取其引用
//该空幻灯片
Slide slide = pres.AddEmptySlide();

//向幻灯片添加矩形（X=2400，Y=1800，宽度=1000，高度=500）到幻灯片
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//隐藏矩形的线条
rect.LineFormat.ShowLines = false;

//向矩形添加文本框，默认文本为 "Hello World"
rect.AddTextFrame("Hello World");

//移除演示文稿的第一张幻灯片，该幻灯片通常由
//Aspose.Slides for .NET 在创建演示文稿时默认添加
pres.Slides.RemoveAt(0);

//将演示文稿写入为 PPT 文件
pres.Write("C:\\hello.ppt");
```





## **新版 Aspose.Slides for .NET 13.x 方法**
```c#
// 实例化 Presentation
Presentation pres = new Presentation();

// 获取第一张幻灯片
ISlide sld = (ISlide)pres.Slides[0];

// 添加矩形类型的 AutoShape
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// 向矩形添加 ITextFrame
ashp.AddTextFrame("Hello World");

// 将文字颜色更改为黑色（默认情况下为白色）
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// 将矩形的线条颜色更改为白色
ashp.ShapeStyle.LineColor.Color = Color.White;

// 移除形状的所有填充格式
ashp.FillFormat.FillType = FillType.NoFill;

// 将演示文稿保存到磁盘
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
