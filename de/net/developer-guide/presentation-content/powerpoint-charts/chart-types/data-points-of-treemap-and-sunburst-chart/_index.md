---
title: "Datenpunkte in Treemap- und Sunburst-Diagrammen in .NET anpassen"
linktitle: "Datenpunkte in Treemap- und Sunburst-Diagrammen"
type: docs
url: /de/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagramm
- sunburst diagramm
- datenpunkt
- beschriftungsfarbe
- zweigfarbe
- PowerPoint
- präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für .NET verwalten, kompatibel mit PowerPoint-Formaten."
---

Unter anderen PowerPoint-Diagrammtypen gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst**‑Diagramm (auch bekannt als Sunburst‑Grafik, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Grafik oder Mehrstufiges‑Kuchendiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für .NET ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in C#.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Beginnen wir damit, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sunburst‑Diagramms**](/slides/de/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Falls die Datenpunkte des Diagramms formatiert werden müssen, sollten wir Folgendes verwenden:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) Klassen und die Eigenschaft [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) bieten Zugriff zum Formatieren von Datenpunkten von Treemap‑ und Sunburst‑Diagrammen. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) wird verwendet, um mehrstufige Kategorien zuzugreifen – er stellt den Container von [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) Objekten dar. Im Grunde ist es ein Wrapper für [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) mit den speziell für Datenpunkte hinzugefügten Eigenschaften. Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) hat zwei Eigenschaften: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) und [**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label)die Zugriff auf die entsprechenden Einstellungen bieten.

## **Wert eines Datenpunkts anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunkt‑Beschriftung und -Farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Dann setzen Sie die Textfarbe auf Gelb:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe eines Datenpunkt‑Zweigs festlegen**
Farbe des Zweigs „Stem 4“ ändern:
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert Segmente automatisch (in der Regel nach absteigenden Werten, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben erben das [Thema/Palette](/slides/de/net/presentation-theme/) der Präsentation, sofern Sie nicht explizit Füllungen/Schriften festlegen. Für konsistente Ergebnisse sollten Sie feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird beim Export nach PDF/PNG die benutzerdefinierte Zweigfarbe und die Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben die Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien erhalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um benutzerdefinierte Overlays über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `ActualX`/`ActualY` für Elemente zur Verfügung (z. B. für ein [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), was bei der genauen Positionierung von Overlays hilft.