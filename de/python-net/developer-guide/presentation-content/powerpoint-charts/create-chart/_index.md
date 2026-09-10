---
title: Diagramme in PowerPoint-Präsentationen in Python erstellen oder aktualisieren
linktitle: Diagramme erstellen oder aktualisieren
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
- Box-und-Whisker-Diagramm
- Trichterdiagramm
- Sonnenstrahl-Diagramm
- Histogramm
- Radar-Diagramm
- Mehrkategorie-Diagramm
- PowerPoint-Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET erstellen und anpassen. Der Leitfaden behandelt das Hinzufügen, Formatieren und Bearbeiten von Diagrammen in Präsentationen mit praktischen Codebeispielen in Python."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Diagramme mit Aspose.Slides für Python via .NET erstellen und anpassen. Sie lernen, wie Sie ein Diagramm zu einer Folie hinzufügen, es mit Daten füllen und formatieren, um Ihren Designanforderungen zu entsprechen. Die Codebeispiele behandeln das Erstellen von Präsentationen und Diagrammen, das Konfigurieren von Reihen, Achsen und Legenden sowie die Integration der Diagrammerstellung in Ihre Anwendungen.

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Einsichten zu gewinnen, die aus einer Tabelle oder einem Tabellenblatt nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, kondensieren oder zusammenfassen;
* Muster und Trends in Daten aufzeigen;
* die Richtung und das Momentum von Daten über die Zeit oder bezogen auf eine bestimmte Maßeinheit ableiten;
* Ausreißer, Aberationen, Abweichungen, Fehler und unsinnige Daten erkennen;
* komplexe Daten kommunizieren oder präsentieren.

In PowerPoint können Sie Diagramme über die *Einfügen*-Funktion erstellen, die Vorlagen für viele Diagrammtypen bietet. Mit Aspose.Slides können Sie sowohl reguläre Diagramme (basierend auf gängigen Diagrammtypen) als auch benutzerdefinierte Diagramme erstellen.

{{% alert color="info" title="Hinweis" %}}

Verwenden Sie die [ChartType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/charttype/)‑Aufzählung im Namensraum [Aspose.Slides.Charts](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/). Die Werte dieser Aufzählung entsprechen verschiedenen Diagrammtypen.

{{% /alert %}}

### **Erstellen von gruppierten Säulendiagrammen**

Dieser Abschnitt erklärt, wie Sie gruppierte Säulendiagramme mit Aspose.Slides für Python via .NET erstellen. Sie lernen, eine Präsentation zu initialisieren, ein Diagramm hinzuzufügen und dessen Elemente wie Titel, Daten, Reihen, Kategorien und Stil anzupassen. Folgen Sie den Schritten, um zu sehen, wie ein standardmäßiges gruppiertes Säulendiagramm erzeugt wird:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.
1. Fügen Sie dem Diagramm einen Titel hinzu.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Löschen Sie alle Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Wenden Sie eine Füllfarbe auf die Diagramm‑Reihen an.
1. Fügen Sie den Reihen Beschriftungen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code demonstriert, wie ein gruppiertes Säulendiagramm erstellt wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert.
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit den Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Diagrammtitel festlegen.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Index des Diagrammdatenblatts festlegen.
    worksheet_index = 0

    # Diagrammdaten-Workbook abrufen.
    workbook = chart.chart_data.chart_data_workbook

    # Standardmäßig generierte Reihen und Kategorien löschen.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Reihen hinzufügen.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # Erste Diagrammreihe abrufen.
    series = chart.chart_data.series[0]

    # Reihendaten befüllen.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Füllfarbe für die Reihe festlegen.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Zweite Diagrammreihe abrufen.
    series = chart.chart_data.series[1]

    # Reihendaten befüllen.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # Füllfarbe für die Reihe festlegen.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # Erstes Beschriftungsfeld so einstellen, dass der Kategoriename angezeigt wird.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # Reihe so einstellen, dass der Wert für die dritte Beschriftung angezeigt wird.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # Präsentation als PPTX-Datei auf die Festplatte speichern.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das gruppierte Säulendiagramm](clustered_column_chart.png)

### **Erstellen von Streudiagrammen**

