---
title: 使用 C++ 将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF（带备注）
type: docs
weight: 100
url: /zh/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿 转 TIFF
- 幻灯片 转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- 将 PPT 保存为 TIFF
- 将 PPTX 保存为 TIFF
- 导出 PPT 为 TIFF
- 导出 PPTX 为 TIFF
- 带备注的 PowerPoint
- 带备注的演示文稿
- 带备注的幻灯片
- 带备注的 PPT
- 带备注的 PPTX
- 带备注的 TIFF
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for C++ 提供了一种简单的解决方案，可将包含备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出带有演讲者备注的整个演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 `Save` 方法的 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for C++ 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 包括以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。  
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。  
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法。

假设我们有一个名为 “speaker_notes.pptx” 的文件，其中包含以下幻灯片：

![演示文稿幻灯片带演讲者备注](slide_with_notes.png)

下面的代码片段演示了如何使用 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 方法在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```cpp
// 实例化代表演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在幻灯片下方显示备注.

// 使用备注布局配置 TIFF 选项。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 将演示文稿保存为带有演讲者备注的 TIFF。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


结果：

![带演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 可在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间选择，分别对应隐藏备注、将备注压缩至单页或允许备注在多页之间流动。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件大小？**

选择高效的压缩方式，例如 `LZW` 或 `RLE`，设置合理的 DPI，并在可以接受的情况下使用较低的 [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（如 8 位或 1 位单色）。适度缩小 [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 也能在不明显影响可读性的前提下降低文件大小。

**如果系统缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发 [substitution](/slides/zh/cpp/font-selection-sequence/)，这可能会改变文本度量和外观。为避免此问题，请 [提供所需字体](/slides/zh/cpp/custom-font/) 或设置默认的 [fallback font](/slides/zh/cpp/fallback-font/)，以确保使用预期的字体。