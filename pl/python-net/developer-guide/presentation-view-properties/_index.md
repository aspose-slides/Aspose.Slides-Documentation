---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w języku Python
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/python-net/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego rozdzielacza
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dostosowanie
- domyślne powiększenie
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Pythona via .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikować układy, poziomy powiększenia oraz ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości dotyczące pozycjonowania różnych obszarów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku w pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano właściwość [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/), aby zapewnić dostęp do właściwości widoku normalnego prezentacji. Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewrestoredproperties/) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/splitterbarstatetype/) enum.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z obszarów zawartości w trybie widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy rozdzielacz powinien przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik woli widzieć jednorodny obszar zawartości zajmujący cały ekran zamiast standardowego widoku normalnego z trzema obszarami zawartości. Jeśli jest włączona, aplikacja może wyświetlić jeden z obszarów zawartości w całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim powinien być wyświetlany pasek rozdzielacza poziomego lub pionowego. Pasek rozdzielacza poziomego oddziela slajd od obszaru zawartości pod slajdem, pasek rozdzielacza pionowego oddziela slajd od bocznego obszaru zawartości. Dostępne wartości to: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored.**

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani nie zmaksymalizowany).

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Właściwość **AutoAdjust** określa, czy rozmiar bocznego obszaru zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podany przykład pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Przywróć właściwości widoku prezentacji
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw domyślną wartość powiększenia**

Aspose.Slides for Python via .NET obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) prezentacji. Właściwości widoku slajdu oraz [notes_view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/notes_view_properties/) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/)
1. Ustaw [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/) prezentacji
1. Zapisz prezentację jako plik PPTX

W poniższym przykładzie ustawiliśmy wartość powiększenia dla widoku slajdu oraz widoku notatek.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Ustawianie właściwości widoku prezentacji
    presentation.view_properties.slide_view_properties.scale = 100 # Wartość powiększenia w procentach dla widoku slajdu
    presentation.view_properties.notes_view_properties.scale = 100 # Wartość powiększenia w procentach dla widoku notatek

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw odstęp siatki**

Użyj [Presentation.view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/), aby uzyskać dostęp do ustawień widoku na poziomie całej prezentacji. Właściwość [ViewProperties.grid_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/grid_spacing/) odczytuje lub zmienia interwał podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia interwał ćwierćcala i zapisuje wynik.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Siatka różni się od [drawing guides](/slides/pl/python-net/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice są indywidualnie pozycjonowanymi poziomymi lub pionowymi liniami wyrównania. Dodawanie, przenoszenie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy także od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki są niezależnymi ustawieniami. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/slide_view_properties/)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu przy jego otwieraniu.

**Czy mogę wstępnie zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jedną setę właściwości widoku.

**Czy mogę przygotować szablon z wstępnie określonymi właściwościami widoku, aby nowe prezentacje otwierały się tak samo?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z tą samą początkową konfiguracją widoku.