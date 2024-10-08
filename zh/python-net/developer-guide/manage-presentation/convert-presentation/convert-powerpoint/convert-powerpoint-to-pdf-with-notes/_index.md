---
title: 使用带注释的PowerPoint转换为PDF
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "转换PowerPoint, 演示文稿, PowerPoint到PDF, 注释, Python, Aspose.Slides"
description: "使用Python将带注释的PowerPoint转换为PDF"
---

Presentation 类所提供的 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法可用于将 PowerPoint PPT 或 PPTX 演示文稿转换为带注释的 PDF。通过 .NET 使用 Aspose.Slides for Python 将 Microsoft PowerPoint 演示文稿保存为 PDF 注释只需两行代码。您只需打开演示文稿并将其保存为 PDF 注释。下面的代码片段将示例演示文稿更新为带注释幻灯片视图的 PDF：

```py
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# 设置幻灯片类型和大小 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

您可能想查看 Aspose [PowerPoint到PDF](https://products.aspose.app/slides/conversion) 或 [PPT到PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) 转换器。 

{{% /alert %}}