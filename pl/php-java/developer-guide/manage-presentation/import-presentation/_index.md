---
title: Importowanie prezentacji z PDF lub HTML w PHP
linktitle: Importowanie prezentacji
type: docs
weight: 60
url: /pl/php-java/import-presentation/
keywords:
- importowanie prezentacji
- import slajdu
- import PDF
- import HTML
- PDF do prezentacji
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentacji
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument w PHP przy użyciu Aspose.Slides, zapewniając płynne i wydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Korzystając z [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/pl/php-java/), możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/), która umożliwia importowanie prezentacji z PDF‑ów, dokumentów HTML itp.

## **Import PowerPoint z PDF**

W tym przypadku konwertujesz plik PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/) .
2. Wywołaj metodę [addFromPdf()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) , przekazując plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod PHP demonstruje operację konwersji PDF do PowerPoint:

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

Możesz sprawdzić darmową aplikację internetową Aspose [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja opisanej tutaj procedury. 

{{% /alert %}} 

## **Import PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/) .
2. Wywołaj metodę [addFromHtml()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) , przekazując plik HTML.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod PHP demonstruje operację konwersji HTML do PowerPoint:

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

**Czy tabele są zachowywane podczas importu PDF i czy ich wykrywanie można poprawić?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfimportoptions/) zawiera metodę [setDetectTables](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfimportoptions/#setDetectTables), która włącza rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.

{{% alert title="Note" color="warning" %}} 

Możesz również używać Aspose.Slides do konwersji HTML na inne popularne formaty plików: 

* [HTML na obraz](https://products.aspose.com/slides/pl/php-java/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/pl/php-java/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/pl/php-java/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/pl/php-java/conversion/html-to-tiff/)

{{% /alert %}}