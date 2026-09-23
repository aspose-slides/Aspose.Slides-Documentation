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
- przyciąganie pionowego podziałnika
- widok pojedynczy
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Pythona via .NET, aby dostosować formaty slajdów PPT, PPTX i ODP — zmieniać układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Dodano własność [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/) , aby zapewnić dostęp do właściwości widoku normalnego prezentacji.  
Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/normalviewrestoredproperties/) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/splitterbarstatetype/).

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Właściwość **ShowOutlineIcons** określa, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z regionów zawartości trybu widoku normalnego.  
Właściwość **SnapVerticalSplitter** określa, czy pionowy podziałnik ma przełączać się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.  
Właściwość **PreferSingleView** określa, czy użytkownik preferuje widok pełnoekranowego jednego regionu zawartości zamiast standardowego widoku normalnego z trzema regionami. Jeśli jest włączona, aplikacja może wyświetlić jeden z regionów zawartości na całym oknie.

Właściwości **VerticalBarState** i **HorizontalBarState** określają stan, w jakim ma być wyświetlany odpowiedni pasek podziałnika (poziomy lub pionowy). Pasek podziałnika poziomego oddziela slajd od regionu zawartości znajdującego się pod slajdem, pasek podziałnika pionowego oddziela slajd od bocznego regionu zawartości. Dostępne wartości to: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** oraz **SplitterBarStateType.Restored**.  

Właściwości **RestoredLeft** i **RestoredTop** określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy zastosowano wartość **SplitterBarStateType.Restored** dla **VerticalBarState** i **HorizontalBarState** odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem RestoredTop, wysokość, gdy jest potomkiem RestoredLeft) w widoku normalnym, gdy region ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).  

Właściwość **DimensionSize** określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).  

Właściwość **AutoAdjust** określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.  

Poniżej podany jest przykład, który pokazuje, jak uzyskać dostęp do właściwości **ViewProperties.NormalViewProperties** prezentacji.

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

Aspose.Slides for Python via .NET obsługuje teraz ustawianie domyślnej wartości powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) prezentacji. Właściwości widoku slajdu oraz [notes_view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/notes_view_properties/) mogą być ustawiane programowo. W tym artykule pokażemy na przykładzie, jak ustawić właściwości widoku prezentacji w Aspose.Slides.

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Ustaw [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/) prezentacji.
1. Zapisz prezentację jako plik PPTX.

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

Użyj [Presentation.view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/), aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Właściwość [ViewProperties.grid_spacing](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/grid_spacing/) odczytuje lub zmienia odstęp podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki podaje się w punktach, gdzie 72 punkty równa się jednemu calowi. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia odstęp kwart cala i zapisuje wynik.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Siatka różni się od [drawing guides](/slides/pl/python-net/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie rozmieszczanymi poziomymi lub pionowymi liniami wyrównania. Dodawanie, przenoszenie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy także od ustawień przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation.view_properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/), aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Odczytaj lub zmień [ViewProperties.show_comments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/show_comments/), aby zapisać preferencję, czy komentarze mają być wyświetlane po otwarciu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To ustawienie kontroluje jedynie zapisaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/python-net/presentation-comments/), aby zapoznać się z operacjami zmieniającymi same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wyświetla bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Dodatkowo ustawia [ViewProperties.last_view](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/last_view/) na [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewtype/), aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

To ustawienie nie określa, czy komentarze są uwzględniane w eksportach do PDF, HTML, obrazu, notatek lub wersji drukowanych. Skonfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**  
Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**  
Nie. Prowadnice rysunkowe i odstęp siatki są niezależnymi ustawieniami. Usunięcie prowadnic nie zmienia przechowywanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**  
[Ustawienia widoku](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) definiowane są na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/pl/python-net/aspose.slides/viewproperties/slide_view_properties/)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę z góry określić różne stany widoku dla różnych użytkowników?**  
Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**  
Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/view_properties/) są przechowywane na poziomie prezentacji, możesz umieścić je w szablonie i tworzyć z niego nowe dokumenty z tą samą początkową konfiguracją widoku.