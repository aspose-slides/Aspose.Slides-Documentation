---
title: Konwertuj prezentacje PowerPoint na PDF z notatkami w .NET
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
description: "Konwertuj formaty PPT i PPTX na PDF z notatkami przy użyciu Aspose.Slides dla .NET. Zachowaj układy i notatki prelegenta w profesjonalnych prezentacjach."
---
## **Przegląd**

W tym artykule dowiesz się, jak konwertować prezentacje PowerPoint na format PDF z notatkami prelegenta przy użyciu Aspose.Slides. Ten przewodnik opisze niezbędne kroki i dostarczy przykłady kodu, które pomogą Ci skutecznie wykonać to zadanie. Po przeczytaniu artykułu będziesz w stanie:

- Zaimplementować proces konwersji, aby przekształcić slajdy PowerPoint w dokumenty PDF, zachowując notatki prelegenta.
- Dostosować wyjściowy plik PDF, aby notatki prelegenta były uwzględnione i sformatowane zgodnie z Twoimi wymaganiami.

## **Konwertuj PowerPoint na PDF z notatkami**

Metodę `Save` w klasie [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) można użyć do konwersji prezentacji PPT lub PPTX na PDF z notatkami prelegenta. Z Aspose.Slides po prostu ładujesz prezentację, konfigurować opcje układu za pomocą klasy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/notescommentslayoutingoptions/) aby uwzględnić notatki prelegenta, a następnie zapisujesz plik jako PDF. Poniższy fragment kodu demonstruje, jak przekonwertować przykładową prezentację na PDF w widoku Notatki slajdu.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Skonfiguruj opcje PDF do renderowania notatek prelegenta.
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

{{% alert color="info" %}} 
Możesz chcieć sprawdzić Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/pl/conversion). 
{{% /alert %}}