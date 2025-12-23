---
title: 在 PHP 中将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF（带备注）
type: docs
weight: 100
url: /zh/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效地导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for PHP via Java 提供了一种简便的解决方案，可将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 `save` 方法的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for PHP via Java 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 包括以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。
1. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。
1. 将演示文稿保存为 TIFF：将配置好的选项传递给 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) 方法。

假设我们有一个名为 **speaker_notes.pptx** 的文件，其包含以下幻灯片：

![带有演讲者备注的演示文稿幻灯片](slide_with_notes.png)

下面的代码片段演示了如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 方法在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```php
// 实例化表示演示文稿文件的 Presentation 类。
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // 在幻灯片下方显示备注。

    // 配置带备注布局的 TIFF 选项。
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 将演示文稿保存为带演讲者备注的 TIFF。
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


结果：

![带有演讲者备注的 TIFF 图像](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

是。使用 [notes layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) 可以在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间选择，分别对应隐藏备注、将备注压缩至单页，或允许备注扩展到额外页面。

**如何在不明显降低质量的情况下减小带备注的 TIFF 文件大小？**

选取高效的 [compression](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setcompressiontype/)（例如 `LZW` 或 `RLE`），设置合理的 DPI，并在可接受的情况下使用较低的 [pixel format](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/)（如 8 bpp 或单色的 1 bpp）。适度降低 [image dimensions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) 也能在不明显影响可读性的前提下减小文件体积。

**如果系统缺少原始字体，备注中的字体会影响结果吗？**

是。缺失的字体会触发 [substitution](/slides/zh/php-java/font-selection-sequence/)，可能改变文本度量和外观。为避免此情况，请 [supply the required fonts](/slides/zh/php-java/custom-font/) 或设置默认的 [fallback font](/slides/zh/php-java/fallback-font/)，以使用预期的字体。