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
description: "从 Microsoft Office 自动化迁移到 Aspose.Slides for .NET，并使用 C# 编写干净、可靠的代码创建新的 PowerPoint（PPT、PPTX）演示文稿。"
---

{{% alert color="primary" %}} 

VSTO 的研发旨在让开发者构建能够在 Microsoft Office 中运行的应用程序。VSTO 基于 COM，但它被包装在 .NET 对象中，以便可以在 .NET 应用程序中使用。VSTO 需要 .NET 框架的支持以及基于 CLR 的 Microsoft Office 运行时。虽然它可以用于制作 Microsoft Office 加载项，但几乎不可能作为服务器端组件使用，并且部署问题严重。

Aspose.Slides for .NET 是一个可以操作 Microsoft PowerPoint 演示文稿的组件，功能类似于 VSTO，但具有以下优势：

- Aspose.Slides 仅包含托管代码，无需安装 Microsoft Office 运行时。
- 可用作客户端组件，也可用作服务器端组件。
- 部署简便，因为 Aspose.Slides 只在一个 DLL 中。

{{% /alert %}} 
## **创建演示文稿**
下面的两个代码示例演示了如何使用 VSTO 和 Aspose.Slides for .NET 实现相同的目标。第一个示例是[VSTO](/slides/zh/net/create-a-new-presentation/);[第二个示例](/slides/zh/net/create-a-new-presentation/) 使用 Aspose.Slides。
### **VSTO 示例**
**VSTO 输出** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//注意：PowerPoint 是一个已在上面这样定义的命名空间
//使用 PowerPoint = Microsoft.Office.Interop.PowerPoint;
```



### **Aspose.Slides for .NET 示例**
**Aspose.Slides 输出** 

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

//写入输出到磁盘
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
