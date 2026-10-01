---
title: Konwertuj prezentacje PowerPoint w trybie Handout przy użyciu C++
linktitle: Tryb Handout
type: docs
weight: 150
url: /pl/cpp/convert-powerpoint-in-handout-mode/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- tryb handout
- materiały pomocnicze
- PPT
- PPTX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Konwertuj prezentacje na materiały pomocnicze w C++. Ustaw liczbę slajdów na stronę, zachowaj notatki, eksportuj do PDF lub obrazów za pomocą Aspose.Slides, z przykładowym kodem. Wypróbuj za darmo."
---
## **Wprowadzenie**

Aspose.Slides zapewnia możliwość konwertowania prezentacji na różne formaty, w tym tworzenia materiałów pomocniczych do druku w trybie Handout. Tryb ten pozwala skonfigurować, jak wiele slajdów ma się pojawiać na jednej stronie, co jest przydatne na konferencjach, seminariach i innych wydarzeniach. Możesz włączyć ten tryb, wywołując metodę `set_SlidesLayoutOptions` w interfejsach [IPdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/ihtmloptions/) oraz [ITiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/itiffoptions/).

Aby ustawić wymiary i orientację strony materiału przed eksportem, zobacz [Rozmiar strony notatek](/slides/pl/cpp/notes-size/).

## **Eksport w trybie Handout**

Aby skonfigurować tryb Handout, użyj obiektu [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handoutlayoutingoptions/), który określa, ile slajdów ma być umieszczonych na jednej stronie oraz inne parametry wyświetlania.

Poniżej znajduje się przykład kodu pokazujący, jak przekonwertować prezentację do formatu PDF w trybie Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Wczytaj prezentację.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ustaw opcje eksportu.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slajdy na jednej stronie poziomo
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // wydrukuj numery slajdów
slidesLayoutOptions->set_PrintFrameSlide(true);                      // wydrukuj ramkę wokół slajdów
slidesLayoutOptions->set_PrintComments(false);                       // brak komentarzy

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Wyeksportuj prezentację do PDF z wybranym układem.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Pamiętaj, że metoda `set_SlidesLayoutOptions` jest dostępna tylko dla niektórych formatów wyjściowych, takich jak PDF, HTML, TIFF oraz przy renderowaniu jako obrazy.
{{% /alert %}} 

## **FAQ**

### Jaka jest maksymalna liczba miniatur slajdów na stronie w trybie Handout?

Aspose.Slides obsługuje [presety](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handouttype/) do 9 miniatur na stronę z układem poziomym lub pionowym: 1, 2, 3, 4 (poziomy/pionowy), 6 (poziomy/pionowy) oraz 9 (poziomy/pionowy).

### Czy mogę zdefiniować własną siatkę, na przykład 5 lub 8 slajdów na stronę?

Nie. Liczba i kolejność miniatur jest ściśle kontrolowana przez wyliczenie [HandoutType](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handouttype/); niestandardowe układy nie są obsługiwane.

### Czy mogę uwzględnić ukryte slajdy w wyjściu Handout?

Tak. Użyj metody `set_ShowHiddenSlides` w ustawieniach eksportu dla docelowego formatu, takiego jak [PdfOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/htmloptions/) lub [TiffOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/tiffoptions/).