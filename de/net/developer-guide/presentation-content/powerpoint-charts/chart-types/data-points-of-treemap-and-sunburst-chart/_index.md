---
title: Datenpunkte von Treemap- und Sunburst-Diagramm
type: docs
url: /de/net/data-points-of-treemap-and-sunburst-chart/
keywords: "Sunburst-Diagramm, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Fügen Sie ein Sunburst-Diagramm in PowerPoint-Präsentationen in C# oder .NET hinzu"
---

Unter den verschiedenen Typen von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst Graph, Sunburst Diagramm, Radialdiagramm, Radialgraph oder Mehrstufiges Tortendiagramm). Diese Diagramme zeigen hierarchische Daten an, die als Baum organisiert sind - von den Blättern bis zur Spitze des Zweigs. Blätter werden durch die Seriendatenpunkte definiert, und jede nachfolgende geschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für .NET ermöglicht das Formatieren der Datenpunkte von Sunburst-Diagrammen und Treemaps in C#.

Hier ist ein Sunburst-Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns anfangen, ein neues Sunburst-Diagramm zur Präsentation hinzuzufügen:



```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Siehe auch" %}} 
- [**Sunburst-Diagramm erstellen**](/slides/de/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Wenn es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) Klassen 
und [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) Eigenschaft 
bieten Zugriff auf die Formatierung der Datenpunkte von Treemap- und Sunburst-Diagrammen. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
wird verwendet, um auf mehrstufige Kategorien zuzugreifen - es stellt den Container für 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) Objekte dar. 
Im Grunde genommen ist es ein Wrapper für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) mit 
den hinzugefügten Eigenschaften, die spezifisch für Datenpunkte sind. 
Die Klasse [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) hat 
zwei Eigenschaften: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) und 
[**Datenetikett**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label), die 
Zugriff auf die entsprechenden Einstellungen bieten.
## **Datenpunktwert anzeigen**
Wert des Datenpunkts "Blatt 4" anzeigen:



```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Datenpunktbeschriftung und Farbe festlegen**
Datenetikett von "Zweig 1" so einstellen, dass der Serienname ("Series1") anstelle des Kategorienamens angezeigt wird. Dann die Textfarbe auf Gelb setzen:



```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Datenpunktzweigfarbe festlegen**

Farbe des Zweigs "Stamm 4" ändern:

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