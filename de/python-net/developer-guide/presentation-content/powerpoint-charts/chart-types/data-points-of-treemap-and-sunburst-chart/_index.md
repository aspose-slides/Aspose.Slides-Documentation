---
title: Customize Data Points in Treemap and Sunburst Charts in Python
linktitle: Data Points in Treemap and Sunburst Charts
type: docs
url: /de/python-net/data-points-of-treemap-and-sunburst-chart/
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
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Python via .NET verwalten, kompatibel mit PowerPoint- und OpenDocument-Formaten."
---

## **Einleitung**

Neben anderen PowerPoint‑Diagrammtypen gibt es zwei hierarchische – **Treemap** und **Sunburst** (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Graph oder mehrstufiges Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze eines Astes. Die Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Python via .NET ermöglicht das Formatieren von Datenpunkten von Sunburst‑Diagrammen und Treemaps in Python.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte *Series1* die Blattknoten definieren, während die anderen Spalten die hierarchischen Datenpunkte definieren:

![Sunburst chart example](sunburst_example.png)

Beginnen wir damit, ein neues Sunburst‑Diagramm zur Präsentation hinzuzufügen:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Siehe auch" %}}
- [**Sunburst‑Diagramme erstellen**](/slides/de/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Wenn Sie Diagrammdatenpunkte formatieren müssen, verwenden Sie die folgenden APIs:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) und die Eigenschaft [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Sie bieten Zugriff auf die Formatierung von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) wird verwendet, um mehrstufige Kategorien zuzugreifen; er stellt einen Container für [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)-Objekte dar. Im Wesentlichen ist er ein Wrapper um [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) mit zusätzlichen, speziell für Datenpunkte definierten Eigenschaften. Der Typ [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) stellt zwei Eigenschaften bereit – [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) und [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) – die Zugriff auf die jeweiligen Einstellungen ermöglichen.

## **Anzeige von Datenpunktwerten**

Dieser Abschnitt zeigt, wie Sie den Wert einzelner Datenpunkte in Treemap‑ und Sunburst‑Diagrammen anzeigen können. Sie sehen, wie Sie Wertebeschriftungen für ausgewählte Punkte aktivieren.

Wert des Datenpunkts „Leaf 4“ anzeigen:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Beschriftungen und Farben für Datenpunkte festlegen**

Dieser Abschnitt zeigt, wie Sie benutzerdefinierte Beschriftungen und Farben für einzelne Datenpunkte in Treemap‑ und Sunburst‑Diagrammen setzen. Sie lernen, wie Sie einen bestimmten Datenpunkt ansprechen, eine Beschriftung zuweisen und eine einfarbige Füllung anwenden, um wichtige Knoten hervorzuheben.

Setzen Sie die Datenbeschriftung von „Branch 1“ so, dass sie den Seriennamen („Series1“) anstelle des Kategorienamens anzeigt, und ändern Sie dann die Textfarbe zu Gelb:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Astfarben für Datenpunkte festlegen**

Verwenden Sie Astfarben, um zu steuern, wie übergeordnete und untergeordnete Knoten visuell in Treemap‑ und Sunburst‑Diagrammen gruppiert werden. Dieser Abschnitt zeigt, wie Sie für einen bestimmten Datenpunkt eine benutzerdefinierte Astfarbe festlegen, um wichtige Teilbäume hervorzuheben und die Lesbarkeit des Diagramms zu verbessern.

Farbe des Astes „Stem 4“ ändern:

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

Nein. PowerPoint sortiert Segmente automatisch (in der Regel absteigend, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben erben das [Thema/Palette](/slides/de/python-net/presentation-theme/) der Präsentation, sofern Sie nicht ausdrücklich Füllungen/Schriften setzen. Für konsistente Ergebnisse sollten Sie solide Füllungen und Textformatierungen auf den erforderlichen Ebenen fixieren.

**Werden beim Export nach PDF/PNG benutzerdefinierte Astfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabeformaten erhalten, weil Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um benutzerdefinierte Overlays über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `actual_x`/`actual_y` für Elemente (z. B. ein [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)) zur Verfügung, was eine präzise Positionierung von Overlays ermöglicht.