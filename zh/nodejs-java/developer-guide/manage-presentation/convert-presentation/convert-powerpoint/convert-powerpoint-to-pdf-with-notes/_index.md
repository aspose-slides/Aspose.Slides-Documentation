---
title: 将 PowerPoint 演示文稿转换为带备注的 PDF（JavaScript）
linktitle: PowerPoint 转 PDF 带备注
type: docs
weight: 50
url: /zh/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- 将演示文稿保存为 PDF
- 将 PPT 保存为 PDF
- 将 PPTX 保存为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- 演讲者备注
- 带备注的 PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 在 JavaScript 中将 PPT 和 PPTX 格式转换为带备注的 PDF。保留布局和演讲者备注，以实现专业演示文稿。"
---
## **概述**

在本文中，您将学习如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为带有演讲者备注的 PDF 格式。本文将涵盖必要的步骤并提供代码示例，帮助您高效完成此任务。阅读本文后，您将能够：

- 实现转换过程，将 PowerPoint 幻灯片转换为 PDF 文档，同时保留演讲者备注。
- 自定义输出 PDF，以确保演讲者备注已包含并按您的要求进行格式化。

在导出之前设置注释页面的尺寸和方向，请参见 [注释页面大小](/slides/zh/nodejs-java/notes-size/)。

## **将 PowerPoint 转换为带注释的 PDF**

可以使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类中的 `save` 方法将 PPT 或 PPTX 演示文稿转换为带有演讲者备注的 PDF。使用 Aspose.Slides，您只需加载演示文稿，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 类配置布局选项以包含演讲者备注，然后将文件保存为 PDF。以下代码片段演示了如何在备注幻灯片视图中将示例演示文稿转换为 PDF。

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// 为渲染演讲者备注配置 PDF 选项。
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // 在幻灯片下方渲染演讲者备注。

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
您可以查看 Aspose [在线 PowerPoint 转 PDF 转换器](https://products.aspose.app/slides/zh/conversion)。
{{% /alert %}}