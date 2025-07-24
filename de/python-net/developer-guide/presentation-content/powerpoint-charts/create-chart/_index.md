---
title: Erstellen oder Aktualisieren von Diagrammen in PowerPoint-Präsentationen mit Python
linktitle: Diagramm erstellen oder aktualisieren
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
- Treemap-Diagramm
- Aktienkursdiagramm
- Box-und-Whisker-Diagramm
- Trichterdiagramm
- Sunburst-Diagramm
- Histogramm
- Radar-Diagramm
- Mehrkategorien-Diagramm
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides for Python via .NET erstellen und anpassen. Es behandelt das Hinzufügen, Formatieren und Bearbeiten von Diagrammen in Präsentationen mit praxisnahen Codebeispielen in Python."
---

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet möglicherweise nicht sofort erkennbar sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, kondensieren oder zusammenfassen
* Muster und Trends in Daten sichtbar machen
* die Richtung und den Schwung von Daten im Laufe der Zeit oder in Bezug auf eine bestimmte Maßeinheit ableiten 
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. identifizieren
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Funktion "Einfügen" erstellen, die Vorlagen bereitstellt, die zum Entwerfen vieler Diagrammtypen verwendet werden. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf gängigen Diagrammtypen) und benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 

Um Ihnen das Erstellen von Diagrammen zu ermöglichen, stellt Aspose.Slides die [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) Enumeration im [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) Namespace bereit. Die Mitglieder dieser Enumeration entsprechen verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Erstellen von Normaldiagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an. 
1. Fügen Sie einen Titel für das Diagramm hinzu. 
1. Greifen Sie auf die Arbeitsmappe der Diagrammdaten zu.
1. Löschen Sie alle standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie einige neue Diagrammdaten für die Diagrammserien hinzu.
1. Fügen Sie eine Füllfarbe für die Diagrammserien hinzu.
1. Fügen Sie Beschriftungen für die Diagrammserien hinzu. 
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein normales Diagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Präsentationsklasse instanziieren, die die PPTX-Datei darstellt
with slides.Presentation() as pres:

    # Auf die erste Folie zugreifen
    sld = pres.slides[0]

    # Diagramm mit Standarddaten hinzufügen
    chart = sld.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 0, 0, 500, 500)

    # Diagrammtitel festlegen
    chart.chart_title.add_text_frame_for_overriding("Beispieltitel")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Erste Serie auf Werte anzeigen setzen
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Index des Arbeitsblatts für die Diagrammdaten festlegen
    defaultWorksheetIndex = 0

    # Auf die Arbeitsmappe der Diagrammdaten zugreifen
    fact = chart.chart_data.chart_data_workbook

    # Standardmäßig generierte Serien und Kategorien löschen
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    s = len(chart.chart_data.series)
    s = len(chart.chart_data.categories)

    # Neue Serien hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Neue Kategorien hinzufügen
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Kategorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Kategorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Kategorie 3"))

    # Erste Diagrammserie nehmen
    series = chart.chart_data.series[0]

    # Jetzt die Seriendaten füllen

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Füllfarbe für die Serie festlegen
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red


    # Zweite Diagrammserie nehmen
    series = chart.chart_data.series[1]

    # Jetzt die Seriendaten füllen
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Füllfarbe für die Serie festlegen
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Erste Beschriftung zeigt den Kategorienamen
    lbl = series.data_points[0].label
    lbl.data_label_format.show_category_name = True

    lbl = series.data_points[1].label
    lbl.data_label_format.show_series_name = True

    # Wert für die dritte Beschriftung anzeigen
    lbl = series.data_points[2].label
    lbl.data_label_format.show_value = True
    lbl.data_label_format.show_series_name = True
    lbl.data_label_format.separator = "/"
                
    # Präsentation mit Diagramm speichern
    pres.save("AsposeChart_out-1.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Streudiagrammen**
Streudiagramme (auch als Streudiagramme oder x-y-Diagramme bekannt) werden häufig verwendet, um Muster zu überprüfen oder Korrelationen zwischen zwei Variablen zu zeigen. 

Sie möchten möglicherweise ein Streudiagramm verwenden, wenn 

* Sie gepaarte numerische Daten haben
* Sie 2 Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob 2 Variablen miteinander verbunden sind
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable hat

Dieser Python-Code zeigt Ihnen, wie Sie ein Streudiagramm mit verschiedenen Markern erstellen: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    slide = pres.slides[0]

    # Standarddiagramm erstellen
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 0, 0, 400, 400)

    # Index des Arbeitsblatts für die Diagrammdaten abrufen
    defaultWorksheetIndex = 0

    # Auf die Arbeitsmappe der Diagrammdaten zugreifen
    fact = chart.chart_data.chart_data_workbook

    # Demo-Serie löschen
    chart.chart_data.series.clear()

    # Neue Serien hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 3, "Serie 2"), chart.type)

    # Erste Diagrammserie nehmen
    series = chart.chart_data.series[0]

    # Neuen Punkt (1:3) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 1), fact.get_cell(defaultWorksheetIndex, 2, 2, 3))

    # Neuen Punkt (2:10) hinzufügen
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 2), fact.get_cell(defaultWorksheetIndex, 3, 2, 10))

    # Typ der Serie ändern
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Marker der Diagrammserie ändern
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Zweite Diagrammserie nehmen
    series = chart.chart_data.series[1]

    # Neuen Punkt (5:2) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 5), fact.get_cell(defaultWorksheetIndex, 2, 4, 2))

    # Neuen Punkt (3:1) hinzufügen
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 3), fact.get_cell(defaultWorksheetIndex, 3, 4, 1))

    # Neuen Punkt (2:2) hinzufügen
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 4, 3, 2), fact.get_cell(defaultWorksheetIndex, 4, 4, 2))

    # Neuen Punkt (5:1) hinzufügen
    series.data_points.add_data_point_for_scatter_series(fact.get_cell(defaultWorksheetIndex, 5, 3, 5), fact.get_cell(defaultWorksheetIndex, 5, 4, 1))

    # Marker der Diagrammserie ändern
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    pres.save("AsposeChart_out-2.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Kreisdiagrammen**

Kreisdiagramme eignen sich am besten zur Darstellung der Beziehung zwischen Teil und Ganzem in Daten, insbesondere wenn die Daten kategorische Labels mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Labels enthalten, sollten Sie stattdessen die Verwendung eines Balkendiagramms in Betracht ziehen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (in diesem Fall `ChartType.PIE`) hinzu.
1. Greifen Sie auf die Diagrammdaten IChartDataWorkbook zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Fügen Sie neue Punkte für Diagramme hinzu und fügen Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms hinzu.
1. Setzen Sie Beschriftungen für Serien.
1. Setzen Sie Führungslinien für Serienbeschriftungen.
1. Legen Sie den Winkel für die Drehung der Kreisdiagramm-Segmente fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Kreisdiagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Präsentationsklasse instanziieren, die die PPTX-Datei darstellt
with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen
    slide = presentation.slides[0]

    # Diagramm mit Standarddaten hinzufügen
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Diagrammtitel festlegen
    chart.chart_title.add_text_frame_for_overriding("Beispieltitel")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
    chart.chart_title.height = 20
    chart.has_title = True

    # Erste Serie auf Werte anzeigen setzen
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Index des Arbeitsblatts für die Diagrammdaten festlegen
    defaultWorksheetIndex = 0

    # Auf die Arbeitsmappe der Diagrammdaten zugreifen
    fact = chart.chart_data.chart_data_workbook

    # Standardmäßig generierte Serien und Kategorien löschen
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Kategorien hinzufügen
    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Erstes Qtr"))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Zweites Qtr"))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Drittes Qtr"))

    # Neue Serien hinzufügen
    series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)

    # Jetzt die Seriendaten füllen
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

    # Funktioniert in der neuen Version nicht
    # Neue Punkte hinzufügen und Sektorfarbe festlegen
    # series.IsColorVaried = True
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan
    # Sektorrahmen festlegen
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Sektorrahmen festlegen
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Sektorrahmen festlegen
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Benutzerdefinierte Beschriftungen für jede der Kategorien für die neue Serie erstellen
    lbl1 = series.data_points[0].label

    # lbl.show_category_name = True
    lbl1.data_label_format.show_value = True

    lbl2 = series.data_points[1].label
    lbl2.data_label_format.show_value = True
    lbl2.data_label_format.show_legend_key = True
    lbl2.data_label_format.show_percentage = True

    lbl3 = series.data_points[2].label
    lbl3.data_label_format.show_series_name = True
    lbl3.data_label_format.show_percentage = True

    # Führungsleitungen für das Diagramm anzeigen
    series.labels.default_data_label_format.show_leader_lines = True

    # Rotationswinkel für die Sektoren des Kreisdiagramms festlegen
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Präsentation mit Diagramm speichern
    presentation.save("PieChart_out-3.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Liniendiagrammen**

Liniendiagramme (auch als Liniendiagramme bekannt) eignen sich am besten in Situationen, in denen Sie Änderungen des Wertes über die Zeit darstellen möchten. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends im Laufe der Zeit verfolgen, Anomalien in Datensätzen hervorheben usw.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (in diesem Fall `ChartType.Line`) hinzu.
1. Greifen Sie auf die Diagrammdaten [IChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Liniendiagramm erstellen: 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)
    
    pres.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

Standardmäßig werden Punkte in einem Liniendiagramm durch durchgehende gerade Linien verbunden. Wenn Sie möchten, dass die Punkte stattdessen durch Striche verbunden werden, können Sie Ihren bevorzugten Strichtyp wie folgt angeben: 

```python
lineChart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in lineChart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

### **Erstellen von Treemap-Diagrammen**

Treemap-Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und gleichzeitig schnell auf Artikel hinweisen möchten, die große Beiträge zu jeder Kategorie leisten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (in diesem Fall `ChartType.TREEMAP`) hinzu.
1. Greifen Sie auf die Diagrammdaten IChartDataWorkbook zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Treemap-Diagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #Äste 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Blatt1"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm1")
    leaf.grouping_levels.set_grouping_item(2, "Ast1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Blatt2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Blatt3"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Blatt4"))

    #Äste 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Blatt5"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm3")
    leaf.grouping_levels.set_grouping_item(2, "Ast2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Blatt6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Blatt7"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Blatt8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(wb.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    pres.save("Treemap-4.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Aktiencharts**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (ChartType.OPEN_HIGH_LOW_CLOSE) hinzu.
1. Greifen Sie auf die Diagrammdaten IChartDataWorkbook zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Geben Sie das Format der HiLo-Linien an.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Beispiel-Python-Code zum Erstellen eines Aktiencharts:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 50, 50, 600, 400, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    wb = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(wb.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(wb.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(wb.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(wb.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(wb.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(wb.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    pres.save("output-5.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Box-and-Whisker-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (ChartType.BOX_AND_WHISKER) hinzu.
1. Greifen Sie auf die Diagrammdaten IChartDataWorkbook zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Box-and-Whisker-Diagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Kategorie 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(wb.get_cell(0, "B6", 16))


    pres.save("BoxAndWhisker-6.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Trichterdiagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (ChartType.Funnel) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Trichterdiagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.add(wb.get_cell(0, "A1", "Kategorie 1"))
    chart.chart_data.categories.add(wb.get_cell(0, "A2", "Kategorie 2"))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", "Kategorie 3"))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", "Kategorie 4"))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", "Kategorie 5"))
    chart.chart_data.categories.add(wb.get_cell(0, "A6", "Kategorie 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(wb.get_cell(0, "B6", 500))

    pres.save("Funnel-7.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Sonnendiagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (in diesem Fall `ChartType.SUNBURST`) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Sonnendiagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    #Äste 1
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C1", "Blatt1"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm1")
    leaf.grouping_levels.set_grouping_item(2, "Ast1")

    chart.chart_data.categories.add(wb.get_cell(0, "C2", "Blatt2"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C3", "Blatt3"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm2")

    chart.chart_data.categories.add(wb.get_cell(0, "C4", "Blatt4"))

    #Äste 2
    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C5", "Blatt5"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm3")
    leaf.grouping_levels.set_grouping_item(2, "Ast2")

    chart.chart_data.categories.add(wb.get_cell(0, "C6", "Blatt6"))

    leaf = chart.chart_data.categories.add(wb.get_cell(0, "C7", "Blatt7"))
    leaf.grouping_levels.set_grouping_item(1, "Stamm4")

    chart.chart_data.categories.add(wb.get_cell(0, "C8", "Blatt8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(wb.get_cell(0, "D8", 3))

    pres.save("Sunburst-8.pptx", slides.export.SaveFormat.PPTX)
```


### **Erstellen von Histogramm-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an (`ChartType.HISTOGRAM` in diesem Fall).
1. Greifen Sie auf die Diagrammdaten `IChartDataWorkbook` zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Histogramm-Diagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(wb.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    pres.save("Histogram-9.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Radardiagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an (`ChartType.RADAR` in diesem Fall).
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Radardiagramm erstellen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 400, 300)
    pres.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Mehrkategorial-Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten in dem gewünschten Typ (ChartType.ClusteredColumn) hinzu.
1. Greifen Sie auf die Diagrammdaten IChartDataWorkbook zu.
1. Löschen Sie die standardmäßigen Serien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Mehrkategorial-Diagramm erstellen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]

    ch = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 600, 450)
    ch.chart_data.series.clear()
    ch.chart_data.categories.clear()


    fact = ch.chart_data.chart_data_workbook
    fact.clear(0)
    defaultWorksheetIndex = 0

    category = ch.chart_data.categories.add(fact.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Gruppe1")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c3", "B"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Gruppe2")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c5", "D"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Gruppe3")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c7", "F"))

    category = ch.chart_data.categories.add(fact.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Gruppe4")
    category = ch.chart_data.categories.add(fact.get_cell(0, "c9", "H"))

    # Serien hinzufügen
    series = ch.chart_data.series.add(fact.get_cell(0, "D1", "Serie 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D2", 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D3", 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D4", 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D5", 40))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D6", 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D7", 60))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D8", 70))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, "D9", 80))
    # Präsentation mit Diagramm speichern
    pres.save("AsposeChart_out-10.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Kartendiagrammen**

Ein Kartendiagramm ist eine Visualisierung eines Gebiets, das Daten enthält. Kartendiagramme eignen sich am besten zum Vergleichen von Daten oder Werten über geografische Regionen.

Dieser Python-Code zeigt Ihnen, wie Sie ein Kartendiagramm erstellen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 50, 50, 500, 400, False)
    pres.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Erstellen von Kombinationsdiagrammen**

