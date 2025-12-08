---
title: 在 C# 中将 PPT 转换为 PPTX
linktitle: 将 PPT 转换为 PPTX
type: docs
weight: 20
url: /zh/net/convert-ppt-to-pptx/
keywords: "C# 将 PPT 转换为 PPTX, 转换 PowerPoint 演示文稿, PPT 转 PPTX, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中将 PowerPoint PPT 转换为 PPTX"
---

## **概述**

本文说明如何使用 C# 和在线 PPT 到 PPTX 转换应用将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。以下主题已覆盖。

- [在 C# 中将 PPT 转换为 PPTX](#convert-ppt-to-pptx)

## **C# 将 PPT 转换为 PPTX**

有关 C# 示例代码将 PPT 转换为 PPTX，请参阅下面的章节，即 [Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，您还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等其他多种格式，正如这些文章中所讨论的。

- [C# 将 PPT 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# 将 PPT 转换为 XPS](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# 将 PPT 转换为 HTML](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# 将 PPT 转换为 ODP](https://docs.aspose.com/slides/net/save-presentation/)
- [C# 将 PPT 转换为 Image](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 转换**

使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最佳解决方案是以编程方式进行。使用 Aspose.Slides API 只需几行代码即可完成。该 API 支持完整兼容性，将 PPT 演示文稿转换为 PPTX，并且可以：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换在自动形状中使用纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}} 

查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用程序：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 **Aspose.Slides API** 构建，您可以看到基本 PPT 到 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个网页应用，允许您拖放 PPT 格式的演示文件并下载转换后的 PPTX。

查找其他实时的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) 示例。

{{% /alert %}} 

## **将 PPT 转换为 PPTX**

要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法的 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。下面的 C# 示例代码使用默认选项将演示文稿从 PPT 转换为 PPTX。

```c#
// 实例化一个表示 PPTX 文件的 Presentation 对象
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// 将 PPTX 演示文稿保存为 PPTX 格式
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```


了解更多关于 [**PPT vs PPTX**](/slides/zh/net/ppt-vs-pptx/) 演示文稿格式以及 [**Aspose.Slides supports PPT to PPTX conversion**](/slides/zh/net/convert-ppt-to-pptx/) 的信息。

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较旧的二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小以及改进的数据恢复能力。

**我可以使用 .NET 将 PPT 转换为 PPTX 吗？**

是的，使用 Aspose.Slides for .NET 库，您可以轻松加载 PPT 文件并仅用几行代码将其保存为 PPTX 格式。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 将多个 PPT 文件以编程方式转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 转换为 PPTX 的过程中都会被完整保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图像格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

是的，Aspose.Slides for .NET 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 到 PPTX 转换？**

是的，您可以使用免费的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用程序，在浏览器中直接完成转换，无需编写任何代码。