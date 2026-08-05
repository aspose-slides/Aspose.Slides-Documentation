---
title: Konwertuj prezentacje PowerPoint w trybie rozdania za pomocą Java
linktitle: Tryb Rozdania
type: docs
weight: 150
url: /pl/java/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb rozdania
- rozdanie
- PPT
- PPTX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Konwertuj prezentacje na rozdania w Javie. Ustaw liczbę slajdów na stronie, zachowaj notatki, eksportuj do PDF lub obrazów za pomocą Aspose.Slides, z przykładowym kodem Java. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji do formatów wyjściowych obsługujących tryb rozdania. W tym trybie wiele slajdów jest rozmieszczonych na jednej stronie, co jest przydatne przy drukowaniu materiałów prezentacyjnych na konferencje, seminaria i podobne wydarzenia.

Tryb rozdania jest konfigurowany za pomocą metody `setSlidesLayoutOptions`, dostępnej w [IPdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihtmloptions/) oraz [ITiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiffoptions/). Aby określić układ rozdania, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/).

## **Eksport w Trybie Rozdania**

Aby wyeksportować prezentację w trybie rozdania, ustaw metodę `setSlidesLayoutOptions` dla docelowych opcji eksportu i przypisz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/), która określa liczbę slajdów na stronę oraz powiązane parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie rozdania.

```java
// Wczytaj prezentację.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ustaw opcje eksportu.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // drukuj numery slajdów
    slidesLayoutOptions.setPrintFrameSlide(true);                     // drukuj ramkę wokół slajdów
    slidesLayoutOptions.setPrintComments(false);                      // brak komentarzy

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Eksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
Należy pamiętać, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniaturek slajdów na stronie w trybie rozdania?**

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/) umożliwiając do 9 miniaturek na stronie z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?**

Nie. Liczba i kolejność miniaturek są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/); niestandardowe układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu rozdania?**

Tak. Włącz ukryte slajdy przy użyciu metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/).