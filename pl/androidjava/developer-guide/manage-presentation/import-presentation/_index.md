---
title: Importowanie prezentacji z PDF lub HTML na Androidzie
linktitle: Import prezentacji
type: docs
weight: 60
url: /pl/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Importuj dokumenty PDF i HTML do prezentacji PowerPoint oraz OpenDocument w Javie za pomocą Aspose.Slides dla Androida, zapewniając płynne i wysokowydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Używając [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/pl/androidjava/), możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/), która pozwala importować prezentacje z plików PDF, dokumentów HTML itp.

## **Importuj PowerPoint z PDF**

W tym przypadku konwertujesz PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/).
2. Wywołaj metodę [addFromPdf()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) i podaj plik PDF.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) aby zapisać plik w formacie PowerPoint.

Ten kod Java demonstruje operację konwersji PDF do PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
Możesz sprawdzić darmową aplikację internetową **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja procesu opisanego tutaj. 
{{% /alert %}} 

## **Importuj PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/).
2. Wywołaj metodę [addFromHtml()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) i podaj strumień zawierający dokument HTML.
3. Użyj metody [save()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) aby zapisać plik w formacie PowerPoint.

Ten kod Java demonstruje operację konwersji HTML do PowerPoint: 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

### Czy tabele są zachowywane podczas importu PDF i czy ich wykrywanie można ulepszyć?

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfimportoptions/) zawiera metodę [setDetectTables](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-), która umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.