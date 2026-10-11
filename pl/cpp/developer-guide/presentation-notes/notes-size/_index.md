---
title: "Zmień rozmiar i orientację strony notatek w C++"
linktitle: "Rozmiar strony notatek"
type: docs
weight: 10
url: /pl/cpp/notes-size/
keywords:
- "rozmiar strony notatek"
- "orientacja notatek"
- "notatki poziome"
- "notatki pionowe"
- "rozmiar wersji konspektu"
- "PowerPoint"
- "prezentacja"
- "PPT"
- "PPTX"
- "C++"
- "Aspose.Slides"
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla C++, zmień orientację, zweryfikuj zapisane rozmiary oraz wyeksportuj notatki lub wersje konspektu do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation::get_NotesSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_notessize/), aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca ona obiekt [INotesSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotessize/), którego metoda [set_Size](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotessize/set_size/) ustawia wymiary. Chociaż obiekt ustawień notatek nie może być zastąpiony, można zmienić jego rozmiar.

Szerokość i wysokość są określane w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_notessize/) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie wersji konspektu. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slidesize/) | Kontroluje wymiary standardowych slajdów prezentacji za pomocą [ISlideSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidesize/). |

Zmiana któregokolwiek ustawienia nie zmienia automatycznie drugiego. Zmiana orientacji strony notatek nie obraca również standardowych slajdów. Zobacz [Slide Size](/slides/pl/cpp/slide-size/), aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Do przykładów eksportu użyj prezentacji zawierającej co najmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona oznacza orientację poziomą, wyższa – orientację pionową, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez przyjmowania standardowego rozmiaru papieru.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Przełącz na orientację poziomą bez zmiany rozmiaru papieru**

Aby zmienić jedynie orientację, zamień miejscami istniejącą szerokość i wysokość. Zachowuje to długości obu stron, w tym te z niestandardowego rozmiaru papieru. Poniższy warunek zapobiega zmianie już poziomej strony na pionową i pozostawia niezmienioną stronę kwadratową.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.get_Width() > size.get_Height()`. Nie podstawiaj wymiarów A4 ani Letter, chyba że również chcesz zmienić rozmiar papieru.

## **Ustaw i zweryfikuj własny rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/), aby zapisać prezentację. Ten przykład ustawia stronę poziomą o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisaną plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja dokładności dla każdego formatu pliku.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Oczekiwanym wynikiem jest `900 x 600 points` oraz `Size preserved: True`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie tylko ustawienia w pamięci.

## **Eksport notatek i wersji konspektu**

Wymiary strony definiują dostępny obszar dla układów notatek lub konspektu. Nie włączają one tych układów samodzielnie: należy również skonfigurować opcje eksportu. Eksport standardowych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notescommentslayoutingoptions/) do [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/), aby uwzględnić notatki w PDF. Ten przykład renderuje również pierwszy slajd z notatkami do PNG przy użyciu [Slide::GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slide/getimage/) oraz [RenderingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej PNG ma 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wyjście rastrowe, którego wymiary zależą także od skali renderowania.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Przy eksporcie PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/notespositions/) umożliwia dodanie dodatkowych stron w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wyjście pod kątem przyciętych notatek i rozmieszczenia istniejących obiektów notes‑master; zmiana samych wymiarów strony nie powinna być traktowana jako gwarancja zmieszczenia całej zawartości. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/cpp/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport wersji konspektu do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handoutlayoutingoptions/) do umieszczenia wielu miniatur slajdów na jednej stronie. Poniższy przykład ustawia stronę o wymiarach 900 × 600 punktów i używa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/handouttype/), aby ułożyć do czterech slajdów na stronie. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony wynika z jej szerokości i wysokości.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Zmiana rozmiaru strony zmienia dostępny obszar dla siatki wersji konspektu, nie zmieniając wymiarów slajdów źródłowych. Do obrazów wersji konspektu użyj [Presentation::GetImages](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/getimages/) z układem konspektu, zamiast metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie wersji konspektu na poziomie prezentacji używa wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie generuje strony konspektu. Zobacz [Handout Mode](/slides/pl/cpp/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksporcie i drukowaniu**

- **Przeglądarki prezentacji:** Przeglądarka może wyświetlać lub drukować notatki zgodnie z własnymi zasadami układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu w tej aplikacji może je znormalizować.
- **Formaty eksportu:** Przykłady PDF z notatkami i wersjami konspektu powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport standardowych slajdów nie uwzględnia rozmiaru strony notatek.
- **Sterowniki drukarek:** Wybór papieru, automatyczna rotacja i ustawienia dopasowania do strony mogą zmienić fizyczny wynik bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale ta właściwość nie zapewnia odrębnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru standardowych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj jej wymiary notatek. Jeśli uległy zmianie, sprawdź, czy zapisanie lub konwersja pliku w innej aplikacji zmieniła ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki i wybór papieru w drukarce.