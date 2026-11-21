---
title: 在 C++ 中将 PowerPoint 演示文稿转换为带备注的 PDF
linktitle: PowerPoint 转 PDF 带备注
type: docs
weight: 50
url: /zh/cpp/convert-powerpoint-to-pdf-with-notes/
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
- 将演示文稿 保存 为 PDF
- 将 PPT 保存 为 PDF
- 将 PPTX 保存 为 PDF
- 导出 PPT 为 PDF
- 导出 PPTX 为 PDF
- 演讲者备注
- 带备注的 PDF
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PPT 与 PPTX 格式转换为带备注的 PDF。保留布局和演讲者备注，以实现专业的演示文稿。"
---
## **概述**

在本文中，您将学习如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为带有演讲者备注的 PDF 格式。本指南将介绍必要的步骤并提供代码示例，帮助您高效完成此任务。阅读完本文后，您将能够：

- 实现转换过程，将 PowerPoint 幻灯片转换为 PDF 文档，同时保留演讲者备注。
- 自定义输出的 PDF，确保演讲者备注被包含并按照您的要求进行格式化。

要在导出前设置备注页的尺寸和方向，请参阅[备注页大小](/slides/zh/cpp/notes-size/)。

## **将 PowerPoint 转换为带备注的 PDF**

可以使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类中的 `Save` 方法将 PPT 或 PPTX 演示文稿转换为带有演讲者备注的 PDF。使用 Aspose.Slides，您只需加载演示文稿，使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/) 类配置布局选项以包含演讲者备注，然后将文件保存为 PDF。以下代码片段演示了如何在备注幻灯片视图中将示例演示文稿转换为 PDF。

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在幻灯片下方渲染演讲者备注。
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
您可能想尝试 Aspose 的[在线 PowerPoint 转 PDF 转换器](https://products.aspose.app/slides/zh/conversion)。
{{% /alert %}}