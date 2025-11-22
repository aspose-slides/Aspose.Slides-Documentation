---
title: Diagramme in PowerPoint-Präsentationen mit Python erstellen oder aktualisieren
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
- Tree-Map-Diagramm
- Börsendiagramm
- Box-und-Whisker-Diagramm
- Trichterdiagramm
- Sunburst-Diagramm
- Histogramm-Diagramm
- Radar-Diagramm
- Mehrkategorie-Diagramm
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Der Leitfaden behandelt das Hinzufügen, Formatieren und Bearbeiten von Diagrammen in Präsentationen mit praxisnahen Codebeispielen in Python."
---

## **Übersicht**

Dieser Artikel bietet eine umfassende Anleitung zur Erstellung und Anpassung von Diagrammen mit Aspose.Slides für Python über .NET. Sie lernen, wie Sie programmgesteuert ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und verschiedene Formatierungsoptionen anwenden, um Ihren spezifischen Designanforderungen gerecht zu werden. Im gesamten Artikel veranschaulichen detaillierte Codebeispiele jeden Schritt, von der Initialisierung der Präsentation und des Diagrammobjekts bis zur Konfiguration von Serien, Achsen und Legenden. Wenn Sie dieser Anleitung folgen, erhalten Sie ein fundiertes Verständnis dafür, wie Sie die dynamische Diagrammerstellung in Ihre Anwendungen integrieren und den Prozess zur Erstellung datenbasierter Präsentationen rationalisieren.

## **Diagramm erstellen**

Diagramme helfen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Tabellenblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