Ein Kombinationsdiagramm (oder Kombodiagramm) ist ein Diagramm, das zwei oder mehr Diagramme auf einem einzigen Diagramm kombiniert. Ein solches Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei (oder mehr) Datensätzen hervorzuheben, zu vergleichen oder zu überprüfen. Auf diese Weise sehen Sie die Beziehung (falls vorhanden) zwischen den Datensätzen.

![combination-chart-ppt](combination-chart-ppt.png)

Dieser Python-Code zeigt Ihnen, wie Sie ein Kombinationsdiagramm in PowerPoint erstellen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts


def create_combo_chart():
    pres = slides.Presentation()
    chart = create_chart(pres.slides[0])
    add_first_series_to_chart(chart)
    add_second_series_to_chart(chart)
    pres.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Serie 2"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Kategorie 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Kategorie 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Kategorie 3"))

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

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Serie 3"), charts.ChartType.SCATTER_WITH_SMOOTH_LINES)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 0, 1, 3), workbook.get_cell(worksheet_index, 0, 2, 5))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 10), workbook.get_cell(worksheet_index, 1, 4, 13))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 20), workbook.get_cell(worksheet_index, 2, 4, 15))

    series.plot_on_second_axis = True

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 5, "Serie 4"), charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS)

    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 3, 5), workbook.get_cell(worksheet_index, 1, 4, 2))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 1, 5, 10), workbook.get_cell(worksheet_index, 1, 6, 7))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 5, 15), workbook.get_cell(worksheet_index, 2, 6, 12))
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 5, 12), workbook.get_cell(worksheet_index, 3, 6, 9))

    series.plot_on_second_axis = True
