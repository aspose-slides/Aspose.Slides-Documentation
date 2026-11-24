---
title: Diagramm-Workbooks in Präsentationen mit Python via Java verwalten
linktitle: Diagramm-Workbook
type: docs
weight: 70
url: /de/python-java/chart-workbook/
keywords:
- Diagramm-Workbook
- Diagrammdaten
- Workbook-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externes Workbook
- externe Daten
- Diagramm-Cache
- Workbook-Wiederherstellung
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via Java: verwalten Sie mühelos Diagramm-Workbooks in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Datenquellen für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines an ein Diagramm gekoppelten externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

Für Workbook‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Einbeziehen von Daten aus ausgeblendeten Zeilen und Spalten**

Verwenden Sie [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten darstellt. Setzen Sie es auf `True`, um nur sichtbare Zellen zu plotten, oder auf `False`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung beeinflusst das Plotten des Diagramms; sie blendet Arbeitsblatt‑Zeilen oder -Spalten nicht ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Objekt auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den folgenden Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, ihre Zellen enthalten jedoch weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (versteckte Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendet) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf Quellzellen zu und lesen Sie [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), um deren ausgeblendeten Status zu prüfen. Diese Methode gibt den Status zurück, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `False`, `True` und `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Ändern der Plot‑Einstellung: behalten Sie das eingebettete Workbook mit [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und laden Sie es mit [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) erneut. Beim Einbeziehen aller Zellen verwenden Sie zudem [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um den vollständigen Bereich, einschließlich der ausgeblendeten Februar‑Kategorie, wiederherzustellen. Das bloße Ändern des Flags reicht nicht aus, um die im Beispiel zwischengespeicherten Diagrammdaten und Kategorien zu aktualisieren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Aktualisieren Sie die Diagrammdaten aus dem eingebetteten Workbook.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Den vollständigen Quellbereich wiederherstellen, einschließlich ausgeblendeter Kategorien.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Das Beispiel speichert zwei Versionen der Präsentation: eine mit nur den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die untenstehenden Bilder zeigen die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Workbooks ausgeblendet.

| Nur sichtbare Zellen (`True`) | Alle Zellen (`False`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-java/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Abrufen des Datenbereichs eines Diagramms**

Bevor Sie Workbook‑Daten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblatt‑Zellen jedes Diagramm verwendet. Die Methode [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) liefert den aktuellen Datenbereich als arbeitsblattqualifizierte Formel, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inklusive. Die Dollar‑Zeichen markieren absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder sein Workbook zu ändern. Wenn das Diagramm kein Workbook als Datenquelle verwendet, wirft es `InvalidOperationException`. Weitere Informationen finden Sie in der [ChartData API‑Referenz](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Formen jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Wenn ein Diagramm kein Workbook verwendet, wird eine Meldung ausgegeben und das nächste Diagramm verarbeitet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Lesen und Schreiben von Diagrammdaten aus einem Workbook**

Aspose.Slides for Python via Java stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) bereit, mit denen Sie Diagramm‑Workbooks (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstes Objekt auf ihrer ersten Folie. Es liest das eingebettete Workbook in ein Byte‑Array, löscht die vorhandenen Reihen und Kategorien und schreibt dasselbe Workbook zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Validieren des Diagrammlayouts nach Workbook‑Modifikation**

Wenn Sie ein eingebettetes Workbook durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen. Diese Diskrepanz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Reihen und Kategorien, bevor Sie das aktualisierte Workbook zurückschreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Objekt auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Workbook‑Bearbeitung stattfinden würde; das ausführbare Beispiel schreibt das ursprüngliche Workbook zurück und validiert das Layout im Speicher.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Modifiziere hier die Workbook-Bytes, zum Beispiel mit Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor das Workbook zurückgeschrieben wird. Rekonstruieren Sie erforderliche Reihen‑ und Kategorien‑Zuordnungen für das aktualisierte Workbook, bevor Sie das Diagramm verwenden.

## **Festlegen, wie Kategorien‑Beschriftungen gespeichert werden**

Rufen Sie [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorycollection/#setUseCells) auf der leeren Kategorien‑Sammlung auf, bevor Sie Beschriftungen hinzufügen. Verwenden Sie Arbeitsblatt‑Zellen, wenn Beschriftungen auf Workbook‑Daten verweisen oder eine Hierarchie bilden, z. B. Quartale, gruppiert nach Jahr. Verwenden Sie Zeichenketten‑Literale für eine ein‑stufige Beschriftung, die keine Zell‑Referenzen benötigt. Diese Einstellung gilt nur für Kategorien. Beide nachfolgenden Diagramme verwenden Arbeitsblatt‑Zellen für ihre numerischen Reihenwerte.

Das Beispiel erstellt zwei Säulendiagramme und gibt den Speicher‑Modus gefolgt von `Q1 Q2 Q3 Q4` für jedes aus. Für arbeitsblattgestützte Beschriftungen liefert [ChartCategory.getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getAsCell) die zugrunde liegende Zelle und [ChartDataCell.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getValue) deren Beschriftung. Für literale Beschriftungen liefert [ChartCategory.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getValue) direkt die Zeichenkette.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    for use_cells in (True, False):
        x = 20 if use_cells else 360
        chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250)
        chart_data = chart.getChartData()
        chart_data.getSeries().clear()
        categories = chart_data.getCategories()
        categories.clear()
        categories.setUseCells(use_cells)

        workbook = chart_data.getChartDataWorkbook()
        series_name = workbook.getCell(0, 0, 1, "Sales")
        series = chart_data.getSeries().add(series_name, chart.getType())
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.getCell(0, row, 0, label)
                categories.add(label_cell)
            else:
                categories.add(label)

            value_cell = workbook.getCell(0, row, 1, jpype.JInt(row * 10))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        stored_in_cells = categories.getUseCells()
        labels = []
        for category in categories:
            value = category.getAsCell().getValue() if stored_in_cells else category.getValue()
            labels.append(str(value))
        print(f"UseCells = {stored_in_cells}:", *labels)

    presentation.save("category-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Benutzerdefinierte Zahlenformate für Workbook‑Zellen festlegen**

Verwenden Sie [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat), um zu steuern, wie numerische Werte in einem Diagramm‑eingebetteten Workbook angezeigt werden. Beispiel: Ein Bericht soll eine Konversionsrate als Prozentsatz mit vier Dezimalstellen und einen Koeffizienten mit fünf Dezimalstellen darstellen. Beide Werte bleiben numerisch, damit sie für Berechnungen und Diagramm‑Plotting verfügbar bleiben.

Ein Zahlenformat ändert die Anzeige, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12.5000%` an; es ersetzt die gespeicherte Zahl nicht durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0.12346` an, ohne den gespeicherten Wert zu runden. Wenn das benutzerdefinierte Format ein leerer String (`""`) ist, wird stattdessen das von [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) zurückgegebene Format verwendet.

Das folgende Beispiel erstellt ein Säulendiagramm und greift über [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf dessen Zellen zu. Auf Arbeitsblatt 0 enthält B2 die Konversionsrate und C2 den Koeffizienten. Beide Zellen liefern Diagrammwerte. Das Beispiel aktiviert außerdem Werte‑Beschriftungen, die an die Quellformate gekoppelt sind.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Workbook‑Zellformate sind von Formaten getrennt, die direkt an Diagrammachsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert ihrer Quellzelle, weil [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) auf `True` gesetzt ist und weil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) ebenfalls auf `True` steht. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12.5000%` und `0.12346`, wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes Zahlenformat, das mit [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) auf `0.00` gesetzt wurde, wobei [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) auf `False` steht.

Um ein Daten‑Label unabhängig zu formatieren, setzen Sie dessen Quell‑Link‑Flag auf `False` und weisen Sie ein Format mit [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) zu. Dies ändert das Format der Workbook‑Zelle nicht. Zum Beispiel zeigt ein unabhängiges Label‑Format `0.00` den ersten Wert als `0.13` an, während B2 weiterhin `12.5000%` anzeigt. Siehe [Diagramm‑Datenbeschriftungen](/slides/de/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) für direkte Beschriftungs‑Formatierung.

Das Bild unten wurde aus der gespeicherten Präsentation nach dem erneuten Öffnen gerendert:

![Säulendiagramm mit quellverknüpften Beschriftungen, die 12.5000 % und 0.12346 zeigen, sowie einer unabhängig formatierten numerischen Achse.](custom-cell-formats.png)

## **Ein Workbook‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Sie können Text aus Workbook‑Zellen als Diagramm‑Datenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Reihe, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Verwalten von Arbeitsblättern**

Die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) bietet Zugriff auf die Arbeitsblätter in einem Diagramm‑Workbook. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Festlegen des Datentyp‑Quelltyps**

