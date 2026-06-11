---
title: Importera presentationer från PDF eller HTML i PHP
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/php-java/import-presentation/
keywords:
- importera presentation
- importera bild
- importera PDF
- importera HTML
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importera PDF- och HTML-dokument till PowerPoint- och OpenDocument-presentationer i PHP med Aspose.Slides för sömlös, högpresterande bildbehandling."
---
## **Introduktion**

Genom att använda [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/sv/php-java/), kan du importera presentationer från filer i andra format. Aspose.Slides tillhandahåller klassen [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/) för att låta dig importera presentationer från PDF‑filer, HTML‑dokument osv.

## **Importera PowerPoint från PDF**

I detta fall konverterar du en PDF till en PowerPoint‑presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/).
2. Anropa metoden [addFromPdf()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) och skicka PDF‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna PHP‑kod demonstrerar PDF‑till‑PowerPoint‑operationen:

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

{{% alert  title="Tip" color="primary" %}} 
Du kanske vill prova den kostnadsfria **Aspose**‑webbappen [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint) eftersom den är en live‑implementation av processen som beskrivs här. 
{{% /alert %}} 

## **Importera PowerPoint från HTML**

I detta fall konverterar du ett HTML‑dokument till en PowerPoint‑presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/).
2. Anropa metoden [addFromHtml()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) och skicka HTML‑filen.
3. Använd metoden [save()](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#save-java.lang.String-int-) för att spara filen i PowerPoint‑format.

Denna PHP‑kod demonstrerar HTML‑till‑PowerPoint‑operationen:

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

**Bevaras tabeller när man importerar en PDF, och kan deras detektering förbättras?**

Tabeller kan detekteras under importen; [PdfImportOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfimportoptions/) innehåller metoden [setDetectTables](https://reference.aspose.com/slides/sv/php-java/aspose.slides/pdfimportoptions/#setDetectTables) som möjliggör tabelligenkänning. Effektiviteten beror på PDF‑filens struktur.

{{% alert title="Note" color="warning" %}} 
Du kan också använda Aspose.Slides för att konvertera HTML till andra populära filformat: 

* [HTML till bild](https://products.aspose.com/slides/sv/php-java/conversion/html-to-image/)
* [HTML till JPG](https://products.aspose.com/slides/sv/php-java/conversion/html-to-jpg/)
* [HTML till XML](https://products.aspose.com/slides/sv/php-java/conversion/html-to-xml/)
* [HTML till TIFF](https://products.aspose.com/slides/sv/php-java/conversion/html-to-tiff/)

{{% /alert %}}