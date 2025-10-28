---
title: Anpassen von Datenpunkten in Treemap- und Sunburst-Diagrammen in Python
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Zweigfarbe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Python via .NET verwalten, kompatibel mit PowerPoint- und OpenDocument-Formaten."
---

## **Einleitung**

Neben anderen PowerPoint-Diagrammtypen gibt es zwei hierarchische Typen — **Treemap** und **Sunburst** (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Graph oder Mehr‑Stufen‑Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind — von Blättern bis zur Oberseite eines Astes. Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie bestimmt. Aspose.Slides für Python via .NET ermöglicht Ihnen das Formatieren von Datenpunkten von Sunburst‑Diagrammen und Treemaps in Python.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte *Series1* die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![Beispiel für Sunburst-Diagramm](sunburst_example.png)

Lassen Sie uns ein neues Sunburst‑Diagramm zur Präsentation hinzufügen:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Siehe auch" %}}
- [**Sunburst‑Diagramme erstellen**](/slides/de/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Wenn Sie Datenpunkte von Diagrammen formatieren müssen, verwenden Sie die folgenden APIs:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) und die Eigenschaft [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Sie ermöglichen den Zugriff auf die Formatierung von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen. Der [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) wird verwendet, um mehrstufige Kategorien zuzugreifen; er stellt einen Container für [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)-Objekte dar. Er ist im Wesentlichen ein Wrapper um den [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) mit zusätzlichen Eigenschaften, die speziell für Datenpunkte gelten. Der Typ [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) stellt zwei Eigenschaften bereit — [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) und [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) — die Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Anzeige von Datenpunktwerten**

Dieser Abschnitt zeigt, wie der Wert einzelner Datenpunkte in Treemap‑ und Sunburst‑Diagrammen angezeigt wird. Sie sehen, wie Sie Wertbeschriftungen für ausgewählte Punkte aktivieren.

Anzeige des Werts des Datenpunkts „Leaf 4“:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Wert des Datenpunkts](data_point_value.png)

## **Beschriftungen und Farben für Datenpunkte festlegen**

Dieser Abschnitt zeigt, wie benutzerdefinierte Beschriftungen und Farben für einzelne Datenpunkte in Treemap‑ und Sunburst‑Diagrammen gesetzt werden. Sie lernen, wie Sie einen bestimmten Datenpunkt ansprechen, eine Beschriftung zuweisen und eine einfarbige Füllung anwenden, um wichtige Knoten hervorzuheben.

Setzen Sie die Datenbeschriftung „Branch 1“ so, dass sie den Seriennamen („Series1“) anstelle des Kategorienamens anzeigt, und ändern Sie anschließend die Textfarbe zu Gelb:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Beschriftung und Farbe des Datenpunkts](data_point_color.png)

## **Zweigfarben für Datenpunkte festlegen**

Verwenden Sie Zweigfarben, um zu steuern, wie Eltern‑ und Kindknoten visuell gruppiert werden in Treemap‑ und Sunburst‑Diagrammen. Dieser Abschnitt zeigt, wie Sie für einen bestimmten Datenpunkt eine benutzerdefinierte Zweigfarbe setzen, um wichtige Teilbäume hervorzuheben und die Lesbarkeit des Diagramms zu verbessern.

Ändern Sie die Farbe des „Stem 4“-Astes:

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

![Zweigfarbe](branch_color.png)

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert Segmente automatisch (typischerweise nach absteigenden Werten, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben erben das [Thema/Palette](/slides/de/python-net/presentation-theme/), sofern Sie keine Füllungen/Schriften explizit setzen. Für konsistente Ergebnisse sollten Sie feste Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Wird beim Export nach PDF/PNG die benutzerdefinierte Zweigfarbe und die Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabeformaten erhalten, weil Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um ein benutzerdefiniertes Overlay über dem Diagramm zu positionieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `actual_x`/`actual_y` für Elemente zur Verfügung (z. B. für ein [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), was eine präzise Platzierung von Overlays ermöglicht.