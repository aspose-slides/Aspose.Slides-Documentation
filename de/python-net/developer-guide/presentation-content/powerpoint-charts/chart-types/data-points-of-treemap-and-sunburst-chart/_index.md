---
title: Datenpunkte von Treemap- und Sunburst-Diagramm
type: docs
url: /de/python-net/data-points-of-treemap-and-sunburst-chart/
keywords: "Sunburst-Diagramm, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Fügen Sie ein Sunburst-Diagramm in eine PowerPoint-Präsentation in Python ein"
---

Unter den verschiedenen Arten von PowerPoint-Diagrammen gibt es zwei "hierarchische" Typen - **Treemap** und **Sunburst** Diagramm (auch bekannt als Sunburst-Graph, Sunburst-Diagramm, Radial-Diagramm, Radial-Graph oder Multi-Level-Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind - von den Blättern bis zur Spitze des Zweiges. Blätter werden durch die Seriedatenpunkte definiert, und jede nachfolgende geschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Python über .NET ermöglicht die Formatierung von Datenpunkten des Sunburst-Diagramms und der Treemap in Python.

Hier ist ein Sunburst-Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während andere Spalten hierarchische Datenpunkte definieren:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Lassen Sie uns damit beginnen, ein neues Sunburst-Diagramm zur Präsentation hinzuzufügen:



```py
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
```

{{% alert color="primary" title="Siehe auch" %}} 
- [**Erstellen eines Sunburst-Diagramms**](/slides/de/python-net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Wenn es notwendig ist, die Datenpunkte des Diagramms zu formatieren, sollten wir Folgendes verwenden:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/), 
[IChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) Klassen 
und [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/) Eigenschaft 
bieten Zugriff auf die Formatierung von Datenpunkten der Treemap und der Sunburst-Diagramme. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevelsManager/) 
wird verwendet, um auf mehrstufige Kategorien zuzugreifen - es stellt den Container von 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) Objekten dar. 
Im Grunde ist es eine Hülle für 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartCategoryLevelsManager/) mit 
den Eigenschaften, die speziell für Datenpunkte hinzugefügt wurden. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/IChartDataPointLevel/) Klasse hat 
zwei Eigenschaften: [**Format**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/) und 
[**Datenbezeichnung** ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapointlevel/)die 
Zugriff auf die entsprechenden Einstellungen bieten.
## **Datenpunktwert anzeigen**
Zeigen Sie den Wert des Datenpunkts "Leaf 4" an:



```py
    dataPoints = chart.chart_data.series[0].data_points
    dataPoints[3].data_point_levels[0].label.data_label_format.show_value = True
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Datenpunktbezeichnung und Farbe festlegen**
Legen Sie die Datenbezeichnung von "Branch 1" fest, um den Seriennamen ("Series1") anstelle des Kategorienamens anzuzeigen. Setzen Sie dann die Textfarbe auf Gelb:



```py
    branch1Label = dataPoints[0].data_point_levels[2].label
    branch1Label.data_label_format.show_category_name = False
    branch1Label.data_label_format.show_series_name = True

    branch1Label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    branch1Label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Datenpunktzweigfarbe festlegen**

Ändern Sie die Farbe des "Stem 4"-Zweigs:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 100, 100, 450, 400)
    dataPoints = chart.chart_data.series[0].data_points

    stem4branch = dataPoints[9].data_point_levels[1]
    
    stem4branch.format.fill.fill_type = slides.FillType.SOLID
    stem4branch.format.fill.solid_fill_color.color = draw.Color.red
      
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)