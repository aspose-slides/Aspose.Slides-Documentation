---
title: 在 .NET 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/net/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPTX
- PPTX 转 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "轻松使用 Aspose.Slides for .NET 将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

本文说明如何使用 C# 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涵盖以下主题。

- 将 PPTX 转换为 PPT（C#）

## **在 .NET 中将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C# 示例代码，请参阅下面的章节，即[将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它只会加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，如这些文章中所讨论的。

- [C# 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPTX 转换为图像](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法的[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类。下面的 C# 代码示例使用默认选项将 Presentation 从 PPTX 转换为 PPT。
```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");

// 将 PPTX 演示文稿保存为 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **常见问题**

**所有 PPTX 的效果和特性在保存为传统的 PPT（97–2003）格式时都会保留吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中可能会简化或光栅化这些特性。

**我能只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，需要创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持每张幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

是的。您可以检测文件是否受保护，使用密码打开它，并且还可以[配置保护/加密设置](/slides/zh/net/password-protected-presentation/)以保存 PPT。