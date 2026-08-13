---
title: 使用 Java 将 PowerPoint 演示文稿转换为带备注的 PDF
linktitle: PowerPoint 转 PDF 带备注
type: docs
weight: 50
url: /zh/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将 PPT 和 PPTX 格式转换为带备注的 PDF。保留布局和演讲者备注，以实现专业演示。"
---
## **概述**

在本文中，您将学习如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为带有演讲者备注的 PDF 格式。本文将介绍必要的步骤并提供代码示例，帮助您高效完成此任务。阅读本文后，您将能够：

- 实现转换过程，将 PowerPoint 幻灯片转换为 PDF 文档，同时保留演讲者备注。
- 自定义输出的 PDF，确保演讲者备注已包含并按照您的要求进行格式化。

## **将 PowerPoint 转换为带备注的 PDF**

`save` 方法可在 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类中用于将 PPT 或 PPTX 演示文稿转换为包含演讲者备注的 PDF。使用 Aspose.Slides，您只需加载演示文稿，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/notescommentslayoutingoptions/) 类配置布局选项以包含演讲者备注，然后将文件保存为 PDF。以下代码片段演示了如何在备注幻灯片视图中将示例演示文稿转换为 PDF。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// 配置用于呈现演讲者备注的 PDF 选项。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在幻灯片下方呈现演讲者备注。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// 将演示文稿保存为带演讲者备注的 PDF。
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
您可能想要查看 Aspose [在线PowerPoint转PDF转换器](https://products.aspose.app/slides/zh/conversion)。 
{{% /alert %}}