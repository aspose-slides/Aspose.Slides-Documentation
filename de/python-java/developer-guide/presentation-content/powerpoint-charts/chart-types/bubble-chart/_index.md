---
title: Bubble-Diagramme in Präsentationen mit Python anpassen
linktitle: Blasendiagramm
type: docs
url: /de/python-java/bubble-chart/
keywords:
- Blasendiagramm
- Blasengröße
- Größen-Skalierung
- Größen-Darstellung
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Blasendiagramme in PowerPoint mit Aspose.Slides für Python via Java an, um Ihre Datenvisualisierung einfach zu verbessern."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit Blasendiagrammen in Aspose.Slides arbeitet. Er behandelt zwei spezifische Anpassungsoptionen: das Skalieren von Blasengrößen über die [setBubbleSizeScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale)-Methode und die Steuerung der Darstellung von Blasengrößenwerten über die [setBubbleSizeRepresentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation)-Methode.

Die Beispiele demonstrieren, wie man ein Blasendiagramm erstellt, die Skalierung der Größen anpasst und die Darstellung der Blasengrößen auf Breite umstellt. Der Artikel enthält außerdem einen kurzen FAQ‑Abschnitt, der die Unterstützung des Diagrammtyps „Bubble with 3‑D“ erläutert, darauf hinweist, dass praktische Diagrammlimits von der Leistung und der Ziel‑PowerPoint‑Version abhängen, und erklärt, dass der Export das Aussehen des Diagramms über die Aspose.Slides‑Rendering‑Engine bewahrt.

## **Skalierung der Blasendiagramm‑Größen**
Aspose.Slides for Python via Java unterstützt die Skalierung von Blasendiagramm‑Größen über die Methoden [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) und [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Das nachfolgende Beispiel zeigt, wie man Blasengrößen skaliert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Daten als Blasendiagramm‑Größen darstellen**
Die Methoden [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) und [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) sind in der Klasse [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/) verfügbar. Die Blasengrößen‑Darstellung gibt an, wie die Werte der Blasengröße im Blasendiagramm repräsentiert werden. Mögliche Werte sind [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/de/python-java/aspose.slides/bubblesizerepresentationtype/#Area) und [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/de/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Die Aufzählung [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/de/python-java/aspose.slides/bubblesizerepresentationtype/) definiert die möglichen Arten, Daten als Blasendiagramm‑Größen zu repräsentieren. Das folgende Beispiel zeigt, wie man Blasengrößen anhand der Breite darstellt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wird ein „Blasendiagramm mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich vom regulären?**

Ja. Es gibt einen eigenen Diagrammtyp „Bubble with 3‑D“. Er wendet 3‑D‑Stil auf die Blasen an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Klasse [chart type](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) verfügbar.

**Gibt es ein Limit für die Anzahl von Serien und Punkten in einem Blasendiagramm?**

Auf API‑Ebene gibt es kein festes Limit; die Beschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit im Rahmen zu halten.

**Wie beeinflusst der Export das Aussehen eines Blasendiagramms (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; die Darstellung erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten die allgemeinen Regeln zur Diagramm‑Grafikrendarstellung (Auflösung, Antialiasing), sodass für den Druck eine ausreichende DPI gewählt werden sollte.