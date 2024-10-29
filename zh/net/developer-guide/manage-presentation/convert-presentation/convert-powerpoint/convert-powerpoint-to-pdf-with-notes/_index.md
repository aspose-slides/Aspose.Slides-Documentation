---
title: 使用 C# 将 PowerPoint 转换为 PDF（包含注释）
linktitle: 使用 C# 将 PowerPoint 转换为 PDF（包含注释）
type: docs
weight: 50
url: /zh/net/convert-powerpoint-to-pdf-with-notes/
keywords: "转换 PowerPoint, 演示文稿, PowerPoint 转 PDF, 注释, c#, csharp, .NET, Aspose.Slides"
description: "使用 C# 或 .NET 将 PowerPoint 转换为 PDF（包含注释）"
---

## **概述**

在 [将 PowerPoint 转换为 PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/) 的过程中，您还可以控制注释和评论在导出文档中的放置方式。它涵盖以下主题。

- [C# 将 PPT 转换为 PDF（包含注释）](#convert-powerpoint-to-pdf-with-notes)
- [C# 将 PPTX 转换为 PDF（包含注释）](#convert-powerpoint-to-pdf-with-notes)
- [C# 将 ODP 转换为 PDF（包含注释）](#convert-powerpoint-to-pdf-with-notes)
- [C# 将 PowerPoint 转换为 PDF（包含注释）](#convert-powerpoint-to-pdf-with-notes)

## **使用注释将 PowerPoint 转换为 PDF**

Presentation 类暴露的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法可用于将 PowerPoint PPT 或 PPTX 演示文稿转换为包含注释的 PDF。使用 Aspose.Slides for .NET 将 Microsoft PowerPoint 演示文稿保存为 PDF 注释是一个两行的过程。您只需打开演示文稿并将其保存为 PDF 注释。以下 C# 代码片段将示例演示文稿更新为带注释幻灯片视图的 PDF：

```c#
// 实例化代表演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// 设置幻灯片类型和大小 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

您可能想查看 Aspose 的 [PowerPoint 转 PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) 或 [PPT 转 PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) 转换器。

{{% /alert %}} 