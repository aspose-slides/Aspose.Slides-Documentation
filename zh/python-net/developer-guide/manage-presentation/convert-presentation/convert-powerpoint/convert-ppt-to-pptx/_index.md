---
title: 在 Python 中将 PPT 转换为 PPTX
linktitle: 将 PPT 转换为 PPTX
type: docs
weight: 20
url: /python-net/convert-ppt-to-pptx/
keywords: "Python 将 PPT 转换为 PPTX, 转换 PowerPoint 演示文稿, PPT 转 PPTX, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint PPT 转换为 PPTX"
---

## **概述**

本文解释了如何使用 Python 和在线 PPT 到 PPTX 转换应用程序将 PPT 格式的 PowerPoint 演示文稿转换为 PPTX 格式。以下主题已涵盖。

- 在 Python 中将 PPT 转换为 PPTX

## **Python 将 PPT 转换为 PPTX**

有关将 PPT 转换为 PPTX 的 Python 示例代码，请查看下面的部分，即 [将 PPT 转换为 PPTX](#convert-ppt-to-pptx)。它只是加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，您还可以将 PPT 文件保存为 PDF、XPS、ODP、HTML 等多种其他格式，如这些文章中所讨论的。 

- [Python 将 PPT 转换为 PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python 将 PPT 转换为 XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python 将 PPT 转换为 HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python 将 PPT 转换为 ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python 将 PPT 转换为图像](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **关于 PPT 到 PPTX 转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果您需要将数千个 PPT 演示文稿转换为 PPTX 格式，最佳解决方案是以编程方式完成。使用 Aspose.Slides API，只需几行代码即可实现。该 API 完全支持 PPT 演示文稿转换为 PPTX，并且可以做到：

- 转换复杂的母版、布局和幻灯片结构。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）、具有自定义几何形状的形状的演示文稿。
- 转换具有纹理和图像填充样式的自动形状的演示文稿。
- 转换具有占位符、文本框和文本持有器的演示文稿。

{{% alert color="primary" %}} 

查看 [**Aspose.Slides PPT 到 PPTX 转换**](https://products.aspose.app/slides/conversion/ppt-to-pptx) 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

此应用程序基于 **Aspose.Slides API** 构建，因此您可以看到基本 PPT 到 PPTX 转换功能的实时示例。Aspose.Slides 转换是一个网络应用程序，允许您将 PPT 格式的演示文稿文件拖放并下载转换为 PPTX。

查找其他实时 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 示例。
{{% /alert %}} 


## **将 PPT 转换为 PPTX**
要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法的 [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。下面的 Python 代码示例使用默认选项将演示文稿从 PPT 转换为 PPTX。

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 对象
pres = slides.Presentation("PPTtoPPTX.ppt")

# 将 PPTX 演示文稿保存为 PPTX 格式
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```



阅读更多关于 [**PPT 与 PPTX**](/slides/python-net/ppt-vs-pptx/) 演示文稿格式的信息，以及 [**Aspose.Slides 如何支持 PPT 到 PPTX 转换**](/slides/python-net/convert-ppt-to-pptx/) 的信息。