---
title: 在 Java 中将 PowerPoint 演示文稿转换为带备注的 TIFF
linktitle: PowerPoint 转 TIFF（带备注）
type: docs
weight: 100
url: /zh/java/convert-powerpoint-to-tiff-with-notes/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 将 PowerPoint 演示文稿转换为带备注的 TIFF。了解如何高效导出带演讲者备注的幻灯片。"
---

## **概述**

Aspose.Slides for Java 提供了一种简便的解决方案，可将 PowerPoint 和 OpenDocument 演示文稿（PPT、PPTX 和 ODP）连同备注转换为 TIFF 格式。该格式广泛用于高质量图像存储、打印和文档归档。使用 Aspose.Slides，您不仅可以导出包含演讲者备注的整个演示文稿，还可以在备注幻灯片视图中生成幻灯片缩略图。转换过程简单高效，利用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的 `save` 方法将整个演示文稿转换为一系列 TIFF 图像，同时保留备注和布局。

## **将演示文稿转换为带备注的 TIFF**

使用 Aspose.Slides for Java 将 PowerPoint 或 OpenDocument 演示文稿保存为带备注的 TIFF 包含以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类：加载 PowerPoint 或 OpenDocument 文件。  
2. 配置输出布局选项：使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) 类指定备注和评论的显示方式。  
3. 将演示文稿保存为 TIFF：将配置好的选项传递给 [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法。

假设我们有一个名为 "speaker_notes.pptx" 的文件，包含如下幻灯片：

![The presentation slide with speaker notes](slide_with_notes.png)

下面的代码片段演示了如何使用 [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 方法在备注幻灯片视图中将演示文稿转换为 TIFF 图像。
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // 在幻灯片下方显示备注。

    // 配置带备注布局的 TIFF 选项。
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 将演示文稿保存为带演讲者备注的 TIFF。
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


结果：

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="提示" color="primary" %}}

查看 Aspose [免费 PowerPoint 到海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}