Streudiagramme (auch Scatter‑Plots oder x‑y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren.

Verwenden Sie ein Streudiagramm, wenn:

* Sie gepaarte numerische Daten haben.
* Sie zwei Variablen haben, die gut zusammenpassen.
* Sie bestimmen möchten, ob die beiden Variablen miteinander verbunden sind.
* Sie eine unabhängige Variable mit mehreren Werten für eine abhängige Variable besitzen.

Dieser Python‑Code zeigt, wie ein Streudiagramm mit unterschiedlichen Markern für jede Reihe erstellt wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Erstellen Sie das Standard-Streudiagramm.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Index des Diagrammdatenblatts festlegen.
    worksheet_index = 0

    # Diagrammdaten-Workbook abrufen.
    workbook = chart.chart_data.chart_data_workbook

    # Standardreihe löschen.
    chart.chart_data.series.clear()

    # Neue Reihen hinzufügen.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Erste Diagrammreihe abrufen.
    series = chart.chart_data.series[0]

    # Neuen Punkt (1:3) zur Reihe hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Neuen Punkt (2:10) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Reihen-Typ ändern.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Markierung der Diagrammreihe ändern.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Zweite Diagrammreihe abrufen.
    series = chart.chart_data.series[1]

    # Neuen Punkt (5:2) zur Diagrammreihe hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Neuen Punkt (3:1) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Neuen Punkt (2:2) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Neuen Punkt (5:1) hinzufügen.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Markierung der Diagrammreihe ändern.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das Streudiagramm](scatter_chart.png)

### **Erstellen von Kreisdiagrammen**

Kreisdiagramme eignen sich am besten, um das Verhältnis von Teil zu Ganzem in Daten darzustellen, insbesondere wenn die Daten kategoriale Labels mit numerischen Werten enthalten. Enthält Ihre Daten jedoch viele Teile oder Labels, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.PIE` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Fügen Sie neue Punkte für das Diagramm hinzu und wenden Sie benutzerdefinierte Farben auf die Sektoren des Kreisdiagramms an.
1. Setzen Sie Beschriftungen für die Reihen.
1. Aktivieren Sie Hilfslinien für die Reihen‑Beschriftungen.
1. Legen Sie den Rotationswinkel für das Kreisdiagramm fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Kreisdiagramm erstellt wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei repräsentiert.
with slides.Presentation() as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie ein Diagramm mit den Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Diagrammtitel festlegen.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Index des Diagrammdatenblatts festlegen.
    worksheet_index = 0

    # Diagrammdaten-Workbook abrufen.
    workbook = chart.chart_data.chart_data_workbook

    # Standardmäßig generierte Reihen und Kategorien löschen.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Neue Reihen hinzufügen.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Reihendaten befüllen.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Sektorfarbe festlegen.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Sektorrand festlegen.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Sektorrand festlegen.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Sektorrand festlegen.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Benutzerdefinierte Beschriftungen für jede Kategorie in der neuen Reihe erstellen.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Reihe so einstellen, dass Leitlinien für das Diagramm angezeigt werden.
    series.labels.default_data_label_format.show_leader_lines = True

    # Rotationswinkel für die Kuchen-Diagramm‑Sektoren festlegen.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Präsentation als PPTX-Datei auf die Festplatte speichern.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das Kreisdiagramm](pie_chart.png)

### **Erstellen von Liniendiagrammen**

Liniendiagramme (auch Liniengraphen genannt) eignen sich besonders für Situationen, in denen Sie Veränderungen von Werten über die Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie große Datenmengen gleichzeitig vergleichen, Änderungen und Trends im Zeitverlauf verfolgen, Anomalien in Datenreihen hervorheben und mehr.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.LINE` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Liniendiagramm erstellt wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Standardmäßig werden Punkte in einem Liniendiagramm durch gerade kontinuierliche Linien verbunden. Wenn Sie die Punkte stattdessen mit Strichen verbinden möchten, können Sie den gewünschten Strichtyp wie folgt angeben:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das Liniendiagramm](line_chart.png)

### **Erstellen von Baumkarte‑Diagrammen**

Baumkarte‑Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und schnell die Elemente hervorheben möchten, die innerhalb jeder Kategorie große Beiträge leisten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.TREEMAP` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Baumkarte‑Diagramm erstellt wird:

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

![Das Baumkarte‑Diagramm](treemap_chart.png)

### **Erstellen von Börsendiagrammen**

Börsendiagramme werden verwendet, um Finanzdaten wie Eröffnungs‑, Hoch‑, Tief‑ und Schlusskurse darzustellen und damit Markttrends sowie Schwankungen zu analysieren. Sie bieten wesentliche Einblicke in die Aktienperformance und unterstützen Investoren und Analysten bei fundierten Entscheidungen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.OPEN_HIGH_LOW_CLOSE` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Geben Sie das Format für Hoch‑Tief‑Linien an.
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

