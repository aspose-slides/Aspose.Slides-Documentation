---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w C++
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/cpp/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Użyj Aspose.Slides for C++, aby skonfigurować układ normalnego widoku, przybliżenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wprowadzenie**

W normalnym widoku programu PowerPoint slajd wyświetlany jest pomiędzy bocznym panelem miniaturek lub konspektem a panelem notatek poniżej. Aspose.Slides dla C++ udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Obejmują one układ paneli, poziomy przybliżenia, odstępy siatki i widoczność komentarzy.

## **O INormalViewProperties**

Użyj [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/), aby uzyskać dostęp do interfejsu [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) pozwala bocznemu panelowi przyciągać się do stanu zminimalizowanego, gdy użytkownik go zwęża. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) kontroluje podziałkę między bocznym panelem a slajdem. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) kontroluje podziałkę nad panelem notatek. Oba przyjmują wartość typu [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu INormalViewProperties**

Kiedy podziałka jest przywracana, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) podaje zapisany rozmiar bocznego panelu, a [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) podaje zapisany rozmiar górnego obszaru slajdu. Oba udostępniają [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Metoda [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) przyjmuje procent od 0 do 100, a [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia rozmiar górnego obszaru slajdu udostępnionego przez [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) na 80% z włączonym automatycznym dostosowaniem oraz maksymalizuje pionową podziałkę. Włącza także ikony konspektu za pomocą [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) dla widoku konspektu.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ustaw domyślną wartość przybliżenia**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) i [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) przechowują niezależne ustawienia przybliżenia dla edytora. Te ustawienia nie wpływają na wymiary slajdów, odtwarzanie pokazu slajdów ani rozdzielczość eksportowanych obrazów.

Ten przykład otwiera istniejącą prezentację i włącza automatyczną skalowanie za pomocą [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/), aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i używa [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/), aby ustawić stałe przybliżenie 80%.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Ustaw odstęp siatki**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wyświetla bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o odległości ćwierć cala, ustawiając interwał na 18 punktów.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Siatka powtarza się w stałych odstępach. [Drawing guides](/slides/pl/cpp/drawing-guides/) oznaczają poszczególne pozycje poziome lub pionowe. Oba są pomocnikami edycji i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksporty do PDF, obrazów lub SVG ich nie zawierają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) przechowuje preferencję, której kompatybilne edytory używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wyświetla bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Wywołuje także [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) z [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/), aby kopia otworzyła się w widoku slajdu.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/cpp/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub wydrukach.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz widoczność siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Dodanie, przesunięcie lub usunięcie prowadnicy nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) dotyczy całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może także zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone z szablonu dziedziczą zapisane w nim ustawienia widoku.