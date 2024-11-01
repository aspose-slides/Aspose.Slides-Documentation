---
title: 在 C# 中将 PPTX 转换为 PPT
linktitle: 将 PPTX 转换为 PPT
type: docs
weight: 21
url: /zh/net/convert-pptx-to-ppt/
keywords: "C# 将 PPTX 转换为 PPT, 转换 PowerPoint 演示文稿, PPTX 转 PPT, C#, Aspose.Slides"
description: "在 C# 中将 PowerPoint PPTX 转换为 PPT"
---

## **概述**

本文解释了如何使用 C# 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涉及以下主题。

- 在 C# 中将 PPTX 转换为 PPT

## **C# 将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C# 示例代码，请参见下面的章节，即 [将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它只是加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，您还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种其他格式，如这些文章中所述。

- [C# 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPTX 转换为图像](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法的 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类。下面的 C# 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。

```c#
// 实例化表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");

// 将 PPTX 演示文稿保存为 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```