![Das Börsendiagramm](stock_chart.png)

### **Erstellen von Box‑und‑Whisker‑Diagrammen**

Box‑und‑Whisker‑Diagramme werden verwendet, um die Verteilung von Daten darzustellen, indem sie zentrale statistische Maße wie Median, Quartile und potenzielle Ausreißer zusammenfassen. Sie sind besonders nützlich in der explorativen Datenanalyse und in statistischen Studien, um die Datenvariabilität schnell zu verstehen und Anomalien zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.BOX_AND_WHISKER` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Box‑und‑Whisker‑Diagramm erstellt wird:

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

### **Erstellen von Trichter‑Diagrammen**

Trichter‑Diagramme werden verwendet, um Prozesse mit sequentiellen Stufen zu visualisieren, bei denen das Datenvolumen von einer Stufe zur nächsten abnimmt. Sie sind besonders hilfreich zur Analyse von Konversionsraten, zur Identifizierung von Engpässen und zur Verfolgung der Effizienz von Vertriebs‑ oder Marketing‑Prozessen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
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

![Das Trichter‑Diagramm](funnel_chart.png)

### **Erstellen von Sonnenstrahl‑Diagrammen**

Sonnenstrahl‑Diagramme werden verwendet, um hierarchische Daten zu visualisieren, wobei die Ebenen als konzentrische Ringe dargestellt werden. Sie veranschaulichen Teil‑zu‑Ganz‑Beziehungen und eignen sich ideal zur Darstellung verschachtelter Kategorien und Unterkategorien in einem kompakten Format.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.SUNBURST` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Sonnenstrahl‑Diagramm erstellt wird:

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

![Das Sonnenstrahl‑Diagramm](sunburst_chart.png)

### **Erstellen von Histogramm‑Diagrammen**

