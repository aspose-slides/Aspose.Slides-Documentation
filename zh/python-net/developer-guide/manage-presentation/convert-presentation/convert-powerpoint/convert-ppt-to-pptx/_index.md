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
description: "使用 Aspose.Slides 在 Python 中快速将传统 PPT 演示文稿转换为现代 PPTX — 清晰的教学、免费代码示例，无需 Microsoft Office 依赖。"
---

## **概述**

本文说明如何使用 Python 以及在线 PPT 到 PPTX 转换应用程序，将 PowerPoint 演示文稿的 PPT 格式转换为 PPTX 格式。涵盖以下主题：

- 使用 Python 将 PPT 转换为 PPTX

## **Python 将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Python 示例代码，请参见下面的章节，即 [Convert PPT to PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见以下文章：

- [Python 将 PPT 转换为 PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python 将 PPT 转换为 XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python 将 PPT 转换为 HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python 将 PPT 转换为 ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python 将 PPT 转换为图像](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将成千上万的 PPT 演示文稿转换为 PPTX 格式，最佳解决方案是以编程方式完成。借助 Aspose.Slides API，只需几行代码即可实现。该 API 完全兼容将 PPT 演示文稿转换为 PPTX，并且可以：

- 将复杂的母版、布局和幻灯片结构转换。
- 将包含图表的演示文稿转换。
- 将包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿转换。
- 将对自动形状使用纹理和图片填充样式的演示文稿转换。
- 将包含占位符、文本框和文本占位符的演示文稿转换。

{{% alert color="primary" %}}

查看 [**Aspose.Slides PPT 到 PPTX 转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用基于 **Aspose.Slides API** 构建，您可以看到基本 PPT 到 PPTX 转换功能的实时示例。Aspose.Slides Conversion 是一个 Web 应用，允许您拖放 PPT 格式的演示文件并下载转换后的 PPTX。

查找其他实时的 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}}

## **将 PPT 转换为 PPTX**
要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法的 [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。下面的 Python 代码示例使用默认选项将演示文稿从 PPT 转换为 PPTX。
```python
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
pres = slides.Presentation("PPTtoPPTX.ppt")

# 以 PPTX 格式保存演示文稿
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


了解更多关于 [**PPT 与 PPTX**](/slides/zh/python-net/ppt-vs-pptx/) 演示文稿格式以及 [**Aspose.Slides 支持 PPT 到 PPTX 转换**](/slides/zh/python-net/convert-ppt-to-pptx/) 的信息。

## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的旧二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件提供更好的性能、更小的文件大小以及改进的数据恢复能力。

**我可以使用 Python 将 PPT 转换为 PPTX 吗？**

是的，使用 Aspose.Slides for Python via .NET 库，您可以轻松加载 PPT 文件并仅用几行代码将其保存为 PPTX 格式。

**Aspose.Slides 支持批量将多个 PPT 文件转换为 PPTX 吗？**

是的，您可以在循环中使用 Aspose.Slides 将多个 PPT 文件以编程方式转换为 PPTX，适用于批量转换场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高保真度。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 到 PPTX 转换过程中都能得到保留。

**我可以将 PPT 文件转换为 PDF 或 HTML 等其他格式吗？**

是的，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等图像格式。

**可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

是的，Aspose.Slides for Python via .NET 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可执行转换。

**是否有在线工具可用于 PPT 到 PPTX 转换？**

是的，您可以使用免费的 [Aspose.Slides PPT 到 PPTX 转换器](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用，在浏览器中直接完成转换，无需编写任何代码。