---
title: Importowanie prezentacji z PDF lub HTML w Javie
linktitle: Importuj prezentację
type: docs
weight: 60
url: /pl/java/import-presentation/
keywords:
- import prezentacji
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
- Java
- Aspose.Slides
description: "Bezproblemowo importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument w Javie przy użyciu Aspose.Slides, zapewniając płynne i wydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides, możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/) , która umożliwia importowanie prezentacji z dokumentów PDF i HTML.

## **Import PowerPoint z PDF**

W tym przypadku konwertujesz PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/) .
2. Wywołaj metodę [addFromPdf()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) , przekazując plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod Java demonstruje operację konwersji PDF do PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
Możesz sprawdzić **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint) aplikację webową, ponieważ jest to działająca implementacja opisanego tutaj procesu. 
{{% /alert %}} 

## **Import PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/) .
2. Wywołaj metodę [addFromHtml()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) , przekazując plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-) , aby zapisać plik w formacie PowerPoint.

Ten kod Java demonstruje operację konwersji HTML do PowerPoint: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Czy tabele są zachowywane podczas importowania PDF i czy ich wykrywanie można ulepszyć?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfimportoptions/) zawiera metodę [setDetectTables](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) , która umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.

{{% alert title="Note" color="warning" %}} 
Możesz również używać Aspose.Slides do konwersji HTML do innych popularnych formatów plików: 

* [HTML do obrazu](https://products.aspose.com/slides/pl/java/conversion/html-to-image/)
* [HTML do JPG](https://products.aspose.com/slides/pl/java/conversion/html-to-jpg/)
* [HTML do XML](https://products.aspose.com/slides/pl/java/conversion/html-to-xml/)
* [HTML do TIFF](https://products.aspose.com/slides/pl/java/conversion/html-to-tiff/)

{{% /alert %}}