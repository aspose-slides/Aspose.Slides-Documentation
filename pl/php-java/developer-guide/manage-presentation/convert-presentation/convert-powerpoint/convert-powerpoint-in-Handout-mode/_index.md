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
description: "Konwertuj prezentacje do handoutów w PHP. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla PHP, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji do różnych formatów, w tym tworzenia notatek do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się wyświetlać na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając metodę `setSlidesLayoutOptions` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/).

Aby ustawić wymiary i orientację strony notatek przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/php-java/notes-size/).

## **Eksport trybu Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handoutlayoutingoptions/), który określa ile slajdów zostaje umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do PDF w trybie Handout.

```php
// Wczytaj prezentację.
$presentation = new Presentation("sample.pptx");

// Ustaw opcje eksportu.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // wydrukuj numery slajdów
$slidesLayoutOptions->setPrintFrameSlide(true);                      // wydrukuj ramkę wokół slajdów
$slidesLayoutOptions->setPrintComments(false);                       // brak komentarzy

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Wyeksportuj prezentację do PDF z wybranym układem.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniaturek slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [predefiniowane ustawienia](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/) do 9 miniaturek na stronie z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomo/pionowo), 6 (poziomo/pionowo) oraz 9 (poziomo/pionowo).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniaturek są ściśle kontrolowane przez klasę [HandoutType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/handouttype/), a dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Włącz ukryte slajdy, używając metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/).