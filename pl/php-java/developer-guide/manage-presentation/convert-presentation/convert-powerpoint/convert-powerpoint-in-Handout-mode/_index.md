---
title: Konwertuj prezentacje PowerPoint w trybie Handout przy użyciu PHP
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/php-java/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- handout
- PPT
- PPTX
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje na materiały pomocnicze w PHP. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla PHP, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wstęp**

Aspose.Slides umożliwia konwertowanie prezentacji do różnych formatów, w tym tworzenie materiałów pomocniczych do druku w trybie Handout. Tryb ten pozwala konfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Tryb można włączyć, ustawiając metodę `setSlidesLayoutOptions` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/), oraz [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) .

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów zostanie umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację na PDF w trybie Handout.

```php
// Załaduj prezentację.
$presentation = new Presentation("sample.pptx");

// Ustaw opcje eksportu.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // drukuj numery slajdów
$slidesLayoutOptions->setPrintFrameSlide(true);                      // drukuj ramkę wokół slajdów
$slidesLayoutOptions->setPrintComments(false);                       // brak komentarzy

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Wyeksportuj prezentację do PDF z wybranym układem.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Miej na uwadze, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniaturek slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/) do 9 miniaturek na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) i 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniaturek są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/); nieobsługiwane są dowolne układy.

**Czy mogę uwzględnić ukryte slajdy w wyniku Handout?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/).