---
title: Diagramm-Workbook in Präsentationen mit Python verwalten
linktitle: Diagramm-Workbook
type: docs
weight: 70
url: /de/python-net/chart-workbook/
keywords:
- Diagramm-Workbook
- Diagrammdaten
- Workbook-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externes Workbook
- externe Daten
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python über .NET: Verwalten Sie Diagramm-Workbooks in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagramm‑Datenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt zudem die Arbeit mit externen Workbooks als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides stellt Methoden zum Lesen und Schreiben von Diagramm‑Data‑Workbooks bereit (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis:** Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine Struktur haben, die der Quelle ähnlich ist.

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

## **Eine Workbook‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Manchmal benötigt man Diagrammbeschriftungen, die direkt aus Zellen des zugrunde liegenden Daten‑Workbooks stammen. Aspose.Slides ermöglicht es, Datenbeschriftungen an bestimmte Workbook‑Zellen zu binden, sodass der Beschriftungstext stets den Wert der Zelle widerspiegelt. Das nachstehende Beispiel zeigt, wie man Werte‑aus‑Zelle‑Beschriftungen aktiviert und ausgewählte Beschriftungen auf benutzerdefinierte Zellen im Workbook des Diagramms verweist.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie anhand des Indexes.
1. Fügen Sie ein Blasendiagramm mit Beispieldaten hinzu.
1. Greifen Sie auf die Diagramm‑Serien zu.
1. Verwenden Sie eine Workbook‑Zelle als Datenbeschriftung.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie man eine Workbook‑Zelle als Diagramm‑Datenbeschriftung festlegt:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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

Der folgende Python‑Code demonstriert, wie man die Eigenschaft `worksheets` verwendet, um auf die Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Datentyp der Datenquelle festlegen**

Der folgende Python‑Code zeigt, wie man einen Datentyp der Datenquelle festlegt:

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

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb), das in einigen Diagrammen eingebettet sein kann, nicht. Sie können die Eigenschaft `embedded_workbook_type` auf [ChartData](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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
            # Eingebettetes Workbook ist im .xlsb-Format, das nicht unterstützt wird.
            continue

        # Hier die Chart-Workbook-Daten lesen oder ändern.
```

## **Externe Workbooks**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Externe Workbooks festlegen**

Durch die Verwendung der Methode [ChartData.set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch den Pfad zu einem externen Workbook aktualisieren, wenn es verschoben wurde.

Obwohl Sie Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie diese Workbooks dennoch als externe Datenquellen verwenden. Wenn Sie einen relativen Pfad für ein externes Workbook angeben, wird dieser automatisch in einen vollständigen Pfad konvertiert.

Der folgende Python‑Code zeigt, wie man ein externes Workbook festlegt:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`update_chart_data`‑Parameter der Methode [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) gibt an, ob das Excel‑Workbook geladen wird.

- Wenn `update_chart_data` auf `False` gesetzt ist, wird nur der Workbook‑Pfad aktualisiert; die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert. Verwenden Sie diese Einstellung, wenn das Ziel‑Workbook nicht existiert oder nicht verfügbar ist.
- Wenn `update_chart_data` auf `True` gesetzt ist, werden die Diagrammdaten aus dem Ziel‑Workbook geladen und aktualisiert.

### **Externe Workbooks erstellen**

Durch die Verwendung der Methoden [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) und [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/) können Sie entweder ein externes Workbook von Grund auf neu erstellen oder ein internes Workbook in ein externes umwandeln.

Dieser Python‑Code demonstriert den Prozess der Erstellung externer Workbooks:

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

### **Den Pfad des externen Datenquellen‑Workbooks für ein Diagramm abrufen**

Manchmal sind die Daten eines Diagramms mit einem externen Excel‑Workbook verknüpft, anstatt mit den eingebetteten Daten der Präsentation. Mit Aspose.Slides können Sie die Datenquelle des Diagramms untersuchen und, falls es sich um ein externes Workbook handelt, den vollständigen Workbook‑Pfad auslesen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/).
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Indexes.
1. Holen Sie sich eine Referenz auf die Diagramm‑Form.
1. Ermitteln Sie die Quelle ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatasourcetype/)), die die Datenquelle des Diagramms darstellt.
1. Prüfen Sie, ob der Quelltyp mit dem Datentyp der externen Workbook‑Datenquelle übereinstimmt.

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

Sie können Daten in externen Workbooks auf die gleiche Weise bearbeiten wie in internen Workbooks. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm hat einen [data source type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/); wenn die Quelle ein externes Workbook ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Projektportabilität; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Workbooks, die sich auf Netzwerkressourcen/Freigaben befinden, verwenden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Workbooks über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/) und verwendet ihn zum Einlesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht geändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/python-net/)) und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm sichtbar.