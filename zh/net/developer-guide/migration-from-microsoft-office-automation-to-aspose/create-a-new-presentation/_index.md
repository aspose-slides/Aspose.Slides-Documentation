---
title: 使用 VSTO 和 Aspose.Slides for .NET 创建新演示文稿
linktitle: 创建新演示文稿
type: docs
weight: 10
url: /zh/net/create-a-new-presentation/
keywords:
- 创建演示文稿
- 新演示文稿
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并使用 C# 编写干净、可靠的代码来创建新的 PowerPoint (PPT, PPTX) 演示文稿。"
---

{{% alert color="primary" %}} 

VSTO 是为让开发人员构建可以在 Microsoft Office 中运行的应用程序而开发的。VSTO 基于 COM，但它被包装在 .NET 对象中，以便可以在 .NET 应用程序中使用。VSTO 需要 .NET 框架的支持以及 Microsoft Office 基于 CLR 的运行时。虽然它可以用于创建 Microsoft Office 加载项，但几乎不可能用作服务器端组件。它还存在严重的部署问题。

Aspose.Slides for .NET 是一个可用于操作 Microsoft PowerPoint 演示文稿的组件，就像 VSTO 一样，但它有几个优势：

- Aspose.Slides 仅包含托管代码，且不需要安装 Microsoft Office 运行时。
- 它可以用作客户端组件或服务器端组件。
- 部署很简单，因为 Aspose.Slides 包含在单个 DLL 中。

{{% /alert %}} 
## **创建演示文稿**
下面有两个代码示例，演示如何使用 VSTO 和 Aspose.Slides for .NET 实现相同的目标。第一个示例是[VSTO](/slides/zh/net/create-a-new-presentation/)，[第二个示例](/slides/zh/net/create-a-new-presentation/) 使用 Aspose.Slides。
### **VSTO 示例**
**VSTO 输出** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//注意：PowerPoint 是一个已经在上面这样定义的命名空间
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//创建演示文稿
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET 示例**
**Aspose.Slides 的输出** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//创建演示文稿
Presentation pres = new Presentation();

//添加标题幻灯片
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//设置标题文本
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//设置副标题文本
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//将输出写入磁盘
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
