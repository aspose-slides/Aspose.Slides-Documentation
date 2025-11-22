---
title: Erstellen oder Aktualisieren von PowerPoint-Präsentationsdiagrammen in Python
linktitle: Ein Diagramm erstellen oder aktualisieren
type: docs
weight: 10
url: /de/python-net/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kreisdiagramm
- Liniendiagramm
- Baumkarte-Diagramm
- Börsendiagramm
- Box‑Und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst‑Diagramm
- Histogramm‑Diagramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Es behandelt das Hinzufügen, Formatieren und Bearbeiten von Diagrammen in Präsentationen mit praktischen Code‑Beispielen in Python."
---

## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung, wie Sie Diagramme mit Aspose.Slides für Python via .NET erstellen und anpassen. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen zu entsprechen. Im gesamten Artikel veranschaulichen detaillierte Code‑Beispiele jeden Schritt – vom Initialisieren der Präsentation und des Diagrammobjekts bis hin zur Konfiguration von Serien, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein solides Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und so den Prozess der Erstellung datengetriebener Präsentationen optimieren.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Arbeitsblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Durch die Verwendung von Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, kondensieren oder zusammenfassen;
* Muster und Trends in Daten aufdecken;
* die Richtung und das Momentum von Daten über die Zeit oder in Relation zu einer bestimmten Maßeinheit ableiten;
* Ausreißer, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 

Verwenden Sie die [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung im [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/)-Namespace. Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Gruppierte Säulendiagramme erstellen**

Dieser Abschnitt erklärt, wie Sie gruppierte Säulendiagramme mit Aspose.Slides für Python via .NET erstellen. Sie lernen, wie Sie eine Präsentation initialisieren, ein Diagramm hinzufügen und Elemente wie Titel, Daten, Serien, Kategorien und Stil anpassen. Befolgen Sie die nachstehenden Schritte, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.  
1. Fügen Sie dem Diagramm einen Titel hinzu.  
1. Greifen Sie auf das Daten‑Arbeitsblatt des Diagramms zu.  
1. Entfernen Sie alle Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Wenden Sie eine Füllfarbe auf die Diagramm‑Serien an.  
1. Fügen Sie Beschriftungen zu den Diagramm‑Serien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert, wie ein gruppiertes Säulendiagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
    with slides.Presentation() as presentation:

        # Greifen Sie auf die erste Folie zu.
        slide = presentation.slides[0]

        # Fügen Sie ein gruppiertes Säulendiagramm mit den Standarddaten hinzu.
        chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

        # Legen Sie den Diagrammtitel fest.
        chart.chart_title.add_text_frame_for_overriding("Sample Title")
        chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
        chart.chart_title.height = 20
        chart.has_title = True

        # Stellen Sie ein, dass die erste Serie Werte anzeigt.
        chart.chart_data.series[0].labels.default_data_label_format.show_value = True

        # Legen Sie den Index des Diagrammdatenblatts fest.
        worksheet_index = 0

        # Holen Sie das Diagrammdaten-Workbook.
        workbook = chart.chart_data.chart_data_workbook

        # Löschen Sie die standardmäßig generierten Serien und Kategorien.
        chart.chart_data.series.clear()
        chart.chart_data.categories.clear()

        # Fügen Sie neue Serien hinzu.
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

        # Fügen Sie neue Kategorien hinzu.
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

        # Holen Sie die erste Diagrammserie.
        series = chart.chart_data.series[0]

        # Befüllen Sie die Seriendaten.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

        # Legen Sie die Füllfarbe für die Serie fest.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.red

        # Holen Sie die zweite Diagrammserie.
        series = chart.chart_data.series[1]

        # Befüllen Sie die Seriendaten.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

        # Legen Sie die Füllfarbe für die Serie fest.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.green

        # Stellen Sie die erste Beschriftung so ein, dass der Kategorienname angezeigt wird.
        label = series.data_points[0].label
        label.data_label_format.show_category_name = True

        label = series.data_points[1].label
        label.data_label_format.show_series_name = True

        # Stellen Sie die Serie so ein, dass für die dritte Beschriftung der Wert angezeigt wird.
        label = series.data_points[2].label
        label.data_label_format.show_value = True
        label.data_label_format.show_series_name = True
        label.data_label_format.separator = "/"
                    
        # Speichern Sie die Präsentation als PPTX-Datei auf dem Datenträger.
        presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Clustered Column chart](clustered_column_chart.png)

