---
title: Diagrammdatenserien in Präsentationen mit Python verwalten
linktitle: Datenserien
type: docs
url: /de/python-net/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsblattzellen, Formatierung, Überlappung, Lückenbreite und negative Werte in Präsentationen mit Python verwalten."
---
## **Übersicht**

Ein Diagramm kann seine geplotteten Werte in Arbeitsblattzellen oder direkt als numerische Literale speichern. Eine [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) repräsentiert einen Satz zusammengehöriger Werte, und jeder [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) stellt einen Punkt in dieser Serie dar. [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/)‑Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. In Diagrammen, die mit Standarddaten erstellt wurden, verwenden Seriennamen, Kategorien und Punktwerte [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)‑Objekte aus dem Diagramm‑Arbeitsbuch.

Für ein typisches Bereichsdiagramm verwendet das Standard‑Arbeitsbuch Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt‑, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber Sie dürfen nicht davon ausgehen, dass jedes vorhandene Diagramm es verwendet. Für eine geladene Präsentation prüfen Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsbuchwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellunge auf Serienebene, wie [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), bieten das Standardaussehen für alle Punkte einer Serie.
- Einstellungen für Datenpunkte, wie [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), überschreiben das Serienaussehen für einen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur gleichen [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) gehören. Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serienfüllung festgelegt ist, bestimmen Diagrammstil und -thema das automatische Aussehen. Wenn sowohl Serien‑ als auch Punktformatierung vorhanden sind, hat die Punktformatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Serienwerte mit numerischen Literalen festlegen**

Verwenden Sie numerische Literale, wenn Serienwerte aus Anwendungsdaten oder Berechnungen stammen und keine Arbeitsblatt‑Zellreferenzen benötigen. Setzen Sie [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) auf [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) bevor Sie jedem Punkt seine [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) über [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/) zuweisen.

Die Sammlungseinstellung steuert den Quelltyp aller Punktwerte in dieser Serie. Jeder Punkt's [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) gibt den ausgewählten Typ an; ändern Sie ihn über die Sammlungseinstellung. Bei `WORKSHEET` verwenden Sie [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/), um auf die referenzierte Zelle zuzugreifen. Bei `DOUBLE_LITERALS` verwenden Sie `as_literal_double`, um die Zahl direkt zu lesen oder zu schreiben.

Das folgende Beispiel erstellt ein Säulendiagramm mit Standardserien und -kategorien und weist dann den vorhandenen Punkten der ersten Serie berechnete Werte von 10, 20 usw. zu. Es speichert die Präsentation, öffnet sie erneut und gibt die gespeicherten Werte aus.

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

Der Quelltyp des Punktwerts ist getrennt von [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), das die interne oder externe Arbeitsbuchkonfiguration des Diagramms identifiziert. Die Verwendung numerischer Literale entfernt nicht von selbst das eingebettete Arbeitsbuch. In diesem Beispiel bleibt das Arbeitsbuch für Kategoriebeschriftungen, Seriennamen und die anderen Serien verfügbar. Siehe [Chart Workbook](/slides/de/python-net/chart-workbook/) für die Arbeitsbuchverwaltung.

Für Streu‑ und Blasendiagramme setzen Sie [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) und [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/), um die Quellen für [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) bzw. [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) auszuwählen. Blasendiagramme verwenden zusätzlich [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) für [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Setzen Sie jede relevante Quelle auf `DOUBLE_LITERALS`, bevor Sie Zahlen über die `as_literal_double`‑Eigenschaft dieses Wertes zuweisen.

## **Diagrammserien‑Überlappung festlegen**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von -100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Setzen Sie [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) , um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie wirkt sich nicht auf nicht zugehörige Seriengruppen in einem Kombinationsdiagramm aus.

Das folgende Beispiel legt die Überlappung für die Gruppe fest, die die erste Serie enthält:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Das neue Diagramm enthält Beispielserien, Kategorien und Werte.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die Serienüberlappung](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), um die Standardfüllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)‑Einstellung die Serienfüllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

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