Punktwerte einer Reihe können auch direkt als numerische Literale gespeichert werden. Siehe [Reihenwerte mit numerischen Literalen festlegen](/slides/de/python-java/chart-series/#set-series-values-using-numeric-literals) für ein vollständiges Beispiel, das sie speichert und liest. Der Quelltyp von Punktwerten ist unabhängig von der internen oder externen Workbook‑Konfiguration des Diagramms; die Verwendung numerischer Literale entfernt das eingebettete Workbook nicht automatisch.

Dieses Beispiel erstellt ein 3‑D‑Säulendiagramm mit Standarddaten und legt zwei Reihen‑Namen mit unterschiedlichen Datenquellen fest. Der erste Name verwendet ein Zeichenketten‑Literal; der zweite verwendet Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) bestimmt die Quelle für jeden Namen. Das Beispiel speichert die Präsentation mit den aktualisierten Reihen‑Namen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Erkennen nicht unterstützter eingebetteter Workbook‑Formate**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet sein kann. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) auf [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Formen auf der ersten Folie einer bestehenden Präsentation, überspringt Nicht‑Diagramm‑Formen und gibt für jedes Diagramm mit einem eingebetteten .xlsb‑Workbook eine Diagnosemeldung aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Lese oder modifiziere unterstützte Diagramm-Workbook-Daten hier.
finally:
    presentation.dispose()
```

## **Externes Workbook**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Ein externes Workbook erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), um ein eingebettetes Diagramm‑Workbook in eine Datei zu exportieren und das Diagramm mit diesem externen Workbook zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Workbook. Der Dateischreibvorgang wird abgeschlossen, bevor das externe Workbook als Datenquelle des Diagramms zugewiesen wird; anschließend wird die verknüpfte Präsentation gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ein externes Workbook zuweisen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (wenn das Workbook verschoben wurde).

Während Sie die Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können solche Workbooks dennoch als externe Datenquelle verwendet werden. Wenn ein relativer Pfad für ein externes Workbook angegeben wird, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet ein externes Workbook, dessen Arbeitsblatt `Sheet1` einen Reihen‑Namen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft das Workbook und verwendet [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um A1:B4 einer Reihe und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der Parameter `updateChartData` von [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) steuert, ob das Workbook geladen wird.

* Wenn `updateChartData` **False** ist, wird nur der Workbook‑Pfad aktualisiert. Die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert, sodass das Workbook nicht verfügbar sein kann.
* Wenn `updateChartData` **True** ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL mit `updateChartData` = `False` zu. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne das nicht verfügbare Workbook zu laden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Den Pfad des externen Datenquellen‑Workbooks eines Diagramms abrufen**

Um das mit einem Diagramm verknüpfte Workbook zu ermitteln, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Workbook‑Pfad ab.

Dieses Beispiel untersucht das erste Objekt auf der ersten Folie einer Präsentation mit einem verknüpften externen Workbook. Handelt es sich um ein Diagramm, das mit einem externen Workbook verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Workbooks genauso bearbeiten, wie Sie Änderungen an internen Workbooks vornehmen. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das das erste Objekt auf der ersten Folie ist und mit einem zugänglichen externen Workbook verknüpft ist. Es setzt den zellenbasierten Wert des ersten Datenpunkts der ersten Reihe auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original‑Workbook unverändert bleiben soll.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Ein Workbook aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm ein externes Workbook verwendet, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) auf und setzen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) auf **True**, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel stellt Workbook‑Daten für ein Diagramm wieder her, das das erste Objekt auf der ersten Folie ist und ein nicht verfügbares externes Workbook referenziert. Es greift über [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Lese oder modifiziere hier die wiederhergestellten Workbook-Daten.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten als akzeptabler Fallback gilt, da der Cache Änderungen am externen Workbook, die nach dem letzten Aktualisieren der Präsentation vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder einem eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm hat einen [Datenquellen‑Typ](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) und einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben des Workbooks ggf. ein Aktualisieren des Links erfordert.

**Kann ich Workbooks auf Netzwerk‑Ressourcen/Freigaben verwenden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Workbooks aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Das Bearbeiten von zellenbasierten Diagrammdaten kann die verknüpfte lokale XLSX‑Datei ebenfalls aktualisieren. Verwenden Sie eine Kopie des Workbooks, wenn das Original unverändert bleiben muss.

**Was tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Workbook‑Datei referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wirkt sich das Aktualisieren dieser Datei auf jedes Diagramm beim nächsten Laden der Daten aus.