---
title: Diagramm‑Arbeitsmappen in Präsentationen mit Python verwalten
linktitle: Diagramm‑Arbeitsmappe
type: docs
weight: 70
url: /de/python-net/chart-workbook/
keywords:
- Diagramm‑Arbeitsmappe
- Diagrammdaten
- Arbeitsmappenzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python via .NET: verwalten Sie Diagramm‑Arbeitsmappen in PowerPoint‑ und OpenDocument‑Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---

## **Diagrammdaten aus einer Arbeitsmappe festlegen**

Aspose.Slides stellt Methoden zum Lesen und Schreiben von Diagramm‑Daten‑Arbeitsmappen bereit (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis:** Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine dem Quellformat ähnliche Struktur aufweisen.

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

## **Eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Manchmal benötigen Sie Diagrammbeschriftungen, die direkt aus Zellen der zugrunde liegenden Datenarbeitsmappe stammen. Aspose.Slides ermöglicht das Binden von Datenbeschriftungen an bestimmte Arbeitsmappen‑Zellen, sodass der Beschriftungstext stets den Zellwert widerspiegelt. Das folgende Beispiel zeigt, wie Sie Wert‑aus‑Zelle‑Beschriftungen aktivieren und ausgewählte Beschriftungen auf benutzerdefinierte Zellen in der Arbeitsmappe des Diagramms verweisen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie anhand des Indexes.  
3. Fügen Sie ein Blasendiagramm mit Beispieldaten hinzu.  
4. Greifen Sie auf die Diagramm‑Serie zu.  
5. Verwenden Sie eine Arbeitsmappen‑Zelle als Datenbeschriftung.  
6. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanziieren der Presentation‑Klasse, die eine Präsentationsdatei darstellt.
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

Der folgende Python‑Code demonstriert, wie Sie die `worksheets`‑Eigenschaft nutzen, um auf die Sammlung von Arbeitsblättern zuzugreifen:

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

## **Den Datentyp der Datenquelle festlegen**

Der folgende Python‑Code zeigt, wie Sie einen Datentyp der Datenquelle angeben:

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

## **Externe Arbeitsmappen**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappen festlegen**

Durch die Verwendung der Methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann zudem den Pfad zu einer externen Arbeitsmappe aktualisieren, falls diese verschoben wurde.

Obwohl Sie Daten in Arbeitsmappen, die an entfernten Speicherorten liegen, nicht editieren können, lassen sich diese dennoch als externe Datenquellen nutzen. Wird ein relativer Pfad zu einer externen Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Der folgende Python‑Code zeigt, wie Sie eine externe Arbeitsmappe festlegen:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `update_chart_data` der Methode [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) gibt an, ob die Excel‑Arbeitsmappe geladen wird.

- Ist `update_chart_data` auf `False` gesetzt, wird nur der Pfad zur Arbeitsmappe aktualisiert; die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Verwenden Sie diese Einstellung, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
- Ist `update_chart_data` auf `True` gesetzt, werden die Diagrammdaten aus der Zielarbeitsmappe geladen und aktualisiert.

### **Externe Arbeitsmappen erstellen**

Durch die Methoden [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe in eine externe konvertieren.

Dieser Python‑Code demonstriert den Prozess der Erstellung einer externen Arbeitsmappe:

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

### **Den Pfad der externen Datenquellen‑Arbeitsmappe für ein Diagramm ermitteln**

Manchmal ist die Datenquelle eines Diagramms mit einer externen Excel‑Arbeitsmappe verknüpft, nicht mit den im Dokument eingebetteten Daten. Mit Aspose.Slides können Sie die Datenquelle des Diagramms prüfen und, falls es sich um eine externe Arbeitsmappe handelt, den vollständigen Pfad auslesen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie mittels Index.  
3. Holen Sie sich einen Verweis auf das Diagramm‑Shape.  
4. Ermitteln Sie die Quelle ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)), die die Datenquelle des Diagramms repräsentiert.  
5. Prüfen Sie, ob der Quelltyp dem Typ einer externen Arbeitsmappe entspricht.

Der folgende Python‑Code demonstriert die Vorgehensweise:

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

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm besitzt einen [Datenquellen‑Typ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) sowie einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ist die Quelle eine externe Arbeitsmappe, kann der vollständige Pfad ausgelesen werden, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wird ein relativer Pfad angegeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portabilität von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die auf Netzwerkressourcen/Freigaben liegen?**

Ja, solche Arbeitsmappen können als externe Datenquelle dienen. Das direkte Editieren von Remote‑Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Nein. Die Präsentation speichert nur einen [Link zur externen Datei](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) und nutzt ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verlinken kein Passwort. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/python-net/)) vorzubereiten und darauf zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.