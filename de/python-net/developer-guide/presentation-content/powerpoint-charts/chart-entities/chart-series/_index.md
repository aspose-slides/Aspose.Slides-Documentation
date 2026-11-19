---
title: Diagrammdatenreihen in Präsentationen mit Python verwalten
linktitle: Datenreihen
type: docs
url: /de/python-net/chart-series/
keywords:
- Diagrammreihe
- Reihenüberlappung
- Reihenfarbe
- Kategoriefarbe
- Reihenname
- Datenpunkt
- Reihenlücke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammreihen, Datenpunkte, Arbeitsmappen-Zellen, Formatierungen, Überlappungen, Lückenbreiten und negative Werte in Präsentationen mit Python verwalten."
---
## **Übersicht**

Ein Diagramm kann seine geplotteten Werte in Arbeitsmappenzellen oder direkt als numerische Literale speichern. Ein [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) repräsentiert einen Satz zusammengehöriger Werte, und jeder [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) stellt einen Punkt in dieser Reihe dar. Objekte von [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) liefern die Beschriftungen oder Gruppierungswerte, die von den Reihen gemeinsam genutzt werden. In Diagrammen, die mit Standarddaten erstellt wurden, verwenden Seriennamen, Kategorien und Punktwerte [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)‑Objekte aus der Diagramm‑Arbeitsmappe.

Für ein typisches Kategoriendiagramm verwendet die Standardarbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation prüfen Sie die von den Reihen, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellunge­n auf Reihenebene, z. B. [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), liefern das Standard‑Aussehen für alle Punkte einer Reihe.
- Datenpunkt‑Einstellungen, z. B. [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), überschreiben das Reihen‑Aussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Reihen, die zur selben [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) gehören. Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Reihen‑Füllung gesetzt ist, bestimmen Diagramm‑Stil und -Theme das automatische Aussehen. Wenn sowohl Reihen‑ als auch Punkt‑Formatierungen vorhanden sind, hat die Punkt‑Formatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

Für ein gruppiertes Zylinderdiagramm sehen Sie, wie [Ändern des 3D‑Serientyps oder der Balkenform](/slides/de/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) die erste Reihe beeinflusst.

## **Serienwerte mit numerischen Literalen festlegen**

Verwenden Sie numerische Literale, wenn Serienwerte aus Anwendungsdaten oder Berechnungen stammen und keine Arbeitsblatt‑Zellreferenzen benötigen. Setzen Sie [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) auf [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) bevor Sie jedem Punkt den [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) über [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) zuweisen.

Die Sammlungseinstellung steuert den Quelltyp aller Punktwerte in dieser Reihe. Jeder Punkt‑[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) gibt den ausgewählten Typ zurück; ändern Sie ihn über die Sammlungseinstellung. Mit `WORKSHEET` verwenden Sie [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) um auf die referenzierte Zelle zuzugreifen. Mit `DOUBLE_LITERALS` verwenden Sie `as_literal_double`, um die Zahl direkt zu lesen oder zu schreiben.

Das folgende Beispiel erzeugt ein Säulendiagramm mit Standard‑Serien und -Kategorien und weist dann berechnete Werte 10, 20 usw. den bestehenden Punkten der ersten Reihe zu. Es speichert die Präsentation, öffnet sie erneut und gibt die gespeicherten Werte aus.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Der Quelltyp des Punktwerts ist getrennt von [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), das die interne oder externe Arbeitsmappen‑Konfiguration des Diagramms identifiziert. Die Verwendung numerischer Literale entfernt nicht automatisch die eingebettete Arbeitsmappe. In diesem Beispiel bleibt die Arbeitsmappe für Kategorielabels, Seriennamen und die anderen Serien verfügbar. Siehe [Diagrammarbeitsmappe](/slides/de/python-net/chart-workbook/) für die Arbeitsmappenverwaltung.

