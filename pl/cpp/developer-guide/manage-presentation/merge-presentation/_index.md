---
title: Efektywne scalanie prezentacji w C++
linktitle: Scalanie prezentacji
type: docs
weight: 40
url: /pl/cpp/merge-presentation/
keywords:
- scal PowerPoint
- scal prezentacje
- scal slajdy
- scal PPT
- scal PPTX
- scal ODP
- połącz PowerPoint
- połącz prezentacje
- połącz slajdy
- połącz PPT
- połącz PPTX
- połącz ODP
- C++
- Aspose.Slides
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w C++ poprzez klonowanie slajdów, kontrolowanie masterów i układów, zmienianie rozmiaru treści slajdów, zachowanie sekcji oraz obsługę chronionych lub dużych plików."
---
## **Przegląd**

Aspose.Slides for C++ scala prezentacje, kopiując slajdy z jednej [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), która może zachować formatowanie slajdu źródłowego lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scal wszystkie slajdy zachowując formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj określony układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scaleniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym kompleksowym przepływie;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie wielowątkowości.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część swojego wyglądu z układu i mastera. Z tego powodu wybrany przez Ciebie overload metody klonowania określa, jak sklonowany slajd zostanie włączony do prezentacji docelowej.

Użyj [ISlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) w jednej z następujących wersji:

