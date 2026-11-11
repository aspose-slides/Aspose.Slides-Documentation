---
title: 在 Python 中将演示文稿转换为带备注的 PDF
linktitle: 演示文稿转 PDF 带备注
type: docs
weight: 50
url: /zh/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- 转换 PPT
- 转换 PPTX
- 转换 ODP
- PowerPoint 转 PDF
- OpenDocument 转 PDF
- 演示文稿转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- ODP 转 PDF
- 演讲者备注
- 带备注的 PDF
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 将 PPT、PPTX 和 ODP 格式转换为带备注的 PDF。保留布局和演讲者备注，以实现专业演示文稿。"
---
## **概述**

在本文中，您将学习如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为包含演讲者备注的 PDF 格式。本指南将介绍必要的步骤，并提供代码示例，帮助您高效完成此任务。阅读本文后，您将能够：

- 实现转换过程，将 PowerPoint 幻灯片转换为 PDF 文档，同时保留演讲者备注。
- 自定义输出的 PDF，以确保演讲者备注被包含并按照您的需求进行格式化。

如需在导出前设置备注页的尺寸和方向，请参阅 [Notes Page Size](/slides/zh/python-net/notes-size/)。

## **将 PowerPoint 转换为带备注的 PDF**

`save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类中使用，以将 PPT 或 PPTX 演示文稿转换为带演讲者备注的 PDF。使用 Aspose.Slides，您只需加载演示文稿，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/) 类配置布局选项以包含演讲者备注，然后将文件保存为 PDF。下面的代码片段演示了如何在备注幻灯片视图中将示例演示文稿转换为 PDF。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # 配置用于呈现演讲者备注的 PDF 选项。
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # 将演示文稿保存为带演讲者备注的 PDF。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
您可能想查看 Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/zh/conversion)。
{{% /alert %}}