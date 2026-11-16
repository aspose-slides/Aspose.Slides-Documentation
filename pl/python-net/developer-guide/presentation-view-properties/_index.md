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
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Użyj Aspose.Slides for Python via .NET, aby skonfigurować układ widoku normalnego, powiększenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wprowadzenie**

W widoku normalnym programu PowerPoint slajd wyświetlany jest pomiędzy panelem bocznym z miniaturami lub konspektem a panelem notatek poniżej. Aspose.Slides for Python via .NET udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Obejmują one układ paneli, poziomy powiększenia, odstępy siatki i widoczność komentarzy.

## **O NormalViewProperties**

Użyj [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) aby uzyskać dostęp do obiektu [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) pozwala panelowi bocznemu zminimalizować się, gdy użytkownik go zwęża. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) kontroluje podziałkę między panelem bocznym a slajdem. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) kontroluje podziałkę nad panelem notatek. Oba przyjmują wartość [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) `MINIMIZED`, `MAXIMIZED` lub `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![A conceptual editor separates a side panel, slide region and bottom region with labelled vertical and horizontal splitters.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*W widoku normalnym pionowa podziałka kontroluje szerokość panelu bocznego. Pozioma podziałka kontroluje przestrzeń nad panelem notatek.*
<!-- visual-explanation:presentation-view-properties:end -->

## **O przywracaniu NormalViewProperties**

Gdy podziałka jest przywracana, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) podaje zapisaną szerokość panelu bocznego, a [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) podaje zapisaną wysokość górnego obszaru slajdu. Oba udostępniają [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Jego właściwość [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) przyjmuje procent od 0 do 100, a [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) na 80% z włączonym automatycznym dostosowaniem i maksymalizuje pionową podziałkę. Włącza również [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) dla widoku konspektu.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw domyślną wartość powiększenia**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) i [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdów, odtwarzanie pokazu slajdów ani rozdzielczość eksportu obrazów.

Ten przykład otwiera istniejącą prezentację i włącza [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) , aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i ustawia [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) na stałe 80% powiększenie.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw odstęp siatki**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wyświetla bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o ćwierćcala, ustawiając interwał na 18 punktów.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Siatka powtarza się w stałym interwale. [Drawing guides](/slides/pl/python-net/drawing-guides/) oznaczają poszczególne pozycje poziome lub pionowe. Oba są pomocnikami edycji i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksporty do PDF, obrazów lub SVG je pomijają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) przechowuje preferencję, którą kompatybilne edytory wykorzystują przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wyświetla bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Ustawia także [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) na [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/), aby kopia otworzyła się w widoku slajdu.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i stany. Aby zmienić same komentarze, zobacz [Presentation Comments](/slides/pl/python-net/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiałach rozdawniczych.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz widoczność siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Dodanie, przeniesienie lub usunięcie prowadnicy nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) dotyczy całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może także zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone z szablonu dziedziczą zapisane ustawienia widoku.