---
title: 在 .NET 中将 PPTX 转换为 PPT
linktitle: PPTX 到 PPT
type: docs
weight: 21
url: /zh/net/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPTX
- PPTX 到 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，轻松将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

本文解释如何使用 C# 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。以下主题已覆盖。

- 使用 C# 将 PPTX 转换为 PPT

## **C# 将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C# 示例代码，请参阅下面的章节，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。它只需加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，您还可以将 PPTX 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，如这些文章所讨论的。

- [C# 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPTX 转换为 Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法，该方法属于[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类。下面的 C# 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。
```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");

// 将 PPTX 演示文稿保存为 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **常见问题**

**所有 PPTX 效果和功能在保存为传统 PPT（97–2003）格式时都会保留吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中可能会对这些功能进行简化或光栅化。

**我可以仅将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。要转换特定幻灯片，请创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

是的。您可以检测文件是否受保护，以密码打开，并且还可以[configure protection/encryption settings](/slides/zh/net/password-protected-presentation/) 为保存的 PPT 配置保护/加密设置。