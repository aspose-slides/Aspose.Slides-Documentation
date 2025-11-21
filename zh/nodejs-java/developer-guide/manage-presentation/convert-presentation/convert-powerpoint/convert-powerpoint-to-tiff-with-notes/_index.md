---
title: 将 PowerPoint 转换为带备注的 TIFF（JavaScript）
linktitle: PowerPoint 转 TIFF（带备注）
type: docs
weight: 100
url: /zh/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- 将 PowerPoint 转换为 TIFF
- 将演示文稿转换为 TIFF
- 将幻灯片转换为 TIFF
- 将 PPT 转换为 TIFF
- 将 PPTX 转换为 TIFF
- 将 ODP 转换为 TIFF
- PowerPoint 转 TIFF
- 演示文稿 转 TIFF
- 幻灯片 转 TIFF
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 将 PowerPoint 和 OpenDocument 演示文稿转换为带备注的 TIFF。了解如何高效地导出演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for Node.js via Java 提供了一种简便的解决方案，可将带备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 `save` 方法的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for Node.js via Java 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 包括以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) 类指定备注和注释的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) 方法。

假设我们有一个名为 "speaker_notes.pptx" 的文件，其中包含以下幻灯片：

![带有演讲者备注的演示幻灯片](slide_with_notes.png)

下面的代码片段演示了如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```js
// 实例化表示演示文稿文件的 Presentation 类。
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // 在幻灯片下方显示备注。

    // 配置带备注布局的 TIFF 选项。
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 将演示文稿保存为带演讲者备注的 TIFF。
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


结果：

![带有演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

是的。使用 [notes layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 可在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间选择，分别对应隐藏备注、将其压缩到单页，或允许其分页显示。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件大小？**

选择一种 [efficient compression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/)（例如 `LZW` 或 `RLE`），设置合适的 DPI，并且在可接受的情况下使用更低的 [pixel format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setpixelformat/)（如 8 bpp 或单色的 1 bpp）。略微降低 [image dimensions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setimagesize/) 也有助于减小文件大小，同时不会明显影响可读性。

**如果系统缺少原始字体，备注中的字体会影响结果吗？**

是的。缺失的字体会触发 [substitution](/slides/zh/nodejs-java/font-selection-sequence/)，可能导致文本度量和外观变化。为避免此问题，请 [supply the required fonts](/slides/zh/nodejs-java/custom-font/) 或设置默认的 [fallback font](/slides/zh/nodejs-java/fallback-font/)，以使用预期的字体。