---
title: Präsentation importieren
type: docs
weight: 60
url: /php-java/import-presentation/
keywords: "PowerPoint importieren, PDF in Präsentation, PDF in PPTX, PDF in PPT, Java, Aspose.Slides für PHP über Java"
description: "PowerPoint-Präsentation aus PDF importieren. PDF in PowerPoint konvertieren"
---

Mit [**Aspose.Slides für PHP über Java**](https://products.aspose.com/slides/php-java/) können Sie Präsentationen aus Dateien in anderen Formaten importieren. Aspose.Slides bietet die [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) Klasse, die es Ihnen ermöglicht, Präsentationen aus PDFs, HTML-Dokumenten usw. zu importieren.

## **PowerPoint aus PDF importieren**

In diesem Fall konvertieren Sie eine PDF in eine PowerPoint-Präsentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) Klasse.
2. Rufen Sie die [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) Methode auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser PHP-Code demonstriert die PDF-zu-PowerPoint-Operation:

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

{{% alert  title="Tipp" color="primary" %}} 

Sie möchten vielleicht die **kostenlose Aspose** [PDF zu PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web-App ausprobieren, da sie eine Live-Implementierung des hier beschriebenen Prozesses ist. 

{{% /alert %}} 

## **PowerPoint aus HTML importieren**

In diesem Fall konvertieren Sie ein HTML-Dokument in eine PowerPoint-Präsentation.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) Klasse.
2. Rufen Sie die [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) Methode auf und übergeben Sie die PDF-Datei.
3. Verwenden Sie die [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode, um die Datei im PowerPoint-Format zu speichern.

Dieser PHP-Code demonstriert die HTML-zu-PowerPoint-Operation:

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

{{% alert title="Hinweis" color="warning" %}} 

Sie können Aspose.Slides auch verwenden, um HTML in andere gängige Dateiformate zu konvertieren: 

* [HTML in Bild](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}