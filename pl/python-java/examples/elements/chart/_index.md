---
title: Wykres
type: docs
weight: 60
url: /pl/python-java/examples/elements/chart/
keywords:
- wykres
- dodaj wykres
- uzyskaj dostęp do wykresu
- usuń wykres
- zaktualizuj wykres
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Utwórz, uzyskaj dostęp, usuń i zaktualizuj wykresy w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java."
---
Ten artykuł demonstruje, jak dodawać, uzyskiwać dostęp, usuwać i aktualizować wykresy w prezentacji przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Instalacja](/slides/pl/python-java/installation/). Każdy przykład najpierw importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM. Uruchom najpierw przykład dodawania, aby utworzyć `chart.pptx` dla pozostałych przykładów.

## **Dodaj wykres**

Dodaj wykres warstwowy do pierwszego slajdu i zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj wykres warstwowy do pierwszego slajdu.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do wykresu**

Znajdź pierwszy wykres w kolekcji kształtów na pierwszym slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Uzyskaj dostęp do pierwszego wykresu na slajdzie.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Usuń wykres**

Usuń pierwszy wykres ze slajdu i zapisz zmodyfikowaną prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Znajdź i usuń pierwszy wykres na slajdzie.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zaktualizuj dane wykresu**

Wyświetl tytuł wykresu, zmień jego tekst i zapisz zaktualizowaną prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Znajdź pierwszy wykres na slajdzie.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Wyświetl tytuł wykresu i zmień jego tekst.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```