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

本文说明如何使用 C# 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涵盖以下主题。

- 在 C# 中将 PPTX 转换为 PPT

## **C# 将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C# 示例代码，请参见下面的章节，即[转换 PPTX 为 PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [C# 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPTX 转换为 Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **转换 PPTX 为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)方法，即[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)类。下面的 C# 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。
```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");

// 将 PPTX 演示文稿保存为 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **常见问答**

**在将 PPTX 保存为传统 PPT（97–2003）格式时，所有效果和功能都会保留吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中某些功能可能会被简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若只转换特定幻灯片，需要先创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持逐幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开，并且还能为保存的 PPT[配置保护/加密设置](/slides/zh/net/password-protected-presentation/)。