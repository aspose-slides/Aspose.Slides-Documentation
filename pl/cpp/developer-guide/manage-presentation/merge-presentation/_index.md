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
description: "Dowiedz się, jak scalać prezentacje PowerPoint i OpenDocument w C++ poprzez klonowanie slajdów, kontrolowanie masterów i układów, zmianę rozmiaru zawartości slajdów, zachowywanie sekcji oraz obsługę zabezpieczonych lub dużych plików."
---
## **Przegląd**

Aspose.Slides for C++ scala prezentacje, kopiując slajdy z jednej [Prezentacji](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) do drugiej. Główną operacją jest [ISlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), który może zachować formatowanie slajdu źródłowego lub dołączyć sklonowany slajd do mastera lub układu w prezentacji docelowej.

Ten artykuł opisuje najczęstsze scenariusze scalania:

- scal wszystkie slajdy, zachowując ich formatowanie źródłowe;
- scal wybrane slajdy;
- zastosuj master z prezentacji docelowej;
- zastosuj konkretny układ z prezentacji docelowej;
- znormalizuj różne rozmiary slajdów przed scalaniem;
- dodaj sklonowane slajdy do sekcji;
- scal kilka prezentacji w jednym przepływie od początku do końca;
- obsłuż mastery, zasoby, notatki, komentarze, multimedia, czcionki, hasła, duże pliki i kwestie związane z wielowątkowością.

## **Jak klonowanie slajdów wpływa na mastery i układy**

Slajd dziedziczy dużą część wyglądu z układu i mastera. Z tego powodu wybrany przeciążony wariant klonowania określa, w jaki sposób połączony slajd zostanie wprowadzony do prezentacji docelowej.

Użyj [ISlideCollection::AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) w jednej z następujących form:

- `AddClone(sourceSlide)` — zachowuje układ i formatowanie slajdu źródłowego. W razie potrzeby master źródłowy może zostać automatycznie sklonowany do prezentacji docelowej. Aspose.Slides automatycznie śledzi sklonowane mastery, więc powtarzające się slajdy używające tego samego mastera nie powodują wielokrotnego klonowania.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — dołącza sklonowany slajd do konkretnego [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/) w prezentacji docelowej. Aspose.Slides szuka pasującego układu pod tym masterem według typu układu lub nazwy.
- `AddClone(sourceSlide, destinationLayout)` — dołącza sklonowany slajd bezpośrednio do konkretnego [ILayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/).

Master lub układ przekazany do przeciążenia `AddClone` musi należeć do **prezentacji docelowej**, a nie do źródłowej.

## **Scalanie całych prezentacji i zachowanie formatowania źródłowego**

Najprostsze scalanie kopiuje każdy slajd ze źródłowej prezentacji do prezentacji docelowej. To właściwy wybór, gdy importowane slajdy powinny zachować swój oryginalny motyw, master i powiązania układu.

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

W rezultacie prezentacja może zawierać wiele masterów, gdy źródło i cel używają różnych projektów. Jest to oczekiwane, gdy formatowanie źródłowe jest celowo zachowywane.

## **Scalanie wybranych slajdów**

Nie musisz klonować każdego slajdu. Poniższy przykład importuje tylko wybrane indeksy slajdów ze źródłowej prezentacji.

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

Sprawdzaj indeksy slajdów przed klonowaniem, gdy pochodzą one od użytkownika lub z zewnętrznej konfiguracji.

## **Scalanie slajdów przy użyciu mastera docelowego**

Użyj przeciążenia [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), gdy importowane slajdy mają korzystać z mastera, który już należy do prezentacji docelowej.

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

Aspose.Slides wybiera odpowiedni układ pod określonym masterem, dopasowując typ lub nazwę układu źródłowego. Jeśli nie istnieje pasujący układ i `allowCloneMissingLayout` ma wartość `true`, układ źródłowy jest klonowany, aby slajd mógł zostać dodany. Jeśli ma wartość `false`, zostaje zgłoszony [PptxEditException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/details_pptxeditexception/).

Użyj `false`, gdy chcesz, aby scalanie zakończyło się niepowodzeniem zamiast wprowadzania dodatkowego układu do mastera docelowego.