Für Streu‑ und Blasendiagramme setzen Sie [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) und [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) um die Quellen für [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) bzw. [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) auszuwählen. Blasendiagramme verwenden zudem [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) für [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Setzen Sie jede zutreffende Quelle auf `DOUBLE_LITERALS`, bevor Sie Zahlen über die jeweilige `as_literal_double`‑Eigenschaft zuweisen.

## **Diagrammreihenüberlappung festlegen**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von –100 % bis 100 %. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Reihen‑Gruppe. Setzen Sie [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) um jede kompatible Reihe in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie beeinflusst nicht unabhängige Reihen‑Gruppen in einem Kombinationsdiagramm.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Reihe enthält:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Das neue Diagramm enthält Beispielreihen, Kategorien und Werte.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The series overlap](series_overlap.png)

## **Füllfarbe der Reihe ändern**

Verwenden Sie [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), um die Standard‑Füllung für eine gesamte Reihe festzulegen. Wenn ein Punkt bereits eine explizite Füllung hat, überschreibt dessen [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) die Reihen‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine durchgehend blaue Füllung auf die erste Reihe an:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The color of the series](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagramm‑Datenarbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standardarbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Reihe. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Sie können auch die bereits von [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet die Annahme einer bestimmten Zeile und Spalte in einem bestehenden Diagramm:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The series name](series_name.png)

### **Eine Serie mit einem Namen aus mehreren Zellen erstellen**

Ein zusammengesetzter Serienname ist nützlich, wenn ein Produktname und ein Berichtszeitraum in separaten Arbeitsmappen­zellen gespeichert sind. Sie können beispielsweise `Product A` in B1 und `2026` in C1 zu einem einzigen Seriennamen kombinieren, wobei beide Teile mit ihren Quellzellen verknüpft bleiben.

Verwenden Sie [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/), um den Namensbereich abzurufen, und übergeben Sie diese Sammlung an [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Das Argument `skip_hidden_cells` steuert, ob ausgeblendete Zellen einbezogen werden: `True` schließt sie aus, `False` schließt sie ein. Dieses Beispiel verwendet `False`, um jede Zelle im Namensbereich einzuschließen.

Das folgende Beispiel erstellt eine Präsentation mit einer Reihe und zwei Datenpunkten. Die Zellen B1:C1 liefern nur den Seriennamen; A2:A3 liefern die Kategorielabels und B2:B3 die numerischen Werte.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Diese beiden Zellen liefern den Seriennamen.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Separate Zellen liefern die Kategorien und numerischen Datenpunkte.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Der resultierende Serienname lautet `Product A 2026`, mit einem Leerzeichen zwischen den beiden Zellwerten. Die Legende zeigt dies als einen Eintrag für beide Spalten an. Das unten stehende Bild wurde aus der gespeicherten Präsentation gerendert:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatische Füllfarbe der Serie abrufen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) gibt die aus dem Serien‑Index und dem Diagramm‑Stil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Reihen‑Füllung nicht explizit definiert wurde. Der Methodenaufruf liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standard‑Reihe aus:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Beispielausgabe für den Standard‑Diagrammstil:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Die genauen Farben hängen vom Diagramm‑Stil und -Theme ab.

## **Invertierte Füllfarbe für eine Diagrammreihe festlegen**

Für Balken‑, Säulen‑ und Blasereihen kann [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Reihen‑Füllung auf solid, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeige‑Farbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Reihe. Arbeitsblatt‑Zeile 0 enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die Invertierung für einen einzelnen Punkt über [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) aktivieren. Im folgenden Beispiel ist die Invertierung für die Reihe deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, sodass die Wirkung sichtbar ist:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Einen bestimmten Datenpunktwert löschen**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugrunde liegende Arbeitsmappen‑Zelle auf `None`. Für ein Säulendiagramm ist der geplottete Wert über [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) verfügbar. Der Datenpunkt bleibt an derselben Kategorien‑Position, das Diagramm behandelt seinen Wert jedoch als leer gemäß den Einstellungen für leere Werte.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Reihe:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme verwenden zudem eine Größen‑Zelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) nicht auf, wenn Sie die anderen Punkte behalten möchten, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Ausgeblendete Zellen, die Werte enthalten, sind ein separater Fall von leeren Zellen. Um Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten ein‑ oder auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappen‑Zelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Setzen Sie [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) auf `None`, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/), um auszuwählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert die Darstellung von Lücken, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Reihe, löscht den Wert für Tag 3 und speichert dasselbe Diagramm für jeden Modus. Es wird keine Eingabedatei benötigt. Der [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorielabels und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die finalen Daten lauten `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Tag 3 wirklich leer lassen, während seine Kategorie und sein Datenpunkt erhalten bleiben.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal statt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `SPAN` nicht das im Bild gezeigte Verbindungssegment erzeugen kann; eine fehlende Säule und eine Säule mit Nullhöhe können ebenfalls gleich aussehen. Ähnlich hat ein Streudiagramm mit nur Markern keine Verbindungslinie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen genutzten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Reihen‑Gruppe und nicht zu einer einzelnen Reihe. Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) einmal für die Gruppe. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die finale Präsentation:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![The gap width](gap_width.png)

## **Serienlinien anzeigen oder ausblenden**

Serienlinien verbinden visuell zusammengehörige Teile eines Diagramms. Verwenden Sie [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/), um sie in unterstützten gestapelten Balken‑ und OfPie‑Diagrammen anzuzeigen oder zu verstecken. In zweidimensionalen gestapelten Balken‑ und Säulendiagrammen verbinden sie entsprechende Stapelgrenzen über Kategorien hinweg. In Pie of Pie‑ und Bar of Pie‑Diagrammen verbinden sie das Haupt‑Plot mit dem sekundären Plot. Diese Einstellung ist kein allgemeiner Verbinder für andere Diagrammtypen.

Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu. Die Einstellung gilt für jede Reihe in dieser Gruppe. [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) ist schreibgeschützt und spiegelt die Einstellung der übergeordneten Gruppe wider; ändern Sie die Gruppeneigenschaft, um sie zu aktualisieren.

Das folgende Beispiel erzeugt ein [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Diagramm mit Standarddaten. Es speichert dasselbe Diagramm mit aktivierten und anschließend deaktivierten Serienlinien, wodurch zwei Präsentationen zum Vergleich entstehen.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| Serienlinien aktiviert | Serienlinien deaktiviert |
| --- | --- |
| ![Kreis‑von‑Kreis‑Diagramm mit aktivierten Serienlinien](series_lines_enabled.png) | ![Kreis‑von‑Kreis‑Diagramm mit deaktivierten Serienlinien](series_lines_disabled.png) |
| Die beiden Linien verbinden den Hauptkreis mit dem Sekundärkreis. | Beide Kreise bleiben sichtbar, aber die Verbindungslinien sind ausgeblendet. |

Serienlinien unterscheiden sich von Datenbeschriftungs‑Verbindungslinien, die Beschriftungen mit ihren Datenpunkten verbinden; von Gitternetzlinien, die Intervalle entlang der Diagrammachsen markieren; und von den Linien in einem Liniendiagramm, die Datenwerte darstellen. Diese Einstellung steuert diese Elemente nicht.

## **FAQ**

**Welche Diagrammtypen unterstützen Datenreihen?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)‑Aufzählung dargestellt werden, verwenden Diagrammdaten, aber ihre Reihen besitzen nicht alle dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriendiagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Reihen‑Typ passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammreihen‑gruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) enthält kompatible Reihen, die gruppenweite Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Reihe nicht zwangsläufig jede Reihe im Diagramm ändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) Beispielsreihen, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Reihen‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie einen völlig eigenen Datensatz hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappen‑Zellen verknüpft?**

Seriennamen, Kategorielabels und Datenpunkt‑Werte referenzieren Zellen in einer [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie Reihen‑Zeilen und Serien‑Wert‑Zeilen ausrichten, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der gesamten Reihe?**

Setzen Sie die betreffende Werte‑Zelle auf `None`, um den Punkt an seiner Kategorien‑Position als leeren Punkt zu behalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) nur, wenn Sie alle Punkte dieser Reihe entfernen wollen. Entfernen Sie zudem nicht die Kategorien, ohne alle Reihen anzupassen, damit ihre Werte weiterhin zur Kategorien‑Sammlung passen.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagrammtyp und von [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ab. Unterstützte Diagramme können Lücken als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#anzeige-leerer-zellen-steuern) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasereihen aktivieren Sie [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) und setzen [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) überschreiben. Diese Eigenschaften beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Reihe als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Reihen‑Format oder, wenn das Reihen‑Format nicht definiert ist, den automatischen Diagramm‑Stil und -Theme. Gruppeneigenschaften wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungs‑Überschreibungen.

**Gibt es eine Grenze für die Anzahl der Reihen, die ein Diagramm enthalten kann?**

Aspose.Slides erhebt keine separate feste Obergrenze für die Reihen‑Anzahl. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Render‑Zeit und Lesbarkeit des Diagramms eine sinnvolle Grenze.

**Was sollte ich ändern, wenn Spalten zu eng beieinander oder zu weit auseinander liegen?**

Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) in der entsprechenden übergeordneten Reihen‑Gruppe. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenrücken zu lassen.