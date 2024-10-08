---
title: 在C#中将PPT转换为PPTX
linktitle: 将PPT转换为PPTX
type: docs
weight: 20
url: /net/convert-ppt-to-pptx/
keywords: "C# 将PPT转换为PPTX, 转换PowerPoint演示文稿, PPT到PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "在C#或.NET中将PowerPoint PPT转换为PPTX"
---

## **概述**

本文解释了如何使用C#将PPT格式的PowerPoint演示文稿转换为PPTX格式，以及使用在线PPT到PPTX转换应用程序。涵盖以下主题。

- [在C#中将PPT转换为PPTX](#convert-ppt-to-pptx)

## **C# 将PPT转换为PPTX**

有关将PPT转换为PPTX的C#示例代码，请参见下面的部分，即[在C#中将PPT转换为PPTX](#convert-ppt-to-pptx)。它只需加载PPT文件并以PPTX格式保存。通过指定不同的保存格式，您还可以将PPT文件另存为许多其他格式，如PDF、XPS、ODP、HTML等，如以下文章中所讨论的。

- [C# 将PPT转换为PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将PPT转换为XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将PPT转换为HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将PPT转换为ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将PPT转换为图像](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **关于PPT到PPTX转换**
使用Aspose.Slides API将旧PPT格式转换为PPTX。如果您需要将成千上万的PPT演示文稿转换为PPTX格式，最佳解决方案是以编程方式完成。使用Aspose.Slides API，您可以仅用几行代码实现。该API支持完全兼容，将PPT演示文稿转换为PPTX，并且可以：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、具有自定义几何形状的形状的演示文稿。
- 转换具有纹理和图片填充样式的自动形状的演示文稿。
- 转换具有占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

查看[**Aspose.Slides PPT到PPTX转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx)应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

该应用基于**Aspose.Slides API**构建，因此您可以查看基本PPT到PPTX转换功能的实时示例。Aspose.Slides转换是一个Web应用，允许您将PPT格式的演示文稿文件放入并下载其转换后的PPTX文件。

查找其他实时的[**Aspose.Slides转换**](https://products.aspose.app/slides/conversion/)示例。
{{% /alert %}} 


## **将PPT转换为PPTX**
要将PPT转换为PPTX，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)方法。下面的C#代码示例使用默认选项将演示文稿从PPT转换为PPTX。

```c#
// 实例化一个表示PPTX文件的Presentation对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// 将PPTX演示文稿保存为PPTX格式
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

了解更多关于[**PPT与PPTX**](/slides/net/ppt-vs-pptx/)演示文稿格式以及[**Aspose.Slides支持PPT到PPTX转换**](/slides/net/convert-ppt-to-pptx/)。