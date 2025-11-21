---
title: Anpassen von Blasendiagrammen in Präsentationen mit Python
linktitle: Blasendiagramm
type: docs
url: /de/python-net/bubble-chart/
keywords:
- Blasendiagramm
- Blasengröße
- Größen-Skalierung
- Größen-Darstellung
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Blasendiagramme in PowerPoint und OpenDocument mit Aspose.Slides für Python über .NET an, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Skalierung der Blasendiagrammgröße**
Aspose.Slides für Python über .NET bietet Unterstützung für die Skalierung von Blasendiagrammen. In Aspose.Slides für Python über .NET wurden die Eigenschaften **ChartSeries.bubble_size_scale** und **ChartSeriesGroup.bubble_size_scale** hinzugefügt. Unten finden Sie ein Beispiel.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```





## **Daten als Blasendiagrammgrößen darstellen**
Die Eigenschaft **bubble_size_representation** wurde zu den Klassen ChartSeries und ChartSeriesGroup hinzugefügt. **bubble_size_representation** gibt an, wie die Werte für die Blasengröße im Blasendiagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.AREA** und **BubbleSizeRepresentationType.WIDTH**. Entsprechend wurde das Enum **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Darstellungsweisen von Daten als Blasendiagrammgrößen zu spezifizieren. Beispielcode ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Wird ein "Blasendiagramm mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem normalen Diagramm?**

Ja. Es gibt einen separaten Diagrammtyp, **Bubble with 3‑D**. Er wendet 3‑D‑Styling auf die Blasen an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung verfügbar.

**Gibt es ein Limit für die Anzahl der Reihen und Punkte in einem Blasendiagramm?**

Auf API‑Ebene gibt es kein festes Limit; die Einschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit in einem angemessenen Rahmen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Blasendiagramms (PDF, Bilder) aus?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; die Darstellung erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten die allgemeinen Renderregeln für Diagramme (Auflösung, Anti‑Aliasing), sodass für den Druck eine ausreichende DPI gewählt werden sollte.