* große Datenmengen auf einer einzigen Folie einer Präsentation aggregieren, komprimieren oder zusammenfassen;
* Muster und Trends in den Daten aufzeigen;
* die Richtung und das Momentum der Daten über die Zeit oder bezogen auf eine bestimmte Maßeinheit ableiten;
* Ausreißer, Aberationen, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für die Gestaltung vieler Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 
Verwenden Sie die [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) Aufzählung im Namensraum [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Die Werte in dieser Aufzählung entsprechen verschiedenen Diagrammtypen.
{{% /alert %}} 

### **Gruppierte Säulendiagramme erstellen**

Dieser Abschnitt erklärt, wie man mit Aspose.Slides für Python über .NET gruppierte Säulendiagramme erstellt. Sie lernen, wie Sie eine Präsentation initialisieren, ein Diagramm hinzufügen und dessen Elemente wie Titel, Daten, Serien, Kategorien und Gestaltung anpassen. Befolgen Sie die nachstehenden Schritte, um zu sehen, wie ein Standard‑Gruppiertes‑Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.
4. Fügen Sie dem Diagramm einen Titel hinzu.
5. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
6. Löschen Sie alle Standardserien und -kategorien.
7. Fügen Sie neue Serien und Kategorien hinzu.
8. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
9. Wenden Sie eine Füllfarbe auf die Diagrammserien an.
10. Fügen Sie den Diagrammserien Beschriftungen hinzu.
11. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert, wie man ein gruppiertes Säulendiagramm erstellt:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert.
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

    # Legen Sie fest, dass die erste Serie Werte anzeigt.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Legen Sie den Index des Diagrammdatentabellenblatts fest.
    worksheet_index = 0

    # Holen Sie das Diagrammdatentabellenbuch.
    workbook = chart.chart_data.chart_data_workbook

    # Löschen Sie die standardmäßig erzeugten Serien und Kategorien.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Serien hinzufügen.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Holen Sie die erste Diagrammserie.
    series = chart.chart_data.series[0]

    # Füllen Sie die Seriendaten.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Legen Sie die Füllfarbe für die Serie fest.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Holen Sie die zweite Diagrammserie.
    series = chart.chart_data.series[1]

    # Füllen Sie die Seriendaten.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Legen Sie die Füllfarbe für die Serie fest.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Setzen Sie das erste Beschriftungsfeld so, dass der Kategoriename angezeigt wird.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Legen Sie fest, dass die Serie den Wert für die dritte Beschriftung anzeigt.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Speichern Sie die Präsentation als PPTX-Datei auf dem Datenträger.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Das gruppierte Säulendiagramm](clustered_column_chart.png)

### **Punktdiagramme erstellen**

Punktdiagramme (auch als Streudiagramme oder X‑Y‑Diagramme bezeichnet) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu veranschaulichen.

Verwenden Sie ein Punktdiagramm, wenn:

* Sie haben gepaarte numerische Daten.
* Sie haben zwei Variablen, die gut zusammenpassen.
* Sie möchten feststellen, ob die beiden Variablen miteinander in Beziehung stehen.
* Sie haben eine unabhängige Variable, die mehrere Werte für eine abhängige Variable aufweist.

Dieser Python‑Code zeigt, wie man ein Punktdiagramm mit unterschiedlichen Markerserien erstellt:
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

    # Legen Sie den Index des Diagrammdatentabellenblatts fest.
    worksheet_index = 0

    # Holen Sie das Diagrammdatentabellenbuch.
    workbook = chart.chart_data.chart_data_workbook

    # Löschen Sie die Standardserie.
    chart.chart_data.series.clear()

    # Neue Serien hinzufügen.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Holen Sie die erste Diagrammserie.
    series = chart.chart_data.series[0]

    # Einen neuen Punkt (1:3) zur Serie hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Einen neuen Punkt (2:10) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Serien-Typ ändern.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Diagrammserien-Marker ändern.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Holen Sie die zweite Diagrammserie.
    series = chart.chart_data.series[1]

    # Einen neuen Punkt (5:2) zur Diagrammserie hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Einen neuen Punkt (3:1) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Einen neuen Punkt (2:2) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Einen neuen Punkt (5:1) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Diagrammserien-Marker ändern.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Das Punktdiagramm](scatter_chart.png)

### **Kreisdiagramme erstellen**

Kreisdiagramme eignen sich am besten, um das Teil‑zu‑Ganzes‑Verhältnis in Daten darzustellen, insbesondere wenn die Daten kategoriale Labels mit numerischen Werten enthalten. Enthält Ihre Daten jedoch viele Teile oder Beschriftungen, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.PIE` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben auf die Sektoren des Kreisdiagramms an.
9. Setzen Sie Beschriftungen für die Serien.
10. Aktivieren Sie Führungslinien für die Serienbeschriftungen.
11. Legen Sie den Rotationswinkel für das Kreisdiagramm fest.
12. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Kreisdiagramm erstellt:
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert.
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

    # Legen Sie fest, dass die erste Serie Werte anzeigt.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # Legen Sie den Index des Diagrammdatentabellenblatts fest.
    worksheet_index = 0

    # Holen Sie das Diagrammdatentabellenbuch.
    workbook = chart.chart_data.chart_data_workbook

    # Löschen Sie die standardmäßig erzeugten Serien und Kategorien.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Neue Serie hinzufügen.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Füllen Sie die Seriendaten.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Legen Sie die Sektorfarbe fest.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Legen Sie den Sektorrand fest.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Legen Sie den Sektorrand fest.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Legen Sie den Sektorrand fest.
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

    # Legen Sie fest, dass die Serie Führungslinien für das Diagramm anzeigt.
    series.labels.default_data_label_format.show_leader_lines = True

    # Legen Sie den Rotationswinkel für die Kreisdiagramm‑Sektoren fest.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Speichern Sie die Präsentation als PPTX-Datei auf dem Datenträger.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Das Kreisdiagramm](pie_chart.png)

### **Liniendiagramme erstellen**

Liniendiagramme (auch als Liniendiagramme bezeichnet) eignen sich am besten, wenn Sie Änderungen von Werten im Zeitverlauf darstellen möchten. Mit einem Liniendiagramm können Sie große Datenmengen gleichzeitig vergleichen, Änderungen und Trends über die Zeit verfolgen, Anomalien in Datenserien hervorheben und mehr.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.LINE` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Liniendiagramm erstellt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```


Standardmäßig werden Punkte in einem Liniendiagramm durch gerade, kontinuierliche Linien verbunden. Wenn Sie die Punkte stattdessen durch Striche verbinden möchten, können Sie Ihren bevorzugten Strichtyp wie folgt angeben:
```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```


Das Ergebnis:

![Das Liniendiagramm](line_chart.png)

### **Tree‑Map‑Diagramme erstellen**

Tree‑Map‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien anzeigen und schnell die großen Beitragszahler innerhalb jeder Kategorie hervorheben möchten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.TREEMAP` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Tree‑Map‑Diagramm erstellt:
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

![Das Tree‑Map‑Diagramm](treemap_chart.png)

### **Börsendiagramme erstellen**

Börsendiagramme werden verwendet, um Finanzdaten wie Eröffnungs-, Höchst‑, Tief‑ und Schlusskurse anzuzeigen, und helfen dabei, Markttrends und Volatilität zu analysieren. Sie bieten wesentliche Einblicke in die Kursentwicklung und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.OPEN_HIGH_LOW_CLOSE` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Geben Sie das Format für HiLowLines an.
9. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Börsendiagramm erstellt:
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

![Das Börsendiagramm](stock_chart.png)

### **Box‑und‑Whisker‑Diagramme erstellen**

Box‑und‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem sie zentrale statistische Maße wie Median, Quartile und mögliche Ausreißer zusammenfassen. Sie sind besonders nützlich in der explorativen Datenanalyse und bei statistischen Studien, um schnell die Variabilität von Daten zu verstehen und Anomalien zu erkennen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.BOX_AND_WHISKER` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Box‑und‑Whisker‑Diagramm erstellt:
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


### **Trichterdiagramme erstellen**

Trichterdiagramme werden verwendet, um Prozesse zu visualisieren, die sequenzielle Phasen umfassen, wobei das Datenvolumen von einer Stufe zur nächsten abnimmt. Sie sind besonders hilfreich zur Analyse von Konversionsraten, zur Identifizierung von Engpässen und zur Verfolgung der Effizienz von Vertriebs‑ oder Marketingprozessen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.FUNNEL` an.
4. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Trichterdiagramm erstellt:
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

![Das Trichterdiagramm](funnel_chart.png)

### **Sunburst‑Diagramme erstellen**

Sunburst‑Diagramme werden verwendet, um hierarchische Daten darzustellen, wobei Ebenen als konzentrische Ringe angezeigt werden. Sie veranschaulichen Teil‑zu‑Ganzes‑Beziehungen und eignen sich ideal zur Darstellung verschachtelter Kategorien und Unterkategorien in einem klaren, kompakten Format.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.SUNBURST` an.
4. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Sunburst‑Diagramm erstellt:
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

![Das Sunburst‑Diagramm](sunburst_chart.png)

### **Histogramm‑Diagramme erstellen**

Histogramm‑Diagramme werden verwendet, um die Verteilung numerischer Daten darzustellen, indem Werte in Klassen (Bins) gruppiert werden. Sie sind besonders nützlich, um Datenmuster wie Häufigkeit, Schiefe und Streuung zu erkennen und Ausreißer in einem Datensatz zu identifizieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.HISTOGRAM` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Histogramm‑Diagramm erstellt:
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

![Das Histogramm‑Diagramm](histogram_chart.png)

### **Radar‑Diagramme erstellen**

Radar‑Diagramme werden verwendet, um multivariate Daten in einem zweidimensionalen Format darzustellen, sodass mehrere Variablen gleichzeitig leicht vergleichbar sind. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über mehrere Leistungsmetriken oder Attribute hinweg zu erkennen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.RADAR` an.
4. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Radar‑Diagramm erstellt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Das Radar‑Diagramm](radar_chart.png)