```

## **Aktualisierung von Diagrammen**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Präsentation enthält, die das Diagramm enthält.
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Arbeitsmappe der Diagrammdaten zu.
5. Ändern Sie die Daten der Diagrammserien, indem Sie die Serienwerte ändern.
6. Fügen Sie eine neue Serie hinzu und füllen Sie die Daten in ihr.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Diagramm aktualisieren:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Präsentationsklasse, die die PPTX-Datei darstellt
with slides.Presentation(path + "ExistingChart.pptx") as pres:

    # Zugriff auf die erste Folie
    sld = pres.slides[0]

    # Diagramm mit Standarddaten hinzufügen
    chart = sld.shapes[0]

    # Festlegen des Index des Arbeitsblatts für die Diagrammdaten
    defaultWorksheetIndex = 0

    # Auf die Arbeitsmappe der Diagrammdaten zugreifen
    fact = chart.chart_data.chart_data_workbook


    # Kategoriename des Diagramms ändern
    fact.get_cell(defaultWorksheetIndex, 1, 0, "Modifizierte Kategorie 1")
    fact.get_cell(defaultWorksheetIndex, 2, 0, "Modifizierte Kategorie 2")


    # Erste Diagrammserie nehmen
    series = chart.chart_data.series[0]

    # Jetzt die Seriendaten aktualisieren
    fact.get_cell(defaultWorksheetIndex, 0, 1, "Neue_Serie1")# Serienname ändern
    series.data_points[0].value.data = 90
    series.data_points[1].value.data = 123
    series.data_points[2].value.data = 44

    # Zweite Diagrammserie nehmen
    series = chart.chart_data.series[1]

    # Jetzt die Seriendaten aktualisieren
    fact.get_cell(defaultWorksheetIndex, 0, 2, "Neue_Serie2")# Serienname ändern
    series.data_points[0].value.data = 23
    series.data_points[1].value.data = 67
    series.data_points[2].value.data = 99


    # Jetzt eine neue Serie hinzufügen
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 3, "Serie 3"), chart.type)

    # Dritte Diagrammserie nehmen
    series = chart.chart_data.series[2]

    # Jetzt die Seriendaten füllen
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 3, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 3, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 3, 30))

    chart.type = charts.ChartType.CLUSTERED_CYLINDER

    # Präsentation mit Diagramm speichern
    pres.save("AsposeChartModified_out-11.pptx", slides.export.SaveFormat.PPTX)
```

