---
title: Diagramm‑Arbeitsmappen in Präsentationen mit Python verwalten
linktitle: Diagramm‑Arbeitsmappe
type: docs
weight: 70
url: /de/python-net/chart-workbook/
keywords:
- Diagramm‑Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen‑Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm‑Cache
- Arbeitsmappen‑Wiederherstellung
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via .NET: verwalten Sie Diagramm‑Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm-Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwendet, Auflistungen von Arbeitsblättern zugreift und den Datentyp für Diagrammwerte festlegt.

Er behandelt zudem die Verwendung externer Arbeitsmappen als Diagramm‑Datenquellen. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-net/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus ausgeblendeten Zeilen und Spalten einbeziehen**

Verwenden Sie [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/plot_visible_cells_only/), um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten darstellt. Setzen Sie es auf `True`, um nur sichtbare Zellen zu plotten, oder auf `False`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung beeinflusst das Plotten des Diagramms; sie blendet Arbeitsblatt‑Zeilen oder -Spalten nicht aus bzw. ein.

Laden Sie [hidden-source-data.pptx](hidden-source-data.pptx) herunter und legen Sie es im Arbeitsverzeichnis ab. Die erste Folie enthält ein Säulendiagramm als erstes Shape. Das eingebettete Arbeitsblatt `Sheet1` enthält den Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, aber ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (verborgene Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.chart_data_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf Quellzellen zu und lesen Sie [ChartDataCell.is_hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatacell/is_hidden/), um deren Ausblendestatus zu prüfen. Diese Eigenschaft ist schreibgeschützt. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `False`, `True` bzw. `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie die eingebettete Arbeitsmappe mit [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und laden Sie sie mit [write_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) erneut. Wenn Sie alle Zellen einbeziehen, verwenden Sie zudem [set_range](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_range/), um den vollständigen Bereich einschließlich der ausgeblendeten Februar‑Kategorie wiederherzustellen. Das bloße Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategoriebeschriftungen dieses Beispiels zu aktualisieren.

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

            # Aktualisieren Sie die Diagrammdaten aus der eingebetteten Arbeitsmappe.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Stellen Sie den vollständigen Quellbereich wieder her, einschließlich ausgeblendeter Kategorien.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Das Beispiel speichert `hidden_cells_True.pptx` mit nur den sichtbaren Einzelhandelswerten (10 und 20) und `hidden_cells_False.pptx` mit allen sechs Werten. Die untenstehenden Bilder wurden aus den gespeicherten Präsentationen nach erneutem Öffnen gerendert; beide Dateien behalten ihre zugewiesene Plot‑Einstellung. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen ausgeblendet.

| Nur sichtbare Zellen (`True`) | Alle Zellen (`False`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [Chart.display_blanks_as](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/display_blanks_as/) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-net/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides for Python via .NET stellt die Methoden [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [write_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) bereit, mit denen Sie Diagramm‑Arbeitsmappen (enthält Diagrammdaten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine Struktur besitzen, die der Quelle ähnlich ist.

Dieses Beispiel öffnet `chart.pptx`, das auf der ersten Folie ein Diagramm als erstes Shape enthalten muss. Es liest die eingebettete Arbeitsmappe in einen Stream, löscht die vorhandenen Serien und Kategorien und schreibt dieselbe Arbeitsmappe zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

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

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategorielisten. Diese Diskrepanz kann dazu führen, dass [Chart.validate_chart_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/validate_chart_layout/) mit einem „Index out of range“-Fehler fehlschlägt. Löschen Sie die bestehenden Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben. Dieses Beispiel erfordert `chart.pptx` mit einem Diagramm als erstes Shape auf der ersten Folie. Der Kommentar markiert, wo die Bearbeitung der Arbeitsmappe stattfinden würde; das ausführbare Beispiel schreibt die Original‑Arbeitsmappe zurück und validiert das Layout im Speicher.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Ändern Sie den Arbeitsmappen-Stream hier, zum Beispiel mit Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor die Arbeitsmappe zurückgeschrieben wird. Stellen Sie bei Bedarf die erforderlichen Serien‑ und Kategoriezuweisungen für die aktualisierte Arbeitsmappe wieder her, bevor Sie das Diagramm verwenden.

## **Eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Sie können Text aus Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwenden. Die folgenden Schritte zeigen, wie Sie die Beschriftungen in einem Blasendiagramm mit Zellen seiner Daten‑Arbeitsmappe verknüpfen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) Klasse.  
2. Greifen Sie über den nullbasierten Index auf die erste Folie zu.  
3. Fügen Sie ein Blasendiagramm mit Standarddaten hinzu.  
4. Greifen Sie auf die Diagramm‑Serien zu.  
5. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
6. Speichern Sie die Präsentation.

Dieses Beispiel öffnet `chart2.pptx`, das mindestens eine Folie enthalten muss, und fügt ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 im Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert das Ergebnis in `resultchart.pptx`.

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

Die Eigenschaft [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) bietet Zugriff auf die Arbeitsblätter einer Diagramm‑Arbeitsmappe. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

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

## **Datentyp der Datenquelle festlegen**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen mithilfe unterschiedlicher Datenquellen fest. Der erste Name verwendet ein String‑Literal; der zweite verwendet Zelle C1 im Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Ergebnis wird in `pres.pptx` gespeichert.

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

## **Nicht unterstützte Formate eingebetteter Arbeitsmappen erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Sie können die Eigenschaft [embedded_workbook_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) auf [ChartData](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Shapes auf der ersten Folie von `sample.pptx`, überspringt Nicht‑Diagramm‑Shapes und gibt für jedes Diagramm mit einer eingebetteten .xlsb‑Arbeitsmappe eine Diagnosemeldung aus.

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

        # Lese oder ändere unterstützte Diagramm‑Arbeitsmappendaten hier.
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Verwenden Sie [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/), um eine eingebettete Diagramm‑Arbeitsmappe in eine Datei zu exportieren und das Diagramm mit dieser externen Arbeitsmappe zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten, schreibt dessen Arbeitsmappe in `externalWorkbook1.xlsx` und schließt den Ausgabestream, bevor die Datei als Diagramm‑Datenquelle zugewiesen wird. Es speichert die verknüpfte Präsentation in `externalWorkbook.pptx`.

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

### **Externe Arbeitsmappe zuweisen**

Mit der Methode [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (wenn diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten liegen, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel erfordert `externalWorkbook.xlsx` im Arbeitsverzeichnis. Das Arbeitsblatt `Sheet1` muss einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthalten. Das Beispiel erstellt ein Kreisdiagramm, verknüpft die Arbeitsmappe und verwendet [set_range](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_range/), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert das Ergebnis in `Presentation_with_externalWorkbook.pptx`.

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

Der Parameter `update_chart_data` von [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) steuert, ob die Arbeitsmappe geladen wird.

* Wenn `update_chart_data` **False** ist, wird nur der Pfad zur Arbeitsmappe aktualisiert. Die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert, sodass die Arbeitsmappe nicht verfügbar sein kann.  
* Wenn `update_chart_data` **True** ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL mit `update_chart_data` auf **False** zu. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne die nicht verfügbare Arbeitsmappe zu laden.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

Um die mit einem Diagramm verknüpfte Arbeitsmappe zu ermitteln, prüfen Sie zunächst, ob das Diagramm eine externe Datenquelle nutzt. Wenn ja, können Sie den Pfad zur Arbeitsmappe wie folgt auslesen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.  
2. Greifen Sie über den nullbasierten Index auf die erste Folie zu.  
3. Prüfen Sie, ob das erste Shape ein Diagramm ist.  
4. Lesen Sie den Diagramm‑Datenquellentyp.  
5. Wenn die Quelle eine externe Arbeitsmappe ist, lesen Sie deren Pfad.

Dieses Beispiel öffnet `externalWorkbook.pptx`, das im vorherigen Beispiel erstellt wurde, und untersucht das erste Shape auf der ersten Folie. Ist es ein Diagramm, das mit einer externen Arbeitsmappe verknüpft ist, gibt das Beispiel [external_workbook_path](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/) in der Konsole aus. Anschließend wird eine Kopie der Präsentation in `Result.pptx` gespeichert.

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

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel erfordert `presentation.pptx` mit einem Diagramm als erstes Shape auf der ersten Folie und einer zugänglichen externen Arbeitsmappe. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die Präsentation in `presentation_out.pptx`. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn die Original‑Arbeitsmappe unverändert bleiben soll.

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

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Falls ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/), konfigurieren Sie dessen [spreadsheet_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/spreadsheet_options/), und setzen Sie [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/de/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) auf `True`, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel öffnet `presentation.pptx`, dessen erstes Shape auf der ersten Folie ein Diagramm sein muss, das auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart.chart_data](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data/) sowie [ChartData.chart_data_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf die wiederhergestellten Daten zu:

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

        # Lesen oder Ändern der wiederhergestellten Arbeitsmappendaten hier.
    else:
        print("The first shape is not a chart.")
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Fallback ist, da der Cache möglicherweise Änderungen, die nach der letzten Aktualisierung der Präsentation an der externen Arbeitsmappe vorgenommen wurden, nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben der Arbeitsmappe ggf. eine Aktualisierung des Links erfordert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können ausschließlich als Quelle genutzt werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Das Bearbeiten von zellbasierten Diagrammdaten kann die verknüpfte lokale XLSX‑Datei ebenfalls aktualisieren. Verwenden Sie eine Kopie der Arbeitsmappe, wenn das Original unverändert bleiben muss.

**Was ist zu tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Eine gängige Vorgehensweise besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) vorzubereiten und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.