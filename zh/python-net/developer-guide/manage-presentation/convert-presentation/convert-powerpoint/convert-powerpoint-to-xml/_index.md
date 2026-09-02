---
title: 在 Python 中将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/python-net/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat.XML
- 将演示文稿保存为 XML
- 将演示文稿导出为 XML
- XML 流
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for Python via .NET 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。XML 输出在需要基于文本的表示以检查演示结构、排除生成文档的故障、在自动化测试中比较输出或与使用 XML 而不是演示包的工作流集成时非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 方法，并传入来自 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 枚举的 `XML` 值。您可以将结果直接写入文件或流。

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` 创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包内部存储的单个 Office Open XML 部分。如果您需要确切的 PPTX 包部件，例如 `ppt/presentation.xml` 或单个幻灯片 XML 文件，请检查 PPTX 包本身。
{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 `SaveFormat.XML` 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/)。源可以是任何受支持加载的演示文稿格式，如 PPT、PPTX 或 ODP。

下面的示例将 PPTX 演示文稿转换为 XML 文件：

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **将 XML 输出写入流**

在 XML 必须保留在内存中或传递给其他组件（例如 Web 服务、存储提供程序或 XML 处理管道）时，使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 的流重载。下面的示例将结果写入 [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) 流并将其倒回以便后续读取：

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # 将 xml_stream 传递给工作流中的下一个组件。
```

## **将 XML 与演示文稿和导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 典型用法 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排除故障、比较生成的输出以及基于 XML 的集成 |
| PPT (`.ppt`) | 传统的二进制演示文稿文件 | 与旧版 PowerPoint 工作流的兼容性 |
| PPTX (`.pptx`) | 包含多个部件的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF 或 TIFF | 固定布局页面或多页图像 | 查看、打印和存档 |
| PNG、JPEG 或 SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资产 |
| HTML 或 HTML5 | 面向 Web 的演示输出 | 浏览器查看和网页发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和面向数据的工作流。与 PDF、TIFF、HTML 以及幻灯片图像格式不同，它表示演示文稿数据，而不是将幻灯片渲染为页面或视觉资产。[supported file formats](/slides/zh/python-net/supported-file-formats/) 表格将 PowerPoint XML 演示文稿列为仅保存格式，因此在工作流必须将导出的文件重新加载回 Aspose.Slides 进行继续编辑时，请勿使用它。

## **常见问题**

**`SaveFormat.XML` 与保存 PPTX 文件相同吗？**

不。PPTX 是一个包含多个 Office Open XML 部件的包，而 `SaveFormat.XML` 创建的是 PowerPoint XML 演示文稿文件。

**可以在不在磁盘上创建文件的情况下保存 XML 输出吗？**

是的。将可写流传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/)。例如，使用 [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) 流进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**

不。PowerPoint XML 演示文稿目前仅支持保存，不支持加载。当需要往返编辑时，请使用 PPTX 或其他受支持的演示文稿格式。

**XML 转换会将每个幻灯片渲染为页面或图像吗？**

不。XML 转换写入结构化的演示文稿数据。若需要面向页面的输出，请使用 PDF 或 TIFF，若需要单个幻灯片图像，请使用 PNG、JPEG 和 SVG。