![Die Farbe der Serie](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird im Diagrammdaten‑Arbeitsbuch gespeichert und normalerweise in der Legende angezeigt. Im Standard‑Arbeitsbuch, das für ein gruppiertes Säulendiagramm erstellt wird, befindet sich die Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

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

Sie können auch die bereits von [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

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

![Der Serienname](series_name.png)

### **Eine Serie mit einem Namen aus mehreren Zellen erstellen**

Ein zusammengesetzter Serienname ist nützlich, wenn ein Produktname und ein Berichtszeitraum in separaten Arbeitsblattzellen gespeichert sind. Zum Beispiel können Sie `Product A` in B1 und `2026` in C1 zu einem einzigen Seriennamen kombinieren, während beide Teile mit ihren Quellzellen verknüpft bleiben.

Verwenden Sie [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/), um den Namensbereich abzurufen, und übergeben Sie diese Sammlung an [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Das Argument `skip_hidden_cells` steuert, ob verborgene Zellen einbezogen werden: `True` schließt sie aus, `False` schließt sie ein. Dieses Beispiel verwendet `False`, um jede Zelle im Namensbereich zu inkludieren.

Das folgende Beispiel erstellt eine Präsentation mit einer Serie und zwei Datenpunkten. Die Zellen B1:C1 liefern nur den Seriennamen; A2:A3 liefern die Kategoriebeschriftungen und B2:B3 die numerischen Werte.

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

Der resultierende Serienname lautet `Product A 2026`, mit einem Leerzeichen zwischen den beiden Zellwerten. Die Legende zeigt dies als einen Eintrag für beide Spalten an. Das Bild unten wurde aus der gespeicherten Präsentation gerendert:

![Säulendiagramm mit Nord‑ und Süd‑Werten und dem zusammengesetzten Seriennamen Product A 2026 in der Legende](composite_series_name.png)

## **Automatische Serienfüllfarbe abrufen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) gibt die aus dem Serienindex und dem Diagrammstil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serienfüllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

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

Beispielausgabe für den Standarddiagrammstil:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Die genauen Farben hängen vom Diagrammstil und -theme ab.

## **Umgekehrte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasensereien kann [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negative Werte mit einer anderen Füllung anzeigen. Setzen Sie die reguläre Serienfüllung auf einfarbig, aktivieren Sie die Umkehrung und weisen Sie die Farbe für negative Werte über [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) zu. Negative Zahlen bleiben im Arbeitsbuch unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 enthält die Kategorienamen und Spalte 1 enthält die Werte:

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

![Die umgekehrte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die Umkehrung für einen einzelnen Punkt über [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) aktivieren. Im folgenden Beispiel ist die Umkehrung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Dem Punkt wird außerdem ein negativer Wert zugewiesen, damit der Effekt sichtbar ist:

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

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie die zugrunde liegende Arbeitsblattzelle auf `None`. Bei einem Säulendiagramm ist der geplottete Wert über [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) verfügbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt seinen Wert als leer gemäß den Diagramm‑Einstellungen für leere Werte.

Das folgende Beispiel löscht nur den zweiten Punkt der ersten Serie:

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

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) auf, wenn Sie die anderen Punkte behalten wollen, da diese Methode jeden Datenpunkt aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Versteckte Zellen, die Werte enthalten, sind ein separater Fall von leeren Zellen. Um Daten aus versteckten Arbeitsblattzeilen und -spalten ein- oder auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsblattzelle steht für fehlende Daten; eine Zelle mit `0` stellt einen bekannten numerischen Wert dar. Setzen Sie [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) auf `None`, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/), um zu wählen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsblattzelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert dasselbe Diagramm in jedem Modus. Keine Eingabedatei ist erforderlich. Das [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die endgültigen Daten sind `10, 20, empty, 30, 40`.

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

    # Lassen Sie Tag 3 wirklich leer, während Sie seine Kategorie und den Datenpunkt beibehalten.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation ein einziges Mal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in jeder Arbeitsmappe leer:

![Liniendiagramme mit identischen Daten: Gap unterbricht die Linie bei Tag 3, Zero lässt die Linie auf Null fallen und Span verbindet Tag 2 mit Tag 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `SPAN` das oben gezeigte Verbindungssegment nicht erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm mit nur Markern keine Verbindungslinie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ oder Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) einmal für die Gruppe. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die endgültige Präsentation:

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

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die Aufzählung [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) repräsentiert werden, verwenden Diagrammdaten, aber ihre Serien haben nicht alle dieselbe Werte‑Struktur oder Einstellungen. Beispielsweise verwenden Bereichsdiagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte, und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Seriengruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) enthält kompatible Serien, die gruppenweite Plot‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe, die über eine Serie erreicht wird, nicht zwangsläufig jede Serie im Diagramm ändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erstellt [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) Beispieldaten für Serien, Kategorien und Werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein komplett benutzerdefiniertes Datenset hinzufügen. Eine Überladung kann ebenfalls ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsblattzellen verbunden?**

Seriennamen, Kategoriebeschriftungen und Datenpunktwerte verweisen auf Zellen in einem [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie Kategorie‑Zeilen und Serien‑Wert‑Zeilen ausgerichtet halten, damit jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen einzelnen Punkt statt der gesamten Serie?**

Setzen Sie die entsprechende Wertzelle auf `None`, um die Position des Punktes in der Kategorie beizubehalten, wobei er leer bleibt. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) nur, wenn Sie alle Punkte dieser Serie entfernen wollen. Wenn Sie auch Kategorien entfernen, aktualisieren Sie jede Serie, sodass ihre Werte mit der Kategorie‑Sammlung abgestimmt bleiben.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ab. Unterstützte Diagramme können Lücken als Unterbrechungen, als Nullwerte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasensereien aktivieren Sie [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) und setzen [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) überschreiben. Diese Eigenschaften betreffen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin die explizite Serienformatierung oder, wenn keine Serienformatierung definiert ist, den automatischen Diagrammstil und das Theme. Gruppeneigenschaften wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungs‑Overrides.

**Gibt es ein Limit, wie viele Serien ein Diagramm enthalten kann?**

Aspose.Slides legt kein separates festes Limit für die Anzahl der Serien eines Diagramms fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was soll ich ändern, wenn Säulen zu nahe beieinander oder zu weit auseinander liegen?**

Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) auf der entsprechenden übergeordneten Seriengruppe. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzuziehen.