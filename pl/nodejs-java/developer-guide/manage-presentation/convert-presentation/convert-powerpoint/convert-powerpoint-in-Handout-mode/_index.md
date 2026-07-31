---
title: Konwertuj prezentacje PowerPoint w trybie Handout przy użyciu JavaScript
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- materiały
- PPT
- PPTX
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje do formatu handout. Ustaw liczbę slajdów na stronie, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla Node.js, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides udostępnia możliwość konwertowania prezentacji do różnych formatów, w tym tworzenia notatek do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Ten tryb można włączyć, ustawiając metodę `setSlidesLayoutOptions` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/).

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów zostanie umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do formatu PDF w trybie Handout.

```js
// Wczytaj prezentację.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Ustaw opcje eksportu.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
slidesLayoutOptions.setPrintSlideNumbers(true);                                // drukuj numery slajdów
slidesLayoutOptions.setPrintFrameSlide(true);                                  // drukuj ramkę wokół slajdów
slidesLayoutOptions.setPrintComments(false);                                   // brak komentarzy

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Eksportuj prezentację do PDF z wybranym układem.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handouttype/) do 9 miniatur na stronę przy układzie poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) i 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Użyj metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/).