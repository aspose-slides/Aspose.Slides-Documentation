---
title: Operacje prezentacji Low-Code w C++
linktitle: API Low-Code
type: docs
weight: 50
url: /pl/cpp/low-code-presentation-operations/
keywords:
- API prezentacji low-code
- konwertowanie prezentacji
- łączenie prezentacji
- iterowanie slajdów
- iterowanie kształtów
- iterowanie tekstu
- zbieranie kształtów
- kompresja prezentacji
- usuwanie nieużywanych slajdów mistrza
- usuwanie nieużywanych slajdów układu
- kompresja osadzonych czcionek
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Użyj niskokodowego API Aspose.Slides w C++, aby konwertować i łączyć prezentacje, iterować zawartość, zbierać kształty oraz zmniejszać rozmiar prezentacji."
---
## **Przegląd**

Przestrzeń nazw [Aspose::Slides::LowCode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/) zapewnia statyczne klasy pomocnicze do typowych operacji na prezentacjach. Te pomocniki opakowują często używane przepływy pracy modelu obiektowego w skoncentrowane metody, dzięki czemu możesz konwertować lub scalać pliki, przetwarzać elementy prezentacji, zbierać kształty i usuwać nieużywaną zawartość przy mniejszej ilości kodu.

Pomocniki low-code są najbardziej przydatne, gdy operacja dotyczy całego pliku lub prezentacji i domyślny przepływ pracy spełnia Twoje wymagania. Użyj pełnego [modelu obiektowego Aspose.Slides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/) wtedy, gdy potrzebujesz szczegółowej kontroli nad poszczególnymi slajdami, mistrzami, układami, kształtami, ustawieniami eksportu lub relacjami między elementami prezentacji.

Poniższa tabela podsumowuje dostępne pomocniki:

| Pomocnik | Zastosowanie |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/) | Konwertowanie prezentacji do innego formatu przy użyciu bezpośredniego wywołania plik-do-pliku. |
| [Merger](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/merger/) | Łączenie pełnych plików prezentacji w tym samym formacie. |
| [ForEach](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/) | Wykonywanie akcji dla każdego slajdu, kształtu, akapitu lub fragmentu tekstu. |
| [Collect](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/collect/) | Pobieranie kształtów z całej prezentacji w celu wielokrotnego przetwarzania lub analizy. |
| [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) | Usuwanie nieużywanych mistrzów i układów oraz zmniejszanie danych osadzonych czcionek. |

## **Konwertowanie prezentacji**

Użyj [Convert::AutoByExtension](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/autobyextension/) wtedy, gdy rozszerzenie pliku wyjściowego wystarczy do wyboru formatu eksportu. Metoda otwiera prezentację źródłową, określa wymagany format na podstawie ścieżki wyjściowej i zapisuje wynik.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Klasa [Convert](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/) udostępnia również dedykowane metody dla wyjść PDF, SVG, JPEG, PNG i TIFF. Użyj pełnego modelu obiektowego, gdy musisz sprawdzić lub zmodyfikować prezentację przed eksportem lub skonfigurować opcję eksportu, której nie udostępnia wybrany pomocnik. Zobacz [Convert Presentation](/cpp/convert-presentation/) po szczegółowe przepływy i opcje formatów.

## **Łączenie prezentacji**

Użyj [Merger::Process](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/merger/process/) aby połączyć pełne pliki prezentacji jednym wywołaniem. Prezentacje wejściowe muszą mieć ten sam format pliku.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Pomocnik jest odpowiedni, gdy wszystkie slajdy mają zostać dołączone do jednego wyniku bez indywidualnego wybierania lub mapowania. Użyj pełnego modelu obiektowego, gdy potrzebujesz scalić wybrane slajdy, zastosować docelowy mistrz lub układ, zachować sekcje explicite lub dopasować różne rozmiary slajdów. Zobacz [Merge Presentations](/cpp/merge-presentation/) dla takich scenariuszy.

## **Iterowanie po elementach prezentacji**

Klasa [ForEach](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/) wywołuje funkcję zwrotną dla każdego żądanego typu elementu prezentacji. Unika zagnieżdżonych pętli kolekcji i jest wygodna przy inspekcji lub zmianach formatowania w całej prezentacji.

Poniższy przykład używa [ForEach::Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/paragraph/) oraz [ForEach::Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/portion/) do inspekcji odpowiadających elementów:

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

