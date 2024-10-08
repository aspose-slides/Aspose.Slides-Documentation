---
title: 将 PowerPoint 转换为 PDF 附注
type: docs
weight: 50
url: /zh/php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "在 java 中将 powerpoint 转换为带附注的 pdf"
description: "将 PowerPoint 转换为带附注的 PDF"
---

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**
以下示例演示如何将演示文稿转换为具有自定义幻灯片大小的 PDF 附注文档。每英寸等于 72。

```php
// 实例化一个表示演示文稿文件的 Presentation 对象
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # 设置幻灯片类型和大小
    $presOut->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $presOut->save("PDF-SelectedSlide.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($presIn)) {
      $presIn->dispose();
    }
    if (!java_is_null($presOut)) {
      $presOut->dispose();
    }
  }
```

## **在附注幻灯片视图中将 PowerPoint 转换为 PDF**
[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法由 [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类提供，可用于将整个演示文稿在附注幻灯片视图中转换为 PDF。以下代码片段将示例演示文稿更新为在附注幻灯片视图中的 PDF。

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $pres->save($resourcesOutputPath . "PDF-Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

您可能想查看 Aspose [PowerPoint 转 PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) 或 [PPT 转 PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) 转换器。 

{{% /alert %}}