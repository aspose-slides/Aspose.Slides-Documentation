---
title: Diagramm-Arbeitsmappen in Präsentationen mit Python via Java verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/python-java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externe Arbeitsmappe
- Externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via Java: Verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdaten‑Beschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Datenquellen für Diagramme. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer an ein Diagramm angehängten externen Arbeitsmappe abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**
Aspose.Slides stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#writeWorkbookStream) bereit, mit denen Sie Diagrammdaten‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieser Python‑Code demonstriert eine Beispiel‑Operation:

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

### **Diagrammlayout nach Arbeitsmappenänderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriensammlungen bei. Diese Inkonsistenz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) eine `ArgumentOutOfRangeException` (Parameter: index) wirft. Um die Ausnahme zu vermeiden, löschen Sie die vorhandenen Serien und Kategorien **before** (vor dem) Schreiben der aktualisierten Arbeitsmappe zurück in das Diagramm.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Lese die Arbeitsmappe nach der Modifizierung (z. B. mit Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Bestehende Datenverweise löschen.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Das Löschen der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass [validateChartLayout](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#validateChartLayout) ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagrammdaten‑Beschriftung festlegen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie sich über den Index einen Verweis auf eine Folie.  
1. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.  
1. Greifen Sie auf die Diagramm‑Serien zu.  
1. Legen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung fest.  
1. Speichern Sie die Präsentation.

Dieser Python‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagrammdaten‑Beschriftung festlegen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

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
Dieser Python‑Code demonstriert eine Operation, bei der die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdataworkbook/#getWorksheets) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Den Datentyp der Datenquelle angeben**
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

## **Erkennen nicht unterstützter eingebetteter Arbeitsmappenformate**
Aspose.Slides unterstützt das Excel‑binäre Arbeitsmappen‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) auf [ChartData](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/python-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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
            # Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
            continue
        # Lese hier die Diagramm-Arbeitsmappendaten oder ändere sie.
finally:
    presentation.dispose()
```

### **Eine externe Arbeitsmappe erstellen**
Mit den Methoden [readWorkbookStream](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#readWorkbookStream) und [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser Python‑Code demonstriert den Vorgang zur Erstellung einer externen Arbeitsmappe:

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

### **Eine externe Arbeitsmappe zuweisen**
Durch die Verwendung der Methode [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Die Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (wenn diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Orten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieser Python‑Code zeigt, wie Sie eine externe Arbeitsmappe zuweisen:

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

Der zweite (`bool`) Parameter der Methode [setExternalWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#setExternalWorkbook) gibt an, ob eine Excel‑Arbeitsmappe geladen werden soll oder nicht.

* Wenn sein Wert auf `False` gesetzt ist, wird nur der Pfad der Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist nützlich, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn sein Wert auf `True` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

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

### **Den Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms erhalten**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Klasse.  
1. Holen Sie sich über den Index einen Verweis auf eine Folie.  
1. Erstellen Sie ein Objekt für das Diagramm‑Shape.  
1. Erstellen Sie ein Objekt für den Quelltyp ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdatasourcetype/)) ‑‑ das den Datenquellentyp des Diagramms darstellt.  
1. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem externen Arbeitsmappen‑Datenquellentyp entspricht.

Dieser Python‑Code demonstriert die Operation:

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
Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser Python‑Code implementiert den beschriebenen Prozess:

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

### **Eine Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**
Verwendet ein Diagramm eine externe Arbeitsmappe, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/), konfigurieren Sie sie mit [SpreadsheetOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/spreadsheetoptions/), und rufen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) mit `True` auf, bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart.getChartData](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/#getChartData) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

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

    # Wiederhergestellte Arbeitsmappendaten hier lesen oder ändern.
finally:
    presentation.dispose()
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Nutzung der zwischengespeicherten Diagrammdaten als akzeptabler Rückgriff in Ordnung ist, da der Cache Änderungen, die nach der letzten Aktualisierung der Präsentation an der externen Arbeitsmappe vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm hat einen [data source type](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getDataSourceType) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzugehen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verlinken kein Passwort. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/python-java/)) vorzubereiten und diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird ein Update dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.