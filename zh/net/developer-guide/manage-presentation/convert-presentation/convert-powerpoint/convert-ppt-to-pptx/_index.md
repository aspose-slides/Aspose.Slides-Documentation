---
title: 在 .NET 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/net/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中快速将传统 PPT 演示文稿转换为现代 PPTX — 清晰的教程，免费 C# 代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文说明如何使用 C# 和在线 PPT 转 PPTX 转换应用将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涵盖以下主题。

- [在 C# 中将 PPT 转换为 PPTX](#convert-ppt-to-pptx)

## **C# 将 PPT 转换为 PPTX**

有关 C# 将 PPT 转换为 PPTX 的示例代码，请参阅下面的章节，即 [Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [C# 将 PPT 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPT 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPT 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPT 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPT 转换为图像](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 转换**

使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将数千个 PPT 演示文稿转换为 PPTX 格式，最佳方案是以编程方式完成。借助 Aspose.Slides API，只需几行代码即可实现。该 API 完全兼容 PPT 转 PPTX，并可以：

- 转换 master、布局和幻灯片的复杂结构。
- 转换包含图表的演示文稿。
- 转换包含组形状、自动形状（如矩形和椭圆）和自定义几何形状的演示文稿。
- 转换对自动形状使用纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文字占位符的演示文稿。

{{% alert color="primary" %}} 

请查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用程序：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 **Aspose.Slides API** 构建，可实时查看基本 PPT 到 PPTX 转换功能的示例。Aspose.Slides Conversion 是一个 Web 应用，可将 PPT 格式的演示文件拖放进去并下载转换后的 PPTX。

查找其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 

## **将 PPT 转换为 PPTX**
要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法，针对 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。下面的 C# 代码示例使用默认选项将演示文稿从 PPT 转换为 PPTX。
```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// 将 PPTX 演示文稿保存为 PPTX 格式
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


进一步了解 [**PPT 与 PPTX**](/slides/zh/net/ppt-vs-pptx/) 演示文稿格式，以及 [**Aspose.Slides 支持 PPT 到 PPTX 转换**](/slides/zh/net/convert-ppt-to-pptx/)。

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较旧的二进制文件格式，而 PPTX 是随 Microsoft Office 2007 推出的基于 XML 的新格式。PPTX 文件提供更好的性能、较小的文件大小和改进的数据恢复能力。

**我可以使用 .NET 将 PPT 转换为 PPTX 吗？**

可以，使用 Aspose.Slides for .NET 库，只需几行代码即可加载 PPT 文件并以 PPTX 格式保存。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

可以，在循环中使用 Aspose.Slides 可编程地批量将多个 PPT 文件转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片布局、动画、形状、图表和其他设计元素在 PPT 到 PPTX 转换过程中都会被保留下来。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

可以，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图像格式。

**在未安装 Microsoft PowerPoint 的情况下可以将 PPT 转换为 PPTX 吗？**

可以，Aspose.Slides for .NET 是一个独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 到 PPTX 转换？**

可以使用免费的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用直接在浏览器中完成转换，无需编写任何代码。