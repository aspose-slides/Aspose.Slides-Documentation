---
title: Konwertuj prezentacje PowerPoint w trybie Handout przy użyciu C++
linktitle: Tryb handout
type: docs
weight: 150
url: /pl/cpp/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- zestawienie
- PPT
- PPTX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Konwertuj prezentacje na zestawienia w C++. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów przy użyciu Aspose.Slides, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides umożliwia konwertowanie prezentacji do różnych formatów, w tym tworzenie zestawień do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się pojawić na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, ustawiając metodę `set_SlidesLayoutOptions` w interfejsach [IPdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ihtmloptions/), i [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/) .

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handoutlayoutingoptions/), który określa, ile slajdów ma być umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do formatu PDF w trybie Handout.

```cpp
// Załaduj prezentację.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ustaw opcje eksportu.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slajdy na jednej stronie w poziomie
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // wydrukuj numery slajdów
slidesLayoutOptions->set_PrintFrameSlide(true);                      // wydrukuj ramkę wokół slajdów
slidesLayoutOptions->set_PrintComments(false);                       // brak komentarzy

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Pamiętaj, że metoda `set_SlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz podczas renderowania jako obrazy.
{{% /alert %}} 

## **FAQ**

**Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie Handout?**

Aspose.Slides obsługuje [presets](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handouttype/) do 9 miniatur na stronie z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

**Czy mogę zdefiniować własną siatkę, np. 5 lub 8 slajdów na stronie?**

Nie. Liczba i kolejność miniatur są ściśle kontrolowane przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handouttype/); dowolne układy nie są obsługiwane.

**Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?**

Tak. Użyj metody `set_ShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/), lub [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/).