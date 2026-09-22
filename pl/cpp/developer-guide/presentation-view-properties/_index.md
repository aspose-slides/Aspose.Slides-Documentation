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
- przyciąganie pionowego podzielnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla C++, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy przybliżenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości dotyczące pozycjonowania różnych obszarów zawartości. Ta informacja pozwala aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) została dodana w celu udostępnienia właściwości normalnego widoku prezentacji. 

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewrestoredproperties/) oraz ich pochodnych, enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/splitterbarstatetype/) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Właściwość **ShowOutlineIcons** określa, czy aplikacja ma wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z obszarów zawartości trybu normalnego widoku.

Właściwość **SnapVerticalSplitter** określa, czy pionowy podzielnik ma przechodzić w stan zminimalizowany, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik woli zobaczyć pełnoekranowy pojedynczy obszar zawartości zamiast standardowego normalnego widoku z trzema obszarami zawartości. Jeśli jest włączona, aplikacja może wyświetlić jeden z obszarów zawartości na całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podzielnika. Pionowy pasek podzielnika oddziela slajd od bocznego obszaru zawartości, poziomy pasek podzielnika oddziela slajd od obszaru zawartości poniżej slajdu. Możliwe wartości to: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w normalnym widoku, gdy zastosowano wartość **SplitterBarStateType.Restored** dla **VerticalBarState** i **HorizontalBarState** odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest elementem RestoredTop, wysokość, gdy jest elementem RestoredLeft) w normalnym widoku, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany). 

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest elementem restoredTop, wysokość, gdy jest elementem restoredLeft).

Właściwość **AutoAdjust** określa, czy rozmiar bocznego obszaru zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, w jaki sposób można uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** dla prezentacji.

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

## **Ustaw domyślną wartość przybliżenia**

Aspose.Slides for C++ obsługuje teraz ustawianie domyślnej wartości przybliżenia prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) prezentacji. Właściwości widoku slajdu oraz [get_NotesViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)
1. Ustaw [Properties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) widoku prezentacji
1. Zapisz prezentację jako plik PPTX

W podanym poniżej przykładzie ustawiliśmy wartość przybliżenia zarówno dla widoku slajdu, jak i widoku notatek.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ustawianie właściwości widoku prezentacji
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Wartość przybliżenia w procentach dla widoku slajdu
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Wartość przybliżenia w procentach dla widoku notatek 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Ustaw odstęp siatki**

Użyj [Presentation::get_ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) do uzyskania dostępu do ustawień widoku na poziomie całej prezentacji. Metody [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_gridspacing/) i [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/set_gridspacing/) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia interwał ćwierćcala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/cpp/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie pozycjonowanymi poziomymi lub pionowymi liniami wyrównania. Dodawanie, przemieszczanie lub usuwanie prowadnic rysunkowych nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocą przy edycji. Nie są renderowane jako zawartość slajdu w formatach PDF, obrazach, SVG ani podczas pokazu slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy także od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale kontrola wyświetlania siatki należy do edytora. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) definiowane są na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), a nie per sekcja, więc jeden zestaw parametrów stosowany jest do całego dokumentu przy otwieraniu.

**Czy mogę zdefiniować wcześniej różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą wstępną konfiguracją widoku.