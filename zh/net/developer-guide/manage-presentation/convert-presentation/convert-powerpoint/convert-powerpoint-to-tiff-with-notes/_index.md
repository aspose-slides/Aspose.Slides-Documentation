---
title: 将 PowerPoint 演示文稿转换为带备注的 TIFF（.NET）
linktitle: PowerPoint 转 TIFF（带备注）
type: docs
weight: 100
url: /zh/net/convert-powerpoint-to-tiff-with-notes/
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
- 带备注的 演示文稿
- 带备注的 幻灯片
- 带备注的 PPT
- 带备注的 PPTX
- 带备注的 TIFF
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for .NET 提供了一种便捷的解决方案，可将带备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的整个演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简洁高效，利用 `Save` 方法通过 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类将整个演示文稿转化为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带注释的 TIFF**

使用 Aspose.Slides for .NET 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 需按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法。

假设我们有一个名为 "speaker_notes.pptx" 的文件，包含如下幻灯片：

![演示文稿幻灯片带演讲者备注](slide_with_notes.png)

下面的代码片段演示如何使用 [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) 属性在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```c#
// 实例化表示演示文稿文件的 Presentation 类.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // 配置带备注布局的 TIFF 选项.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // 在幻灯片下方显示备注.
        }
    };

    // 将演示文稿连同演讲者备注保存为 TIFF.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


结果：

![带演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="提示" color="primary" %}}
查看 Aspose [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中注释区域的位置吗？**

可以。使用 notes layout settings（注释布局设置）在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间进行选择，分别对应隐藏注释、将其压缩到单页，或允许其在多页上继续显示。

**如何在不明显降低质量的情况下减小带注释的 TIFF 文件大小？**

选择高效的压缩方式（例如 `LZW` 或 `RLE`），设置合适的 DPI，并在可接受的情况下使用较低的 pixel format（如 8 bpp 或 1 bpp 单色）。略微缩小 image dimensions（图像尺寸）也能在不明显影响可读性的前提下降低文件大小。

**如果系统缺少原始字体，注释中的字体会影响结果吗？**

会。缺失的字体会触发 substitution（替换），这可能改变文字度量和外观。为避免此问题，请 [supply the required fonts](/slides/zh/net/custom-font/) 或设置默认的 [fallback font](/slides/zh/net/fallback-font/)，以确保使用预期的字体。