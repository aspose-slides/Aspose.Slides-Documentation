---
title: Konwertuj prezentacje PowerPoint w trybie ulotek przy użyciu Java
linktitle: Tryb ulotek
type: docs
weight: 150
url: /pl/java/convert-powerpoint-in-Handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb ulotek
- ulotka
- PPT
- PPTX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Konwertuj prezentacje na ulotki w Javie. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów z Aspose.Slides, z przykładowym kodem Java. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji do formatów wyjściowych, które obsługują tryb ulotek. W tym trybie wiele slajdów jest rozmieszczonych na jednej stronie, co jest przydatne przy drukowaniu materiałów prezentacyjnych na konferencje, seminaria i podobne wydarzenia.

Tryb ulotek konfiguruje się za pomocą metody `setSlidesLayoutOptions`, która jest dostępna w [IPdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihtmloptions/), oraz [ITiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiffoptions/). Aby określić układ ulotek, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/).

## **Eksport w trybie ulotek**

Aby wyeksportować prezentację w trybie ulotek, ustaw metodę `setSlidesLayoutOptions` w docelowych opcjach eksportu i przypisz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/), która definiuje liczbę slajdów na stronę oraz powiązane parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do formatu PDF w trybie ulotek.

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

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie ulotek?**

Aspose.Slides obsługuje [ustawienia wstępne](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/) do 9 miniatur na stronę z kolejnością poziomą lub pionową: 1, 2, 3, 4 (pozioma/pionowa), 6 (pozioma/pionowa) oraz 9 (pozioma/pionowa).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?**

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez klasę [HandoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/); dowolne układy nie są wspierane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu trybu ulotek?**

Tak. Włącz ukryte slajdy za pomocą metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/).