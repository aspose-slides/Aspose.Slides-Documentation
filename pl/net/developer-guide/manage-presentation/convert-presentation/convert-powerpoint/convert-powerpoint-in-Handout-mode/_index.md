---
title: Konwertowanie prezentacji PowerPoint w trybie rozdania w .NET
linktitle: Tryb rozdania
type: docs
weight: 150
url: /pl/net/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb rozdania
- rozdanie
- PowerPoint
- prezentacja
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje do formatu rozdania w .NET. Ustaw liczbę slajdów na stronie, zachowaj notatki, eksportuj do PDF lub obrazów za pomocą Aspose.Slides, z przykładowym kodem C#. Wypróbuj bezpłatnie."
---
## **Wstęp**

Aspose.Slides umożliwia konwertowanie prezentacji do formatów wyjściowych, które obsługują tryb rozdania. W tym trybie wiele slajdów jest rozmieszczonych na jednej stronie, co jest przydatne przy drukowaniu materiałów prezentacyjnych na konferencje, seminaria i podobne wydarzenia.

Tryb rozdania jest konfigurowany za pomocą właściwości `SlidesLayoutOptions`, dostępnej w [IPdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ihtmloptions/) oraz [ITiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/itiffoptions/). Aby określić układ rozdania, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handoutlayoutingoptions/).

## **Eksport w trybie rozdania**

Aby wyeksportować prezentację w trybie rozdania, ustaw właściwość `SlidesLayoutOptions` w docelowych opcjach eksportu i przypisz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handoutlayoutingoptions/), która definiuje liczbę slajdów na stronie oraz powiązane parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację na PDF w trybie rozdania.

```c#
// Wczytaj prezentację.
using var presentation = new Presentation("sample.pptx");

// Set the export options.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slajdy na jednej stronie poziomo
        PrintSlideNumbers = true,                   // drukuj numery slajdów
        PrintFrameSlide = true,                     // drukuj ramkę wokół slajdów
        PrintComments = false                       // brak komentarzy
    }
};

// Export the presentation to PDF with the chosen layout.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Należy pamiętać, że właściwość `SlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz podczas renderowania jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie rozdania?**

Aspose.Slides obsługuje [predefiniowane ustawienia](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handouttype/) do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handouttype/); układy dowolne nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu w trybie rozdania?**

Tak. Włącz opcję `ShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/).