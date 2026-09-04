---
title: Diagramm
type: docs
weight: 60
url: /de/python-java/examples/elements/chart/
keywords:
- Diagramm
- Diagramm hinzufügen
- Diagramm zugreifen
- Diagramm entfernen
- Diagramm aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen, Zugreifen, Entfernen und Aktualisieren von Diagrammen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java."
---
Dieser Artikel zeigt, wie man Diagramme in einer Präsentation hinzufügt, darauf zugreift, sie entfernt und aktualisiert, wobei **Aspose.Slides for Python via Java** verwendet wird.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides`, bevor die JVM gestartet wird, und importiert dann die API, sobald die JVM läuft. Führen Sie zuerst das Hinzufügen‑Beispiel aus, um `chart.pptx` für die übrigen Beispiele zu erstellen.

## **Diagramm hinzufügen**

Fügen Sie ein Flächendiagramm zur ersten Folie hinzu und speichern Sie die Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Füge ein Flächendiagramm zur ersten Folie hinzu.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zugriff auf ein Diagramm**

Suchen Sie das erste Diagramm in der Formsammlung auf der ersten Folie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Greife auf das erste Diagramm auf der Folie zu.
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

## **Diagramm entfernen**

Entfernen Sie das erste Diagramm von der Folie und speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Finde und entferne das erste Diagramm auf der Folie.
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

## **Diagrammdaten aktualisieren**

Zeigen Sie den Diagrammtitel an, ändern Sie dessen Text und speichern Sie die aktualisierte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Finde das erste Diagramm auf der Folie.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Zeige den Diagrammtitel an und ändere dessen Text.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```