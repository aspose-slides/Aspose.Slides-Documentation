---
title: 在 .NET 中将 PowerPoint 演示文稿转换为带备注的 PDF
linktitle: PowerPoint 转 PDF（带备注）
type: docs
weight: 50
url: /zh/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PDF
- 演示文稿 转 PDF
- 幻灯片 转 PDF
- PPT 转 PDF
- PPTX 转 PDF
- 将 演示文稿 保存 为 PDF
- 将 PPT 保存 为 PDF
- 将 PPTX 保存 为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- 演讲者备注
- 带备注的 PDF
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PPT 和 PPTX 格式转换为带备注的 PDF。保留布局和演讲者备注，以实现专业演示文稿。"
---

## **概述**

在本文中，您将学习如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为带有演讲者备注的 PDF 格式。本指南将涵盖必要的步骤并提供代码示例，帮助您高效完成此任务。阅读本文后，您将能够：

- 实现转换过程，将 PowerPoint 幻灯片转换为 PDF 文档，同时保留演讲者备注。
- 自定义输出的 PDF，确保演讲者备注被包含并按照您的要求进行格式化。

## **将 PowerPoint 转换为带备注的 PDF**

`Save` 方法位于 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类中，可用于将 PPT 或 PPTX 演示文稿转换为带有演讲者备注的 PDF。使用 Aspose.Slides，您只需加载演示文稿，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 类配置布局选项以包含演讲者备注，然后将文件保存为 PDF。以下代码片段演示了如何将示例演示文稿转换为备注幻灯片视图下的 PDF。

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 配置用于渲染演讲者备注的 PDF 选项。
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在幻灯片下方渲染演讲者备注。
        }
    };

    // 将演示文稿保存为带有演讲者备注的 PDF。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
您可能想了解 Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion)。 
{{% /alert %}}