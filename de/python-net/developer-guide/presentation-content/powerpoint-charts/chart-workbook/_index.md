---
title: Diagrammarbeitsmappen in Präsentationen mit Python verwalten
linktitle: Diagrammarbeitsmappe
type: docs
weight: 70
url: /de/python-net/chart-workbook/
keywords:
- Diagrammarbeitsmappe
- Diagrammdaten
- Arbeitsbuchzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externes Arbeitsbuch
- Externe Daten
- Diagramm-Cache
- Arbeitsbuchwiederherstellung
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via .NET: Verwalten Sie Diagrammarbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsbuch‑Streams liest und schreibt, Arbeitsblatt‑Zellen als Diagramm‑Datenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte angibt.

Außerdem wird die Arbeit mit externen Arbeitsmappen als Datenquelle für Diagramme behandelt. Die Beispiele demonstrieren, wie man ein externes Arbeitsbuch erstellt und zuweist, den Pfad eines externen Arbeitsbuchs, das mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn das Arbeitsbuch verfügbar ist.

Für Arbeitsblatt‑Zellen, die fehlende Daten darstellen, siehe [Control the Display of Empty Cells](/slides/de/python-net/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Einbeziehen von Daten aus ausgeblendeten Zeilen und Spalten**

Verwenden Sie [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/), um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten plotten soll. Setzen Sie es auf `True`, um nur sichtbare Zellen zu plotten, oder auf `False`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung beeinflusst das Plotten des Diagramms; sie blendet Arbeitsblatt‑Zeilen oder -Spalten nicht ein oder aus.

Die [sample presentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Shape auf der ersten Folie. Das eingebettete Arbeitsblatt, `Sheet1`, enthält den Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, ihre Zellen enthalten jedoch weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf Quellzellen zu und lesen Sie [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/), um deren ausgeblendeten Status zu prüfen. Diese Eigenschaft ist schreibgeschützt. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `False`, `True` bzw. `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten, nachdem Sie die Plot‑Einstellung geändert haben: behalten Sie das eingebettete Arbeitsbuch mit [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und laden Sie es mit [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) neu. Wenn Sie alle Zellen einbeziehen, verwenden Sie außerdem [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/), um den vollständigen Bereich, einschließlich der ausgeblendeten Februar‑Kategorie, wiederherzustellen. Das bloße Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategoriebeschriftungen dieses Beispiels zu aktualisieren.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Diagrammdaten aus dem eingebetteten Arbeitsbuch aktualisieren.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Den vollständigen Quellbereich wiederherstellen, einschließlich ausgeblendeter Kategorien.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Das Beispiel speichert zwei Versionen der Präsentation: eine mit nur den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die untenstehenden Bilder wurden aus den gespeicherten Präsentationen nach dem erneuten Öffnen gerendert; beide Dateien behalten ihre zugewiesene Plot‑Einstellung. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen ausgeblendet.

| Nur sichtbare Zellen (`True`) | Alle Zellen (`False`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Control the Display of Empty Cells](/slides/de/python-net/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Abrufen des Datenbereichs eines Diagramms**

Bevor Sie Arbeitsbuch‑Daten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblatt‑Zellen jedes Diagramm verwendet. Die Methode [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) gibt den aktuellen Datenbereich als arbeitsblatt‑qualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich und `$A$1:$D$5` identifiziert die Zellen A1 bis D5, inklusiv. Die Dollarzeichen bedeuten absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder sein Arbeitsbuch zu verändern. Wenn das Diagramm kein Arbeitsbuch als Datenquelle verwendet, wird eine Ausnahme ausgelöst. Weitere Informationen finden Sie in der [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Shapes jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Wenn der Bereich nicht ermittelt werden kann, wird eine Diagnose‑Meldung ausgegeben und mit dem nächsten Diagramm fortgefahren.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Diagrammdaten aus einem Arbeitsbuch lesen und schreiben**

Aspose.Slides for Python via .NET stellt die Methoden [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) bereit, mit denen Sie Diagramm‑Arbeitsmappen (die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise strukturiert sein oder eine ähnliche Struktur wie die Quelle besitzen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstes Shape auf der ersten Folie. Es liest das eingebettete Arbeitsbuch in einen Stream, löscht die vorhandenen Serien und Kategorien und schreibt dasselbe Arbeitsbuch zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Diagrammlayout nach Arbeitsbuchänderung validieren**

Wenn Sie ein eingebettetes Arbeitsbuch durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen. Diese Diskrepanz kann dazu führen, dass [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) mit einem Index‑Out‑of‑Range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie das aktualisierte Arbeitsbuch zurückschreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Arbeitsbuch‑Bearbeitung stattfinden würde; das ausführbare Beispiel schreibt das originale Arbeitsbuch zurück und validiert das Layout im Speicher.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Arbeitsbuch-Stream hier ändern, zum Beispiel mit Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor das Arbeitsbuch zurückgeschrieben wird. Bauen Sie alle erforderlichen Serien‑ und Kategoriezurodnungen für das aktualisierte Arbeitsbuch neu auf, bevor Sie das Diagramm verwenden.

## **Benutzerdefinierte Zahlenformate für Arbeitsbuchzellen festlegen**

Verwenden Sie [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/), um zu steuern, wie numerische Werte in einem eingebetteten Diagramm‑Arbeitsbuch angezeigt werden. Zum Beispiel kann ein Bericht eine Konversionsrate als Prozentsatz mit vier Dezimalstellen und einen Koeffizienten mit fünf Dezimalstellen anzeigen. Beide Werte sollten numerisch bleiben, damit sie für Berechnungen und Diagramm‑Plotting verfügbar sind.

Ein Zahlenformat ändert nur die Anzeige, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12.5000%` an; es ersetzt die gespeicherte Zahl nicht durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0.12346` an, ohne den gespeicherten Wert zu runden. Wenn das benutzerdefinierte Format ein leerer String (`""`) ist, wird stattdessen [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) verwendet.

Im folgenden Beispiel wird ein Säulendiagramm erstellt und über [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf seine Zellen zugegriffen. Auf Arbeitsblatt 0 enthält B2 die Konversionsrate und C2 den Koeffizienten. Beide Zellen liefern Diagrammwerte. Das Beispiel aktiviert außerdem Wertbeschriftungen, die mit den Quellformaten verknüpft sind.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Arbeitsblatt‑Zellformate sind von Formaten getrennt, die direkt an Diagrammachsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert ihrer Quellzelle, weil [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) aktiviert ist und weil [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) auf `True` steht. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12.5000%` und `0.12346` an, wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` mit [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) auf `False`.

Um eine Datenbeschriftung unabhängig zu formatieren, setzen Sie deren Quell‑Link‑Flag auf `False` und weisen ihr ein [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) zu. Dies ändert das Format der Arbeitsblattzelle nicht. Beispiel: Ein unabhängiges Beschriftungsformat `0.00` zeigt den ersten Wert als `0.13` an, während B2 weiterhin `12.5000%` anzeigt. Siehe [Chart Data Labels](/slides/de/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) für direkte Beschriftungsformatierung.

Das folgende Bild wurde aus der gespeicherten Präsentation nach dem erneuten Öffnen gerendert:

![Säulendiagramm mit quellenverknüpften Beschriftungen, die 12.5000% und 0.12346 zeigen, sowie einer unabhängig formatierten numerischen Achse.](custom-cell-formats.png)

## **Ein Arbeitsblatt‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Sie können Text aus Arbeitsblatt‑Zellen als Diagramm‑Datenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Arbeitsblätter verwalten**

Die Eigenschaft [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) bietet Zugriff auf die Arbeitsblätter eines Diagramm‑Arbeitsbuchs. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Datentyp der Datenquelle angeben**

Serien‑Punktwerte können auch direkt als numerische Literale gespeichert werden. Siehe [Set Series Values Using Numeric Literals](/slides/de/python-net/chart-series/#set-series-values-using-numeric-literals) für ein vollständiges Beispiel, das sie speichert und liest. Der Quelltyp von Punktwerten ist von der internen oder externen Arbeitsbuch‑Konfiguration des Diagramms getrennt; die Verwendung von numerischen Literalen entfernt nicht automatisch das eingebettete Arbeitsbuch.

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und setzt zwei Seriennamen, die unterschiedliche Datenquellen verwenden. Der erste Name verwendet ein String‑Literal; der zweite verwendet die Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Erkennung nicht unterstützter eingebetteter Arbeitsbuch‑Formate**

Aspose.Slides unterstützt das Excel‑Binärarbeitsbuch‑Format (.xlsb) nicht, das in manchen Diagrammen eingebettet werden kann. Sie können die Eigenschaft [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) auf [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel prüft die Shapes auf der ersten Folie einer bestehenden Präsentation, überspringt Nicht‑Diagramm‑Shapes und gibt für jedes Diagramm mit einem eingebetteten .xlsb‑Arbeitsbuch eine Diagnose‑Meldung aus.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Unterstützte Diagrammarbeitsbuchdaten hier lesen oder ändern.
```

## **Externes Arbeitsbuch**

Aspose.Slides unterstützt die Verwendung externer Arbeitsbücher als Datenquelle für Diagramme.

### **Ein externes Arbeitsbuch erstellen**

Verwenden Sie [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), um ein eingebettetes Diagramm‑Arbeitsbuch in eine Datei zu exportieren und das Diagramm mit diesem externen Arbeitsbuch zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Arbeitsbuch. Es schließt den Ausgabestream, bevor es das externe Arbeitsbuch als Diagramm‑Datenquelle zuweist, und speichert anschließend die verknüpfte Präsentation.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Ein externes Arbeitsbuch zuweisen**

Mit der Methode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einem Diagramm ein externes Arbeitsbuch als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Arbeitsbuch zu aktualisieren (falls dieses verschoben wurde).

Während Sie die Daten in Arbeitsbüchern, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Arbeitsbücher dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad zu einem externen Arbeitsbuch angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet ein externes Arbeitsbuch, dessen Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft das Arbeitsbuch und verwendet [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `update_chart_data` von [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) steuert, ob das Arbeitsbuch geladen wird.

* Ist `update_chart_data` `False`, wird nur der Arbeitsbuch‑Pfad aktualisiert. Die Diagrammdaten werden nicht aus dem Ziel‑Arbeitsbuch geladen oder aktualisiert, sodass das Arbeitsbuch nicht verfügbar sein kann.
* Ist `update_chart_data` `True`, werden die Diagrammdaten aus dem Ziel‑Arbeitsbuch aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL zu, wobei `update_chart_data` auf `False` gesetzt ist. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne das nicht verfügbare Arbeitsbuch zu laden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms ermitteln**

Um das Arbeitsbuch zu identifizieren, das mit einem Diagramm verknüpft ist, prüfen Sie, ob das Diagramm eine externe Datenquelle nutzt, und rufen Sie dessen Arbeitsbuch‑Pfad ab.

Dieses Beispiel prüft das erste Shape auf der ersten Folie einer Präsentation mit einem verknüpften externen Arbeitsbuch. Handelt es sich um ein Diagramm, das auf ein externes Arbeitsbuch verweist, gibt das Beispiel [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsbüchern genauso bearbeiten, wie Sie Änderungen an internen Arbeitsbüchern vornehmen. Wenn ein externes Arbeitsbuch nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist und mit einem zugänglichen externen Arbeitsbuch verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original erhalten bleiben soll.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Ein Arbeitsbuch aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm ein externes Arbeitsbuch verwendet, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Arbeitsbuch aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), konfigurieren Sie dessen [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), und setzen Sie [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) auf `True`, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel stellt Arbeitsbuch‑Daten für ein Diagramm wieder her, das das erste Shape auf der ersten Folie ist und ein nicht verfügbares externes Arbeitsbuch referenziert. Es greift über [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) und [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf die wiederhergestellten Daten zu:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Wiederhergestellte Arbeitsbuchdaten hier lesen oder ändern.
    else:
        print("The first shape is not a chart.")
```

Ist das externe Arbeitsbuch nicht verfügbar und die Wiederherstellung deaktiviert, löst Aspose.Slides eine Ausnahme aus. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache möglicherweise keine Änderungen enthält, die nach dem letzten Aktualisieren der Präsentation am externen Arbeitsbuch vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder einem eingebetteten Arbeitsbuch verknüpft ist?**

Ja. Ein Diagramm hat einen [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); wenn die Quelle ein externes Arbeitsbuch ist, können Sie den vollständigen Pfad auslesen, um sicherzugehen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsbüchern unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad konvertiert. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben des Arbeitsbuchs eine Aktualisierung des Links erfordern kann.

**Kann ich Arbeitsbücher verwenden, die sich auf Netzwerk‑Ressourcen/Freigaben befinden?**

Ja, solche Arbeitsbücher können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsbücher aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Das Bearbeiten von zellbasierten Diagrammdaten kann auch die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie des Arbeitsbuchs, wenn das Original unverändert bleiben muss.

**Was tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten berücksichtigt.