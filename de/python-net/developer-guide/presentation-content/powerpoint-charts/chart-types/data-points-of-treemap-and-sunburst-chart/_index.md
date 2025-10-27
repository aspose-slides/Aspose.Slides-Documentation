---
title: Customize Data Points in Treemap and Sunburst Charts in Python
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /de/python-net/developer-guide/presentation-content/powerpoint-charts/chart-types/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap chart
- sunburst chart
- data point
- label color
- branch color
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage data points in treemap and sunburst charts with Aspose.Slides for Python via .NET, compatible with PowerPoint and OpenDocument formats."
---

## **Einleitung**

Unter den anderen PowerPoint‑Diagrammtypen gibt es zwei hierarchische – **Treemap** und **Sunburst** (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Chart, Radial‑Graph oder Multi‑Level‑Pie‑Chart). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze eines Astes. Die Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides for Python via .NET ermöglicht es Ihnen, Datenpunkte von Sunburst‑Diagrammen und Treemaps in Python zu formatieren.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![Sunburst chart example](sunburst_example.png)

Lassen Sie uns beginnen, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Siehe auch" %}}
- [**Sunburst-Diagramme erstellen**](/slides/de/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Wenn Sie Diagrammdatenpunkte formatieren müssen, verwenden Sie die folgenden APIs:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), und die Eigenschaft [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Sie bieten Zugriff auf die Formatierung von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) wird verwendet, um mehrstufige Kategorien zuzugreifen; es stellt einen Container von [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)-Objekten dar. Es ist im Wesentlichen ein Wrapper um [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) mit zusätzlichen, für Datenpunkte spezifischen Eigenschaften. Der Typ [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) stellt zwei Eigenschaften bereit – [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) und [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) – die Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Anzeigen von Datenpunktwerten**

Dieser Abschnitt zeigt, wie Sie den Wert einzelner Datenpunkte in Treemap‑ und Sunburst‑Diagrammen anzeigen. Sie sehen, wie Sie Wertebeschriftungen für ausgewählte Punkte aktivieren.

Anzeige des Werts des Datenpunkts „Leaf 4“:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Beschriftungen und Farben für Datenpunkte festlegen**

Dieser Abschnitt zeigt, wie Sie benutzerdefinierte Beschriftungen und Farben für einzelne Datenpunkte in Treemap‑ und Sunburst‑Diagrammen festlegen. Sie lernen, wie Sie auf einen bestimmten Datenpunkt zugreifen, eine Beschriftung zuweisen und eine einheitliche Füllung anwenden, um wichtige Knoten hervorzuheben.

Setzen Sie die Datenbeschriftung „Branch 1“ so, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird, und ändern Sie anschließend die Textfarbe zu Gelb:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Zweigfarben für Datenpunkte festlegen**

Verwenden Sie Zweigfarben, um zu steuern, wie Eltern‑ und Kindknoten visuell in Treemap‑ und Sunburst‑Diagrammen gruppiert werden. Dieser Abschnitt zeigt, wie Sie eine benutzerdefinierte Zweigfarbe für einen bestimmten Datenpunkt setzen, um wichtige Teilbäume hervorzuheben und die Lesbarkeit des Diagramms zu verbessern.

Ändern Sie die Farbe des Astes „Stem 4“:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**  
Nein. PowerPoint sortiert Segmente automatisch (typischerweise absteigend, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeiten der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**  
Diagrammfarben erben das [Theme/Palette](/slides/de/python-net/presentation-theme/) der Präsentation, sofern Sie nicht ausdrücklich Füllungen/Schriften festlegen. Für konsistente Ergebnisse sollten Sie solide Füllungen und Textformatierungen auf den erforderlichen Ebenen fixieren.

**Wird beim Export nach PDF/PNG die benutzerdefinierte Zweigfarbe und Beschriftungseinstellungen beibehalten?**  
Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabedateien erhalten, da Aspose.Slides mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um ein benutzerdefiniertes Overlay über dem Diagramm zu platzieren?**  
Ja. Nachdem das Diagrammlayout validiert wurde, stehen `actual_x`/`actual_y` für Elemente (zum Beispiel ein [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)) zur Verfügung, was eine präzise Positionierung von Overlays ermöglicht.