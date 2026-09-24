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
description: "Entdecken Sie Aspose.Slides für Python über .NET: Verwalten Sie mühelos Diagramm‑Arbeitsmappen in PowerPoint- und OpenDocument‑Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammw Werte festlegt.

Er behandelt zudem die Arbeit mit externen Arbeitsmappen als Diagramm‑Datenquellen. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/python-net/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Chartdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides bietet Methoden zum Lesen und Schreiben von Diagramm‑Arbeitsmappendaten (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis:** Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine Struktur haben, die der Quelle ähnlich ist.

Der folgende Python‑Code demonstriert eine Beispiel‑Operation:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Diagrammlayout nach Arbeitsmappenänderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriensammlungen bei. Diese Diskrepanz kann dazu führen, dass [IChart.validate_chart_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichart/validate_chart_layout/) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben.

```python
# Nach dem Ändern des Arbeitsmappen-Streams (z. B. mit Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Vorhandene Datenreferenzen löschen.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe konsistent ist, sodass `validate_chart_layout` ohne Fehler abgeschlossen werden kann.

## **Eine WorkBook‑Zelle als Diagrammdatenbeschriftung festlegen**

Manchmal benötigen Sie Diagrammbeschriftungen, die direkt aus Zellen der zugrunde liegenden Daten‑WorkBook stammen. Aspose.Slides ermöglicht das Binden von Datenbeschriftungen an bestimmte WorkBook‑Zellen, sodass der Beschriftungstext stets den Zellenwert widerspiegelt. Das nachfolgende Beispiel zeigt, wie Sie Werte‑aus‑Zelle‑Beschriftungen aktivieren und ausgewählte Beschriftungen auf benutzerdefinierte Zellen in der WorkBook des Diagramms verweisen lassen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand des Indexes.
1. Fügen Sie ein Blasendiagramm mit Beispieldaten hinzu.
1. Greifen Sie auf die Diagrammserie zu.
1. Verwenden Sie eine WorkBook‑Zelle als Datenbeschriftung.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie man eine WorkBook‑Zelle als Diagrammdatenbeschriftung festlegt:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanziieren Sie die Klasse Presentation, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Arbeitsblätter verwalten**

Der folgende Python‑Code demonstriert die Verwendung der `worksheets`‑Eigenschaft zum Zugriff auf die Arbeitsblatt‑Sammlung:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Den Datentyp der Datenquelle angeben**

Der folgende Python‑Code zeigt, wie ein Datentyp der Datenquelle angegeben wird:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nicht unterstützte eingebettete Arbeitsmappenformate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Sie können die Eigenschaft `embedded_workbook_type` auf [ChartData](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
            continue

        # Diagramm‑Arbeitsmappendaten hier lesen oder ändern.
```

## **Externe Arbeitsmappen**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappen festlegen**

Durch die Verwendung der Methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann außerdem den Pfad zu einer externen Arbeitsmappe aktualisieren, wenn diese verschoben wurde.

Obwohl Sie Daten in Arbeitsmappen, die an entfernten Speicherorten liegen, nicht bearbeiten können, können Sie diese Arbeitsmappen dennoch als externe Datenquellen nutzen. Wenn Sie einen relativen Pfad für eine externe Arbeitsmappe angeben, wird dieser automatisch in einen vollständigen Pfad umgewandelt.

Der folgende Python‑Code zeigt, wie eine externe Arbeitsmappe festgelegt wird:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Übergebe False, damit nur der Pfad gespeichert wird: die Zielarbeitsmappe muss noch nicht existieren.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `update_chart_data` der Methode [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) gibt an, ob die Excel‑Arbeitsmappe geladen wird.

- Wenn `update_chart_data` auf `False` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert; die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Verwenden Sie diese Einstellung, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.
- Wenn `update_chart_data` auf `True` gesetzt ist (Standard), werden die Diagrammdaten aus der Zielarbeitsmappe geladen und aktualisiert. Kann die Arbeitsmappe nicht geöffnet werden, wird eine Ausnahme mit der Meldung „External workbook is not available“ ausgelöst.

### **Externe Arbeitsmappen erstellen**

Durch die Verwendung der Methoden [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe in eine externe konvertieren.

Dieser Python‑Code demonstriert den Erstellungsprozess einer externen Arbeitsmappe:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Den Pfad der externen Datenquellen‑Arbeitsmappe für ein Diagramm abrufen**

Manchmal ist die Datenquelle eines Diagramms mit einer externen Excel‑Arbeitsmappe verknüpft, anstatt mit den eingebetteten Daten der Präsentation. Mit Aspose.Slides können Sie die Datenquelle des Diagramms prüfen und, wenn es sich um eine externe Arbeitsmappe handelt, den vollständigen Arbeitsmappen‑Pfad auslesen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich einen Verweis auf die Folie anhand ihres Indexes.
1. Holen Sie sich einen Verweis auf das Diagramm‑Shape.
1. Ermitteln Sie die Quelle ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatasourcetype/)), die die Datenquelle des Diagramms repräsentiert.
1. Prüfen Sie, ob der Quelltyp dem externen Arbeitsmappen‑Datenquellentyp entspricht.

Der folgende Python‑Code demonstriert den Vorgang:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Diagrammdaten bearbeiten**

Sie können Daten in externen Arbeitsmappen genauso bearbeiten wie in internen Arbeitsmappen. Kann eine externe Arbeitsmappe nicht geladen werden, wird eine Ausnahme ausgelöst.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Eine Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/), aktivieren Sie dann [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/de/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/) über [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/spreadsheet_options/), bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart.chart_data](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data/) und [ChartData.chart_data_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf die wiederhergestellten Daten zu:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Die wiederhergestellten Arbeitsmappendaten hier lesen oder ändern.
```

Ist die externe Arbeitsmappe nicht verfügbar und ist die Wiederherstellung deaktiviert, löst Aspose.Slides eine Ausnahme aus. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der im Cache gespeicherten Diagrammdaten als akzeptabler Rückgriff zulässig ist, da der Cache möglicherweise keine Änderungen enthält, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden.

## **FAQ**

**Kann ich ermitteln, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird dieser automatisch in einen absoluten Pfad konvertiert. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen auf Netzwerkressourcen/Freigaben verwenden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können lediglich als Quelle dienen.

**Schreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation überschrieben?**

Nur wenn Sie die Diagrammdaten bearbeitet haben. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/) und verwendet ihn zum Lesen der Daten, sodass das Öffnen und Speichern einer Präsentation die Arbeitsmappe unverändert lässt. Werte, die Sie jedoch über die Diagrammdaten ändern (siehe [Edit Chart Data](#edit-chart-data) oben), werden beim Speichern der Präsentation zurück in die externe Arbeitsmappe geschrieben – arbeiten Sie mit einer Kopie, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/python-net/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.