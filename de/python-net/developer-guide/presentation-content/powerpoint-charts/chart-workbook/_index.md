---
title: Diagramm-Arbeitsmappen in Präsentationen mit Python verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/python-net/chart-workbook/
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
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Python über .NET: Verwalten Sie mühelos Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie Diagrammdaten über Arbeitsmappen‑Streams gelesen und geschrieben werden, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet werden, auf Arbeitsblatt‑Sammlungen zugegriffen wird und der Datentyp für Diagrammwerte angegeben wird.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen. Die Beispiele demonstrieren, wie eine externe Arbeitsmappe erstellt und zugewiesen wird, wie der Pfad einer an ein Diagramm gebundenen externen Arbeitsmappe ermittelt wird und wie Diagrammdaten bearbeitet werden, wenn die Arbeitsmappe verfügbar ist.

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides stellt Methoden zum Lesen und Schreiben von Diagramm‑Datenarbeitsmappen bereit (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis:** Die Diagrammdaten müssen auf dieselbe Weise organisiert sein oder eine dem Quellformat ähnliche Struktur aufweisen.

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

## **Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festlegen**

Manchmal benötigen Sie Diagrammbeschriftungen, die direkt aus Zellen der zugrunde liegenden Datenarbeitsmappe stammen. Aspose.Slides ermöglicht das Binden von Datenbeschriftungen an bestimmte Arbeitsmappen‑Zellen, sodass der Beschriftungstext stets den Zellenwert widerspiegelt. Das nachfolgende Beispiel zeigt, wie Wert‑aus‑Zelle‑Beschriftungen aktiviert werden und ausgewählte Beschriftungen auf benutzerdefinierte Zellen in der Arbeitsmappe des Diagramms verweisen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.
1. Holen Sie eine Referenz auf die Folie anhand ihres Index.
1. Fügen Sie ein Blasendiagramm mit Beispieldaten hinzu.
1. Greifen Sie auf die Diagrammserie zu.
1. Verwenden Sie eine Arbeitsmappen‑Zelle als Datenbeschriftung.
1. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie eine Arbeitsmappen‑Zelle als Diagramm‑Datenbeschriftung festgelegt wird:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
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

Der folgende Python‑Code demonstriert, wie die `worksheets`‑Eigenschaft verwendet wird, um auf die Arbeitsblatt‑Sammlung zuzugreifen:

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

## **Nicht unterstützte eingebettete Arbeitsmappen‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die `embedded_workbook_type`‑Eigenschaft auf [ChartData](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/) zusammen mit der [WorkbookType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/workbooktype/)‑Aufzählung verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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

Durch die Verwendung der [ChartData.set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑Methode können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann zudem den Pfad zu einer externen Arbeitsmappe aktualisieren, wenn diese verschoben wurde.

Obwohl Sie Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie diese Arbeitsmappen weiterhin als externe Datenquellen verwenden. Wenn Sie einen relativen Pfad für eine externe Arbeitsmappe angeben, wird dieser automatisch in einen vollständigen Pfad umgewandelt.

Der folgende Python‑Code zeigt, wie eine externe Arbeitsmappe festgelegt wird:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `update_chart_data` der [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑Methode gibt an, ob die Excel‑Arbeitsmappe geladen wird.

- Wenn `update_chart_data` auf `False` gesetzt ist, wird nur der Arbeitsmappen‑Pfad aktualisiert; die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Verwenden Sie diese Einstellung, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.
- Wenn `update_chart_data` auf `True` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe geladen und aktualisiert.

### **Externe Arbeitsmappen erstellen**

Durch die Verwendung der [read_workbook_stream](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)‑ und [set_external_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑Methoden können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe in eine externe umwandeln.

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

### **Pfad der externen Datenquellen‑Arbeitsmappe für ein Diagramm ermitteln**

Manchmal ist die Datenquelle eines Diagramms mit einer externen Excel‑Arbeitsmappe verknüpft, anstatt die eingebetteten Daten der Präsentation zu verwenden. Mit Aspose.Slides können Sie die Datenquelle des Diagramms prüfen und, falls es sich um eine externe Arbeitsmappe handelt, den vollständigen Pfad auslesen.

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/de/python-net/api-reference/aspose.slides/presentation/)‑Klasse.
1. Holen Sie eine Referenz auf die Folie anhand ihres Index.
1. Holen Sie eine Referenz auf das Diagramm‑Shape.
1. Ermitteln Sie die Quelle ([ChartDataSourceType](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdatasourcetype/)), die die Datenquelle des Diagramms darstellt.
1. Prüfen Sie, ob der Quelltyp dem Typ einer externen Arbeitsmappe entspricht.

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

Sie können Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten wie in internen Arbeitsmappen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erstellen Sie ein [LoadOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/)-Objekt und aktivieren Sie [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/de/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) über [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/spreadsheet_options/), bevor Sie die Präsentation öffnen.

Das folgende Python‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [Chart.chart_data](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/chart_data/) und [ChartData.chart_data_workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) auf die wiederhergestellten Daten zu:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Lesen oder ändern Sie hier die wiederhergestellten Arbeitsmappendaten.
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der im Cache gespeicherten Diagrammdaten als akzeptabler Fallback zulässig ist, da der Cache möglicherweise Änderungen enthält, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/) und einen [path to an external workbook](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad lesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portierbarkeit von Projekten; jedoch speichert die Präsentation den absoluten Pfad in der PPTX‑Datei.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle genutzt werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/) und verwendet ihn zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/python-net/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Zeigen sie alle auf dieselbe Datei, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm reflektiert.