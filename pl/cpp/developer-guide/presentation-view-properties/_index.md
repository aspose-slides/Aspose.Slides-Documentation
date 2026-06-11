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

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości dotyczące pozycjonowania różnych obszarów treści. Te informacje pozwalają aplikacji zapisać stan widoku w pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Metoda [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) została dodana, aby zapewnić dostęp do właściwości widoku normalnego prezentacji.

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/inormalviewrestoredproperties/) oraz ich potomkowie, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/splitterbarstatetype/) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja ma wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z obszarów treści trybu widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy podziałnik ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik woli zobaczyć pełnoekranowy jednopunktowy obszar treści zamiast standardowego widoku normalnego z trzema obszarami treści. Po włączeniu aplikacja może wyświetlić jeden z obszarów treści w całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podziałnika. Poziomy pasek podziałnika oddziela slajd od obszaru treści pod slajdem, pionowy pasek podziałnika oddziela slajd od bocznego obszaru treści. Możliwe wartości to: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest potomkiem RestoredTop, wysokość, gdy jest potomkiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Właściwość **AutoAdjust** określa, czy rozmiar bocznego obszaru treści ma kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej znajduje się przykład pokazujący, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** dla prezentacji.

``` cpp
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

Aspose.Slides dla C++ obsługuje teraz ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) prezentacji. Właściwości widoku slajdu oraz [get_NotesViewProperties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) można ustawić programowo. W tym temacie zobaczymy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)
1. Ustaw [Properties](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/) widoku prezentacji
1. Zapisz prezentację jako plik PPTX

W podanym poniżej przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ustawianie właściwości widoku prezentacji
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Wartość powiększenia w procentach dla widoku slajdu
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Wartość powiększenia w procentach dla widoku notatek 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) są definiowane na poziomie prezentacji ([Widok normalny](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Widok slajdu](https://reference.aspose.com/slides/pl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), a nie per sekcja, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę z góry określić różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_viewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty na jego podstawie z taką samą początkową konfiguracją widoku.