---
title: 在 Android 上将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF（含备注）
type: docs
weight: 100
url: /zh/androidjava/convert-powerpoint-to-tiff-with-notes/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿转 TIFF
- 幻灯片转 TIFF
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for Android via Java 提供了一种简便的解决方案，可将带有备注的 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的完整演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的 `save` 方法将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for Android via Java 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF，需按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。  
2. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) 类指定备注和注释的显示方式。  
3. 将演示文稿保存为 TIFF：将配置好的选项传递给 [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

假设我们有一个名为 “speaker_notes.pptx” 的文件，其中包含以下幻灯片：

![The presentation slide with speaker notes](slide_with_notes.png)

下面的代码片段演示了如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法在备注幻灯片视图下将演示文稿转换为 TIFF 图像。
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在幻灯片下方显示备注。

    // 配置带有备注布局的 TIFF 选项。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 将演示文稿保存为带有演讲者备注的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


结果：

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以控制生成的 TIFF 中备注区域的位置吗？**

可以。使用 [notes layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 在 `None`、`BottomTruncated` 或 `BottomFull` 等选项之间选择，分别对应隐藏备注、将备注压缩到单页以及允许备注在多页之间流动。

**如何在不明显降低质量的前提下降低带备注的 TIFF 文件大小？**

选择高效的压缩方式，如 `LZW` 或 `RLE`，设置合理的 DPI，若可以接受，使用较低的 [pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)（例如 8 bpp 或单色的 1 bpp）。适当减小 [image dimensions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) 也有助于在不明显影响可读性的情况下减小文件体积。

**如果系统中缺少原始字体，备注中的字体会影响结果吗？**

会。缺失的字体会触发 [substitution](/slides/zh/androidjava/font-selection-sequence/)，这可能会改变文本度量和外观。为避免此问题，请 [提供所需字体](/slides/zh/androidjava/custom-font/) 或设置默认的 [fallback font](/slides/zh/androidjava/fallback-font/)，以确保使用预期的字体。