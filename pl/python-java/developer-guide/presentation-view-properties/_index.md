---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Pythonie za pośrednictwem Java
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/python-java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- widok pojedynczy
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
description: "Odkryj właściwości widoku Aspose.Slides dla Pythona za pośrednictwem Java, aby dostosować slajdy PPT, PPTX i ODP — zmieniaj układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wstęp**

Widok normalny składa się z trzech obszarów treści: samego slajdu, bocznego obszaru treści oraz dolnego obszaru treści. Właściwości widoku normalnego opisują pozycjonowanie tych obszarów treści. Informacje te umożliwiają aplikacji zapisanie stanu widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano metodę [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties), aby zapewnić dostęp do właściwości widoku normalnego prezentacji.

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/) i [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/) oraz wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/).

## **O NormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) określają, czy aplikacja ma wyświetlać ikony przy wyświetlaniu treści konspektu w dowolnym z obszarów treści w trybie widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) określają, czy pionowy podziałnik ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Metody [getPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) określają, czy użytkownik preferuje widok pełnoekranowego jednego obszaru treści zamiast standardowego widoku normalnego z trzema obszarami treści. Jeśli jest włączone, aplikacja może zdecydować o wyświetleniu jednego z obszarów treści w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) określają stan, w jakim ma być wyświetlany poziomy lub pionowy pasek podziału. Poziomy pasek podziału oddziela slajd od obszaru treści pod slajdem; pionowy pasek podziału oddziela slajd od bocznego obszaru treści. Dostępne wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop) określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/python-java/aspose.slides/splitterbarstatetype/#Restored) jest zastosowana do [getVerticalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), odpowiednio.

## **O przywracaniu NormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) w widoku normalnym, gdy obszar ma zmienny przywrócony rozmiar (ani zminimalizowany, ani zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) określa rozmiar obszaru slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredTop), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) określa, czy rozmiar bocznego obszaru treści ma kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java obsługuje ustawianie domyślnej wartości powiększenia, tak aby była zastosowana już przy otwarciu prezentacji. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNotesViewProperties) można konfigurować programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) w Aspose.Slides.
{{% /alert %}}

Aby ustawić właściwości widoku, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/) [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).

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
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Procent powiększenia dla widoku slajdu.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Procent powiększenia dla widoku notatek.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw odstęp siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties), aby uzyskać dostęp do ustawień widoku obowiązujących dla całej prezentacji. Metody [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getGridSpacing) i [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setGridSpacing) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odstęp siatki podawany jest w punktach, przy czym 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z wymaganiami dokumentacji API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wypisuje aktualny odstęp siatki, ustawia odstęp ćwierć cala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/python-java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie rozmieszczonymi poziomymi lub pionowymi liniami wyrównania. Dodawanie, przesuwanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocnikami edycji. Nie są renderowane jako treść slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties), aby uzyskać dostęp do ustawień widoku obowiązujących dla całej prezentacji. Użyj [ViewProperties.getShowComments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getShowComments) i [ViewProperties.setShowComments](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setShowComments), aby odczytać lub zmienić zapisaną preferencję dotyczącą wyświetlania komentarzy przy otwieraniu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To ustawienie kontroluje tylko zapisaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/python-java/presentation-comments/) po informacje o operacjach zmieniających same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wypisuje aktualne ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Używa także [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#setLastView) wraz z [ViewType.SlideView](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewtype/#SlideView), aby skonfigurować początkowy widok edycji razem z widocznością komentarzy.

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

To ustawienie nie decyduje o tym, czy komentarze są uwzględniane w eksportach do PDF, HTML, obrazu, notatek lub materiałów rozdawczych. Konfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki to odrębne ustawienia. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/pl/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi View Properties, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getViewProperties) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.