---
title: Zarządzanie nagłówkami i stopkami prezentacji w C++
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/cpp/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiały rozdawnicze
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak zarządzać symbolami stopki, daty i godziny, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach rozdawniczych za pomocą Aspose.Slides for C++."
---
## **Przegląd**

PowerPoint używa różnych symboli nagłówka i stopki w zależności od typu strony. Aspose.Slides for C++ umożliwia kontrolowanie tekstu i widoczności tych symboli za pomocą interfejsów menedżera nagłówka/stopki.

Dostępne symbole zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz materiałów rozdawniczych | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie ma symbolu nagłówka. Nagłówki są dostępne na stronach notatek i materiałach rozdawniczych. Dla zwykłych slajdów użyj zamiast tego symboli stopki, daty/godziny oraz numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Interfejs [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideheaderfootermanager/) steruje jednym zwykłym slajdem. Interfejs [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslideheaderfootermanager/) steruje jednym slajdem notatek. Menedżerowie master i layout mogą także propagować ustawienia do zależnych slajdów, natomiast interfejs [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) steruje mistrzem materiału rozdawniczego.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych symboli i zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc wystarczy kontrolować ich widoczność.

Użyj [`SetFooterText`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) i [`SetDateTimeText`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) do ustawiania tekstu oraz [`SetFooterVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), i [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) aby wyświetlić odpowiednie symbole.

Poniższy kompletny przykład stosuje tę samą stopkę, tekst daty/godziny oraz widoczność numeru slajdu we wszystkich zwykłych slajdach:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

Jeśli musisz zaktualizować tylko jeden slajd, uzyskaj go bezpośrednio poprzez [`Presentation::get_Slide`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_slide/) zamiast iterować po całej kolekcji slajdów.

## **Ustaw nagłówki i stopki w mistrzu notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie symboli dla stron notatek. Użyj interfejsu [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) gdy chcesz zmienić tylko sam mistrz notatek.

Poniższy przykład ustawia nagłówek, stopkę i tekst daty/godziny w mistrzu notatek oraz sprawia, że wszystkie obsługiwane symbole są widoczne w tym mistrzu:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

Metoda [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) zwraca `nullptr`, gdy prezentacja nie zawiera mistrza notatek.

## **Zastosuj ustawienia mistrza notatek do podrzędnych slajdów notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki do siebie oraz do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji w [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) gdy te same ustawienia mają obowiązywać w całej hierarchii notatek.

Na przykład, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) i [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizują nagłówek mistrza notatek oraz wszystkie nagłówki podrzędne. Dostępne są równoważne metody dla stopek, daty/godziny i numerów slajdów.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

Metody propagacji użyte powyżej to [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), oraz [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Ustaw nagłówki i stopki na pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego interfejsu [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslideheaderfootermanager/) gdy chcesz dostosować tylko tę stronę notatek.

Metoda [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslidemanager/addnotesslide/) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

Jeśli najpierw propagujesz ustawienia z mistrza notatek, a następnie zmienisz pojedynczy slajd notatek, późniejsze ustawienia per‑slajd pozwalają dostosować tę stronę notatek niezależnie.

## **Ustaw nagłówki i stopki w mistrzu materiału rozdawniczego**

Strony materiału rozdawniczego używają mistrza materiału rozdawniczego dla swoich symboli nagłówka, stopki, daty/godziny i numeru strony. W przeciwieństwie do notatek, ustawienia materiału rozdawniczego zarządzane są przez mistrza materiału rozdawniczego, a nie przez pojedyncze slajdy rozdawnicze.

Użyj [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) aby uzyskać dostęp do mistrza materiału rozdawniczego. Jeśli nie istnieje, wywołaj [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) aby utworzyć domyślny mistrz materiału rozdawniczego.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslideheaderfootermanager/) steruje slajdem układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslideheaderfootermanager/) steruje zwykłym mistrzem slajdu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasternotesslideheaderfootermanager/) steruje mistrzem notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inotesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje symbol nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) zmienia mistrza materiału rozdawniczego i obsługuje wszystkie cztery typy symboli.

Używaj propagacji z mistrza lub układu, gdy to samo ustawienie ma obowiązywać w całej jego hierarchii. Używaj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebujesz lokalnego ustawienia dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje symbolu nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj symboli stopki, daty/godziny i numeru slajdu. Symbol nagłówka jest dostępny na stronach notatek i materiałach rozdawniczych.

**Co zrobić, gdy symbol stopki, daty/godziny lub numeru slajdu nie jest widoczny?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby ją włączyć. Na przykład, [`get_IsFooterVisible`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) informuje, czy symbol stopki jest obecny, a [`SetFooterVisibility`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Użyj [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/set_firstslidenumber/), aby ustawić pierwszy numer slajdu. Symbol numeru slajdu potem korzysta z zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane razem z resztą zawartości prezentacji w formacie wyjściowym. Ich wygląd zależy od typu eksportowanej strony oraz od odpowiednich ustawień widoczności symboli.