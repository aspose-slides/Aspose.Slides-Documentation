---
title: Import prezentací z PDF nebo HTML v PHP
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/php-java/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
- PDF do prezentace
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentace
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v PHP pomocí Aspose.Slides pro bezproblémové a výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/cs/php-java/), můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) , která vám umožní importovat prezentace z PDF, HTML dokumentů atd.

## **Importovat PowerPoint z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/).
2. Zavolejte metodu [addFromPdf()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) a předáte soubor PDF.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#save-java.lang.String-int-) , abyste soubor uložili ve formátu PowerPoint.

Tento PHP kód demonstruje operaci převodu PDF do PowerPoint:

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

Možná budete chtít vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože jde o živou implementaci zde popsaného postupu. 

{{% /alert %}} 

## **Importovat PowerPoint z HTML**

V tomto případě můžete převést dokument HTML na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/).
2. Zavolejte metodu [addFromHtml()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) a předáte soubor HTML.
3. Použijte metodu [save()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#save-java.lang.String-int-) , abyste soubor uložili ve formátu PowerPoint.

Tento PHP kód demonstruje operaci převodu HTML do PowerPoint:

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

## **Často kladené otázky**

**Jsou tabulky při importu PDF zachovány a lze jejich detekci zlepšit?**

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfimportoptions/) obsahuje metodu [setDetectTables](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pdfimportoptions/#setDetectTables), která umožňuje rozpoznání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Note" color="warning" %}} 

Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML to image](https://products.aspose.com/slides/cs/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/cs/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/cs/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/cs/php-java/conversion/html-to-tiff/)

{{% /alert %}}