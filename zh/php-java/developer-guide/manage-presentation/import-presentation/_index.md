---
title: 在 PHP 中从 PDF 或 HTML 导入演示文稿
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/php-java/import-presentation/
keywords:
- 导入演示文稿
- 导入幻灯片
- 导入 PDF
- 导入 HTML
- PDF 转演示文稿
- PDF 转 PPT
- PDF 转 PPTX
- PDF 转 ODP
- HTML 转演示文稿
- HTML 转 PPT
- HTML 转 PPTX
- HTML 转 ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中将 PDF 和 HTML 文档导入 PowerPoint 和 OpenDocument 演示文稿，实现无缝、高性能的幻灯片处理。"
---

使用 [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供 [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) 类，以便您从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在此情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) 类的实例。  
2. 调用 [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 方法并传入 PDF 文件。  
3. 使用 [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

以下 PHP 代码演示了 PDF 转 PowerPoint 的操作：
```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}} 
您可以查看 Aspose 免费的 [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web 应用，因为它是本文所述过程的实时实现。 
{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在此情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) 类的实例。  
2. 调用 [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 方法并传入 HTML 文件。  
3. 使用 [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

以下 PHP 代码演示了 HTML 转 PowerPoint 的操作：
```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **常见问题**

**导入 PDF 时表格是否会保留，是否可以改进表格检测？**

在导入期间可以检测表格；[PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) 包含一个 [setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/#setDetectTables) 方法，可启用表格识别。其效果取决于 PDF 的结构。

{{% alert title="Note" color="warning" %}} 
您还可以使用 Aspose.Slides 将 HTML 转换为其他流行文件格式： 

* [HTML to image](https://products.aspose.com/slides/php-java/conversion/html-to-image/)  
* [HTML to JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)  
* [HTML to XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)  
* [HTML to TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)  

{{% /alert %}}