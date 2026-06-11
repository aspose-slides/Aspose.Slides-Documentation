---
title: Konwertowanie prezentacji PowerPoint w trybie Handout przy użyciu PHP
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/php-java/convert-powerpoint-in-Handout-mode/
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
description: "Konwertuj prezentacje do notatek w PHP. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla PHP, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji do różnych formatów, w tym tworzenia notatek do druku w trybie Handout. Ten tryb pozwala skonfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając metodę `setSlidesLayoutOptions` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/) .

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów jest umieszczanych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```php
// Załaduj prezentację.
$presentation = new Presentation("sample.pptx");

// Ustaw opcje eksportu.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // wydrukuj numery slajdów
$slidesLayoutOptions->setPrintFrameSlide(true);                      // wydrukuj ramkę wokół slajdów
$slidesLayoutOptions->setPrintComments(false);                       // brak komentarzy

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Eksportuj prezentację do PDF z wybranym układem.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronę w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/) do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) i 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/).