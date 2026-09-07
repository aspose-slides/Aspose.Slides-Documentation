---
title: 在 Python 中将 PowerPoint 演示文稿转换为 XPS
linktitle: PowerPoint 转 XPS
type: docs
weight: 70
url: /zh/python-java/convert-powerpoint-to-xps/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 XPS
- 演示文稿转 XPS
- PPT 转 XPS
- PPTX 转 XPS
- 将 PPT 保存为 XPS
- 将 PPTX 保存为 XPS
- 导出 PPT 为 XPS
- 导出 PPTX 为 XPS
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中将 PowerPoint PPT 和 PPTX 演示文稿转换为 XPS，支持默认或自定义导出设置。"
---
## **概述**

Aspose.Slides for Python via Java 允许您通过将 PPT 或 PPTX 文件另存为 XPS 格式来将 PowerPoint 演示文稿转换为 XPS。本文说明了 XPS 可能有用的情形，并展示如何使用默认设置或自定义 [XpsOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xpsoptions/) 设置导出演示文稿。

## **关于 XPS**

XPS（XML Paper Specification）是 Microsoft 开发的基于 XML 的文档格式。它描述固定页面，保留文本和图形的布局，以便使用兼容的软件进行查看和打印。

## **何时使用 Microsoft XPS 格式**

当文档工作流需要固定布局文件以通过 XPS 兼容工具进行共享或打印时，请使用 XPS。接收方需要支持 XPS 的软件。如果您的工作流需要 PDF，请参见[将 PowerPoint 转换为 PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)。

{{% alert color="info" title="Note" %}}

要尝试将 PPT 或 PPTX 演示文稿转换为 XPS，请使用[免费在线转换器](https://products.aspose.app/slides/zh/conversion)。

{{% /alert %}}

| 输入 PowerPoint 演示文稿 | 输出 XPS 文档 |
| --- | --- |
| ![原始 PowerPoint 演示文稿](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![已转换为 XPS 的演示文稿](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **使用 Aspose.Slides 进行 XPS 转换**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法并指定 [SaveFormat.Xps](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Xps) 将演示文稿导出为 XPS。您可以使用默认导出设置，或提供 [XpsOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xpsoptions/) 来自定义输出。

下面的每个示例在需要时启动 Java 虚拟机，并在使用后释放演示文稿。将输入文件名替换为您的 PPT 或 PPTX 文件的路径。

### **使用默认设置将演示文稿转换为 XPS**

以下 Python 代码使用默认设置将演示文稿转换为 XPS：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 将演示文稿保存为 XPS 文档。
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **使用自定义设置将演示文稿转换为 XPS**

以下示例使用 [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) 将矢量图元保存为 PNG 图像，以便在生成的 XPS 文档中使用：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # 使用自定义 XPS 设置保存演示文稿。
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以将 XPS 保存到流而不是文件吗？**

是的。[Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法有接受 Java 输出流的重载。使用 Python via Java 时，可通过 JPype 使用兼容的 Java 流，例如 Java 字节数组输出流，将导出的数据保存在内存中。

**隐藏的幻灯片会包含在 XPS 输出中吗？**

默认情况下会排除隐藏的幻灯片。若要包含它们，请在保存前将 [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) 设置为 `True`。

**XPS 会保留动画和幻灯片切换效果吗？**

不会。XPS 包含固定页面，因此导出的幻灯片不会播放动画或过渡效果。