### **Mehrkategorie‑Diagramme erstellen**

Mehrkategorie‑Diagramme werden verwendet, um Daten darzustellen, die mehr als eine kategoriale Gruppierung umfassen, sodass Werte über mehrere Dimensionen gleichzeitig verglichen werden können. Sie sind besonders hilfreich, wenn Sie Trends und Beziehungen innerhalb komplexer, mehrschichtiger Datensätze analysieren müssen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.
4. Greifen Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
5. Löschen Sie die Standardserien und -kategorien.
6. Fügen Sie neue Serien und Kategorien hinzu.
7. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
8. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Mehrkategorie‑Diagramm erstellt:
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

    # Eine Serie hinzufügen.
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

![Das Mehrkategorie‑Diagramm](multi_category_chart.png)

### **Karten‑Diagramme erstellen**

Karten‑Diagramme werden verwendet, um geografische Daten zu visualisieren, indem Informationen spezifischen Standorten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie sind besonders nützlich, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend zu analysieren.

Dieser Python‑Code zeigt, wie man ein Karten‑Diagramm erstellt:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Das Karten‑Diagramm](map_chart.png)

### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen, wodurch Beziehungen zwischen ihnen leichter erkennbar werden.

![Das Kombinations‑Diagramm](combination_chart.png)

