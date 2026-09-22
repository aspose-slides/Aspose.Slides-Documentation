---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Pythonie przy użyciu Java
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/python-java/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides for Python via Java, aby dostosować slajdy PPT, PPTX i ODP — regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości normalnego widoku opisują położenie tych obszarów. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Do metody [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties) dodano dostęp do właściwości normalnego widoku prezentacji.

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/) i [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/) oraz wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/).

## **O NormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) określają, czy aplikacja ma wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z obszarów zawartości trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) określają, czy pionowy podziałnik ma przechodzić w stan zminimalizowany, gdy boczny obszar jest wystarczająco mały.

Metody [getPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) określają, czy użytkownik preferuje wyświetlenie jednego pełnoekranowego obszaru zawartości zamiast standardowego normalnego widoku z trzema obszarami. Jeśli włączone, aplikacja może wyświetlić jeden z obszarów w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) określają stan, w jakim ma być wyświetlany pionowy lub poziomy pasek podziałnika. Pionowy pasek oddziela slajd od bocznego obszaru, a poziomy oddziela slajd od obszaru poniżej. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) określają rozmiar górnego lub bocznego obszaru slajdu w normalnym widoku, gdy do [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) oraz [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored).

## **O przywracaniu NormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) w normalnym widoku, gdy obszar ma zmienny przywrócony rozmiar (niezminimalizowany ani niezmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) określa rozmiar obszaru slajdu (szerokość przy [getRestoredTop], wysokość przy [getRestoredLeft]).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) określa, czy rozmiar bocznego obszaru zawartości ma automatycznie kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

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

## **Ustaw domyślną wartość powiększenia**

{{% alert color="info" title="Uwaga" %}}

Aspose.Slides for Python via Java obsługuje ustawianie domyślnej wartości powiększenia, tak aby była już zastosowana przy otwieraniu prezentacji. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) prezentacji. Metody [getSlideViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) mogą być konfigurowane programowo. W tym temacie pokażemy, na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) obiektu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) w Aspose.Slides.

{{% /alert %}}

Aby ustawić właściwości widoku, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Ustaw [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) obiektu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
3. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

W poniższym przykładzie ustawiamy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

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

## **Ustaw odstępy siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties), aby uzyskać dostęp do ustawień widoku na poziomie całej prezentacji. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getGridSpacing) i [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setGridSpacing) odczytują lub zmieniają odstęp podstawowej siatki edycji. Ustawienie to dotyczy całej prezentacji, a nie pojedynczych slajdów. Odstęp siatki podawany jest w punktach, gdzie 72 punkty równa się jednemu calowi. Używaj wartości dodatnich, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wypisuje bieżący odstęp siatki, ustawia odstęp ćwierć cala i zapisuje wynik.

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

Siatka różni się od [przewodników rysunku](/slides/pl/python-java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, natomiast przewodniki rysunku są indywidualnie rozmieszczonymi liniami wyrównania poziomego lub pionowego. Dodawanie, przenoszenie lub usuwanie przewodników nie zmienia odstępu siatki.

Zarówno siatka, jak i przewodniki rysunku są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani pokazu slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka ma być wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie przewodników rysunku zmienia odstęp siatki?**

Nie. Przewodniki rysunku i odstęp siatki to niezależne ustawienia. Usunięcie przewodników pozostawia zapisany odstęp siatki bez zmian.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) definiowane są na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), a nie per sekcja, więc jeden zestaw parametrów obowiązuje dla całego dokumentu przy otwieraniu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć nowe dokumenty na jego podstawie z taką samą początkową konfiguracją widoku.