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
- rozkładka
- PPT
- PPTX
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Konwertuj prezentacje na materiały pomocnicze. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides dla Node.js, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji na różne formaty, w tym tworzenia materiałów pomocniczych do drukowania w trybie Handout. Ten tryb umożliwia skonfigurowanie, w jaki sposób wiele slajdów wyświetla się na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając metodę `setSlidesLayoutOptions` w klasach [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) i [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/).

Aby ustawić wymiary i orientację strony materiału pomocniczego przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/nodejs-java/notes-size/).

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handoutlayoutingoptions/), który określa, ile slajdów zostanie umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację na PDF w trybie Handout.

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
slidesLayoutOptions.setPrintSlideNumbers(true);                                // drukuj numery slajdów
slidesLayoutOptions.setPrintFrameSlide(true);                                  // drukuj ramkę wokół slajdów
slidesLayoutOptions.setPrintComments(false);                                   // brak komentarzy

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}

Pamiętaj, że metoda `setSlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.

{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronę w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handouttype/) do 9 miniatur na stronę z układaniem poziomym lub pionowym: 1, 2, 3, 4 (poziomo/pionowo), 6 (poziomo/pionowo) oraz 9 (poziomo/pionowo).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronę?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/handouttype/); niestandardowe układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyniku Handout?**

Tak. Użyj metody `setShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/).