- `AddClone(sourceSlide)` — zachowuje układ i formatowanie slajdu źródłowego. W razie potrzeby master źródłowy może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, więc powtarzające się slajdy używające tego samego mastera źródłowego nie powodują wielokrotnego klonowania tego mastera.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do konkretnego docelowego [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/). Aspose.Slides poszukuje pasującego układu pod tym masterem według typu lub nazwy układu.
- `AddClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do konkretnego docelowego [ILayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/).

Master lub układ przekazany do overloadu `AddClone` musi należeć do **prezentacji docelowej**, a nie do prezentacji źródłowej.

## **Scal całe prezentacje i zachowaj formatowanie źródła**

Najprostsze scalanie kopiuje każdy slajd z prezentacji źródłowej do prezentacji docelowej. Jest to właściwy wybór, gdy zaimportowane slajdy powinny zachować oryginalny motyw, master i powiązania układów.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Powstała prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródła jest świadomie zachowywane.

## **Scal wybrane slajdy**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów z prezentacji źródłowej.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Sprawdzaj poprawność indeksów slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scal slajdy przy użyciu mastera docelowego**

Użyj overloadu [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) gdy zaimportowane slajdy powinny podążać za masterem, który już należy do prezentacji docelowej.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje odpowiedni układ i `allowCloneMissingLayout` ma wartość `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli ma wartość `false`, zostaje rzucony [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/details_pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się błędem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scal slajdy przy użyciu określonego układu docelowego**

Użyj overloadu [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) gdy dokładnie wiesz, którego układu docelowego mają używać zaimportowane slajdy.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Zastosowanie układu docelowego zmienia odziedziczoną relację układu; nie przerysowuje treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby potwierdzić, że odziedziczone formatowanie i zachowanie placeholderów jest odpowiednie.

## **Scal prezentacje o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przerysowuje automatycznie jego zawartości na nową powierzchnię. Kształty mogą więc wyglądać na przesunięte, nieoczekiwanie skalowane lub znajdować się poza widoczną częścią slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize::SetSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesize/setsize/) może skalować istniejącą zawartość przy jednoczesnej zmianie wymiarów slajdu. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/) skaluje zawartość, aby zmieściła się w żądanym rozmiarze.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej prezentacji źródłowej do innych operacji, otwórz osobną instancję do scalania.

## **Scal slajdy do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji prezentacji źródłowej. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i wyraźnie klonuj slajdy do nich przy użyciu [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Sklonowane slajdy są dopisywane do wskazanej sekcji docelowej. Aby zachować kilka sekcji źródłowych, odtwórz te sekcje w docelowej prezentacji i mapuj każdy slajd źródłowy do odpowiadającej sekcji docelowej.

## **Scal wiele prezentacji w bezpieczny sposób**

Poniższy przykładowy scenariusz end‑to‑end używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdego dodatkowego źródła, utrzymuje każde źródło otwarte tylko podczas kopiowania i zapisuje ostateczny plik jednorazowo.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Jest to użyteczna podstawa do zachowania formatowania źródłowego zaimportowanych slajdów. Jeśli wynik musi używać jednego motywu docelowego, zastąp prostą instrukcję `AddClone(slide)` odpowiednim overloadem mastera docelowego lub układu docelowego, przedstawionym wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie wprowadzić wymagany master źródłowy do prezentacji docelowej. Aspose.Slides utrzymuje wewnętrzny rejestr automatycznie klonowanych masterów, aby uniknąć wielokrotnego klonowania tego samego mastera. Mastery klonowane ręcznie nie są śledzone w tym rejestrze, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie równoważne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz wyraźnie master lub układ docelowy i zweryfikuj wynik po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane podczas klonowania slajdu. Aspose.Slides udostępnia także dedykowane API dla [presentation notes](https://docs.aspose.com/slides/pl/cpp/presentation-notes/) i [presentation comments](https://docs.aspose.com/slides/pl/cpp/presentation-comments/).

Jeśli ważne jest formatowanie strony notatek, zweryfikuj scalaną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą różnić się między plikami źródłowymi. W przepływach recenzenckich sprawdzaj także autorów komentarzy oraz wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, osadzone audio, osadzone wideo i dane OLE. Klonuj sam slajd, a nie tylko jego widoczne kształty, aby Aspose.Slides mógł zachować związki slajdu z jego zasobami.

Zasoby osadzone i linkowane należy traktować odrębnie. Linkowane audio, wideo, obiekt OLE lub hiperłącze pozostają zależne od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść osadzoną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym zostanie otwarta scalaną prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych prezentacji źródłowych zawsze zostaną oddeduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, sprawdź scalaną paczkę i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Czcionki osadzone i dostępność czcionek**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia musi pozostać spójna na różnych maszynach, nie zakładaj, że samodzielne klonowanie slajdów zapewni dostępność każdej wymaganej czcionki w środowisku docelowym. Możesz sprawdzić osadzone czcionki przy pomocy [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać osadzaniem zgodnie z opisem w [Embed Fonts in Presentations](https://docs.aspose.com/slides/pl/cpp/embedded-font/).

Sprawdź również, czy masz prawo do osadzania czcionek używanych w plikach źródłowych. Licencje czcionek mogą ograniczać możliwość osadzania.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte przed klonowaniem jego slajdów. Podaj hasło za pomocą [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Otwieranie zaszyfrowanego źródła nie powoduje automatycznego zastosowania tego samego zabezpieczenia w prezentacji docelowej. Ochronę wyjściową należy skonfigurować osobno, gdy jest wymagana.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą znacząco obciążać pamięć. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Manage Presentation BLOBs](https://docs.aspose.com/slides/pl/cpp/manage-blob/) po więcej strategii dotyczących dużych plików.

W przypadku dużych plików, o ile to możliwe, wczytuj je z ścieżek plików, zwalniaj każdą prezentację źródłową zaraz po jej scałowaniu i unikaj wielokrotnego zapisywania wyników pośrednich, chyba że przepływ pracy wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie wczytuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) jednocześnie z wielu wątków. Trzymaj każdą instancję prezentacji w zakresie jednej operacji scalania. Jeśli równolegle przetwarzasz niezależne zadania, używaj niezależnych instancji prezentacji i przestrzegaj [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/pl/cpp/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest potrzebny zaimportowanemu slajdowi.

**Jak sprawić, aby zaimportowane slajdy używały tematu docelowego?**

Użyj overloadu, który przyjmuje master docelowy. Przekaż master z prezentacji docelowej, a nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy używać określonego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy zaimportowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybierał spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przerysowywana do wymiarów docelowych. Zmniejsz rozmiar prezentacji źródłowej najpierw, gdy potrzebne jest przewidywalne rozmieszczenie, np. przy użyciu [SlideSize::SetSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/).

**Czy mogę scalić pliki PPT, PPTX i ODP w jeden plik?**

Tak. Wczytaj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz docelowy plik w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie obsługują dokładnie tego samego zestawu funkcji, po scaleniu międzyformatowym zweryfikuj złożoną zawartość. Zobacz [Supported File Formats](https://docs.aspose.com/slides/pl/cpp/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, przy podstawowej pętli, która tylko klonuje slajdy. Odtwórz wymagane sekcje w prezentacji docelowej i użyj overloadu sekcji [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane razem ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych przeglądowych wątków, zweryfikuj wynik scalania, ponieważ te scenariusze obejmują zarówno struktury na poziomie prezentacji, jak i treść slajdów.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość osadzona jest przenoszona jako część powiązań zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich pliki docelowe lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy osadzone czcionki ze wszystkich źródeł są gwarantowane w scentralizowanej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w celu dystrybucji czcionek. Sprawdź osadzone czcionki w docelowej prezentacji i wyraźnie zarządzaj ich osadzaniem lub dostępnością czcionek zewnętrznych, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go przy użyciu odpowiedniego [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/), a następnie normalnie sklonuj jego slajdy. Ochrona wyjściowa jest konfigurowana oddzielnie.

**Jak obsłużyć bardzo duże prezentacje?**

Używaj zarządzania BLOB, gdy duże obiekty binarne dominują w zużyciu pamięci, preferuj wczytywanie z ścieżek plików dla bardzo dużych plików, zwalniaj prezentacje źródłowe niezwłocznie po ich scałowaniu i zapisuj ostateczny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) jednocześnie w wielu wątkach. Każdą operację scalania utrzymuj w odrębnych instancjach prezentacji.