---
title: Импорт Презентации
type: docs
weight: 60
url: /ru/php-java/import-presentation/
keywords: "Импорт PowerPoint, PDF в Презентацию, PDF в PPTX, PDF в PPT, Java, Aspose.Slides для PHP через Java"
description: "Импорт презентации PowerPoint из PDF. Конвертировать PDF в PowerPoint"
---

Используя [**Aspose.Slides для PHP через Java**](https://products.aspose.com/slides/php-java/), вы можете импортировать презентации из файлов в других форматах. Aspose.Slides предоставляет класс [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) для импорта презентаций из PDF, HTML документов и т.д.

## **Импорт PowerPoint из PDF**

В этом случае вам нужно конвертировать PDF в презентацию PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Вызовите метод [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) и передайте PDF файл.
3. Используйте метод [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот PHP код демонстрирует операцию PDF в PowerPoint:

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

{{% alert  title="Совет" color="primary" %}} 

Вы можете попробовать **бесплатное приложение Aspose** [PDF в PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), так как это живая реализация процесса, описанного здесь. 

{{% /alert %}} 

## **Импорт PowerPoint из HTML**

В этом случае вам нужно конвертировать HTML документ в презентацию PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/).
2. Вызовите метод [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) и передайте HTML файл.
3. Используйте метод [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) для сохранения файла в формате PowerPoint.

Этот PHP код демонстрирует операцию HTML в PowerPoint:

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

{{% alert title="Примечание" color="warning" %}} 

Вы также можете использовать Aspose.Slides для конвертации HTML в другие популярные форматы файлов: 

* [HTML в изображение](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}