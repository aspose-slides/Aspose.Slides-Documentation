---
title: Zarządzanie prowadnicami rysunkowymi w prezentacjach w Pythonie
linktitle: Prowadnice rysunkowe
type: docs
weight: 85
url: /pl/python-java/drawing-guides/
keywords:
- prowadnica rysunkowa
- prowadnica pozioma
- prowadnica pionowa
- prowadnica wyrównania
- widok slajdu
- slajd master
- slajd układu
- master notatek
- master wersji drukowanej
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dodawaj, uzyskuj dostęp i usuwaj poziome oraz pionowe prowadnice rysunkowe w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

Prowadnice rysunkowe to regulowane poziome i pionowe linie, które pomagają użytkownikom konsekwentnie wyrównywać kształty podczas edycji prezentacji w programie PowerPoint. Są szczególnie przydatne, gdy aplikacja generuje prezentację, którą później będzie ręcznie dopracowywać: aplikacja może zapisać te same pomoce wyrównania, których autorzy powinni używać przy dodawaniu lub przemieszczaniu treści.

Prowadnice rysunkowe są pomocnikami edycji, a nie treścią slajdu. Nie pojawiają się w pokazie slajdów ani w renderowanym outputcie. Aspose.Slides for Python via Java udostępnia je za pośrednictwem klasy [DrawingGuidesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/) . Prowadnica jest reprezentowana przez [DrawingGuide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguide/) i posiada orientację, pozycję oraz kolor.

Pozycja jest mierzona w punktach od lewego górnego rogu odpowiedniego slajdu lub mastera. Pionowa prowadnica używa współrzędnej poziomej, zazwyczaj pomiędzy zerem a szerokością slajdu. Pozioma prowadnica używa współrzędnej pionowej, zazwyczaj pomiędzy zerem a wysokością slajdu.

## **Dodaj prowadnice do widoku slajdu**

Użyj [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) aby zarządzać prowadnicami wyświetlanymi podczas edycji zwykłych slajdów. Wywołaj [DrawingGuidesCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/#add) z wartością [Orientation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/orientation/) oraz pozycją w punktach.

Poniższy przykład dodaje jedną pionową prowadnicę po prawej stronie środka slajdu oraz jedną poziomą prowadnicę pod nią:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do prowadnic rysunkowych**

Metody [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/#getCount) i [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/#get_Item) umożliwiają dostęp do istniejących prowadnic. Metody [DrawingGuide.getOrientation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguide/#getPosition) i [DrawingGuide.getColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguide/#getColor) zwracają wartości, które można również zmienić za pomocą odpowiednich metod ustawiających.

Poniższy przykład odczytuje prowadnice widoku slajdu z prezentacji utworzonej powyżej:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Dodaj prowadnice do slajdów master i układu**

Master slajdu i każdy z jego slajdów układu może mieć własne kolekcje prowadnic rysunkowych. Użyj [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getDrawingGuides) dla slajdu master oraz [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getDrawingGuides) dla slajdu układu.

Poniższy przykład dodaje pionową prowadnicę do pierwszego slajdu master oraz poziomą prowadnicę do pierwszego slajdu układu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodaj prowadnice do masterów notatek i wersji drukowanej**

Mastery notatek i mastery wersji drukowanej również obsługują prowadnice rysunkowe. Użyj [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslide/#getDrawingGuides) i [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides), aby uzyskać dostęp do ich kolekcji. Jeśli prezentacja nie zawiera jednego z tych masterów, `MasterNotesSlideManager.setDefaultMasterNotesSlide` lub `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` tworzy domyślny master i go zwraca.

Poniższy przykład dodaje poziomą prowadnicę do mastera notatek oraz pionową prowadnicę do mastera wersji drukowanej:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wyczyść prowadnice rysunkowe**

Wywołaj [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/#clear), aby usunąć wszystkie prowadnice z określonej kolekcji. Czyszczenie jednej kolekcji nie ma wpływu na prowadnice przechowywane w innym zakresie.

Poniższy przykład wyczyść prowadnice widoku slajdu oraz wszystkie prowadnice na masterach slajdów, slajdach układu, masterze notatek i masterze wersji drukowanej, nie tworząc brakujących masterów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy prowadnice rysunkowe pojawiają się w pokazie slajdów lub wyeksportowanych obrazach?**

Nie. Prowadnice rysunkowe są pomocnikami wyrównywania podczas edycji i nie są renderowane jako treść prezentacji.

**Czy prowadzicę rysunkową można dodać bezpośrednio do pojedynczego zwykłego slajdu?**

Prowadnice edycyjne zwykłych slajdów są przechowywane w właściwościach widoku slajdu prezentacji. Oddzielne kolekcje prowadnic są dostępne dla masterów slajdów, slajdów układu, masterów notatek i masterów wersji drukowanej.

**Jakie jednostki są używane do określania pozycji prowadnic?**

Pozycje są określane w punktach, gdzie 72 punkty to jeden cal. Pozycje pionowe mierzone są od lewej krawędzi, a pozycje poziome od górnej krawędzi.

**Czy wyczyszczenie prowadnic rysunkowych usuwa kształty lub zmienia treść slajdu?**

Nie. Metoda [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/drawingguidescollection/#clear) usuwa tylko prowadnice w wybranej kolekcji. Kształty i inne elementy slajdu pozostają niezmienione.