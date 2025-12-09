---
title: 使用 VSTO 和 Aspose.Slides for .NET 动态添加文本
linktitle: 动态添加文本
type: docs
weight: 20
url: /zh/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- 添加文本
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何将 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并在 C# 中向 PowerPoint (PPT、PPTX) 演示文稿添加动态文本。"
---

{{% alert color="primary" %}} 

开发人员常见的任务之一是动态向幻灯片添加文本。本文展示了使用[VSTO](/slides/zh/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)和[Aspose.Slides for .NET](/slides/zh/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)动态添加文本的代码示例。

{{% /alert %}} 
## **动态添加文本**
两种方法遵循以下步骤：

1. 创建演示文稿。
1. 添加空白幻灯片。
1. 添加文本框。
1. 设置文本。
1. 写入演示文稿。
## **VSTO 代码示例**
下面的代码片段会生成一个包含普通幻灯片和一段文本的演示文稿。

**在 VSTO 中创建的演示文稿** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//注意：PowerPoint 是一个已在上面这样定义的命名空间
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//获取空白幻灯片布局
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//添加空白幻灯片
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//添加文本
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//设置文本
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//将输出写入磁盘
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```




## **Aspose.Slides for .NET 示例**
下面的代码片段使用 Aspose.Slides 创建一个包含普通幻灯片和一段文本的演示文稿。

**使用 Aspose.Slides for .NET 创建的演示文稿** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//创建演示文稿
Presentation pres = new Presentation();

//默认情况下会添加空白幻灯片，当您创建
//演示文稿时使用默认构造函数
//因此，我们不需要再添加空白幻灯片
ISlide sld = pres.Slides[1];

//添加文本框
//要添加它，我们首先添加一个矩形
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//隐藏其线条
shp.LineFormat.Style = LineStyle.NotDefined;

//然后在内部添加文本框
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//设置文本
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//将输出写入磁盘
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
