---
title: Presentaties importeren vanuit PDF of HTML in PHP
linktitle: Presentatie importeren
type: docs
weight: 60
url: /nl/php-java/import-presentation/
keywords:
- presentatie importeren
- dia importeren
- PDF importeren
- HTML importeren
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importeer PDF- en HTML-documenten naar PowerPoint- en OpenDocument-presentaties in PHP met Aspose.Slides voor naadloze, high-performance dia-verwerking."
---
## **Inleiding**

Met [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/nl/php-java/) kunt u presentaties importeren vanuit bestanden in andere formaten. Aspose.Slides biedt de klasse [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/) om presentaties te importeren vanuit PDF‑bestanden, HTML‑documenten, enz.

## **PowerPoint importeren vanuit PDF**

In dit geval kunt u een PDF converteren naar een PowerPoint‑presentatie.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/) aan.  
2. Roep de methode [addFromPdf()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) aan en geef het PDF‑bestand door.  
3. Gebruik de methode [save()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#save-java.lang.String-int-) om het bestand op te slaan in het PowerPoint‑formaat.

Deze PHP‑code demonstreert de PDF‑naar‑PowerPoint‑bewerking:

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
U kunt de gratis **Aspose** [PDF naar PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) web‑app bekijken, omdat dit een live‑implementatie is van het hier beschreven proces. 
{{% /alert %}} 

## **PowerPoint importeren vanuit HTML**

In dit geval kunt u een HTML‑document converteren naar een PowerPoint‑presentatie.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/) aan.  
2. Roep de methode [addFromHtml()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) aan en geef het HTML‑bestand door.  
3. Gebruik de methode [save()](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#save-java.lang.String-int-) om het bestand op te slaan in het PowerPoint‑formaat.

Deze PHP‑code demonstreert de HTML‑naar‑PowerPoint‑bewerking:

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

## **FAQ**

**Worden tabellen behouden bij het importeren van een PDF, en kan hun detectie worden verbeterd?**

Tabellen kunnen tijdens het importeren worden gedetecteerd; [PdfImportOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfimportoptions/) bevat een [setDetectTables](https://reference.aspose.com/slides/nl/php-java/aspose.slides/pdfimportoptions/#setDetectTables)-methode die tabelherkenning mogelijk maakt. De effectiviteit hangt af van de structuur van de PDF.

{{% alert title="Opmerking" color="warning" %}} 
U kunt ook Aspose.Slides gebruiken om HTML te converteren naar andere populaire bestandsformaten: 

* [HTML naar afbeelding](https://products.aspose.com/slides/nl/php-java/conversion/html-to-image/)
* [HTML naar JPG](https://products.aspose.com/slides/nl/php-java/conversion/html-to-jpg/)
* [HTML naar XML](https://products.aspose.com/slides/nl/php-java/conversion/html-to-xml/)
* [HTML naar TIFF](https://products.aspose.com/slides/nl/php-java/conversion/html-to-tiff/)

{{% /alert %}}