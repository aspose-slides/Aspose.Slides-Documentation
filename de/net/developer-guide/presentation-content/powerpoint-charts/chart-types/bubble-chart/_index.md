---
title: "Anpassen von Bubble-Diagrammen in Präsentationen in .NET"
linktitle: "Bubble-Diagramm"
type: docs
url: /de/net/bubble-chart/
keywords:
- "Bubble-Diagramm"
- "Bubble-Größe"
- "Größen-Skalierung"
- "Größen-Darstellung"
- "PowerPoint"
- "Präsentation"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Erstellen und passen Sie leistungsstarke Bubble-Diagramme in PowerPoint mithilfe von Aspose.Slides für .NET an, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Bubble-Chart-Größenskalierung**
Aspose.Slides für .NET bietet Unterstützung für die Skalierung der Bubble‑Chart‑Größe. In Aspose.Slides für .NET wurden die Eigenschaften **IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** hinzugefügt. Unten ist ein Beispiel angegeben.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Daten als Bubble‑Chart‑Größen darstellen**
Der Eigenschaft **BubbleSizeRepresentation** wurde zu den Schnittstellen IChartSeries, IChartSeriesGroup und den zugehörigen Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Chart dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Entsprechend wurde das Aufzählungselement **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Darstellungsweisen von Daten als Bubble‑Chart‑Größen zu spezifizieren. Beispielcode ist unten angegeben.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wird ein "Bubble-Chart mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem normalen?**

Ja. Es gibt einen separaten Diagrammtyp, "Bubble mit 3‑D". Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Aufzählung [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) verfügbar.

**Gibt es ein Limit für die Anzahl der Serien und Punkte in einem Bubble‑Chart?**

Auf API‑Ebene gibt es kein hartes Limit; die Beschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit in einem vernünftigen Rahmen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Charts aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering wird von der Aspose.Slides‑Engine durchgeführt. Für Raster‑/Vektor‑Formate gelten die allgemeinen Render‑Regeln für Diagrammgrafiken (Auflösung, Anti‑Aliasing), daher sollte für den Druck ein ausreichender DPI‑Wert gewählt werden.