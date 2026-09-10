---
title: Anpassen von Donut-Diagrammen in Präsentationen mit Python via Java
linktitle: Donut-Diagramm
type: docs
weight: 30
url: /de/python-java/doughnut-chart/
keywords:
- Donut-Diagramm
- Mittelabstand
- Lochgröße
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donut-Diagramme in Aspose.Slides für Python via Java erstellen und anpassen und dabei PowerPoint-Formate für dynamische Präsentationen unterstützen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man in Aspose.Slides mit einem Donut‑Diagramm arbeitet, indem man das Diagramm zu einer Folie hinzufügt, die Größe des Mittellochs festlegt und die Präsentation speichert. Er konzentriert sich auf die Methode [setDoughnutHoleSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) und demonstriert die grundlegenden Schritte, die erforderlich sind, um diesen Diagrammtyp im Code anzupassen.

Er enthält zudem ein kurzes FAQ zu verwandten Donut‑Diagramm‑Szenarien, wie dem Verwenden mehrerer Serien zum Erstellen mehrerer Ringe, dem Arbeiten mit explodierten Donut‑Diagrammen und dem Exportieren eines Diagramms als Raster‑Bild oder SVG.

## **Festlegen der Mittelabstandes in einem Donut‑Diagramm**

{{% alert color="info" title="Hinweis" %}}

Aspose.Slides für Python via Java unterstützt das Festlegen der Größe des Lochs in einem Donut‑Diagramm. Dieser Abschnitt demonstriert, wie man die Lochgröße anhand eines Beispiels angibt.

{{% /alert %}}

Um die Größe des Lochs in einem Donut‑Diagramm festzulegen, führen Sie folgende Schritte aus:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Objekt.
1. Fügen Sie ein Donut‑Diagramm zur Folie hinzu.
1. Geben Sie die Größe des Lochs im Donut‑Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Das folgende Beispiel setzt die Größe des Lochs in einem Donut‑Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Erstelle eine Instanz der Presentation-Klasse.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Schreibe die Präsentation auf die Festplatte.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich ein mehrstufiges Donut‑Diagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut‑Diagramm mehrere Serien hinzu – jede Serie wird zu einem eigenen Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut‑[Diagrammtyp](https://reference.aspose.com/slides/de/python-java/aspose.slides/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie erhalte ich ein Bild eines Donut‑Diagramms (PNG/SVG) für einen Bericht?**

Ein Diagramm ist ein [shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/); Sie können es in ein [Raster‑Bild](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) rendern oder das Diagramm als SVG‑Bild exportieren.