---
title: Bubble-Diagramme in Präsentationen mit Python anpassen
linktitle: Bubble-Diagramm
type: docs
url: /de/python-net/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Größenskalierung
- Größenrepräsentation
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und Anpassen leistungsstarker Bubble-Diagramme in PowerPoint und OpenDocument mit Aspose.Slides für Python via .NET, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Skalierung der Bubble-Diagrammgröße**
Aspose.Slides für Python via .NET bietet Unterstützung für die Skalierung der Bubble-Diagrammgröße. In Aspose.Slides für Python via .NET wurden die Eigenschaften **ChartSeries.bubble_size_scale** und **ChartSeriesGroup.bubble_size_scale** hinzugefügt. Nachfolgend ein Beispiel.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Daten als Bubble-Diagrammgrößen darstellen**
Die Eigenschaft **bubble_size_representation** wurde zu den Klassen ChartSeries und ChartSeriesGroup hinzugefügt. **bubble_size_representation** gibt an, wie die Bubble-Größenwerte im Bubble-Diagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.AREA** und **BubbleSizeRepresentationType.WIDTH**. Entsprechend wurde das Enum **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Arten der Darstellung von Daten als Bubble-Diagrammgrößen zu spezifizieren. Nachfolgend ein Beispielcode.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wird ein "Bubble-Diagramm mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem regulären?**

Ja. Es gibt einen separaten Diagrammtyp, "Bubble with 3‑D". Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Aufzählung [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) verfügbar.

**Gibt es ein Limit für die Anzahl von Serien und Punkten in einem Bubble-Diagramm?**

Auf der API‑Ebene gibt es kein festes Limit; die Beschränkungen ergeben sich aus der Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Anzahl der Punkte für Lesbarkeit und Rendering‑Geschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble-Diagramms aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering wird von der Aspose.Slides‑Engine durchgeführt. Für Raster‑/Vektor‑Formate gelten die allgemeinen Regeln für die Diagramm‑Grafikdarstellung (Auflösung, Antialiasing), daher sollte eine ausreichende DPI für den Druck gewählt werden.