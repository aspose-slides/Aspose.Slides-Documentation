---
title: 在 C++ 中将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF（含备注）
type: docs
weight: 100
url: /zh/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
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

Aspose.Slides for C++ 提供了一个简单的解决方案，可将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简便高效，利用 `Save` 方法的 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类，将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for C++ 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 需要以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 类指定备注和批注的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法。

假设我们有一个名为 "speaker_notes.pptx" 的文件，其中包含以下幻灯片：

![The presentation slide with speaker notes](slide_with_notes.png)

下面的代码片段演示了如何使用 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 方法在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```cpp
// 实例化表示演示文稿文件的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // 在幻灯片下方显示备注。

// 配置带备注布局的 TIFF 选项。
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 将演示文稿保存为带有演讲者备注的 TIFF。
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


结果：

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

查看 Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **常见问题**

**我能控制生成的 TIFF 中备注区域的位置吗？**

可以。使用[备注布局设置](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) 在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间选择，分别对应隐藏备注、将备注压缩到单页以及允许备注在多页上继续显示。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件大小？**

选择[高效的压缩](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)（如 `LZW` 或 `RLE`），设置合理的 DPI，并在可接受的情况下使用更低的[像素格式](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/)（例如 8 bpp 或单色的 1 bpp）。适度减小[图像尺寸](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 也能在不明显影响可读性的前提下帮助降低文件大小。

**如果系统中缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发[替换](/slides/zh/cpp/font-selection-sequence/)，从而改变文本度量和外观。为避免此问题，请[提供所需字体](/slides/zh/cpp/custom-font/)或设置默认的[回退字体](/slides/zh/cpp/fallback-font/)，以使用预期的字形。