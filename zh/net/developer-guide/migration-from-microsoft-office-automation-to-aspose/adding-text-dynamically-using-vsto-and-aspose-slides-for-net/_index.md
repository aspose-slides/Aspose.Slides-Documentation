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
description: "了解如何从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并在 C# 中向 PowerPoint（PPT、PPTX）演示文稿添加动态文本。"
---

{{% alert color="primary" %}} 
开发人员经常需要完成的一个常见任务是动态向幻灯片添加文本。本文展示了使用[VSTO](/slides/zh/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)和[Aspose.Slides for .NET](/slides/zh/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/)动态添加文本的代码示例。
{{% /alert %}} 
## **Adding Text Dynamically**
两种方法都遵循以下步骤：

1. 创建演示文稿。
1. 添加空白幻灯片。
1. 添加文本框。
1. 设置文本。
1. 写入演示文稿。
## **VSTO Code Example**
下面的代码片段会生成一个包含普通幻灯片和一段文字的演示文稿。

**The presentation as created in VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//注：PowerPoint 是在上面这样定义的命名空间
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```




## **Aspose.Slides for .NET Example**
下面的代码片段使用 Aspose.Slides 创建一个包含普通幻灯片和一段文字的演示文稿。

**The presentation as created using Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//创建演示文稿
Presentation pres = new Presentation();

//默认情况下会添加空白幻灯片，当您创建
//演示文稿时使用默认构造函数
//因此，我们无需再添加空白幻灯片
ISlide sld = pres.Slides[1];

//添加文本框
//要添加它，我们将先添加一个矩形
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//隐藏其边框
shp.LineFormat.Style = LineStyle.NotDefined;

//然后在其中添加文本框
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//设置文本
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//将输出写入磁盘
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