Der folgende Python‑Code zeigt, wie man das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt:
```python
def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Diagrammtitel festlegen.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Diagrammlegende festlegen.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Standardmäßig erzeugte Serien und Kategorien löschen.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Erste Serie hinzufügen.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Horizontale Achse festlegen.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Vertikale Achse festlegen.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Farbe der vertikalen Hauptgitternetzlinien festlegen.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Sekundäre horizontale Achse festlegen.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Sekundäre vertikale Achse festlegen.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```


## **Diagramme aktualisieren**

Aspose.Slides für Python über .NET ermöglicht das Aktualisieren von PowerPoint‑Diagrammen durch Ändern von Diagrammdaten, Formatierungen und Stilen. Diese Funktionalität vereinfacht das Aktualisieren von Präsentationen mit dynamischen Inhalten und stellt sicher, dass Diagramme aktuelle Daten und visuelle Standards exakt wiedergeben.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die die Präsentation mit dem Diagramm repräsentiert.
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen, um das Diagramm zu finden.
4. Greifen Sie auf das Datenarbeitsblatt des Diagramms zu.
5. Ändern Sie die Diagrammdatenserie, indem Sie die Serienwerte anpassen.
6. Fügen Sie eine neue Serie hinzu und füllen Sie deren Daten.
7. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man ein Diagramm aktualisiert:
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

            # Legen Sie den Index des Diagrammdatentabellenblatts fest.
            worksheet_index = 0

            # Holen Sie das Diagramm-Datenarbeitsbuch.
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

Aspose.Slides für Python über .NET bietet die Flexibilität, einen bestimmten Datenbereich aus einem Arbeitsblatt als Quelle für die Diagrammdaten festzulegen. Dadurch können Sie einen Teil Ihres Arbeitsblatts direkt dem Diagramm zuordnen und steuern, welche Zellen zu den Serien und Kategorien des Diagramms beitragen. So lassen sich Diagramme einfach aktualisieren und mit den neuesten Daten im Arbeitsblatt synchronisieren, sodass Ihre PowerPoint‑Präsentationen stets aktuelle und genaue Informationen widerspiegeln.

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), die die Präsentation mit dem Diagramm repräsentiert.
2. Holen Sie sich eine Referenz auf eine Folie anhand ihres Index.
3. Durchlaufen Sie alle Formen, um das Diagramm zu finden.
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.
5. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man den Datenbereich für ein Diagramm festlegt:
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

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammserie automatisch ein unterschiedliches Standard‑Markersymbol.

Dieser Python‑Code zeigt, wie man einen Diagrammserien‑Marker automatisch festlegt:
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

**Welche Diagrammtypen werden von Aspose.Slides für Python über .NET unterstützt?**

Aspose.Slides für Python über .NET unterstützt eine breite Palette von Diagrammtypen, darunter Balken-, Linien-, Kreis-, Flächen-, Punkt-, Histogramm-, Radar- und viele weitere. Diese Flexibilität ermöglicht Ihnen die Auswahl des am besten geeigneten Diagrammtyps für Ihre Datenvisualisierung.

**Wie füge ich einer Folie ein neues Diagramm hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf das Datenarbeitsbuch des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) zugreifen, sämtliche Standardserien und -kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert aktualisieren, sodass es die neuesten Daten widerspiegelt.

**Ist es möglich, das Erscheinungsbild des Diagramms anzupassen?**

Ja, Aspose.Slides für Python über .NET bietet umfangreiche Anpassungsmöglichkeiten. Sie können Farben, Schriftarten, Beschriftungen, Legenden und andere Formatierungselemente ändern, um das Erscheinungsbild des Diagramms an Ihre spezifischen Designanforderungen anzupassen.
