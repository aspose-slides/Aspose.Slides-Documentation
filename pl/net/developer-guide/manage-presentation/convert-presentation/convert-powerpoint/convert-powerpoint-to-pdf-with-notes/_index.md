---
title: Konwertuj prezentacje PowerPoint do PDF z notatkami w .NET
linktitle: PowerPoint do PDF z notatkami
type: docs
weight: 50
url: /pl/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PDF
- prezentacja do PDF
- slajd do PDF
- PPT do PDF
- PPTX do PDF
- zapisz prezentację jako PDF
- zapisz PPT jako PDF
- zapisz PPTX jako PDF
- eksportuj PPT do PDF
- eksportuj PPTX do PDF
- notatki prelegenta
- PDF z notatkami
- .NET
- C#
- Aspose.Slides
description: "Konwertuj formaty PPT i PPTX do PDF z notatkami przy użyciu Aspose.Slides dla .NET. Zachowaj układy i notatki prelegenta dla profesjonalnych prezentacji."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint do formatu PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten poradnik omówi niezbędne kroki i dostarczy przykłady kodu, aby pomóc Ci efektywnie wykonać to zadanie. Po przeczytaniu tego artykułu będziesz w stanie:

- Zaimplementować proces konwersji, przekształcając slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby notatki prelegenta zostały uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertowanie PowerPoint na PDF z notatkami**

Metoda `Save` w klasie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) może być użyta do konwersji prezentacji PPT lub PPTX do PDF z notatkami prelegenta. Korzystając z Aspose.Slides, po prostu ładujesz prezentację, konfigurujesz opcje układu przy użyciu klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu pokazuje, jak przekonwertować przykładową prezentację na PDF w widoku slajdu z notatkami.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Skonfiguruj opcje PDF dla renderowania notatek prelegenta.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Renderuj notatki prelegenta pod slajdem.
        }
    };

    // Zapisz prezentację jako PDF z notatkami prelegenta.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
Możesz chcieć sprawdzić konwerter Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 
{{% /alert %}}