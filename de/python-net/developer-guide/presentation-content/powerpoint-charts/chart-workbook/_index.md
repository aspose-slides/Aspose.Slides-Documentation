---
title: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /python-net/chart-workbook/
keywords: "Diagramm-Arbeitsmappe, Diagrammdaten, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Diagramm-Arbeitsmappe in PowerPoint-Präsentation in Python"
---

## **Diagrammdaten aus der Arbeitsmappe festlegen**

Aspose.Slides bietet einige Methoden, mit denen Sie Diagrammdaten-Arbeitsmappen lesen und schreiben können (die Diagrammdaten, die mit Aspose.Cells bearbeitet wurden). **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieser Python-Code demonstriert eine Beispieloperation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine Präsentationsdatei darstellt
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series

    series[0].labels.default_data_label_format.show_label_value_from_cell = True

    wb = chart.chart_data.chart_data_workbook

    series[0].labels[0].value_from_cell = wb.get_cell(0, "A10", "Wert der Zelle Bezeichnung 0")
    series[0].labels[1].value_from_cell = wb.get_cell(0, "A11", "Wert der Zelle Bezeichnung 1")
    series[0].labels[2].value_from_cell = wb.get_cell(0, "A12", "Wert der Zelle Bezeichnung 2")

    pres.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Arbeitsmappe-Zelle als Diagramm-Datenbezeichnung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
1. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.
1. Greifen Sie auf die Diagrammserie zu.
1. Setzen Sie die Arbeitsmappen-Zelle als Datenbezeichnung.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Arbeitsmappen-Zelle als Diagramm-Datenbezeichnung festlegen: xxx

```python

```

## **Arbeitsblätter verwalten**

Dieser Python-Code demonstriert eine Operation, bei der die `worksheets`-Eigenschaft verwendet wird, um auf eine Arbeitsblattkollektion zuzugreifen:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
   chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
   wb =  chart.chart_data.chart_data_workbook
   for i in range(len(wb.worksheets)):
      print(wb.worksheets[i].name)
```

## **Datentyp der Quelle angeben**

Dieser Python-Code zeigt Ihnen, wie Sie einen Typ für eine Datenquelle angeben:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    val = chart.chart_data.series[0].name

    val.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    val.data = "LiteralString"

    val = chart.chart_data.series[0].name
    val.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NeueZelle")

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Externe Arbeitsmappe**

{{% alert color="primary" %}} 
In [Aspose.Slides für .NET 19.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-19-4-release-notes/) haben wir die Unterstützung für externe Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Externe Arbeitsmappe erstellen**

Mit einigen Methoden von **`IChartData`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser Python-Code demonstriert den Prozess der Erstellung einer externen Arbeitsmappe:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 500, 400)
    chart.chart_data.chart_data_workbook.clear(0)

    chart.chart_data.set_external_workbook(path + "externalWorkbook.xlsx")

    chart.chart_data.set_range("Sheet1!$A$2:$B$5")
    series = chart.chart_data.series[0]
    series.parent_series_group.is_color_varied = True
    pres.save("response2.pptx", slides.export.SaveFormat.PPTX)
```

### **Externe Arbeitsmappe festlegen**

Mit der **`chartData.set_external_workbook`**-Methode können Sie eine externe Arbeitsmappe als Datenquelle für einDiagramm zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die anremote Standorten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wenn der relative Pfad für eine externe Arbeitsmappe angegeben wird, wird er automatisch in einen Vollpfad umgewandelt.

Dieser Python-Code zeigt Ihnen, wie Sie eine externe Arbeitsmappe festlegen:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

# Der Pfad zum Dokumentenverzeichnis.
with slides.Presentation() as pres:

    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data
                    
    chartData.set_external_workbook(path + "externalWorkbook.xlsx")
                  

    chartData.series.add(chartData.chart_data_workbook.get_cell(0, "B1"), charts.ChartType.PIE)
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B2"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B3"))
    chartData.series[0].data_points.add_data_point_for_pie_series(chartData.chart_data_workbook.get_cell(0, "B4"))

    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A2"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A3"))
    chartData.categories.add(chartData.chart_data_workbook.get_cell(0, "A4"))
    pres.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Der Parameter `chart_data` (unter der Methode `set_external_workbook`) wird verwendet, um anzugeben, ob eine Excel-Arbeitsmappe geladen wird oder nicht. 

* Wenn der Wert `chart_data` auf `false` festgelegt ist, wird nur der Arbeitsmappenpfad aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung möchten Sie möglicherweise verwenden, wenn die Zielarbeitsmappe nicht vorhanden oder nicht verfügbar ist. 
* Wenn der Wert `chart_data` auf `true` festgelegt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chartData = chart.chart_data

    chartData.set_external_workbook("http://path/doesnt/exists", False)

    pres.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Pfad zur externen Datenquelle des Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) Klasse.
1. Holen Sie sich eine Referenz auf eine Folie durch ihren Index.
1. Erstellen Sie ein Objekt für die Diagrammform.
1. Erstellen Sie ein Objekt für den Quelle (`ChartDataSourceType`)-Typ, der die Datenquelle des Diagramms darstellt.
1. Geben Sie die relevante Bedingung an, basierend darauf, dass der Quellentyp mit dem Typ der externen Arbeitsmappe übereinstimmt.

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("response2.pptx") as pres:
    chart = pres.slides[0].shapes[0]
    sourceType = chart.chart_data.data_source_type
    if sourceType == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf die gleiche Weise bearbeiten, wie Sie Änderungen an den Inhalten interner Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser Python-Code ist eine Umsetzung des beschriebenen Prozesses:

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "presentation.pptx") as pres:
    pres.slides[0].shapes[0].chart_data.series[0].data_points[0].value.as_cell.value = 100
    pres.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
```