## **Scalanie slajdów przy użyciu konkretnego układu docelowego**

Użyj przeciążenia [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), gdy dokładnie wiesz, którego układu docelowego mają używać importowane slajdy.

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

Zastosowanie układu docelowego zmienia dziedziczoną relację układu; nie przetwarza treści slajdu źródłowego. Jeśli układy źródłowy i docelowy mają różne struktury placeholderów, sprawdź wynik, aby upewnić się, że dziedziczone formatowanie i zachowanie placeholderów są odpowiednie.

## **Scalanie prezentacji o różnych rozmiarach slajdów**

Prezentacje o różnych wymiarach slajdów można scalać, ale klonowanie slajdu do prezentacji o innym rozmiarze nie przetwarza automatycznie jego zawartości na nową powierzchnię. Kształty mogą więc zostać przesunięte, skalowane nieoczekiwanie lub znajdować się poza widocznym obszarem slajdu.

Praktycznym podejściem jest zmiana rozmiaru prezentacji źródłowej przed klonowaniem. Metoda [SlideSize::SetSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesize/setsize/) może skalować istniejącą zawartość przy jednoczesnej zmianie wymiarów slajdu. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/) skaluje treść, aby zmieściła się w żądanym rozmiarze.

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

Zmiana rozmiaru modyfikuje obiekt prezentacji źródłowej w pamięci. Jeśli potrzebujesz niezmienionej wersji źródła do innych operacji, otwórz osobną instancję na potrzeby scalania.

## **Scalanie slajdów do sekcji prezentacji**

Podstawowa pętla klonowania slajdów nie odtwarza hierarchii sekcji źródłowej prezentacji. Jeśli sekcje mają znaczenie w wyniku, utwórz lub wybierz sekcje w prezentacji docelowej i klonuj slajdy do nich jawnie przy użyciu [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/).

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

Sklonowane slajdy są dopisywane do określonej sekcji docelowej. Aby zachować kilka sekcji źródłowych, wylicz [Presentation::get_Sections](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sections/), pobierz bieżące slajdy każdej sekcji źródłowej za pomocą [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/getslideslistofsection/), odtwórz sekcje w prezentacji docelowej i klonuj każdy zwrócony slajd do odpowiadającej mu sekcji docelowej. Zobacz [Zarządzanie sekcjami slajdów](/slides/pl/cpp/slide-section/) po kompletny przykład wyliczania sekcji, w tym sekcje puste i zmiany strukturalne.

## **Bezpieczne scalanie wielu prezentacji**

Poniższy przykład od początku do końca używa pierwszej prezentacji jako docelowej, normalizuje rozmiar slajdu każdej kolejnej źródłowej, utrzymuje każde źródło otwarte tylko w czasie kopiowania i zapisuje ostateczny plik jednorazowo.

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

Jest to przydatna podstawa do zachowania formatowania źródłowego importowanych slajdów. Jeśli wynik ma używać jednego motywu docelowego, zastąp prostą metodę `AddClone(slide)` odpowiednim przeciążeniem mastera lub układu docelowego, jak pokazano wcześniej.

## **Praktyczne uwagi**

### **Mastery, układy i wierność formatowania**

Domyślne klonowanie slajdów może automatycznie przenieść wymagany master źródłowy do prezentacji docelowej. Aspose.Slides prowadzi wewnętrzny rejestr automatycznie sklonowanych masterów, aby uniknąć ich wielokrotnego klonowania. Ręcznie sklonowane mastery nie są rejestrowane, więc unikaj wstępnego klonowania masterów, chyba że potrzebujesz wyraźnej kontroli nad strukturą mastera.

Nie zakładaj, że dwa mastery lub układy o tej samej nazwie są wizualnie identyczne. Jeśli szablon korporacyjny ma kontrolować ostateczny wygląd, wybierz master lub układ docelowy wyraźnie i zweryfikuj rezultat po scaleniu.

### **Notatki i komentarze**