## **Festlegen des Datenbereichs für Diagramme**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse, die die Präsentation enthält, die das Diagramm enthält.
2. Holen Sie sich eine Referenz zu einer Folie über ihren Index.
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie den Datenbereich für ein Diagramm festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Präsentationsklasse, die die PPTX-Datei darstellt
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # Zugriff auf die erste Folie und Diagramm hinzufügen
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    chart.chart_data.set_range("Sheet1!A1:B4")
    presentation.save("SetDataRange_out-12.pptx", slides.export.SaveFormat.PPTX)
```


## **Verwenden von Standardmarkern in Diagrammen**
Wenn Sie einen Standardmarker in Diagrammen verwenden, erhält jede Diagrammserie automatisch verschiedene Standardmarkersymbole.

Dieser Python-Code zeigt Ihnen, wie Sie einen Diagrammserienmarker automatisch festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    fact = chart.chart_data.chart_data_workbook
    chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Serie 1"), chart.type)
    series = chart.chart_data.series[0]

    chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 1, 24))
    chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 1, 23))
    chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 1, -10))
    chart.chart_data.categories.add(fact.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 1, None))

    chart.chart_data.series.add(fact.get_cell(0, 0, 2, "Serie 2"), chart.type)
    #Zweite Diagrammserie nehmen
    series2 = chart.chart_data.series[1]

    #Jetzt die Seriendaten füllen
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(fact.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    pres.save("DefaultMarkersInChart-13.pptx", slides.export.SaveFormat.PPTX)
```