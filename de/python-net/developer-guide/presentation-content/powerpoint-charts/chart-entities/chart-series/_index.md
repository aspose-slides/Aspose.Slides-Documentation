---
title: Diagrammdatenserien in Präsentationen mit Python verwalten
linktitle: Datenserien
type: docs
url: /de/python-net/chart-series/
keywords:
- Diagrammserie
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
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappenzellen, Formatierung, Überlappung, Lückenbreite und negative Werte in Präsentationen mit Python verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Ein [ChartSeries](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/) stellt einen Satz zusammengehöriger Werte dar, und jeder [ChartDataPoint](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Zellen der Arbeitsmappe. [ChartCategory](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartcategory/)-Objekte stellen die Beschriftungen oder Gruppierungswerte bereit, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [ChartDataCell](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatacell/)‑Objekten verbunden und werden nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriediagramm verwendet die Standards‑Arbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Arbeitsblatt-, Zeilen‑ und Spaltenindizes, die an [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) übergeben werden, sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Bei einer geladenen Präsentation sollten Sie die von den Serien, Kategorien und Datenpunkten referenzierten Zellen prüfen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serienebene, wie [ChartSeries.format](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/format/), legen das Standardaussehen für alle Punkte einer Serie fest.
- Einstellungen für Datenpunkte, wie [ChartDataPoint.format](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/format/), überschreiben das Serienaussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseriesgroup/) gehören. Greifen Sie über [ChartSeries.parent_series_group](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/parent_series_group/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn keine explizite Punkt‑ oder Serienfüllung festgelegt ist, bestimmen Diagramm‑Stil und -Theme das automatische Aussehen. Liegen sowohl Serien‑ als auch Punktformatierungen vor, hat die Punktformatierung für diesen Punkt Vorrang.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagramm‑Serien‑Überlappung festlegen**

[ChartSeries.overlap](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/overlap/) gibt an, wie stark Balken oder Säulen in einem 2D‑Diagramm überlappen, von –100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung in der übergeordneten Seriengruppe. Setzen Sie [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseriesgroup/overlap/), um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie wirkt sich nicht auf nicht verwandte Seriengruppen in einem Kombinationsdiagramm aus.

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

![The series overlap](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [ChartSeries.format](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/format/), um die Standardfüllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [ChartDataPoint.format](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/format/) die Serienfüllung für diesen Punkt.

Das folgende Beispiel wendet eine durchgehende blaue Füllung auf die erste Serie an:

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

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standards‑Arbeitsmappe, die für ein gruppiertes Säulendiagramm erstellt wird, befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

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

Sie können auch die Zelle aktualisieren, auf die bereits [ChartSeries.name](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/name/) verweist. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

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

## **Automatische Serien‑Füllfarbe abfragen**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) gibt die Farbe zurück, die aus dem Serien‑Index und dem Diagramm‑Stil berechnet wird. Dies ist die Farbe, die verwendet wird, wenn die Serienfüllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standards‑Serie aus:

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

## **Umgekehrte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramme kann [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negative Werte mit einer anderen Füllung darstellen. Setzen Sie die reguläre Serienfüllung auf durchgehend, aktivieren Sie die Invertierung und weisen Sie die Farbe für negative Werte über [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) zu. Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

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

Sie können die Invertierung für einen einzelnen Punkt über [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) aktivieren. Im folgenden Beispiel ist die Invertierung für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, damit der Effekt sichtbar wird:

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

## **Einen bestimmten Datenpunktwert leeren**

Um einen Punkt leer zu machen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugrunde liegende Arbeitsmappen‑Zelle auf `None`. Für ein Säulendiagramm ist der dargestellte Wert über [ChartDataPoint.value](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/value/) verfügbar. Der Datenpunkt bleibt an derselben Kategorienposition, aber das Diagramm behandelt den Wert als leer gemäß den Einstellungen für leere Werte des Diagramms.

Das folgende Beispiel leert nur den zweiten Punkt in der ersten Serie:

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

Scatter‑Diagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zusätzlich eine Größenzelle. Leeren Sie nur die Zelle, die den Wert repräsentiert, den Sie entfernen möchten. Rufen Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapointcollection/clear/) nicht auf, wenn Sie die anderen Punkte behalten wollen, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Versteckte Zellen, die Werte enthalten, sind ein anderer Fall als leere Zellen. Um Daten aus ausgeblendeten Zeilen und Spalten des Arbeitsblatts ein- oder auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappen‑Zelle stellt fehlende Daten dar; eine Zelle mit `0` stellt einen bekannten numerischen Wert dar. Setzen Sie [ChartDataCell.value](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatacell/value/) auf `None`, um eine Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [Chart.display_blanks_as](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/display_blanks_as/), um festzulegen, wie das Diagramm leere Zellen darstellt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsmappen‑Zelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, leert den Wert für Tag 3 und speichert das Diagramm jeweils mit einem anderen Modus. Es wird keine Eingabedatei benötigt. Der [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/) nutzt Arbeitsblatt 0, Spalte 0 für Kategorienamen und Spalte 1 für Werte; Zeile 0 enthält den Seriennamen. Die endgültigen Daten lauten `10, 20, empty, 30, 40`.

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

    # Lassen Sie Tag 3 wirklich leer, während Sie seine Kategorie und Datenpunkt beibehalten.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal, anstatt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in jeder Arbeitsmappe leer:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm macht alle drei Modi leicht vergleichbar. Balken‑ und Säulendiagramme besitzen keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `SPAN` das gezeigte Verbindungssegment nicht erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm ohne Linien nur Markierungen und keinen Verbindungspfad. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen­clustern, angegeben als Prozentsatz der Balken‑ bzw. Säulenbreite. Ähnlich wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) einmal für die Gruppe. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

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

![The gap width](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/charttype/)-Aufzählung repräsentiert werden, verwenden Diagrammdaten, doch ihre Serien besitzen nicht überall dieselbe Wertstruktur oder dieselben Einstellungen. Beispielsweise nutzen Kategoriediagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte, und Blasendiagramme zusätzlich die Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagramm‑Serien‑Gruppe?**

Eine [ChartSeriesGroup](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseriesgroup/) enthält kompatible Serien, die gruppenweite Darstellungs‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Serie nicht notwendigerweise jede Serie im Diagramm beeinflusst.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [ShapeCollection.add_chart](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_chart/) Beispielserien, -kategorien und -werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategorien‑Sammlungen leeren, bevor Sie ein völlig benutzerdefiniertes Datenset hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagramm‑Objekte mit Arbeitsmappen‑Zellen verknüpft?**

Seriennamen, Kategorienbeschriftungen und Datenpunktwerte verweisen auf Zellen in einem [ChartDataWorkbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das entsprechende Diagrammelement. Wenn Sie eigene Daten erstellen, halten Sie die Zeilen für Kategorien und Serienwerte ausgerichtet, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie leere ich einen einzelnen Punkt statt der gesamten Serie?**

Setzen Sie die betreffende Wertzelle auf `None`, um die Position des Punktes als leeren Punkt beizubehalten. Verwenden Sie [ChartDataPointCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapointcollection/clear/) nur, wenn Sie alle Punkte dieser Serie entfernen möchten. Entfernen Sie zudem nicht die Kategorien, ohne alle Serien anzupassen, da sonst die Werte nicht mehr mit der Kategorien‑Sammlung übereinstimmen.

**Wie werden leere Punkte dargestellt?**

Das Ergebnis hängt vom Diagrammtyp und von [Chart.display_blanks_as](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/display_blanks_as/) ab. Unterstützte Diagramme können Lücken als Lücken, als Nullwerte oder durch Verbinden benachbarter Punkte anzeigen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Control the Display of Empty Cells](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme aktivieren Sie [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/invert_if_negative/) und setzen Sie [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Sie können das Verhalten für einen einzelnen Punkt mit [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) überschreiben. Diese Eigenschaften beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat für diesen Punkt Vorrang. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn kein Serienformat definiert ist, den automatischen Diagramm‑Stil und das Theme. Gruppeneigenschaften wie Überlappung und Lückenbreite steuern das Layout und sind keine punktbezogenen Formatierungsüberschreibungen.

**Gibt es ein Limit für die Anzahl der Serien in einem Diagramm?**

Aspose.Slides legt kein separates festes Serien‑Zähl‑Limit fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und Diagramm‑Lesbarkeit ein sinnvolles Limit.

**Was sollte ich ändern, wenn Säulen zu dicht beieinander oder zu weit auseinander liegen?**

Setzen Sie [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) auf der entsprechenden übergeordneten Seriengruppe. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.