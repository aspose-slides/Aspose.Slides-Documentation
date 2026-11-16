---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Pythonie za pośrednictwem Javy
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/python-java/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Użyj Aspose.Slides dla Pythona za pośrednictwem Javy, aby skonfigurować układ normalnego widoku, powiększenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wstęp**

W normalnym widoku PowerPointu slajd wyświetlany jest pomiędzy bocznym panelem miniatur lub konspektem a panelem notatek poniżej. Aspose.Slides dla Pythona za pośrednictwem Javy udostępnia zapisane preferencje edycji prezentacji poprzez [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Obejmują one układ paneli, poziomy powiększenia, odstępy siatki i widoczność komentarzy.

## **O NormalViewProperties**

Użyj [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) aby uzyskać dostęp do klasy [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) pozwala bocznemu panelowi przyciągać się do stanu zminimalizowanego, gdy użytkownik go zwęża. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) kontroluje podziałkę pomiędzy bocznym panelem a slajdem. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) kontroluje podziałkę nad panelem notatek. Oba przyjmują wartość typu [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu NormalViewProperties**

Gdy podziałka jest przywracana, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) zwraca zapisaną wielkość bocznego panelu, a [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) zwraca zapisaną wielkość górnego obszaru slajdu. Oba zwracają instancję [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Jej metoda [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) przyjmuje wartość procentową od 0 do 100, a [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomą podziałkę, ustawia rozmiar zwrócony przez [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) na 80% z włączonym automatycznym dopasowaniem oraz maksymalizuje pionową podziałkę. Wywołuje także [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) aby wyświetlić ikony w widoku konspektu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw domyślną wartość powiększenia**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) i [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdu, odtwarzanie pokazu slajdów ani rozdzielczość eksportowanych obrazów.

Ten przykład otwiera istniejącą prezentację i wywołuje [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale), aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i wywołuje [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale), aby ustawić stałe powiększenie 80%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw odstęp siatki**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wypisuje aktualny odstęp w istniejącej prezentacji i zapisuje siatkę o ćwierć cala, ustawiając interwał na 18 punktów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Siatka powtarza się w stałym interwale. [Przewodniki rysowania](/slides/pl/python-java/drawing-guides/) oznaczają poszczególne pozycje poziome lub pionowe. Oba są pomocy edycyjnymi i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksporty do PDF, obrazów lub SVG ich nie uwzględniają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) przechowuje preferencję, której kompatybilne edytory używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wypisuje bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Wywołuje także [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) z [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView), aby kopia otworzyła się w widoku slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Komentarze prezentacji](/slides/pl/python-java/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiały rozdawnicze.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja przechowuje interwał siatki. Aby zobaczyć siatkę, włącz jej widoczność w edytorze.

**Czy usunięcie przewodników rysowania zmienia odstęp siatki?**

Nie. Dodanie, przesunięcie lub usunięcie przewodnika nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) dotyczy całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może także zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone z szablonu dziedziczą zapisane ustawienia widoku.