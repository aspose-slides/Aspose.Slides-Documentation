---
title: 将 PowerPoint 转换为带备注的 TIFF（C#）
linktitle: PowerPoint 转 TIFF 带备注
type: docs
weight: 100
url: /zh/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- 转换 PowerPoint 为 TIFF
- 将演示文稿转换为 TIFF
- 将幻灯片转换为 TIFF
- 将 PPT 转换为 TIFF
- 将 PPTX 转换为 TIFF
- 将 ODP 转换为 TIFF
- PowerPoint 转 TIFF
- 演示文稿转 TIFF
- 幻灯片转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- ODP 转 TIFF
- 带备注的 PowerPoint
- 带备注的演示文稿
- 带备注的幻灯片
- 带备注的 PPT
- 带备注的 PPTX
- 带备注的 ODP
- 带备注的 TIFF
- C#
- .NET
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for .NET 提供了一个简单的解决方案，用于将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出带有演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 `Save` 方法的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for .NET 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 包括以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法。

假设我们有一个 "speaker_notes.pptx" 文件，其中包含以下幻灯片：

![演示文稿幻灯片（带演讲者备注）](slide_with_notes.png)

下面的代码片段演示了如何使用 [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 属性在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```c#
// 实例化表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // 配置带备注布局的 TIFF 选项。
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在幻灯片下方显示备注。
        }
    };

    // 将演示文稿连同演讲者备注保存为 TIFF。
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


结果：

![带演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose 的 [免费 PowerPoint 海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

是。使用 [notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间进行选择，分别可隐藏备注、将其压缩到单页，或允许其分页显示。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件大小？**

选择高效的压缩方式，例如 `LZW` 或 `RLE`，设置合理的 DPI，并在可接受的情况下使用更低的 [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)（如 8 bpp 或单色 1 bpp）。适度缩小 [image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) 也能在不明显影响可读性的前提下进一步减小文件体积。

**如果系统中缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发 [substitution](/slides/zh/net/font-selection-sequence/)，可能改变文本度量和外观。为避免此问题，请 [提供所需字体](/slides/zh/net/custom-font/) 或设置默认的 [fallback font](/slides/zh/net/fallback-font/)，以确保使用预期的字体。