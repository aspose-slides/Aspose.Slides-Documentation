---
title: Importowanie prezentacji z PDF lub HTML w .NET
linktitle: Importuj prezentację
type: docs
weight: 60
url: /pl/net/import-presentation/
keywords:
- importowanie prezentacji
- importowanie slajdu
- importowanie PDF
- importowanie HTML
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
description: "Bezproblemowo importuj dokumenty PDF i HTML do prezentacji PowerPoint i OpenDocument w .NET przy użyciu Aspose.Slides, zapewniając płynne i wydajne przetwarzanie slajdów."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides, możesz importować prezentacje z plików w innych formatach. Aspose.Slides udostępnia klasę [SlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/), która pozwala importować prezentacje z dokumentów PDF i HTML.

## **Importuj PowerPoint z PDF**

W tym przypadku konwertujesz plik PDF na prezentację PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). 
2. Wywołaj metodę [AddFromPdf](https://reference.aspose.com/slides/pl/net/aspose.slides.slidecollection/addfrompdf/methods/1) i przekaz plik PDF. 
3. Użyj metody [Save](https://reference.aspose.com/slides/pl/net/aspose.slides.presentation/save/methods/5), aby zapisać plik w formacie PowerPoint.

Ten kod C# demonstruje operację konwersji PDF do PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Możesz chcieć wypróbować darmową aplikację internetową **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), ponieważ jest to działająca implementacja opisanej tutaj procedury. 
{{% /alert %}} 

## **Importuj PowerPoint z HTML**

W tym przypadku konwertujesz dokument HTML na prezentację PowerPoint.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). 
2. Wywołaj metodę [AddFromHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) i przekaz plik HTML. 
3. Użyj metody [Save](https://apireference.aspose.com/slides/pl/net/aspose.slides.presentation/save/methods/5), aby zapisać plik jako dokument PowerPoint.

Ten kod C# demonstruje operację konwersji HTML do PowerPoint: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

### Czy tabele są zachowywane podczas importu PDF i czy ich wykrywanie można poprawić?

Tabele mogą być wykrywane podczas importu; [PdfImportOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.import/pdfimportoptions/) zawiera parametr [DetectTables](https://reference.aspose.com/slides/pl/net/aspose.slides.import/pdfimportoptions/detecttables/), który umożliwia rozpoznawanie tabel. Skuteczność zależy od struktury pliku PDF.

{{% alert title="Note" color="warning" %}} 
Możesz także używać Aspose.Slides do konwersji HTML do innych popularnych formatów plików: 

* [HTML na obraz](https://products.aspose.com/slides/pl/net/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/pl/net/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/pl/net/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/pl/net/conversion/html-to-tiff/)

{{% /alert %}}