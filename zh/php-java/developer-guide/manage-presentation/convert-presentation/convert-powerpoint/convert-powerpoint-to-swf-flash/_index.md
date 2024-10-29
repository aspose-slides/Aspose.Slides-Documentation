---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /zh/php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX 到 SWF"
description: "将 PowerPoint PPT, PPTX 转换为 SWF "
---

## **将 PPT(X) 转换为 SWF**
[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法由 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类公开，可以将整个演示文稿转换为 **SWF** 文档。以下示例演示如何使用 [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions) 类提供的选项将演示文稿转换为 **SWF** 文档。您还可以使用 [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) 类和 [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) 接口在生成的 SWF 中包含注释。

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
```php

```