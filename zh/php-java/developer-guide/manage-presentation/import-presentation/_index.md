---
title: 导入演示文稿
type: docs
weight: 60
url: /zh/php-java/import-presentation/
keywords: "导入 PowerPoint，PDF 到演示文稿，PDF 到 PPTX，PDF 到 PPT，Java，Aspose.Slides for PHP via Java"
description: "从 PDF 导入 PowerPoint 演示文稿。将 PDF 转换为 PowerPoint"
---

使用 [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) 类，使您能够从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在这种情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) 类的实例。
2. 调用 [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 方法，并传入 PDF 文件。
3. 使用 [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法以 PowerPoint 格式保存文件。

以下 PHP 代码演示了 PDF 到 PowerPoint 的操作：

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

{{% alert title="提示" color="primary" %}} 

您可能想查看 **Aspose 免费** [PDF 到 PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 网络应用程序，因为它是此处描述过程的实时实现。

{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在这种情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) 类的实例。
2. 调用 [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 方法，并传入 PDF 文件。
3. 使用 [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法以 PowerPoint 格式保存文件。

以下 PHP 代码演示了 HTML 到 PowerPoint 的操作：

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

{{% alert title="注意" color="warning" %}} 

您还可以使用 Aspose.Slides 将 HTML 转换为其他流行的文件格式：

* [HTML 转图片](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}