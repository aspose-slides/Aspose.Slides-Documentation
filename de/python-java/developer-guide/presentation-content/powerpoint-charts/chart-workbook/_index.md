---
title: Diagramm-Workbooks in Präsentationen mit Python über Java verwalten
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
description: "Entdecken Sie Aspose.Slides für Python über Java: Verwalten Sie mühelos Diagramm-Workbooks in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

Für Workbook‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#writeWorkbookStream) bereit, mit denen Sie Diagrammdaten‑Workbooks (die mit Aspose.Cells bearbeitete Diagrammdaten enthalten) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine dem Quell‑Workbook ähnliche Struktur aufweisen.

Dieser Python‑Code demonstriert einen Beispielvorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Diagrammlayout nach Workbook‑Änderung validieren**

Wenn Sie ein eingebettetes Workbook durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen bei. Diese Inkonsistenz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) eine `ArgumentOutOfRangeException` (Parameter: index) auslöst. Um die Ausnahme zu vermeiden, löschen Sie die vorhandenen Reihen und Kategorien **vor** dem Schreiben des aktualisierten Workbooks zurück in das Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Lese das Workbook nach der Änderung (z. B. mit Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Bestehende Datenreferenzen löschen.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit dem neuen Workbook übereinstimmt, sodass [validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) ohne Fehler abgeschlossen werden kann.

## **Eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.  
4. Greifen Sie auf die Diagramm‑Reihe zu.  
5. Setzen Sie die Workbook‑Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Dieser Python‑Code zeigt, wie Sie eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

Dieser Python‑Code demonstriert einen Vorgang, bei dem die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#getWorksheets) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Datentyp der Datenquelle angeben**

Dieser Python‑Code zeigt, wie Sie einen Typ für eine Datenquelle angeben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Erkennen nicht unterstützter eingebetteter Workbook‑Formate**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) auf [ChartData](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/python-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Eingebettetes Workbook ist im .xlsb-Format, das nicht unterstützt wird.
            continue
        # Diagramm-Workbook-Daten hier lesen oder ändern.
finally:
    presentation.dispose()
```

## **Externes Workbook**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Externes Workbook erstellen**

Mit den Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#readWorkbookStream) und [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie entweder ein externes Workbook von Grund auf neu erstellen oder ein internes Workbook extern machen.

Dieser Python‑Code demonstriert den Prozess der Erstellung eines externen Workbooks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Externes Workbook festlegen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Obwohl Sie die Daten in Workbooks, die an entfernten Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle verwenden. Wenn ein relativer Pfad für ein externes Workbook angegeben wird, wird er automatisch in einen vollständigen Pfad konvertiert.

Dieser Python‑Code zeigt, wie Sie ein externes Workbook festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der zweite (`bool`)-Parameter der Methode [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) wird verwendet, um anzugeben, ob ein Excel‑Workbook geladen werden soll oder nicht.

* Wenn sein Wert auf `False` gesetzt ist, wird nur der Workbook‑Pfad aktualisiert – die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn das Ziel‑Workbook nicht existiert oder nicht verfügbar ist.  
* Wenn sein Wert auf `True` gesetzt ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Pfad des externen Datenquellen‑Workbooks eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer Folie über deren Index.  
3. Erstellen Sie ein Objekt für die Diagramm‑Form.  
4. Erstellen Sie ein Objekt für den Quelltyp ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatasourcetype/)), das die Datenquelle des Diagramms repräsentiert.  
5. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Workbook‑Datenquelle entspricht.

Dieser Python‑Code demonstriert den Vorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Workbooks auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Workbooks vornehmen. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser Python‑Code ist eine Umsetzung des beschriebenen Prozesses:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ein Workbook aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm ein fehlendes oder nicht verfügbares externes Workbook verwendet, kann Aspose.Slides das Diagramm‑Workbook aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erzeugen Sie [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/), konfigurieren Sie es mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `True` auf, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel öffnet eine Präsentation, deren Diagramm ein nicht verfügbares externes Workbook referenziert, und greift über [Chart.getChartData](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#getChartData) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Lesen oder ändern Sie hier die wiederhergestellten Workbook-Daten.
finally:
    presentation.dispose()
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache Änderungen am externen Workbook nach der letzten Aktualisierung der Präsentation möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datenquelltyp](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getDataSourceType) sowie über einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Dies ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Workbooks mit Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle genutzt werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getExternalWorkbookPath), und verwendet diesen zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/python-java/)) und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm widergespiegelt.