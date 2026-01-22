---
title: 在 .NET 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/net/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
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

本文介绍如何使用 C# 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。涵盖以下内容。

- 在 C# 中将 PPTX 转换为 PPT

## **在 .NET 中将 PPTX 转换为 PPT**

如需 C# 示例代码将 PPTX 转换为 PPT，请参见下文[将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并保存为 PPT 格式。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见以下文章。

- [在 .NET 中将 PPTX 转换为 PDF](/slides/zh/net/convert-powerpoint-to-pdf/)
- [在 .NET 中将 PPTX 转换为 XPS](/slides/zh/net/convert-powerpoint-to-xps/)
- [在 .NET 中将 PPTX 转换为 HTML](/slides/zh/net/convert-powerpoint-to-html/)
- [在 .NET 中将 PPTX 转换为 ODP](/slides/zh/net/save-presentation/)
- [在 .NET 中将 PPTX 转换为 PNG](/slides/zh/net/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**

要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法的 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类。下面的 C# 代码示例使用默认选项将 Presentation 从 PPTX 转换为 PPT。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");

// 将 PPTX 演示文稿保存为 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **常见问题**

**将 PPTX 的所有效果和功能在保存为旧版 PPT（97–2003）格式时是否全部保留？**

并非总是保留。PPT 格式缺少某些新功能（如特定效果、对象和行为），因此在转换过程中可能会被简化或光栅化。

**我可以仅将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，请创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持逐幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

是的。您可以检测文件是否受保护，使用密码打开它，并且还可以为保存的 PPT[配置保护/加密设置](/slides/zh/net/password-protected-presentation/)。