---
title: Chart-Berechnungen für Präsentationen in Python optimieren
linktitle: Chart-Berechnungen
type: docs
weight: 50
url: /de/python-net/chart-calculations/
keywords:
- Chart-Berechnungen
- Chart-Elemente
- Elementposition
- tatsächliche Position
- untergeordnetes Element
- übergeordnetes Element
- Chart-Werte
- tatsächlicher Wert
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verstehen Sie Chart-Berechnungen, Datenaktualisierungen und Präzisionssteuerung in Aspose.Slides für Python via .NET für PPT, PPTX und ODP, mit praktischen Codebeispielen."
---

## **Tatsächliche Werte von Diagrammelementen berechnen**
Aspose.Slides for Python via .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Dies hilft Ihnen, die tatsächlichen Werte von Diagrammelementen zu berechnen. Die tatsächlichen Werte umfassen die Position von Elementen, die das IActualLayout‑Interface implementieren (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) und die tatsächlichen Achsenwerte (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```


## **Tatsächliche Position von übergeordneten Diagrammelementen berechnen**
Aspose.Slides for Python via .NET bietet eine einfache API zum Abrufen dieser Eigenschaften. Die Eigenschaften von IActualLayout liefern Informationen über die tatsächliche Position des übergeordneten Diagrammelements. Es ist erforderlich, vorher die Methode IChart.ValidateChartLayout() aufzurufen, um die Eigenschaften mit tatsächlichen Werten zu füllen.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```


## **Informationen im Diagramm ausblenden**
Dieses Thema erklärt, wie Sie Informationen im Diagramm ausblenden können. Mit Aspose.Slides for Python via .NET können Sie **Titel, Vertikale Achse, Horizontale Achse** und **Gitternetzlinien** im Diagramm ausblenden. Das nachstehende Code‑Beispiel zeigt, wie diese Eigenschaften verwendet werden.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Ausblenden des Diagrammtitels
    chart.has_title = False

    # Ausblenden der Werteachse
    chart.axes.vertical_axis.is_visible = False

    # Sichtbarkeit der Kategorienachse
    chart.axes.horizontal_axis.is_visible = False

    # Ausblenden der Legende
    chart.has_legend = False

    # Ausblenden der Hauptgitternetzlinien
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Festlegen der Serienlinienfarbe
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Funktionieren externe Excel‑Arbeitsmappen als Datenquelle und wie wirkt sich das auf die Neuberechnung aus?**

Ja. Ein Diagramm kann eine externe Arbeitsmappe referenzieren: Wenn Sie die externe Quelle verbinden oder aktualisieren, werden Formeln und Werte aus dieser Arbeitsmappe übernommen, und das Diagramm spiegelt die Änderungen während Öffnen/Bearbeiten wider. Die API ermöglicht das[Angeben des Pfads zur externen Arbeitsmappe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) und die Verwaltung der verknüpften Daten.

**Kann ich Trendlinien berechnen und anzeigen, ohne die Regression selbst zu implementieren?**

Ja. [Trendlinien](/slides/de/python-net/trend-line/) (linear, exponentiell und weitere) werden von Aspose.Slides hinzugefügt und aktualisiert; ihre Parameter werden automatisch aus den Seriendaten neu berechnet, sodass Sie keine eigenen Berechnungen durchführen müssen.

**Wenn eine Präsentation mehrere Diagramme mit externen Verknüpfungen enthält, kann ich steuern, welche Arbeitsmappe jedes Diagramm für berechnete Werte verwendet?**

Ja. Jedes Diagramm kann auf seine eigene[externe Arbeitsmappe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) verweisen, oder Sie können pro Diagramm unabhängig von den anderen eine externe Arbeitsmappe erstellen/ersetzen.