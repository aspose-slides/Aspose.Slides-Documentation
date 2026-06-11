---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Pythonie
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
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Pythona poprzez .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości dotyczące rozmieszczenia różnych obszarów treści. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok był w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano właściwość [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/) umożliwiającą dostęp do właściwości widoku normalnego prezentacji.  

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewrestoredproperties/) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/splitterbarstatetype/).

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja ma wyświetlać ikony podczas wyświetlania treści konspektu w którymkolwiek z obszarów treści trybu widoku normalnego.

Właściwość **SnapVerticalSplitter** określa, czy pionowy rozdzielacz ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość **PreferSingleView** określa, czy użytkownik preferuje wyświetlanie jednego obszaru treści w trybie pełnoekranowym zamiast standardowego widoku normalnego z trzema obszarami treści. Jeśli jest włączona, aplikacja może wyświetlić jeden z obszarów treści w całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim powinien być wyświetlany pionowy lub poziomy pasek rozdzielacza. Poziomy pasek rozdzielacza oddziela slajd od obszaru treści znajdującego się pod slajdem, pionowy pasek rozdzielacza oddziela slajd od bocznego obszaru treści. Dozwolone wartości to: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla **VerticalBarState** i **HorizontalBarState** zastosowano wartość **SplitterBarStateType.Restored**.

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem RestoredTop, wysokość, gdy jest dzieckiem RestoredLeft) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).

Właściwość **DimensionSize** określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Właściwość **AutoAdjust** określa, czy rozmiar bocznego obszaru treści ma kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
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

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
2. Ustaw [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/) prezentacji .
3. Zapisz prezentację jako plik PPTX .

W poniższym przykładzie ustawiliśmy wartość powiększenia dla widoku slajdu oraz widoku notatek.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Ustawianie właściwości widoku prezentacji
    presentation.view_properties.slide_view_properties.scale = 100 # Wartość powiększenia w procentach dla widoku slajdu
    presentation.view_properties.notes_view_properties.scale = 100 # Wartość powiększenia w procentach dla widoku notatek 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/slide_view_properties/)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje do przeglądania mogą respektować preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z zdefiniowanymi wcześniej właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty z tym samym początkowym ustawieniem widoku.