Notatki prelegenta i komentarze slajdów są powiązane z treścią slajdu i są kopiowane przy klonowaniu slajdu. Aspose.Slides udostępnia także dedykowane API dla [notatek w prezentacji](/slides/pl/cpp/presentation-notes/) i [komentarzy w prezentacji](/slides/pl/cpp/presentation-comments/).

Jeśli formatowanie strony notatek jest istotne, sprawdź scaloną prezentację, ponieważ mastery notatek są obiektami na poziomie prezentacji i mogą się różnić między plikami źródłowymi. W procesach przeglądu zweryfikuj także autorów komentarzy i wątki komentarzy po połączeniu plików od różnych autorów lub szablonów.

### **Obrazy, audio, wideo, obiekty OLE i linki zewnętrzne**

Slajdy mogą odwoływać się do zasobów na poziomie prezentacji, takich jak obrazy, wbudowane audio, wbudowane wideo i dane OLE. Sklonuj sam slajd, a nie tylko jego widoczne kształty, aby Aspose.Slides mógł zachować powiązania slajdu z zasobami.

Zasoby wbudowane i linkowane należy traktować inaczej. Linkowany audio, wideo, obiekt OLE lub hiperłącze pozostaje zależny od zewnętrznego celu; klonowanie slajdu nie zamienia linku zewnętrznego w treść wbudowaną. Testuj ścieżki i adresy URL zasobów linkowanych w środowisku, w którym otwierana będzie scalona prezentacja.

Aspose.Slides wyraźnie śledzi automatycznie klonowane mastery, ale nie należy tego traktować jako ogólnej gwarancji, że identyczne zasoby binarne z niepowiązanych źródeł zawsze zostaną zduplikowane. Jeśli rozmiar pliku wyjściowego jest istotny, przeanalizuj scalony pakiet i zmierz wynik zamiast polegać na domyślnej deduplikacji.

### **Wbudowane czcionki i ich dostępność**

Czcionki są zarządzane na poziomie prezentacji. Jeśli typografia ma pozostać spójna na różnych maszynach, nie zakładaj, że sam klon slajdów zapewnia dostępność wszystkich potrzebnych czcionek w środowisku docelowym. Możesz sprawdzić wbudowane czcionki przy pomocy [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getembeddedfonts/) i zarządzać wbudowywaniem explicite, jak opisano w [Wbudowywanie czcionek w prezentacjach](/slides/pl/cpp/embedded-font/).

Upewnij się także, że masz prawo do wbudowywania czcionek użytych w plikach źródłowych. Licencje czcionek mogą ograniczać ich wbudowywanie.

### **Prezentacje zabezpieczone hasłem**

Źródło zabezpieczone hasłem musi zostać pomyślnie otwarte przed klonowaniem jego slajdów. Hasło podaje się przez [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Otwarcie zaszyfrowanego źródła nie nakłada automatycznie tego samego zabezpieczenia na prezentację docelową. Odpowiednie zabezpieczenie wyjścia konfiguruje się osobno, gdy jest to wymagane.

### **Duże prezentacje i zużycie pamięci**

Duże prezentacje zawierające obrazy wysokiej rozdzielczości, audio, wideo lub inne duże obiekty binarne mogą pochłaniać znaczną ilość pamięci. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) zapewnia kontrolę nad obsługą BLOB‑ów i użyciem plików tymczasowych. Zobacz [Zarządzanie BLOB‑ami w prezentacji](/slides/pl/cpp/manage-blob/) po strategie obsługi dużych plików.

W przypadku dużych plików preferuj ładowanie z pełnych ścieżek, zwalniaj każdą prezentację źródłową natychmiast po scaleniu i unikaj powtarzalnego zapisywania wyników pośrednich, chyba że przepływ wymaga punktów kontrolnych.

### **Bezpieczeństwo wątków**

Nie ładuj, nie modyfikuj, nie zapisuj ani nie klonuj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) równocześnie z wielu wątków. Każda instancja prezentacji powinna być ograniczona do jednej operacji scalania. Jeśli równolegle przetwarzasz niezależne zadania, używaj oddzielnych instancji prezentacji i stosuj wytyczne [wielowątkowości Aspose.Slides](/slides/pl/cpp/multithreading/).

## **FAQ**