Domyślnie przeglądanie kształtów i tekstu w całej prezentacji obejmuje slajdy normalne, mistrza i układu. Przeciążenia z parametrem `includeNotes` mogą również przetwarzać slajdy notatek. Użyj bezpośrednich pętli kolekcji, gdy ważna jest kolejność przeglądania, wczesne wyjście, filtrowanie przed wywołaniem funkcji zwrotnej lub szczegółowa kontrola rodzic‑dziecko.

## **Zbieranie kształtów**

Użyj [Collect::Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/collect/shapes/) gdy potrzebujesz kolekcji wszystkich kształtów w prezentacji, a nie funkcji zwrotnej dla każdego z nich. Jest to przydatne, gdy ten sam zestaw będzie filtrowany, zliczany lub przetwarzany wielokrotnie.

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

Użyj [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/) zamiast, gdy każdy kształt może być obsłużony od razu i nie musisz zachować zebranych wyników.

## **Kompresja zawartości prezentacji**

Klasa [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) może usuwać nieużywane elementy strukturalne i zmniejszać dane osadzonych czcionek:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) usuwa slajdy układu, które nie są referencjowane przez żaden normalny slajd.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) usuwa slajdy mistrza, które nie są już używane.
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

Usuwaj nieużywane układy przed nieużywanymi mistrzami, aby mistrz, który stanie się nieodwołany po czyszczeniu układów, mógł również zostać usunięty. Zapisz zoptymalizowaną prezentację do nowego pliku, jeśli później możesz potrzebować oryginalnych mistrzów, układów lub kompletnych danych osadzonych czcionek. Po więcej szczegółów zobacz [Slide Master](/cpp/slide-master/) i [Embedded Font](/cpp/embedded-font/).

## **FAQ**

**Kiedy powinienem używać API low-code zamiast pełnego modelu obiektowego?**

Używaj pomocników low-code, gdy standardowa operacja dotyczy całego pliku lub prezentacji i nie wymaga szczegółowej kontroli nad poszczególnymi elementami. Używaj pełnego modelu obiektowego, gdy musisz wybrać konkretne slajdy, kontrolować relacje mistrz‑układ, sprawdzić stan pośredni lub skonfigurować zachowanie, którego pomocnik nie udostępnia.

**Czy Merger może łączyć prezentacje w różnych formatach plików?**

Nie. [Merger::Process](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/merger/process/) wymaga, aby prezentacje wejściowe były w tym samym formacie. Najpierw skonwertuj pliki wejściowe do wspólnego formatu, na przykład przy użyciu [Convert::AutoByExtension](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/convert/autobyextension/), a następnie scal przetworzone pliki.

**Czy ForEach przetwarza slajdy mistrza, układu i notatek?**

[ForEach::Slide](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/slide/) iteruje przez normalne slajdy prezentacji. Operacje [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/paragraph/) i [ForEach::Portion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/portion/) obejmują domyślnie slajdy normalne, mistrza i układu. Użyj ich przeciążeń z `includeNotes` ustawionym na `true`, aby uwzględnić slajdy notatek.

**Jaka jest różnica między ForEach::Shape a Collect::Shapes?**

Użyj [ForEach::Shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/shape/), aby przetwarzać każdy kształt od razu za pomocą funkcji zwrotnej. Użyj [Collect::Shapes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/collect/shapes/), gdy potrzebujesz wyniku, który można zachować, filtrować, liczyć lub przeglądać wielokrotnie.

**Czy Compress zawsze zmniejsza rozmiar pliku prezentacji?**

Niekoniecznie. Wynik zależy od tego, czy prezentacja zawiera nieużywane układy, nieużywane mistrze lub osadzone czcionki z nieużywanymi znakami. Jeśli żadne z tych elementów nie występują, odpowiednie operacje [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/) mogą nie zmniejszyć rozmiaru pliku.

**Czy zmiany wprowadzone przez ForEach lub Compress są zapisywane automatycznie?**

Nie. Te pomocniki działają na załadowanym obiekcie [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) w pamięci. Po zmianie elementów w funkcji zwrotnej [ForEach](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/foreach/) lub po uruchomieniu [Compress](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/), wywołaj [Presentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/save/), aby zapisać wynik.

## **Powiązane artykuły**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)