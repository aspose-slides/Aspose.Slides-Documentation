---
title: 在 Python via Java 中将 PowerPoint 演示文稿转换为 XML
linktitle: PowerPoint 转 XML
type: docs
weight: 145
url: /zh/python-java/convert-powerpoint-to-xml/
keywords:
- 将 PowerPoint 转换为 XML
- 将演示文稿转换为 XML
- PPT 转 XML
- PPTX 转 XML
- ODP 转 XML
- PowerPoint XML 演示文稿
- SaveFormat.Xml
- 将演示文稿保存为 XML
- 将演示文稿导出为 XML
- XML 流
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python via Java 中将 PowerPoint 和 OpenDocument 演示文稿转换为 PowerPoint XML 文件或流。"
---
## **概述**

Aspose.Slides for Python via Java 可以将 PowerPoint 演示文稿转换为 PowerPoint XML 演示文稿格式。XML 输出在需要文本化表示以检查演示结构、排除生成文档的故障、在自动化测试中比较输出，或与消耗 XML 而非演示包的工作流集成时非常有用。

使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法并传入来自 [SaveFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/) 类的 [Xml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Xml) 值。您可以将结果直接写入文件或写入流。

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Xml) 会创建 PowerPoint XML 演示文稿。它不会提取 PPTX 包中存储的各个 Office Open XML 部分。如果您需要确切的 PPTX 包部件，例如 `ppt/presentation.xml` 或单独的幻灯片 XML 文件，请检查 PPTX 包本身。

{{% /alert %}}

## **将演示文稿转换为 XML 文件**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载源演示文稿，然后将输出路径和 [SaveFormat.Xml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Xml) 传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)。源可以是任何受支持的加载格式，如 PPT、PPTX 或 ODP。

以下示例将 PPTX 演示文稿转换为 XML 文件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **将 XML 输出写入流**

当 XML 必须保留在内存中或传递给其他组件（例如 Web 服务、存储提供程序或 XML 处理管道）时，使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 的流重载。以下示例将结果写入 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 并将生成的 XML 获取为 Python bytes 对象：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # 将 xml_data 传递给工作流中的下一个组件。
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **将 XML 与演示文稿和导出格式进行比较**

根据结果的使用方式选择输出格式：

| 格式 | 输出 | 典型使用场景 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 演示文稿 | 检查结构、排除故障、比较生成的输出以及基于 XML 的集成 |
| PPT (`.ppt`) | 传统二进制演示文稿文件 | 与旧版 PowerPoint 工作流的兼容性 |
| PPTX (`.pptx`) | 包含多个部件的 Office Open XML 包 | 常规 PowerPoint 编辑和演示文稿交换 |
| PDF 或 TIFF | 固定布局页面或多页图像 | 查看、打印和归档 |
| PNG、JPEG 或 SVG | 单个幻灯片的渲染表示 | 缩略图、预览和图像资源 |
| HTML 或 HTML5 | 面向 Web 的演示输出 | 浏览器查看和网页发布 |

与 PPT 和 PPTX 不同，XML 输出主要用于检查和数据导向的工作流。与 PDF、TIFF、HTML 以及幻灯片图像格式不同，XML 表示的是演示文稿数据，而不是将幻灯片渲染为页面或视觉资产。[supported file formats](/slides/zh/python-java/supported-file-formats/) 表中将 PowerPoint XML 演示文稿列为仅保存格式，因此在工作流需要将导出文件重新加载回 Aspose.Slides 进行继续编辑时，请不要使用它。

## **常见问题解答**

**XML 导出与保存 PPTX 文件是否相同？**

不是。PPTX 是包含多个 Office Open XML 部件的包，而 [SaveFormat.Xml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Xml) 会创建 PowerPoint XML 演示文稿文件。

**我可以在不创建磁盘文件的情况下保存 XML 输出吗？**

可以。将可写的 Java 输出流传递给 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)。例如，使用 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 进行内存处理。

**Aspose.Slides 能再次加载导出的 XML 文件吗？**

不能。PowerPoint XML 演示文稿目前仅支持保存，不支持加载。需要往返编辑时，请使用 PPTX 或其他受支持的演示文稿格式。

**XML 转换会将每个幻灯片渲染为页面或图像吗？**

不会。XML 转换写入的是结构化的演示文稿数据。若需要页面导向的输出，请使用 PDF 或 TIFF；若需要单个幻灯片图像，请使用 PNG、JPEG 或 SVG。