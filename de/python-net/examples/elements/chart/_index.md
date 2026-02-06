---
title: Diagramm
type: docs
weight: 60
url: /de/python-net/examples/elements/chart/
keywords:
- diagramm
- diagramm hinzufügen
- diagramm zugreifen
- diagramm entfernen
- diagramm aktualisieren
- codebeispiele
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Erstellen und Anpassen von Diagrammen in Python mit Aspose.Slides: Daten hinzufügen, Serien, Achsen und Beschriftungen formatieren, Typen ändern und exportieren – funktioniert mit PPT, PPTX und ODP."
---
Beispiele zum Hinzufügen, Zugreifen, Entfernen und Aktualisieren verschiedener Diagrammtypen mit **Aspose.Slides for Python via .NET**. Die folgenden Code-Snippets demonstrieren grundlegende Diagramm-Operationen.

## **Diagramm hinzufügen**

Diese Methode fügt dem ersten Folie ein einfaches Flächendiagramm hinzu.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Füge ein einfaches Säulendiagramm zur ersten Folie hinzu.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf ein Diagramm zugreifen**

Der folgende Code ruft ein Diagramm aus der Formsammlung ab.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Greife auf das erste Diagramm auf der Folie zu.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Diagramm entfernen**

Der folgende Code entfernt ein Diagramm von einer Folie.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein Diagramm.
        chart = slide.shapes[0]

        # Diagramm entfernen.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagrammdaten aktualisieren**

Sie können Diagrammeigenschaften wie den Titel ändern.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein Diagramm.
        chart = slide.shapes[0]

        # Diagrammtitel ändern.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```