### **Punktediagramme erstellen**

Punktediagramme (auch Streudiagramme oder x‑y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren.

Verwenden Sie ein Punktediagramm, wenn:

* Sie gepaarte numerische Daten haben.  
* Sie zwei Variablen besitzen, die gut zusammenpassen.  
* Sie feststellen möchten, ob die beiden Variablen zusammenhängen.  
* Sie eine unabhängige Variable mit mehreren Werten für eine abhängige Variable haben.

Dieser Python‑Code zeigt, wie Sie ein Punktediagramm mit unterschiedlichen Markerserien erstellen:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Erstellen Sie das Standard-Streudiagramm.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Legen Sie den Index des Diagrammdatenblatts fest.
    worksheet_index = 0

    # Holen Sie das Diagrammdaten-Workbook.
    workbook = chart.chart_data.chart_data_workbook

    # Löschen Sie die Standard-Serien.
    chart.chart_data.series.clear()

    # Fügen Sie neue Serien hinzu.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Holen Sie die erste Diagrammserie.
    series = chart.chart_data.series[0]

    # Fügen Sie der Serie einen neuen Punkt (1:3) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Fügen Sie einen neuen Punkt (2:10) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Ändern Sie den Serientyp.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Ändern Sie den Marker der Diagrammserie.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Holen Sie die zweite Diagrammserie.
    series = chart.chart_data.series[1]

    # Fügen Sie der Diagrammserie einen neuen Punkt (5:2) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Fügen Sie einen neuen Punkt (3:1) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Fügen Sie einen neuen Punkt (2:2) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Fügen Sie einen neuen Punkt (5:1) hinzu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Ändern Sie den Marker der Diagrammserie.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Scatter chart](scatter_chart.png)

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Enthält Ihre Datenmenge jedoch viele Teile oder Beschriftungen, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.PIE` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben auf die Segmente des Kreisdiagramms an.  
1. Legen Sie Beschriftungen für die Serien fest.  
1. Aktivieren Sie Führungs‑ (Leader‑) Linien für die Serienbeschriftungen.  
1. Setzen Sie den Rotationswinkel für das Kreisdiagramm.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Kreisdiagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation() as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Fügen Sie ein Diagramm mit den Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Legen Sie den Diagrammtitel fest.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Stellen Sie die erste Serie so ein, dass Werte angezeigt werden.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Legen Sie den Index des Diagrammdatenblatts fest.
    worksheet_index = 0

    # Holen Sie das Diagrammdaten-Workbook.
    workbook = chart.chart_data.chart_data_workbook

    # Löschen Sie die standardmäßig generierten Serien und Kategorien.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Fügen Sie neue Kategorien hinzu.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Fügen Sie neue Serien hinzu.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Befüllen Sie die Seriendaten.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Legen Sie die Segmentfarbe fest.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Legen Sie die Segmentgrenze fest.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Legen Sie die Segmentgrenze fest.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Legen Sie die Segmentgrenze fest.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Erstellen Sie benutzerdefinierte Beschriftungen für jede Kategorie in der neuen Serie.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Setzen Sie die Serie so, dass Führungs­linien für das Diagramm angezeigt werden.
    series.labels.default_data_label_format.show_leader_lines = True

    # Legen Sie den Drehwinkel für die Kreisdiagramm‑Segmente fest.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Speichern Sie die Präsentation als PPTX-Datei auf dem Datenträger.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Pie chart](pie_chart.png)

### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniendiagramme genannt) eignen sich am besten, wenn Sie Änderungen von Werten über die Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie eine große Datenmenge gleichzeitig vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenserien hervorheben und vieles mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.LINE` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Liniendiagramm erstellt wird:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


Standardmäßig werden Punkte in einem Liniendiagramm durch gerade, durchgängige Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, können Sie den gewünschten Strichtyp wie folgt angeben:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


Das Ergebnis:

![The Line chart](line_chart.png)

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien darstellen und schnell die großen Beitragsleister innerhalb jeder Kategorie hervorheben möchten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.TREEMAP` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Tree‑Map‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Zweig 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Zweig 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```



Das Ergebnis:

![The Treemap chart](treemap_chart.png)

### **Börsendiagramme erstellen**

Börsendiagramme werden verwendet, um Finanzdaten wie Eröffnungs-, Höchst-, Tief‑ und Schlusskurse darzustellen und so Markttrends sowie Volatilität zu analysieren. Sie bieten wesentliche Einblicke in die Kursentwicklung und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.OPEN_HIGH_LOW_CLOSE` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Legen Sie das Format der HiLowLines fest.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Börsendiagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Stock chart](stock_chart.png)

### **Box‑Und‑Whisker‑Diagramme erstellen**

Box‑Und‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem zentrale statistische Kennzahlen wie Median, Quartile und mögliche Ausreißer zusammengefasst werden. Sie sind besonders nützlich in explorativer Datenanalyse und statistischen Studien, um Datenvariabilität schnell zu erfassen und Anomalien zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.BOX_AND_WHISKER` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Box‑Und‑Whisker‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```


### **Trichter‑Diagramme erstellen**

Trichter‑Diagramme visualisieren Prozesse mit aufeinanderfolgenden Stufen, wobei das Datenvolumen von einer Stufe zur nächsten abnimmt. Sie helfen besonders dabei, Konversionsraten zu analysieren, Engpässe zu identifizieren und die Effizienz von Vertriebs‑ oder Marketing‑Prozessen zu überwachen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.FUNNEL` an.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Trichter‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Funnel chart](funnel_chart.png)

