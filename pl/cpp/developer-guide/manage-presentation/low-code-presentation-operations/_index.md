---
title: Operacje prezentacji low-code w C++
linktitle: API low-code
type: docs
weight: 50
url: /pl/cpp/low-code-presentation-operations/
keywords:
- API low-code prezentacji
- konwertuj prezentację
- scal prezentacje
- iteruj slajdy
- iteruj kształty
- iteruj tekst
- zbieraj kształty
- kompresuj prezentację
- usuń nieużywane slajdy master
- usuń nieużywane slajdy układu
- kompresuj osadzone czcionki
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Użyj API low-code Aspose.Slides w C++, aby konwertować i scalać prezentacje, iterować zawartość, zbierać kształty i zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw Aspose::Slides::LowCode udostępnia statyczne klasy pomocnicze dla typowych operacji na prezentacjach. Te pomocniki opakowują często używane przepływy pracy modelu obiektowego w dedykowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego modelu obiektowego Aspose.Slides, gdy potrzebujesz precyzyjnej kontroli nad poszczególnymi slajdami, masterami, układami, kształtami, ustawieniami eksportu lub zależnościami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik‑do‑pliku. |
| [Merger](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/merger/) | Łączenie pełnych plików prezentacji tego samego formatu. |
| [ForEach](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu powtarzalnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych masterów i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertuj prezentację**

Użyj Convert::AutoByExtension, gdy rozszerzenie pliku wyjściowego wystarczy do wybrania formatu eksportu. Metoda otwiera źródłową prezentację, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Klasa Convert udostępnia także dedykowane metody dla wyjść PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, która nie jest dostępna w wybranym pomocniku. Zobacz [Convert Presentation](/slides/pl/cpp/convert-presentation/), aby poznać przepływy pracy i opcje specyficzne dla formatów.

## **Scal prezentacje**

Użyj Merger::Process, aby połączyć pełne pliki prezentacji jednym wywołaniem. Wejściowe prezentacje muszą mieć ten sam format pliku.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Ten pomocnik jest odpowiedni, gdy wszystkie slajdy powinny zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania ich. Użyj pełnego modelu obiektowego, gdy musisz scalić wybrane slajdy, zastosować docelowy master lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/slides/pl/cpp/merge-presentation/), aby poznać te scenariusze.

## **Iteruj przez elementy prezentacji**

Klasa ForEach wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianie formatowania na poziomie całej prezentacji.

Poniższy przykład używa ForEach::Slide, ForEach::Shape, ForEach::Paragraph i ForEach::Portion do inspekcji odpowiadających elementów:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Domyślnie przegląd kształtów i tekstu w całej prezentacji obejmuje slajdy normalne, master i układ. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Używaj bezpośrednich pętli kolekcji, gdy istotna jest kolejność przeglądania, wczesne zakończenie, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola relacji rodzic‑dziecko.

## **Zbierz kształty**

Użyj Collect::Shapes, gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, zamiast funkcji zwrotnej dla każdego kształtu. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, zliczany lub przetwarzany wielokrotnie.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Użyj ForEach::Shape, gdy każdy kształt może być obsłużony od razu i nie musisz przechowywać zebranego wyniku.

## **Skompresuj zawartość prezentacji**

Klasa Compress może usuwać nieużywane elementy strukturalne i zmniejszać dane osadzonych czcionek:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) usuwa slajdy układu, które nie są referencjonowane przez żaden normalny slajd.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) usuwa slajdy master, które nie są już używane.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) usuwa nieużywane znaki z osadzonych czcionek.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Usuń nieużywane układy przed nieużywanymi masterami, aby master, który stanie się nieodwoływany po czyszczeniu układów, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później będziesz potrzebować oryginalnych masterów, układów lub pełnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/slides/pl/cpp/slide-master/) i [Embedded Font](/slides/pl/cpp/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Użyj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować zależności master‑layout, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger::Process](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/merger/process/) wymaga, aby wejściowe prezentacje miały ten sam format. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert::AutoByExtension](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/autobyextension/), a następnie scal skonwertowane pliki.

**Czy ForEach przetwarza slajdy master, układ oraz notatek?**

[ForEach::Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/slide/) iteruje przez normalne slajdy prezentacji. Operacje [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/paragraph/) i [ForEach::Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/portion/) obejmują domyślnie slajdy normalne, master i układ. Użyj ich przeciążeń z `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica pomiędzy ForEach::Shape a Collect::Shapes?**

Użyj [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/), aby przetwarzać każdy kształt od razu w funkcji zwrotnej. Użyj [Collect::Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz wyliczalnego wyniku, który możesz zachować, filtrować, liczyć lub przeglądać wielokrotnie.

**Czy Compress zawsze powoduje zmniejszenie rozmiaru pliku prezentacji?**

Nie koniecznie. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mastery lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) w pamięci. Po zmianie elementów w wywołaniu zwrotnym [ForEach](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/), wywołaj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Konwertuj prezentację](/slides/pl/cpp/convert-presentation/)
- [Scal prezentacje](/slides/pl/cpp/merge-presentation/)
- [Slide Master](/slides/pl/cpp/slide-master/)
- [Zarządzaj polem tekstowym](/slides/pl/cpp/manage-textbox/)
- [Osadzona czcionka](/slides/pl/cpp/embedded-font/)