Histogramm‑Diagramme werden verwendet, um die Verteilung numerischer Daten darzustellen, indem Werte in Bereiche oder Klassen (Bins) gruppiert werden. Sie sind besonders nützlich, um Datenmuster wie Häufigkeit, Schiefe und Streuung zu erkennen und Ausreißer in einem Datensatz zu identifizieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.HISTOGRAM` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie eine neue Reihe hinzu und füllen Sie sie mit Datenpunkten. Ein Histogramm hat keine Kategorien; die Bins werden aus den Werten berechnet.
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

![Das Histogramm‑Diagramm](histogram_chart.png)

### **Erstellen von Radar‑Diagrammen**

Radar‑Diagramme werden verwendet, um multivariate Daten in einem zweidimensionalen Format darzustellen, wodurch ein einfacher Vergleich mehrerer Variablen gleichzeitig möglich ist. Sie sind besonders nützlich, um Muster, Stärken und Schwächen über mehrere Leistungskennzahlen oder Attribute hinweg zu erkennen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie den Typ `ChartType.RADAR` an.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Radar‑Diagramm erstellt wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das Radar‑Diagramm](radar_chart.png)

### **Erstellen von Diagrammen mit mehreren Kategorien**

Diagramme mit mehreren Kategorien werden verwendet, um Daten darzustellen, die mehr als eine kategoriale Gruppierung umfassen, sodass Sie Werte über mehrere Dimensionen gleichzeitig vergleichen können. Sie sind besonders hilfreich, wenn Sie Trends und Zusammenhänge in komplexen, mehrschichtigen Datensätzen analysieren müssen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und geben Sie den Typ `ChartType.CLUSTERED_COLUMN` an.
1. Greifen Sie auf das Daten‑Workbook des Diagramms ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zu.
1. Löschen Sie die Standard‑Reihen und -Kategorien.
1. Fügen Sie neue Reihen und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagramm‑Reihen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Diagramm mit mehreren Kategorien erstellt wird:

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

    # Reihe hinzufügen.
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

![Das Diagramm mit mehreren Kategorien](multi_category_chart.png)

### **Erstellen von Karten‑Diagrammen**

Karten‑Diagramme werden verwendet, um geografische Daten zu visualisieren, indem Informationen bestimmten Orten wie Ländern, Bundesländern oder Städten zugeordnet werden. Sie sind besonders nützlich, um regionale Trends, demografische Daten und räumliche Verteilungen klar und ansprechend darzustellen.

Dieser Python‑Code zeigt, wie ein Karten‑Diagramm erstellt wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Das Karten‑Diagramm](map_chart.png)

### **Erstellen von Kombinations‑Diagrammen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Diagramm. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehreren Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen und so Beziehungen zwischen ihnen zu erkennen.

![Das Kombinations‑Diagramm](combination_chart.png)

Der folgende Python‑Code zeigt, wie das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellt wird:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

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

    # Standardmäßig generierte Reihen und Kategorien löschen.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Erste Reihe hinzufügen.
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

    # Farbe der vertikalen Hauptgitterlinien festlegen.
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

Aspose.Slides für Python via .NET ermöglicht das Aktualisieren von Diagrammdaten, Formatierungen und Stilen, um Ihre PowerPoint‑Präsentationen auf dem neuesten Stand zu halten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse, um die Präsentation zu öffnen, die das Diagramm enthält.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Durchlaufen Sie alle Formen, um das Diagramm zu finden.
1. Greifen Sie auf das Daten‑Worksheet des Diagramms zu.
1. Ändern Sie die Diagramm‑Datenreihen, indem Sie die Werte der Reihen anpassen.
1. Fügen Sie eine neue Reihe hinzu und füllen Sie deren Daten.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie ein Diagramm aktualisiert wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanziieren Sie die Presentation‑Klasse, die eine PPTX‑Datei repräsentiert.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Index des Diagrammdatenblatts festlegen.
            worksheet_index = 0

            # Diagrammdaten‑Workbook abrufen.
            workbook = chart.chart_data.chart_data_workbook

            # Diagramm‑Kategorienamen ändern.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Erste Diagrammreihe abrufen.
            series = chart.chart_data.series[0]

            # Reihen‑Daten aktualisieren.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Seriennamen ändern.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Zweite Diagrammreihe abrufen.
            series = chart.chart_data.series[1]

            # Reihen‑Daten aktualisieren.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Seriennamen ändern.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Eine neue Reihe hinzufügen.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Reihen‑Daten befüllen.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Präsentation mit dem Diagramm speichern.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Datenbereich für ein Diagramm festlegen**

Aspose.Slides für Python via .NET ermöglicht die Verwendung eines bestimmten Arbeitsblattbereichs als Datenquelle für ein Diagramm. Dadurch wird gesteuert, welche Zellen die Reihen und Kategorien des Diagramms versorgen, und Sie können das Diagramm aktualisieren, um Änderungen im Arbeitsblatt widerzuspiegeln.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse, um die Präsentation zu öffnen, die das Diagramm enthält.
1. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
1. Durchlaufen Sie alle Formen, um das Diagramm zu finden.
1. Greifen Sie auf die Diagrammdaten zu und legen Sie den Bereich fest.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie der Datenbereich für ein Diagramm festgelegt wird:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Instanziieren Sie die Presentation-Klasse, die eine PPTX-Datei darstellt.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Zugriff auf die erste Folie.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard‑Marker in Diagrammen verwenden**

Wenn Sie Standard‑Marker in Diagrammen verwenden, erhält jede Diagramm‑Reihe automatisch ein unterschiedliches Markersymbol.

Dieser Python‑Code zeigt, wie ein Diagramm‑Reihen‑Marker automatisch festgelegt wird:

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

    # Reihendaten befüllen.
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

Aspose.Slides für Python via .NET unterstützt ein breites Spektrum an Diagrammtypen, darunter Balken, Linien, Kuchen, Flächen, Streu, Histogramm, Radar und vieles mehr. Diese Flexibilität erlaubt es Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse, rufen die gewünschte Folie über ihren Index ab und rufen dann die Methode auf, um ein Diagramm hinzuzufügen, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Daten‑Workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/)) zugreifen, alle Standard‑Reihen und -Kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert auffrischen, um die neuesten Daten widerzuspiegeln.

**Ist es möglich, das Erscheinungsbild des Diagramms anzupassen?**

Ja, Aspose.Slides für Python via .NET bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und weitere Formatierungselemente ändern, um das Aussehen des Diagramms an Ihre spezifischen Designanforderungen anzupassen.