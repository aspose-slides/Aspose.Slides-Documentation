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

## **Einführung**

Unter den anderen PowerPoint‑Diagrammtypen gibt es zwei hierarchische — **Treemap** und **Sunburst** (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Chart, Radial‑Graph oder mehrstufiges Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum organisiert sind – von den Blättern bis zur Spitze eines Zweiges. Blätter werden durch die Datenpunkte der Serie definiert, und jede anschließend verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides for Python via .NET ermöglicht das Formatieren von Datenpunkten von Sunburst‑Diagrammen und Treemaps in Python.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten die hierarchischen Datenpunkte definieren:

![Sunburst chart example](sunburst_example.png)

Lassen Sie uns beginnen, indem wir ein neues Sunburst‑Diagramm zur Präsentation hinzufügen:
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```


{{% alert color="primary" title="Siehe auch" %}}
- [**Sunburst‑Diagramme erstellen**](/slides/de/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Wenn Sie Diagrammdatenpunkte formatieren müssen, verwenden Sie die folgenden APIs:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), und die Eigenschaft [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Sie bieten Zugriff auf die Formatierung von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen. [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) wird verwendet, um mehrstufige Kategorien zuzugreifen; es stellt einen Container von [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)‑Objekten dar. Es ist im Wesentlichen ein Wrapper um [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) mit zusätzlichen Eigenschaften, die speziell für Datenpunkte gelten. Der Typ [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) stellt zwei Eigenschaften bereit – [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) und [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) – die Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Datenpunktwerte anzeigen**

Dieser Abschnitt zeigt, wie man den Wert einzelner Datenpunkte in Treemap‑ und Sunburst‑Diagrammen anzeigt. Sie sehen, wie man Wertbeschriftungen für ausgewählte Punkte aktiviert.

Anzeige des Wertes des Datenpunkts „Leaf 4“:
```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```


![Data point value](data_point_value.png)

## **Beschriftungen und Farben für Datenpunkte festlegen**

Dieser Abschnitt zeigt, wie benutzerdefinierte Beschriftungen und Farben für einzelne Datenpunkte in Treemap‑ und Sunburst‑Diagrammen festgelegt werden. Sie lernen, wie Sie auf einen bestimmten Datenpunkt zugreifen, eine Beschriftung zuweisen und eine einfarbige Füllung anwenden, um wichtige Knoten hervorzuheben.

Setzen Sie die Datenbeschriftung „Branch 1“, so dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird, und stellen Sie dann die Textfarbe auf Gelb ein:
```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```


![Data point's label and color](data_point_color.png)

## **Zweigfarben für Datenpunkte festlegen**

Verwenden Sie Zweigfarben, um zu steuern, wie Eltern‑ und Kindknoten in Treemap‑ und Sunburst‑Diagrammen visuell gruppiert werden. Dieser Abschnitt zeigt, wie für einen bestimmten Datenpunkt eine benutzerdefinierte Zweigfarbe festgelegt wird, um wichtige Teilbäume hervorzuheben und die Lesbarkeit des Diagramms zu verbessern.

Ändern Sie die Farbe des Zweigs „Stem 4“:
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

Nein. PowerPoint sortiert Segmente automatisch (in der Regel absteigend nach Wert, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie wirkt sich das Präsentationsthema auf die Farben von Segmenten und Beschriftungen aus?**

Diagrammfarben übernehmen das [theme/palette](/slides/de/python-net/presentation-theme/) der Präsentation, sofern Sie nicht explizit Füllungen/Schriftarten festlegen. Für konsistente Ergebnisse sollten Sie einfarbige Füllungen und Textformatierungen auf den gewünschten Ebenen festsetzen.

**Wird der Export nach PDF/PNG benutzerdefinierte Zweigfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabeformaten erhalten, da Aspose.Slides das Diagramm mit den angewendeten Formatierungen rendert.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements berechnen, um benutzerdefinierte Overlays über dem Diagramm zu platzieren?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `actual_x`/`actual_y` für Elemente zur Verfügung (z. B. für einen [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)), was bei der genauen Positionierung von Overlays hilft.