---
title: Konwertuj prezentacje PowerPoint w trybie materiału przy użyciu Java
linktitle: Tryb materiału
type: docs
weight: 150
url: /pl/java/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb materiału
- materiał
- PPT
- PPTX
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Konwertuj prezentacje do materiałów w języku Java. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides, z przykładowym kodem Java. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides pozwala konwertować prezentacje do formatów wyjściowych, które obsługują tryb materiału rozdysponowanego. W tym trybie wiele slajdów jest rozmieszczonych na jednej stronie, co jest przydatne przy drukowaniu materiałów prezentacji na konferencje, seminaria i podobne wydarzenia.

Tryb materiału rozdysponowanego konfiguruje się za pomocą metody `setSlidesLayoutOptions`, która jest dostępna w [IPdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihtmloptions/), oraz [ITiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itiffoptions/). Aby określić układ materiału, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/) .

Aby ustawić wymiary i orientację strony materiału przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/java/notes-size/).

## **Eksport trybu materiału**

Aby wyeksportować prezentację w trybie materiału, ustaw metodę `setSlidesLayoutOptions` dla docelowych opcji eksportu i przypisz instancję [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handoutlayoutingoptions/) , która definiuje liczbę slajdów na stronę oraz powiązane parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak skonwertować prezentację do formatu PDF w trybie materiału.

```java
import com.aspose.slides.*;

// Wczytaj prezentację.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Ustaw opcje eksportu.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // wydrukuj numery slajdów
    slidesLayoutOptions.setPrintFrameSlide(true);                     // wydrukuj ramkę wokół slajdów
    slidesLayoutOptions.setPrintComments(false);                      // bez komentarzy

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Wyeksportuj prezentację do PDF z wybranym układem.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Ostrzeżenie" %}}
Zwróć uwagę, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie materiału?**

Aspose.Slides obsługuje [predefiniowane ustawienia](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/) do 9 miniatur na stronie z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez klasę [HandoutType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/handouttype/) ; własne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu trybu materiału?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/htmloptions/), lub [TiffOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/tiffoptions/).