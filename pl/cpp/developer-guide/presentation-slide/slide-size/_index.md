---
title: Zmień rozmiar slajdu prezentacji w C++
linktitle: Rozmiar slajdu
type: docs
weight: 70
url: /pl/cpp/slide-size/
keywords:
- rozmiar slajdu
- proporcje
- standard
- szerokokątny
- 4:3
- 16:9
- ustaw rozmiar slajdu
- zmień rozmiar slajdu
- niestandardowy rozmiar slajdu
- specjalny rozmiar slajdu
- unikalny rozmiar slajdu
- slajd w pełnym rozmiarze
- typ ekranu
- nie skaluj
- zapewnij dopasowanie
- maksymalizuj
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak szybko zmienić rozmiar slajdów w plikach PPT, PPTX i ODP za pomocą C++ i Aspose.Slides, optymalizując prezentacje dla dowolnego ekranu bez utraty jakości."
---
## **Wprowadzenie**

Aspose.Slides zapewnia kompleksowe narzędzia do regulacji rozmiaru slajdu i proporcji w prezentacjach PowerPoint, co jest kluczowe zarówno przy drukowaniu, jak i wyświetlaniu na ekranie.

Popularne rozmiary slajdów i proporcje:

- **Standard (proporcje 4:3)**: Idealne dla starszych ekranów i urządzeń.
- **Szerokokątny (proporcje 16:9)**: Zalecane dla nowoczesnych projektorów i wyświetlaczy.

Zapewnij spójność w całej prezentacji, ponieważ jeden rozmiar slajdu i proporcje obowiązują wszystkie slajdy. Aby uzyskać optymalne wyniki, ustaw wymiary slajdu na początku procesu tworzenia prezentacji, co pozwoli uniknąć komplikacji.

{{% alert color="info" %}} 
Domyślnie prezentacje tworzone przy użyciu Aspose.Slides używają standardowych proporcji 4:3.
{{% /alert %}}

Strony notatek i materiały do rozdania mają oddzielne wymiary od zwykłych slajdów. Zobacz [Notes Page Size](/slides/pl/cpp/notes-size/), aby zmienić ich rozmiar i orientację.

## **Zmiana rozmiaru slajdu w prezentacjach**

 Ten przykładowy kod pokazuje, jak zmienić rozmiar slajdu w prezentacji w C++ przy użyciu Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Określanie własnych rozmiarów slajdów w prezentacjach**

Jeśli standardowe rozmiary slajdów (4:3 i 16:9) nie odpowiadają Twoim potrzebom, możesz zdecydować się na określony, unikalny rozmiar slajdu. Na przykład, jeśli planujesz wydrukować slajdy w pełnym rozmiarze na niestandardowym układzie strony lub wyświetlać prezentację na określonych typach ekranów, prawdopodobnie skorzystasz z własnych ustawień rozmiaru prezentacji.

Ten przykładowy kod pokazuje, jak używać Aspose.Slides for C++ do określenia własnego rozmiaru slajdu w prezentacji w C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Rozmiar papieru A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Obsługa treści slajdu po zmianie rozmiaru**

Po zmianie rozmiaru slajdu w prezentacji zawartość slajdów (np. obrazy lub obiekty) może ulec zniekształceniu. Domyślnie obiekty są automatycznie skalowane, aby pasowały do nowego rozmiaru slajdu. Jednak przy zmianie rozmiaru slajdu możesz określić ustawienie, które definiuje, jak Aspose.Slides radzi sobie z zawartością slajdów.

W zależności od tego, co zamierzasz osiągnąć, możesz użyć jednego z następujących ustawień:

- `DoNotScale`

  Jeśli **nie** chcesz, aby obiekty na slajdach były skalowane, użyj tego ustawienia.

- `EnsureFit`

  Jeśli chcesz skalować do mniejszego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides zmniejszyło obiekty tak, aby wszystkie zmieściły się na slajdzie (w ten sposób unikasz utraty treści), użyj tego ustawienia.

- `Maximize`

  Jeśli chcesz skalować do większego rozmiaru slajdu i potrzebujesz, aby Aspose.Slides powiększyło obiekty, aby były proporcjonalne do nowego rozmiaru slajdu, użyj tego ustawienia.

Ten przykładowy kod pokazuje, jak używać ustawienia `Maximize` przy zmianie rozmiaru slajdu w prezentacji:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Czy mogę ustawić własny rozmiar slajdu przy użyciu jednostek innych niż cale (np. punktów lub milimetrów)?

Tak. Aspose.Slides wewnętrznie używa punktów, gdzie 1 punkt to 1/72 cala. Możesz przeliczyć dowolną jednostkę (taką jak milimetry lub centymetry) na punkty i użyć przeliczonej wartości do określenia szerokości i wysokości slajdu.

### Czy bardzo duży własny rozmiar slajdu wpłynie na wydajność i zużycie pamięci podczas renderowania?

Tak. Większe wymiary slajdu (w punktach) połączone z wyższą skalą renderowania prowadzą do zwiększonego zużycia pamięci i dłuższego czasu przetwarzania. Dąż do praktycznego rozmiaru slajdu i dostosowuj skalę renderowania tylko w razie potrzeby, aby uzyskać pożądaną jakość wyjścia.

### Czy mogę zdefiniować jeden niestandardowy rozmiar slajdu, a następnie scalać slajdy z prezentacji o różnych rozmiarach?

Nie możesz [merge presentations](/slides/pl/cpp/merge-presentation/) gdy mają różne rozmiary slajdów — najpierw zmień rozmiar jednej prezentacji, aby odpowiadał drugiej. Przy zmianie rozmiaru slajdu możesz wybrać, jak istniejąca zawartość jest obsługiwana za pomocą opcji [SlideSizeScaleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/). Po wyrównaniu rozmiarów możesz scalać slajdy, zachowując formatowanie.

### Czy mogę generować miniatury poszczególnych kształtów lub konkretnych obszarów slajdu i czy będą one respektować nowy rozmiar slajdu?

Tak. Aspose.Slides może renderować miniatury dla [entire slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/getimage/) oraz dla [selected shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/). Powstałe obrazy odzwierciedlają aktualny rozmiar i proporcje slajdu, zapewniając spójne kadrowanie i geometrię.