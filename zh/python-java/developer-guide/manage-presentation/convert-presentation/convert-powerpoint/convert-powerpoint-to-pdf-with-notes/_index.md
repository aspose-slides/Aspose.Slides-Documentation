---
title: 在 Python 中将 PowerPoint 演示文稿转换为带备注的 PDF
linktitle: PowerPoint 转 PDF 带备注
type: docs
weight: 50
url: /zh/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PDF
- 演示文稿 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将演示文稿 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- 演讲者备注
- 带备注的 PDF
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PPT 和 PPTX 演示文稿转换为带有演讲者备注的 PDF。配置备注位置并保留长备注。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for Python via Java 将 PowerPoint 演示文稿转换为带有演讲者备注的 PDF。您可以在每张幻灯片下方包含备注，并允许较长的备注延伸到附加页面。有关其他 PDF 导出设置，请参阅 [Convert PowerPoint to PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)。

## **将 PowerPoint 转换为带备注的 PDF**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的 [save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 方法将 PPT 或 PPTX 演示文稿导出为 PDF。要包含演讲者备注，创建一个 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 对象，并使用其 [setNotesPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) 方法配置备注位置。使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 将此布局分配给 [PdfOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/pdfoptions/)。

下面的示例加载 `sample.pptx` 并将其导出为带有幻灯片下方演讲者备注的 `output.pdf`：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # 配置用于呈现场演讲者备注的 PDF 选项。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # 将演示文稿保存为带有演讲者备注的 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
您也可以尝试 [在线 PowerPoint 转 PDF 转换器](https://products.aspose.app/slides/zh/conversion)。
{{% /alert %}}

## **常见问题**

**如何防止长篇演讲者备注被截断？**

使用 [NotesPositions.BottomFull](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomFull)，如上例所示。此设置会显示完整的备注，并在需要时使用附加页面。

**我可以将每张幻灯片及其备注保持在同一页上吗？**

使用 [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notespositions/#BottomTruncated)。此设置将备注限制在一页内，超出部分可能会被截断。

**如何导出不含演讲者备注的幻灯片？**

省略备注布局配置，并使用在 [Convert PowerPoint to PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/) 中描述的标准 PDF 导出方式。