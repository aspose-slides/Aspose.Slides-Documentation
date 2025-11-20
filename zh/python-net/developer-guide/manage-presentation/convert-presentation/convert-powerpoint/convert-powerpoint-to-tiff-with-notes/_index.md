---
title: 将 PowerPoint 演示文稿转换为带备注的 TIFF（Python）
linktitle: PowerPoint 转 TIFF 带备注
type: docs
weight: 100
url: /zh/python-net/convert-powerpoint-to-tiff-with-notes/
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
- 带备注的 PowerPoint
- 带备注的 演示文稿
- 带备注的 幻灯片
- 带备注的 PPT
- 带备注的 PPTX
- 带备注的 TIFF
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for Python via .NET 提供了一种简便的解决方案，可将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 `save` 方法的 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for Python via .NET 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF，需按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) 方法。

假设我们有一个 “speaker_notes.pptx” 文件，其中包含以下幻灯片：

![带有演讲者备注的演示文稿幻灯片](slide_with_notes.png)

下面的代码片段演示了如何使用 [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) 属性将演示文稿转换为备注幻灯片视图下的 TIFF 图像。
```py
# 实例化表示演示文件的 Presentation 类。
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # 在幻灯片下方显示备注。
    
    # 配置带备注布局的 TIFF 选项。
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # 将演示文稿保存为带有演讲者备注的 TIFF。
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


结果：

![带有演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**是否可以控制生成的 TIFF 中备注区域的位置？**

是。使用 [notes layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) 可以在 `NONE`、`BOTTOM_TRUNCATED` 或 `BOTTOM_FULL` 等选项中进行选择，分别对应隐藏备注、将备注压缩到单页以及允许备注在多页之间流动。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件尺寸？**

选择一种 [efficient compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/)（例如 `LZW` 或 `RLE`），设置合适的 DPI；如果可以接受，使用更低的 [pixel format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/)（如 8 bpp 或单色的 1 bpp）。适度降低 [image dimensions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) 也有助于减小文件大小，同时不明显影响可读性。

**如果系统缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发 [substitution](/slides/zh/python-net/font-selection-sequence/)，从而改变文本度量和外观。为避免此问题，请 [supply the required fonts](/slides/zh/python-net/custom-font/) 或设置默认的 [fallback font](/slides/zh/python-net/fallback-font/)，以确保使用预期的字体。