---
title: Blasendiagramm
type: docs
url: /de/net/bubble-chart/
keywords: "Blasendiagramm, Diagrammgröße, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Diagrammgröße von Blasendiagrammen in PowerPoint-Präsentationen in C# oder .NET"
---

## **Größenanpassung von Blasendiagrammen**
Aspose.Slides für .NET bietet Unterstützung für die Größenanpassung von Blasendiagrammen. In Aspose.Slides für .NET wurden die Eigenschaften **IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** hinzugefügt. Unten steht ein Beispiel.  
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Daten als Größen von Blasendiagrammen darstellen**
Die Eigenschaft **BubbleSizeRepresentation** wurde zu den Schnittstellen IChartSeries, IChartSeriesGroup und den zugehörigen Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Blasengrößenwerte im Blasendiagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Entsprechend wurde das Aufzählungselement **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Darstellungs‑weisen von Daten als Größen von Blasendiagrammen anzugeben. Beispielcode ist unten angegeben.  
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Wird ein „Blasendiagramm mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich vom normalen Diagramm?**  
Ja. Es gibt einen eigenen Diagrammtyp „Bubble with 3‑D“. Er wendet eine 3‑D‑Darstellung auf die Blasen an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑Aufzählung verfügbar.

**Gibt es eine Begrenzung der Anzahl von Serien und Punkten in einem Blasendiagramm?**  
Auf API‑Ebene gibt es keine feste Obergrenze; die Beschränkungen ergeben sich aus Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendergeschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Blasendiagramms aus (PDF, Bilder)?**  
Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendern erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten die allgemeinen Regeln zur Diagrammdarstellung (Auflösung, Antialiasing), daher sollten Sie für den Druck eine ausreichende DPI‑Zahl wählen.