---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w C++
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/cpp/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla C++, aby dostosować formaty slajdów PPT, PPTX i ODP - regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Ta informacja pozwala aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) została dodana, aby zapewnić dostęp do właściwości normalnego widoku prezentacji.  

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewrestoredproperties/) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/splitterbarstatetype/) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony, jeśli wyświetla zawartość konspektu w dowolnym z regionów zawartości trybu widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy podziałnik powinien przełączać się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik preferuje pełnoekranowy pojedynczy region zawartości zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli jest włączona, aplikacja może wyświetlić jeden z regionów w całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim powinien być wyświetlany pasek podziałnika poziomego lub pionowego. Pionowy pasek podziałnika oddziela slajd od bocznego regionu zawartości, poziomy pasek podziałnika oddziela slajd od regionu zawartości pod slajdem. Możliwe wartości to: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy zastosowano wartość **SplitterBarStateType.Restored** dla **VerticalBarState** oraz **HorizontalBarState** odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy region ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).  

Właściwość **DimensionSize** określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft).

Właściwość **AutoAdjust** określa, czy boczny region zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Przykład poniżej pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Przywróć właściwości widoku prezentacji
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ustaw domyślną wartość powiększenia**

Aspose.Slides for C++ obsługuje teraz ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) prezentacji. Właściwości widoku slajdu oraz [get_NotesViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) można ustawić programowo. W tym temacie pokażemy, jak przy pomocy przykładu ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Ustaw właściwości widoku [Properties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) prezentacji.
3. Zapisz prezentację jako plik PPTX.

W podanym poniżej przykładzie ustawiliśmy wartość powiększenia dla widoku slajdu oraz widoku notatek.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ustawianie właściwości widoku prezentacji
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Wartość powiększenia w procentach dla widoku slajdu
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Wartość powiększenia w procentach dla widoku notatek 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Ustaw odstęp siatki**

Użyj [Presentation::get_ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/), aby uzyskać dostęp do ustawień widoku na poziomie całej prezentacji. Metody [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_gridspacing/) i [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/set_gridspacing/) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odstęp siatki podawany jest w punktach, przy czym 72 punkty = 1 cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla aktualny odstęp siatki, ustawia odstęp ćwierć cala i zapisuje wynik.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Siatka różni się od [drawing guides](/slides/pl/cpp/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe to indywidualnie pozycjonowane linie wyrównania poziome lub pionowe. Dodawanie, przesuwanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze podczas otwierania prezentacji**

Użyj [Presentation::get_ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/), aby uzyskać dostęp do ustawień widoku na poziomie prezentacji. Użyj [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_showcomments/) i [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/set_showcomments/), aby zapisać preferencję dotyczącą wyświetlania komentarzy przy otwieraniu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To ustawienie kontroluje jedynie zapisaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/cpp/presentation-comments/) po operacje, które zmieniają same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wyświetla bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Używa również [IViewProperties::set_LastView](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/set_lastview/) z [ViewType::SlideView](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewtype/), aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

To ustawienie nie określa, czy komentarze zostaną uwzględnione w eksportach PDF, HTML, obrazu, notatek lub materiałów rozdawniczych. Skonfiguruj odpowiednie opcje eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki są odrębnymi ustawieniami. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

Ustawienia widoku ([View settings](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/)) definiowane są na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), nie per sekcja, więc jeden zestaw parametrów obowiązuje dla całego dokumentu przy otwieraniu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje odtwarzające mogą honorować preferencje użytkownika, ale sam plik zawiera jedną grupę właściwości widoku.

**Czy mogę przygotować szablon z zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.