---
title: 在 Python 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/python-net/convert-ppt-to-pptx/
keywords:
- 转换 PPT
- PPT 转 PPTX
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中快速将旧版 PPT 演示文稿转换为现代 PPTX — 清晰的教程，免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文介绍如何使用 Python 将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式，以及使用在线 PPT 转 PPTX 转换应用程序。涵盖以下主题：

- 使用 Python 将 PPT 转换为 PPTX

## **Python 将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Python 示例代码，请参见下节，即[Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，您还可以将 PPT 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，详见以下文章：

- [Python Convert PPT to PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convert PPT to XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convert PPT to HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convert PPT to ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convert PPT to Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **关于 PPT 转 PPTX 转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最佳方案是通过编程实现。借助 Aspose.Slides API，只需几行代码即可完成。该 API 完全兼容 PPT 转 PPTX，并且可以：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换为自动形状提供纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本占位符的演示文稿。

{{% alert color="primary" %}}

了解一下[**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx)应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 **Aspose.Slides API** 构建，您可以看到基本 PPT 转 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个网页应用，允许您拖放 PPT 格式的演示文稿文件并下载已转换为 PPTX 的文件。

查找其他实时的[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)示例。
{{% /alert %}}

## **将 PPT 转换为 PPTX**
要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，使用 [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。下面的 Python 代码示例使用默认选项将演示文稿从 PPT 转换为 PPTX。
```python
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
pres = slides.Presentation("PPTtoPPTX.ppt")

# 将演示文稿保存为 PPTX 格式
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


阅读更多关于[**PPT vs PPTX**](/slides/zh/python-net/ppt-vs-pptx/)演示文稿格式以及[**Aspose.Slides 支持 PPT 转 PPTX 转换**](/slides/zh/python-net/convert-ppt-to-pptx/)的信息。

## 常见问题

### **PPT 和 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较早的二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小和更完善的数据恢复能力。

### **我可以使用 Python 将 PPT 转换为 PPTX 吗？**

是的，使用 Aspose.Slides for Python via .NET 库，您只需几行代码即可加载 PPT 文件并以 PPTX 格式保存。

### **进行 PPT 到 PPTX 转换是否必须使用 Aspose.Slides for Python via .NET？**

是的，Aspose.Slides API 提供了转换、操作和保存 PowerPoint 演示文稿所需的所有方法和类，无需依赖 Microsoft PowerPoint。

### **Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

是的，您可以在循环中使用 Aspose.Slides 编程批量转换多个 PPT 文件为 PPTX，适用于批量转换场景。

### **转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 转 PPTX 过程中都会被保留。

### **我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图片格式。

### **是否可以在没有安装 Microsoft PowerPoint 的情况下进行 PPT 到 PPTX 转换？**

可以，Aspose.Slides for Python via .NET 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可完成转换。

### **是否有在线工具可用于 PPT 到 PPTX 转换？**

是的，您可以使用免费的[Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx)网页应用，在浏览器中直接完成转换，无需编写任何代码。