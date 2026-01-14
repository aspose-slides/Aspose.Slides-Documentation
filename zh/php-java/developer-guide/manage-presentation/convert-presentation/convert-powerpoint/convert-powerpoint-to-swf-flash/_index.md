---
title: 在 PHP 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/php-java/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 SWF
- 演示文稿 转 SWF
- 幻灯片 转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint 转 Flash
- 演示文稿 转 Flash
- 幻灯片 转 Flash
- PPT 转 Flash
- PPTX 转 Flash
- 将 PPT 保存为 SWF
- 将 PPTX 保存为 SWF
- 将 PPT 导出为 SWF
- 将 PPTX 导出为 SWF
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将 PowerPoint（PPT/PPTX）转换为 SWF Flash。逐步代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **将演示文稿转换为 Flash**

由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类公开的 [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) 方法可用于将整个演示文稿转换为 **SWF** 文档。以下示例演示如何使用 [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) 类提供的选项将演示文稿转换为 **SWF** 文档。您还可以通过使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) 类在生成的 SWF 中包含批注。
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # 保存演示文稿
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以在 SWF 中包含隐藏幻灯片吗？**

是的。使用 [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) 中的 [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) 方法启用隐藏幻灯片。默认情况下，隐藏幻灯片不会被导出。

**我如何控制压缩和最终的 SWF 大小？**

使用 [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) 方法并 [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) 来平衡文件大小和图像保真度。

**'setViewerIncluded' 的作用是什么？何时应该禁用它？**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) 会添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要没有 UI 的纯粹 SWF 框架，请禁用它。

**如果导出机器上缺少源字体会怎样？**

Aspose.Slides 将使用您在 [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) 中通过 [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) 指定的字体进行替换，以避免意外的回退。