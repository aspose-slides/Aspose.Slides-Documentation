---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Pythonie za pośrednictwem Java
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/python-java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- treść konspektu
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
- Python
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Pythona za pośrednictwem Java, aby dostosować slajdy PPT, PPTX i ODP — regulować układy, poziomy przybliżenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech regionów treści: samego slajdu, bocznego regionu treści oraz dolnego regionu treści. Właściwości widoku normalnego opisują położenie tych regionów treści. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano metodę [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties), aby udostępnić dostęp do właściwości widoku normalnego prezentacji.

Klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/) i [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/) oraz wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/) zostały dodane.

## **O NormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z regionów treści w trybie widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) określają, czy pionowy podzielnik ma się przyciągać do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Metody [getPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) określają, czy użytkownik woli widzieć pojedynczy region treści w pełnym oknie zamiast standardowego widoku normalnego z trzema regionami treści. Jeśli włączone, aplikacja może wyświetlić jeden z regionów treści w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) określają stan, w jakim ma być wyświetlany poziomy lub pionowy pasek podziału. Poziomy pasek podziału oddziela slajd od regionu treści pod slajdem; pionowy pasek podziału oddziela slajd od bocznego regionu treści. Dostępne wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored) jest zastosowana do [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), odpowiednio.

## **O przywracaniu NormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) w widoku normalnym, gdy region ma zmienny przywrócony rozmiar (niezminimalizowany ani nie zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) określa, czy rozmiar bocznego regionu treści ma się dostosowywać do nowego rozmiaru przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniższy przykład pokazuje, jak uzyskać dostęp do [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) dla prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Przywróć właściwości widoku prezentacji.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw domyślną wartość przybliżenia**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java obsługuje ustawianie domyślnej wartości przybliżenia, tak aby była już zastosowana przy otwieraniu prezentacji. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) można konfigurować programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) dla [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) w [Aspose.Slides](/slides/pl/).
{{% /alert %}}

Aby ustawić właściwości widoku, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) dla [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ustaw właściwości widoku prezentacji.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Procent przybliżenia dla widoku slajdu.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Procent przybliżenia dla widoku notatek.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów dotyczy całego dokumentu po otwarciu.

**Czy mogę wstępnie określić różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie określonymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z tą samą początkową konfiguracją widoku.