---
title: Verwalten von Diagramm‑Workbooks in Präsentationen mit Python via Java
linktitle: Diagramm‑Workbook
type: docs
weight: 70
url: /de/python-java/chart-workbook/
keywords:
- Diagramm‑Workbook
- Diagrammdaten
- Workbook‑Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externes Workbook
- externe Daten
- Diagramm‑Cache
- Workbook‑Wiederherstellung
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via Java: verwalten Sie Diagramm‑Workbooks mühelos in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines externen Workbooks, das einem Diagramm zugeordnet ist, abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

Für Workbook‑Zellen, die fehlende Daten darstellen, siehe [Steuere die Anzeige leerer Zellen](/slides/de/python-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus ausgeblendeten Zeilen und Spalten einbeziehen**

Verwenden Sie [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly), um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblattzeilen und -spalten darstellt. Setzen Sie es auf `True`, um nur sichtbare Zellen zu plotten, oder auf `False`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung steuert das Diagramm‑Plotten; sie blendet Arbeitszeilen oder -spalten nicht ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Shape auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den folgenden Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, aber ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf Quellzellen zu und lesen Sie [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden), um deren ausgeblendeten Status zu prüfen. Diese Methode gibt den ausgeblendeten Status zurück, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `False`, `True` und `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie das eingebettete Workbook mit [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und laden Sie es mit [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) erneut. Beim Einschließen aller Zellen verwenden Sie außerdem [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um den vollständigen Bereich einschließlich der ausgeblendeten Februar‑Kategorie wiederherzustellen. Das reine Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategorielabels dieses Beispiels zu aktualisieren.

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
                # Wiederherstellen des gesamten Quellbereichs, einschließlich ausgeblendeter Kategorien.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Das Beispiel speichert zwei Versionen der Präsentation: eine nur mit den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die Bilder unten illustrieren die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Workbooks ausgeblendet.

| Nur sichtbare Zellen (`True`) | Alle Zellen (`False`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuere die Anzeige leerer Zellen](/slides/de/python-java/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Diagrammdatenbereich abrufen**

Bevor Sie Workbook‑Daten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um festzustellen, welche Arbeitsblattzellen jedes Diagramm verwendet. Die Methode [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) gibt den aktuellen Datenbereich als arbeitsblattqualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellenbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inkl. Die Dollarzeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder sein Workbook zu ändern. Wenn das Diagramm kein Workbook als Datenquelle verwendet, wird eine `InvalidOperationException` ausgelöst. Weitere Informationen finden Sie in der [ChartData API-Referenz](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Shapes direkt auf jeder Folie auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Wenn ein Diagramm kein Workbook verwendet, wird eine Meldung ausgegeben und mit dem nächsten Diagramm fortgefahren.

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

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides für Python via Java bietet die Methoden [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), mit denen Sie Diagramm‑Workbooks (die mit Aspose.Cells bearbeitete Diagrammdaten enthalten) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstes Shape auf ihrer ersten Folie. Es liest das eingebettete Workbook in ein Byte‑Array, löscht die vorhandenen Serien und Kategorien und schreibt dasselbe Workbook zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

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

### **Diagrammlayout nach Workbook‑Änderung validieren**

Wenn Sie ein eingebettetes Workbook durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie das aktualisierte Workbook zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist. Der Kommentar markiert, wo das Workbook bearbeitet werden würde; das ausführbare Beispiel schreibt das Original‑Workbook zurück und validiert das Layout im Speicher.

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

        # Ändern Sie hier die Workbook-Bytes, zum Beispiel mit Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor das Workbook zurückgeschrieben wird. Stellen Sie vor der Verwendung des Diagramms alle erforderlichen Serien‑ und Kategorieszuordnungen für das aktualisierte Workbook wieder her.

## **Ein Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

Sie können Text aus Workbook‑Zellen als Diagrammdatenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 im Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

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

## **Arbeitsblätter verwalten**

Die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) bietet Zugriff auf die Arbeitsblätter in einem Diagramm‑Workbook. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen auf der Konsole aus.

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

## **Datentyp der Datenquelle festlegen**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen mit verschiedenen Datenquellen fest. Der erste Name verwendet ein Zeichenketten‑Literal; der zweite verwendet die Zelle C1 im Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

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

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet sein kann. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) auf [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel prüft die Shapes auf der ersten Folie einer vorhandenen Präsentation, überspringt Nicht‑Diagramm‑Shapes und gibt für jedes Diagramm mit einem eingebetteten .xlsb‑Workbook eine Diagnosemeldung aus.

```python
import jpype
import asposeslides

if not jpape.isJVMStarted():
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
        # Lese oder bearbeite hier unterstützte Chart‑Workbook‑Daten.
finally:
    presentation.dispose()
```

## **Externes Workbook**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Externes Workbook erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) und [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), um ein eingebettetes Diagramm‑Workbook in eine Datei zu exportieren und das Diagramm mit diesem externen Workbook zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Workbook. Es schließt den Dateischreibvorgang ab, bevor das externe Workbook als Datenquelle zugewiesen wird, und speichert die verknüpfte Präsentation.

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

### **Externes Workbook zuweisen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Obwohl Sie die Daten in Workbooks, die an Remote‑Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle verwenden. Wird ein relativer Pfad für ein externes Workbook angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet ein externes Workbook, dessen Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft das Workbook und verwendet [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

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

Dieses Beispiel prüft das erste Shape auf der ersten Folie einer Präsentation mit einem verknüpften externen Workbook. Handelt es sich um ein Diagramm, das mit einem externen Workbook verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

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

Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist und mit einem zugänglichen externen Workbook verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original‑Workbook unverändert bleiben muss.

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

Verwendet ein Diagramm ein externes Workbook, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) auf und setzen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) auf **True**, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel stellt Workbook‑Daten für ein Diagramm wieder her, das das erste Shape auf der ersten Folie ist und auf ein nicht verfügbares externes Workbook verweist. Es greift über [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

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

        # Lesen oder ändern Sie hier die wiederhergestellten Workbook-Daten.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ist das externe Workbook nicht verfügbar und ist die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückfall ist, da der Cache möglicherweise nicht die nach der letzten Aktualisierung der Präsentation vorgenommenen Änderungen am externen Workbook enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datentyp der Datenquelle](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) und einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzugehen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Geben Sie einen relativen Pfad an, wird er automatisch in einen absoluten Pfad konvertiert. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben des Workbooks ggf. eine Aktualisierung des Links erfordert.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle genutzt werden. Das direkte Bearbeiten von remote gespeicherten Workbooks aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Das Bearbeiten von zellbasierten Diagrammdaten kann zudem die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie des Workbooks, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) vorzubereiten und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Zeigen sie alle auf dieselbe Datei, werden Änderungen an dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.