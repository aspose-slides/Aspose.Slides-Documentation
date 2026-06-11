---
title: Importowanie prezentacji z PDF lub HTML w .NET
linktitle: Import prezentacji
type: docs
weight: 60
url: /pl/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo importuj dokumenty PDF i HTML do prezentacji PowerPoint i OpenDocument w .NET za pomocą Aspose.Slides, zapewniając płynne i wysokowydajne przetwarzanie slajdów."
---
## **Wstęp**

Korzystając z Aspose.Slides, możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/), która pozwala na importowanie prezentacji z dokumentów PDF i HTML.

## **Importuj PowerPoint z PDF**

W tym przypadku konwertujesz plik PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Wywołaj metodę [AddFromPdf](https://reference.aspose.com/slides/pl/net/aspose.slides.slidecollection/addfrompdf/methods/1) i przekaż plik PDF.
3. Użyj metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides.presentation/save/methods/5), aby zapisać plik w formacie PowerPoint.

Ten kod C# demonstruje operację konwersji PDF do PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Możesz sprawdzić darmową aplikację internetową **Aspose free** [PDF do PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja procesu opisanego tutaj. 
{{% /alert %}} 

## **Importuj PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Wywołaj metodę [AddFromHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) i przekaż plik HTML.
3. Użyj metody [Save](https://apireference.aspose.com/slides/pl/net/aspose.slides.presentation/save/methods/5), aby zapisać plik jako dokument PowerPoint.

Ten kod C# demonstruje operację konwersji HTML do PowerPoint: 

```c#
using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy tabele są zachowywane podczas importu PDF i czy ich wykrywanie można ulepszyć?**

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.import/pdfimportoptions/) zawiera parametr [DetectTables](https://reference.aspose.com/slides/pl/net/aspose.slides.import/pdfimportoptions/detecttables/), który umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.

{{% alert title="Note" color="warning" %}} 
Możesz również używać Aspose.Slides do konwersji HTML do innych popularnych formatów plików: 

* [HTML do obrazu](https://products.aspose.com/slides/pl/net/conversion/html-to-image/)
* [HTML do JPG](https://products.aspose.com/slides/pl/net/conversion/html-to-jpg/)
* [HTML do XML](https://products.aspose.com/slides/pl/net/conversion/html-to-xml/)
* [HTML do TIFF](https://products.aspose.com/slides/pl/net/conversion/html-to-tiff/)

{{% /alert %}}