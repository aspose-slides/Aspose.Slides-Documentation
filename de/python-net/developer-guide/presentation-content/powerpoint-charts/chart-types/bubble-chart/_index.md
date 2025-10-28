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
description: "Erstellen und anpassen leistungsstarker Bubble-Diagramme in PowerPoint und OpenDocument mit Aspose.Slides für Python via .NET, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Größen‑Skalierung von Bubble‑Diagrammen**
Aspose.Slides für Python via .NET bietet Unterstützung für die Größenskalierung von Bubble‑Diagrammen. In Aspose.Slides für Python via .NET wurden die Eigenschaften **ChartSeries.bubble_size_scale** und **ChartSeriesGroup.bubble_size_scale** hinzugefügt. Nachfolgend ein Beispiel.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Daten als Bubble‑Diagrammgrößen darstellen**
Die Eigenschaft **bubble_size_representation** wurde zu den Klassen **ChartSeries** und **ChartSeriesGroup** hinzugefügt. **bubble_size_representation** gibt an, wie die Bubble‑Größenwerte im Diagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.AREA** und **BubbleSizeRepresentationType.WIDTH**. Entsprechend wurde das Enum **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Darstellungsarten zu definieren. Beispielcode siehe unten.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Wird ein „Bubble‑Diagramm mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich von einem herkömmlichen?**

Ja. Es gibt einen separaten Diagrammtyp, „Bubble with 3‑D“. Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist im [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Enum verfügbar.

**Gibt es eine Obergrenze für die Anzahl von Serien und Punkten in einem Bubble‑Diagramm?**

Auf API‑Ebene gibt es kein festes Limit; die Begrenzungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit überschaubar zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Diagramms aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; die Darstellung erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten allgemeine Grafik‑Renderregeln (Auflösung, Anti‑Aliasing), wählen Sie also eine ausreichend hohe DPI für den Druck.