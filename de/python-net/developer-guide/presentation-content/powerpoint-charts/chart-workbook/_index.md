---
title: "Diagramm‑Arbeitsmappen in Präsentationen mit Python verwalten"
linktitle: "Diagramm‑Arbeitsmappe"
type: docs
weight: 70
url: /de/python-net/chart-workbook/
keywords:
- diagramm‑arbeitsmappe
- diagrammdaten
- arbeitsmappen‑zelle
- datenbeschriftung
- arbeitsblatt
- datenquelle
- externe arbeitsmappe
- externe daten
- diagramm‑cache
- arbeitsmappen‑wiederherstellung
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python über .NET: verwalten Sie mühelos Diagramm‑Arbeitsmappen in PowerPoint- und OpenDocument‑Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp für Diagrammwerte angibt.

Außerdem wird die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen behandelt. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides stellt Methoden zum Lesen und Schreiben von Diagramm‑Arbeitsmappen bereit (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis:** Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine ähnliche Struktur wie die Quelle besitzen.

Der folgende Python‑Code demonstriert einen Beispielvorgang:

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

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Reihen‑ und Kategorien‑Sammlungen bei. Diese Diskrepanz kann dazu führen, dass [IChart.validate_chart_layout](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/ichart/validate_chart_layout/) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Reihen und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück ins Diagramm schreiben.

```python
# Nach dem Ändern des Arbeitsmappen-Streams (z.B. mit Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Vorhandene Datenverweise löschen.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Das Leeren der Sammlungen stellt sicher, dass die Diagrammdatenstruktur mit der neuen Arbeitsmappe übereinstimmt, sodass `validate_chart_layout` ohne Fehler abgeschlossen werden kann.

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

Manchmal benötigen Sie Diagrammbeschriftungen, die direkt aus Zellen der zugrunde liegenden Daten‑Arbeitsmappe stammen. Aspose.Slides ermöglicht das Binden von Datenbeschriftungen an bestimmte Arbeitsmappen‑Zellen, sodass der Beschriftungstext stets den Zellwert widerspiegelt. Das nachfolgende Beispiel zeigt, wie Sie Werte‑aus‑Zelle‑Beschriftungen aktivieren und ausgewählte Beschriftungen auf benutzerdefinierte Zellen im Diagramm‑Arbeitsmappen‑Bereich verweisen lassen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie nach Index.  
3. Fügen Sie ein Blasendiagramm mit Beispieldaten hinzu.  
4. Greifen Sie auf die Diagramm‑Reihen zu.  
5. Verwenden Sie eine Arbeitsmappen‑Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festgelegt wird:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
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

Der nachfolgende Python‑Code demonstriert, wie die Eigenschaft `worksheets` verwendet wird, um auf die Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Datentyp der Datenquelle angeben**

Der nachfolgende Python‑Code zeigt, wie ein Datentyp‑der‑Datenquelle angegeben wird:

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

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

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

        # Lesen oder ändern Sie hier die Diagramm-Arbeitsmappendaten.
```

## **Externe Arbeitsmappen**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappen festlegen**

Durch die Verwendung der Methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einer Diagrammdatenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch den Pfad zu einer externen Arbeitsmappe aktualisieren, wenn sie verschoben wurde.

Obwohl Sie Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie diese Arbeitsmappen dennoch als externe Datenquellen verwenden. Wenn Sie einen relativen Pfad für eine externe Arbeitsmappe angeben, wird dieser automatisch in einen vollständigen Pfad umgewandelt.

Der folgende Python‑Code zeigt, wie eine externe Arbeitsmappe festgelegt wird:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Übergeben Sie False, damit nur der Pfad gespeichert wird: die Zielarbeitsmappe muss noch nicht existieren.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `update_chart_data` der Methode [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) gibt an, ob die Excel‑Arbeitsmappe geladen wird.

- Wenn `update_chart_data` auf `False` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert; die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Verwenden Sie diese Einstellung, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
- Wenn `update_chart_data` auf `True` (Standard) gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe geladen und aktualisiert. Kann die Arbeitsmappe nicht geöffnet werden, wird eine Ausnahme mit der Meldung „External workbook is not available“ ausgelöst.

### **Externe Arbeitsmappen erstellen**

Durch die Verwendung der Methoden [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe in eine externe umwandeln.

Dieser Python‑Code demonstriert den Vorgang zur Erstellung einer externen Arbeitsmappe:

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

### **Pfad der externen Datenquellen‑Arbeitsmappe für ein Diagramm abrufen**

Manchmal ist die Datenquelle eines Diagramms mit einer externen Excel‑Arbeitsmappe verknüpft, anstatt mit den eingebetteten Präsentationsdaten. Mit Aspose.Slides können Sie die Datenquelle des Diagramms inspizieren und, falls es sich um eine externe Arbeitsmappe handelt, den vollständigen Pfad auslesen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie nach ihrem Index.  
3. Holen Sie sich eine Referenz auf das Diagramm‑Shape.  
4. Ermitteln Sie die Quelle ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatasourcetype/)), die die Diagrammdatenquelle repräsentiert.  
5. Prüfen Sie, ob der Quelltyp dem Typ einer externen Arbeitsmappe entspricht.

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

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm eine externe Arbeitsmappe, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erzeugen Sie [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/), aktivieren Sie anschließend [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/de/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) über [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/spreadsheet_options/), bevor Sie die Präsentation öffnen.

Der folgende Python‑Beispielcode öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart.chart_data](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data/) sowie [ChartData.chart_data_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf die wiederhergestellten Daten zu:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lese oder ändere hier die wiederhergestellten Arbeitsmappendaten.
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Nutzung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache Änderungen, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzugehen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird dieser automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nur wenn Sie die Diagrammdaten bearbeitet haben. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/) und verwendet diesen zum Lesen der Daten, sodass das Öffnen und Speichern einer Präsentation die Arbeitsmappe unverändert lässt. Werte, die Sie jedoch über die Diagrammdaten ändern (siehe **Diagrammdaten bearbeiten** weiter oben), werden beim Speichern der Präsentation zurück in die externe Arbeitsmappe geschrieben – arbeiten Sie mit einer Kopie, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/python-net/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm wirksam.