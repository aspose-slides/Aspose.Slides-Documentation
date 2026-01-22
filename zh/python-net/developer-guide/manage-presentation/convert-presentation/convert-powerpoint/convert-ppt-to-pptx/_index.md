---
title: 在Python中将PPT转换为PPTX
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

本文说明如何使用 Python 将 PPT 格式的 PowerPoint 演示文稿转换为 PPTX 格式，以及使用在线 PPT 转 PPTX 转换应用程序进行转换。涉及的主题如下：

- 在 Python 中将 PPT 转换为 PPTX

## **Python 将 PPT 转换为 PPTX**

有关在 Python 中将 PPT 转换为 PPTX 的示例代码，请参阅下面的章节，即[转换 PPT 为 PPTX](#convert-ppt-to-pptx)。它仅加载 PPT 文件并以 PPTX 格式保存。通过指定不同的保存格式，还可以将 PPT 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，详见以下文章：

- [在 Python 中将 PPT 转换为 PDF](/slides/zh/python-net/convert-powerpoint-to-pdf/)
- [在 Python 中将 PPT 转换为 XPS](/slides/zh/python-net/convert-powerpoint-to-xps/)
- [在 Python 中将 PPT 转换为 HTML](/slides/zh/python-net/convert-powerpoint-to-html/)
- [在 Python 中将 PPT 转换为 ODP](/slides/zh/python-net/save-presentation/)
- [在 Python 中将 PPT 转换为 PNG](/slides/zh/python-net/convert-powerpoint-to-png/)

## **关于 PPT 转 PPTX 转换**
使用 Aspose.Slides API 将旧的 PPT 格式转换为 PPTX。如果需要将数千个 PPT 演示文稿批量转换为 PPTX，最好的解决方案是编程实现。借助 Aspose.Slides API，只需几行代码即可完成转换。该 API 完全兼容 PPT 转 PPTX，并且能够：

- 转换包含复杂母版、布局和幻灯片结构的演示文稿。
- 转换包含图表的演示文稿。
- 转换包含组合形状、自动形状（如矩形和椭圆）以及自定义几何形状的演示文稿。
- 转换对自动形状使用纹理和图片填充样式的演示文稿。
- 转换包含占位符、文本框和文本持有者的演示文稿。

{{% alert color="primary" %}}
看看 **Aspose.Slides PPT 转 PPTX 转换** 应用：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

该应用基于 **Aspose.Slides API** 构建，您可以实时体验基本的 PPT 转 PPTX 转换功能。Aspose.Slides 转换是一个 Web 应用，允许您拖拽 PPT 格式的演示文稿文件并下载转换后的 PPTX。

查找其他实时 **Aspose.Slides 转换** 示例。
{{% /alert %}}

## **将 PPT 转换为 PPTX**
要将 PPT 转换为 PPTX，只需将文件名和保存格式传递给 **Presentation** 类的 **Save** 方法。下面的 Python 示例代码使用默认选项将演示文稿从 PPT 转换为 PPTX。
```python
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
pres = slides.Presentation("PPTtoPPTX.ppt")

# 将演示文稿保存为 PPTX 格式
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


了解更多关于 **PPT 与 PPTX** 演示文稿格式的信息以及 **Aspose.Slides 如何支持 PPT 转 PPTX 转换**。
## **常见问题**

**PPT 与 PPTX 格式有什么区别？**

PPT 是 Microsoft PowerPoint 使用的较旧的二进制文件格式，而 PPTX 是随 Microsoft Office 2007 引入的基于 XML 的新格式。PPTX 文件性能更佳、文件体积更小且数据恢复能力更强。

**可以使用 Python 将 PPT 转换为 PPTX 吗？**

可以，使用 Aspose.Slides for Python via .NET 库，只需几行代码即可加载 PPT 文件并保存为 PPTX 格式。

**Aspose.Slides 是否支持批量将多个 PPT 文件转换为 PPTX？**

可以，在循环中使用 Aspose.Slides 编程批量转换多个 PPT 文件为 PPTX，适用于批处理场景。

**转换后内容和格式会被保留吗？**

Aspose.Slides 在转换演示文稿时保持高度保真。幻灯片布局、动画、形状、图表以及其他设计元素在 PPT 转 PPTX 过程中均会被保留。

**可以将 PPT 文件转换为 PDF、HTML 等其他格式吗？**

可以，Aspose.Slides 支持将 PPT 文件转换为多种格式，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等图片格式。

**是否可以在未安装 Microsoft PowerPoint 的情况下进行 PPT 转 PPTX 转换？**

可以，Aspose.Slides for Python via .NET 是独立的 API，无需 Microsoft PowerPoint 或任何第三方软件即可完成转换。

**是否有在线工具可以进行 PPT 转 PPTX 转换？**

可以，使用免费的 [Aspose.Slides PPT 转 PPTX 转换器](https://products.aspose.app/slides/conversion/ppt-to-pptx) Web 应用即可直接在浏览器中完成转换，无需编写任何代码。