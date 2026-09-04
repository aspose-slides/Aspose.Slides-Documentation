---
title: Grafiek
type: docs
weight: 60
url: /nl/python-java/examples/elements/chart/
keywords:
- grafiek
- grafiek toevoegen
- grafiek benaderen
- grafiek verwijderen
- grafiek bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak, benader, verwijder en werk grafieken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides for Python via Java."
---
Dit artikel laat zien hoe je grafieken toevoegt, benadert, verwijdert en bijwerkt in een presentatie met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert vervolgens de API nadat de JVM draait. Voer eerst het voorbeeld voor het toevoegen uit om `chart.pptx` te maken voor de overige voorbeelden.

## **Grafiek toevoegen**

Voeg een gebiedsgrafiek toe aan de eerste dia en sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een gebiedsgrafiek toe aan de eerste dia.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafiek benaderen**

Zoek de eerste grafiek in de vormverzameling op de eerste dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Benader de eerste grafiek op de dia.
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

## **Grafiek verwijderen**

Verwijder de eerste grafiek van de dia en sla de gewijzigde presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Zoek en verwijder de eerste grafiek op de dia.
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

## **Grafiekgegevens bijwerken**

Toon de titel van de grafiek, wijzig de tekst en sla de bijgewerkte presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Zoek de eerste grafiek op de dia.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Toon de titel van de grafiek en wijzig de tekst.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```