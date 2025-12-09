---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen in .NET
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Zweigfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für .NET verwalten, kompatibel mit PowerPoint-Formaten."
---

Neben anderen PowerPoint‑Diagrammtypen gibt es zwei „hierarchische“ Typen – **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Graph oder Mehrstufiges‑Kuchendiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum strukturiert sind – von den Blättern bis zur Spitze des Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie bestimmt. Aspose.Slides for .NET ermöglicht das Formatieren von Datenpunkten des Sunburst‑Diagramms und des Treemap‑Diagramms in C#.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

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
- [**Sunburst‑Diagramm erstellen**](/slides/de/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Falls es nötig ist, Datenpunkte des Diagramms zu formatieren, sollten wir die folgenden verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) Klassen 
und [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) Eigenschaft 
bieten Zugriff zum Formatieren von Datenpunkten der Treemap‑ und Sunburst‑Diagramme. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
wird verwendet, um mehrstufige Kategorien zuzugreifen – er repräsentiert den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) Objekten. 
Im Grunde ist er ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) mit 
den Eigenschaften, die speziell für Datenpunkte hinzugefügt wurden. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) hat 
zwei Eigenschaften: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) und 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) , die 
Zugriff auf die entsprechenden Einstellungen bieten.

## **Datenpunktwert anzeigen**
Wert des Datenpunkts „Leaf 4“ anzeigen:
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Datenpunktbeschriftung und -farbe festlegen**
Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird. Anschließend setzen Sie die Textfarbe auf Gelb:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Farbe des Datenpunkt‑Zweigs festlegen**
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

Nein. PowerPoint sortiert Segmente automatisch (in der Regel absteigend nach Wert, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen es durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben übernehmen das [theme/palette](/slides/de/net/presentation-theme/) der Präsentation, sofern Sie nicht explizit Füllungen/Schriften festlegen. Für konsistente Ergebnisse sollten Sie solide Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation werden Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien beibehalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements für eine benutzerdefinierte Überlagerungsplatzierung über dem Diagramm berechnen?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `ActualX`/`ActualY` für Elemente (z. B. ein [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)) zur Verfügung, was eine präzise Positionierung von Überlagerungen ermöglicht.