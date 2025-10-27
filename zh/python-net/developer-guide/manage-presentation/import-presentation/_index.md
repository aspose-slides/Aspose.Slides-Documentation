---
title: 使用 Python 导入演示文稿
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/python-net/import-presentation/
keywords:
- import PowerPoint
- import presentation
- import slide
- PDF to presentation
- PDF to PPT
- PDF to PPTX
- PDF to ODP
- HTML to presentation
- HTML to PPT
- HTML to PPTX
- HTML to ODP
- Python
- Aspose.Slides
description: "轻松在 Python 中使用 Aspose.Slides 将 PDF 和 HTML 文档导入 PowerPoint 和 OpenDocument 演示文稿，实现无缝、高性能的幻灯片处理。"
---

## **概述**

使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，您可以从其他文件格式导入内容到演示文稿中。[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) 类提供了将幻灯片从 PDF、HTML 等来源导入的方法。

## **将 PDF 转换为演示文稿**

本节展示如何使用 Aspose.Slides 将 PDF 转换为演示文稿。它将引导您导入 PDF、将其页面转换为幻灯片，并将结果保存为 PPTX 文件。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 调用 [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) 方法并传入 PDF 文件。  
3. 使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PowerPoint 格式。

下面的 Python 示例演示了将 PDF 转换为演示文稿的过程：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="提示" color="primary" %}}
您可能想尝试 Aspose 免费的 [PDF 转 PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 在线应用程序——它是本文所述过程的实时实现。
{{% /alert %}}

## **将 HTML 转换为演示文稿**

本节展示如何使用 Aspose.Slides 将 HTML 内容导入演示文稿。它涵盖了加载 HTML、将其转换为保留文本、图像和基本格式的幻灯片，以及将结果保存为 PPTX 文件。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 调用 [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) 方法并传入 HTML 文件。  
3. 使用 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 方法将演示文稿保存为 PowerPoint 格式。

下面的 Python 示例演示了将 HTML 转换为演示文稿的过程：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**在导入 PDF 时表格是否会被保留，且能否改进其检测？**

在导入过程中可以检测到表格；[PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) 包含 `detect_tables` 参数，可启用表格识别。其效果取决于 PDF 的结构。

{{% alert title="注意" color="info" %}}
您还可以使用 Aspose.Slides 将 HTML 转换为其他流行的文件格式：

* [HTML 转 图片](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}