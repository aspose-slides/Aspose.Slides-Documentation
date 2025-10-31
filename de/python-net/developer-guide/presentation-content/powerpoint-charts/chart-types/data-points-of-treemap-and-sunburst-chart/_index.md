---
title: Datenpunkte in Treemap- und Sunburst-Diagrammen in Python anpassen
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Datenpunkt
- Beschriftungsfarbe
- Verzweigungsfarbe
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Datenpunkte in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für Python via .NET verwalten, kompatibel mit PowerPoint und OpenDocument-Formaten."
---

## **Einleitung**

Unter den PowerPoint-Diagrammtypen gibt es zwei hierarchische – **Treemap** und **Sunburst** (auch bekannt als Sunburst‑Graph, Sunburst‑Diagramm, Radial‑Diagramm, Radial‑Graph oder Mehrstufiges Kreisdiagramm). Diese Diagramme zeigen hierarchische Daten, die als Baum strukturiert sind – von Blättern bis zur Spitze eines Astes. Die Blätter werden durch die Datenpunkte der Serie definiert, und jede nachfolgende verschachtelte Gruppierungsebene wird durch die entsprechende Kategorie definiert. Aspose.Slides für Python via .NET ermöglicht es Ihnen, Datenpunkte von Sunburst‑Diagrammen und Treemaps in Python zu formatieren.

Hier ist ein Sunburst‑Diagramm, bei dem die Daten in der Spalte Series1 die Blattknoten definieren, während die anderen Spalten hierarchische Datenpunkte definieren:

![Beispiel für ein Sunburst-Diagramm](sunburst_example.png)

Lassen Sie uns ein neues Sunburst‑Diagramm zur Präsentation hinzufügen:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Siehe auch" %}}
- [**Sunburst-Diagramme erstellen**](/slides/de/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Wenn Sie Diagrammdatenpunkte formatieren müssen, verwenden Sie die folgenden APIs:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/), und die Eigenschaft [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Sie ermöglichen den Zugriff auf die Formatierung von Datenpunkten in Treemap‑ und Sunburst‑Diagrammen. Der [ChartDataPointLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevelsmanager/) wird verwendet, um mehrstufige Kategorien zu greifen; er stellt einen Container für [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/)-Objekte dar. Er ist im Wesentlichen ein Wrapper um den [ChartCategoryLevelsManager](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/) mit zusätzlichen, spezifischen Eigenschaften für Datenpunkte. Der Typ [ChartDataPointLevel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/) expose zwei Eigenschaften – [format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/format/) und [label](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointlevel/label/) – die Zugriff auf die entsprechenden Einstellungen ermöglichen.

## **Werte der Datenpunkte anzeigen**

Dieser Abschnitt zeigt, wie der Wert einzelner Datenpunkte in Treemap‑ und Sunburst‑Diagrammen angezeigt wird. Sie sehen, wie Sie Werte‑Beschriftungen für ausgewählte Punkte aktivieren.

Den Wert des Datenpunkts „Leaf 4“ anzeigen:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Wert des Datenpunkts](data_point_value.png)

## **Beschriftungen und Farben für Datenpunkte festlegen**

Dieser Abschnitt zeigt, wie benutzerdefinierte Beschriftungen und Farben für einzelne Datenpunkte in Treemap‑ und Sunburst‑Diagrammen festgelegt werden. Sie lernen, wie Sie auf einen bestimmten Datenpunkt zugreifen, eine Beschriftung zuweisen und eine einfarbige Füllung anwenden, um wichtige Knoten hervorzuheben.

Die Datenbeschriftung „Branch 1“ so einstellen, dass der Serienname („Series1“) anstelle des Kategorienamens angezeigt wird, und anschließend die Textfarbe auf Gelb setzen:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Beschriftung und Farbe des Datenpunkts](data_point_color.png)

## **Verzweigungsfarben für Datenpunkte festlegen**

Verzweigungsfarben werden verwendet, um zu steuern, wie übergeordnete und untergeordnete Knoten visuell gruppiert werden in Treemap‑ und Sunburst‑Diagrammen. Dieser Abschnitt zeigt, wie eine benutzerdefinierte Verzweigungsfarbe für einen bestimmten Datenpunkt gesetzt wird, um wichtige Unterbäume hervorzuheben und die Lesbarkeit des Diagramms zu verbessern.

Farbe des Astes „Stem 4“ ändern:

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

![Verzweigungsfarbe](branch_color.png)

## **FAQ**

**Kann ich die Reihenfolge (Sortierung) der Segmente in Sunburst/Treemap ändern?**

Nein. PowerPoint sortiert Segmente automatisch (typischerweise nach absteigenden Werten, im Uhrzeigersinn). Aspose.Slides spiegelt dieses Verhalten wider: Sie können die Reihenfolge nicht direkt ändern; Sie erreichen dies durch Vorverarbeitung der Daten.

**Wie beeinflusst das Präsentationsthema die Farben von Segmenten und Beschriftungen?**

Diagrammfarben erben das [Thema/Palette](/slides/de/python-net/presentation-theme/) der Präsentation, solange Sie nicht explizit Füllungen/Schriften setzen. Für konsistente Ergebnisse sollten Sie einfarbige Füllungen und Textformatierungen auf den erforderlichen Ebenen festlegen.

**Werden beim Export nach PDF/PNG benutzerdefinierte Verzweigungsfarben und Beschriftungseinstellungen beibehalten?**

Ja. Beim Export der Präsentation bleiben Diagrammeinstellungen (Füllungen, Beschriftungen) in den Ausgabeformaten erhalten, da Aspose.Slides die Diagrammformatierung anwendet.

**Kann ich die tatsächlichen Koordinaten einer Beschriftung/eines Elements für benutzerdefinierte Overlays über dem Diagramm ermitteln?**

Ja. Nachdem das Diagrammlayout validiert wurde, stehen `actual_x`/`actual_y` für Elemente (z. B. für ein [DataLabel](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/)) zur Verfügung, was präzises Positionieren von Overlays ermöglicht.