**Jak zachować oryginalny projekt każdej prezentacji źródłowej?**

Użyj [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/) bez podawania mastera lub układu docelowego. Aspose.Slides może automatycznie sklonować master źródłowy, gdy jest on potrzebny importowanemu slajdowi.

**Jak sprawić, aby importowane slajdy korzystały z tematu docelowego?**

Użyj przeciążenia przyjmującego master docelowy. Przekaż master z prezentacji docelowej, nie ze źródłowej. Aspose.Slides spróbuje dopasować każdy slajd źródłowy do odpowiedniego układu pod tym masterem.

**Kiedy powinienem użyć konkretnego układu docelowego zamiast mastera docelowego?**

Użyj konkretnego układu, gdy każdy importowany slajd ma korzystać z jednego znanego układu. Użyj mastera, gdy chcesz, aby Aspose.Slides wybrał układ spośród układów tego mastera na podstawie typu lub nazwy układu źródłowego.

**Czy można scalać prezentacje o różnych rozmiarach slajdów?**

Tak, ale zawartość slajdu nie jest automatycznie przystosowywana do wymiarów docelowych. Najpierw zmień rozmiar prezentacji źródłowej, jeśli potrzebne jest przewidywalne rozmieszczenie, np. przy pomocy [SlideSize::SetSize](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesize/setsize/) i [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidesizescaletype/).

**Czy mogę scalać pliki PPT, PPTX i ODP w jedną prezentację?**

Tak. Załaduj każdą prezentację źródłową, sklonuj wymagane slajdy do jednej prezentacji docelowej i zapisz ją w obsługiwanym formacie wyjściowym. Ponieważ formaty prezentacji nie oferują dokładnie tego samego zestawu funkcji, po scaleniu międzyformatowym zweryfikuj złożoną zawartość. Zobacz [Obsługiwane formaty plików](/slides/pl/cpp/supported-file-formats/).

**Czy sekcje źródłowe są zachowywane automatycznie?**

Nie, nie przy podstawowej pętli, która tylko klonuje slajdy. Utwórz wymagane sekcje w prezentacji docelowej i użyj przeciążenia sekcji w [AddClone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/), gdy struktura sekcji musi być zachowana.

**Czy notatki prelegenta i komentarze są zachowywane?**

Są kopiowane razem ze sklonowanym slajdem. W przepływach zależnych od stylizacji mastera notatek, autorów komentarzy lub danych przeglądu wątkowego, sprawdź wynik scalania, ponieważ te scenariusze obejmują zarówno struktury na poziomie prezentacji, jak i treść slajdu.

**Co się dzieje z audio, wideo, obiektami OLE i hiperłączami?**

Zawartość wbudowana jest przenoszona jako część relacji zasobów sklonowanego slajdu. Linki zewnętrzne pozostają zewnętrzne, więc ich docelowe pliki lub adresy URL muszą być nadal dostępne po scaleniu.

**Czy wszystkie wbudowane czcionki z każdego źródła są dostępne w scalonej prezentacji?**

Nie polegaj wyłącznie na klonowaniu slajdów w kwestii wdrażania czcionek. Sprawdź wbudowane czcionki w docelowej prezentacji i zarządzaj ich wbudowywaniem lub dostępnością zewnętrzną, gdy typografia jest istotna.

**Jak scalić plik zabezpieczony hasłem?**

Otwórz go z właściwym [LoadOptions::set_Password](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_password/), a następnie normalnie sklonuj jego slajdy. Zabezpieczenie wyjścia konfiguruje się osobno.

**Jak radzić sobie z bardzo dużymi prezentacjami?**

Używaj zarządzania BLOB‑ami, gdy duże obiekty binarne dominują w zużyciu pamięci, preferuj ładowanie z pełnych ścieżek dla bardzo dużych plików, zwalniaj prezentacje źródłowe niezwłocznie po ich scaleniu i zapisuj ostateczny wynik tylko wtedy, gdy jest to konieczne.

**Czy mogę scalać slajdy z wielu wątków?**

Nie używaj jednej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) równocześnie w wielu wątkach. Każda operacja scalania powinna mieć własną, odrębną instancję prezentacji.