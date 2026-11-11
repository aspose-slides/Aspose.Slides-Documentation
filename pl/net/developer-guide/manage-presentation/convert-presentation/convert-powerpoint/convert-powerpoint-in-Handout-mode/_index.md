---
title: Konwertowanie prezentacji PowerPoint w trybie rozdania w .NET
linktitle: Tryb rozdania
type: docs
weight: 150
url: /pl/net/convert-powerpoint-in-handout-mode/
keywords:
- konwertować PowerPoint
- konwertować prezentację
- tryb rozdania
- rozdanie
- PowerPoint
- prezentacja
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje do formatu rozdania w .NET. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides, z przykładowym kodem C#. Wypróbuj za darmo."
---
## **Wstęp**

Aspose.Slides umożliwia konwertowanie prezentacji do formatów wyjściowych obsługujących tryb rozdania. W tym trybie wiele slajdów jest rozmieszczonych na jednej stronie, co jest przydatne przy drukowaniu materiałów prezentacyjnych na konferencje, seminaria i podobne wydarzenia.

Tryb rozdania jest konfigurowany za pomocą własności `SlidesLayoutOptions`, która jest dostępna w [IPdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/ihtmloptions/) i [ITiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/itiffoptions/). Aby określić układ rozdania, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handoutlayoutingoptions/).

Aby ustawić wymiary i orientację strony rozdania przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/net/notes-size/).

## **Eksport w trybie rozdania**

Aby wyeksportować prezentację w trybie rozdania, ustaw własność `SlidesLayoutOptions` dla docelowych opcji eksportu i przypisz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handoutlayoutingoptions/), która definiuje liczbę slajdów na stronę oraz powiązane parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację na PDF w trybie rozdania.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Załaduj prezentację.
using var presentation = new Presentation("sample.pptx");

// Ustaw opcje eksportu.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 4 slajdy na jednej stronie w poziomie
        PrintSlideNumbers = true,                   // wydrukuj numery slajdów
        PrintFrameSlide = true,                     // wydrukuj ramkę wokół slajdów
        PrintComments = false                       // brak komentarzy
    }
};

// Eksportuj prezentację do PDF z wybranym układem.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
Pamiętaj, że właściwość `SlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

### Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie rozdania?

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handouttype/) do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

### Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/net/aspose.slides.export/handouttype/); dowolne układy nie są obsługiwane.

### Czy mogę uwzględnić ukryte slajdy w wyjściu rozdania?

Tak. Włącz opcję `ShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/).