### **Sunburst‑Diagramme erstellen**

Sunburst‑Diagramme visualisieren hierarchische Daten, indem Ebenen als konzentrische Ringe dargestellt werden. Sie verdeutlichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal, um verschachtelte Kategorien und Unterkategorien kompakt darzustellen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.SUNBURST` an.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Sunburst‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Zweig 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Zweig 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Sunburst chart](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme stellen die Verteilung numerischer Daten dar, indem Werte in Klassen (Bins) gruppiert werden. Sie sind besonders nützlich, um Muster wie Häufigkeit, Schiefe und Streuung zu erkennen und Ausreißer in einem Datensatz zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.HISTOGRAM` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Histogramm‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Histogram chart](histogram_chart.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme zeigen multivariate Daten in einem zweidimensionalen Format, wodurch mehrere Variablen gleichzeitig leicht miteinander verglichen werden können. Sie eignen sich besonders, um Muster, Stärken und Schwächen über verschiedene Leistungskennzahlen hinweg zu erkennen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.RADAR` an.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Radar‑Diagramm erstellt wird:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Radar chart](radar_chart.png)

### **Mehrkategorie‑Diagramme erstellen**

Mehrkategorie‑Diagramme zeigen Daten, die mehr als eine kategoriale Gruppierung enthalten, sodass Sie Werte über mehrere Dimensionen hinweg gleichzeitig vergleichen können. Sie sind besonders hilfreich, wenn Sie Trends und Zusammenhänge in komplexen, mehrschichtigen Datensätzen analysieren müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.  
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.  
1. Entfernen Sie die Standard‑Serien und -Kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Serien hinzu.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Mehrkategorie‑Diagramm erstellt wird:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Serie hinzufügen.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Präsentation mit dem Diagramm speichern.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The multi category chart](multi_category_chart.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme visualisieren geografische Daten, indem Informationen bestimmten Standorten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie sind besonders nützlich, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend darzustellen.

Dieser Python‑Code zeigt, wie ein Karten‑Diagramm erstellt wird:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The Map chart](map_chart.png)

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieser Diagrammtyp ermöglicht es, Unterschiede zwischen mehreren Datensätzen hervorzuheben, zu vergleichen oder zu prüfen und Beziehungen zwischen ihnen zu erkennen.

![The combination chart](combination_chart.png)

Dieser Python‑Code zeigt, wie Sie ein Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellen:
```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    presentation = slides.Presentation()

    chart = create_chart(presentation.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)

    presentation.save("ComboChart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    series = chart.chart_data.series[1]

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    return chart


def add_first_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Series 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```


## **Diagramme aktualisieren**

Aspose.Slides für Python via .NET ermöglicht das Aktualisieren von PowerPoint‑Diagrammen durch Ändern von Diagrammdaten, Formatierung und Styling. Diese Funktion vereinfacht das Aktualisieren von Präsentationen mit dynamischen Inhalten und stellt sicher, dass Diagramme aktuelle Daten und visuelle Standards korrekt wiedergeben.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, die die Präsentation mit dem Diagramm repräsentiert.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Durchlaufen Sie alle Shapes, um das Diagramm zu finden.  
1. Greifen Sie auf das Daten‑Arbeitsblatt des Diagramms zu.  
1. Ändern Sie die Diagramm‑Datenserien, indem Sie die Serienwerte anpassen.  
1. Fügen Sie eine neue Serie hinzu und füllen Sie deren Daten.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie ein Diagramm aktualisieren:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanziieren Sie die Presentation‑Klasse, die eine PPTX‑Datei darstellt.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Legen Sie den Index des Diagrammdatenblatts fest.
            worksheet_index = 0

            # Holen Sie das Diagrammdaten‑Workbook.
            workbook = chart.chart_data.chart_data_workbook

            # Ändern Sie die Diagrammkategorienamen.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Holen Sie die erste Diagrammserie.
            series = chart.chart_data.series[0]

            # Aktualisieren Sie die Seriendaten.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Ändern des Seriennamens.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Holen Sie die zweite Diagrammserie.
            series = chart.chart_data.series[1]

            # Aktualisieren Sie die Seriendaten.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Ändern des Seriennamens.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Fügen Sie eine neue Serie hinzu.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Füllen Sie die Seriendaten.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Speichern Sie die Präsentation mit dem Diagramm.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Datenbereich für Diagramme festlegen**

Aspose.Slides für Python via .NET bietet die Flexibilität, einen bestimmten Datenbereich aus einem Arbeitsblatt als Quelle für die Diagrammdaten zu definieren. Das bedeutet, dass Sie einen Teil Ihres Arbeitsblatts direkt dem Diagramm zuordnen können, sodass Sie genau steuern, welche Zellen zu den Serien und Kategorien des Diagramms beitragen. Auf diese Weise können Sie Diagramme leicht aktualisieren und mit den neuesten Änderungen im Arbeitsblatt synchronisieren, sodass Ihre PowerPoint‑Präsentationen aktuelle und genaue Informationen enthalten.

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, die die Präsentation mit dem Diagramm repräsentiert.  
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
1. Durchlaufen Sie alle Shapes, um das Diagramm zu finden.  
1. Greifen Sie auf die Diagrammdaten zu und legen Sie den Bereich fest.  
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie den Datenbereich für ein Diagramm festlegen:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```


## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Serie automatisch ein unterschiedliches Standard‑Marker‑Symbol.

Dieser Python‑Code zeigt, wie Sie einen Diagramm‑Serien‑Marker automatisch festlegen:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Seriendaten füllen.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides für Python via .NET unterstützt?**

Aspose.Slides für Python via .NET unterstützt eine breite Palette von Diagrammtypen, darunter Balken, Linien, Kreis, Flächen, Streu, Histogramm, Radar und viele mehr. Diese Flexibilität ermöglicht die Auswahl des am besten geeigneten Diagrammtyps für Ihre Datenvisualisierungs‑Bedürfnisse.

**Wie füge ich einer Folie ein neues Diagramm hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse, holen Sie die gewünschte Folie über ihren Index und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zugreifen, die Standard‑Serien und -Kategorien entfernen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert aktualisieren, sodass es die neuesten Daten widerspiegelt.

**Ist es möglich, das Aussehen des Diagramms anzupassen?**

Ja, Aspose.Slides für Python via .NET bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere Formatierungselemente ändern, um das Diagramm an Ihre spezifischen Designanforderungen anzupassen.