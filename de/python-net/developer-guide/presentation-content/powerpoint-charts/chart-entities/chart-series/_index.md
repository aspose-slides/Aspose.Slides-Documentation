---
title: Diagrammserie
type: docs
url: /de/python-net/chart-series/
keywords: "Diagrammserie, Serienfarbe, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Diagrammserien in PowerPoint-Präsentationen in Python"
---

Eine Serie ist eine Reihe oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserienüberlappung festlegen**

Mit der [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/) Eigenschaft können Sie festlegen, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: dies ist eine Projektion der entsprechenden Gruppen-Eigenschaft. Daher ist diese Eigenschaft schreibgeschützt.

Verwenden Sie die `parent_series_group.overlap` Lese-/Schreib-Eigenschaft, um Ihren bevorzugten Wert für `overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Fügen Sie ein gruppiertes Säulendiagramm auf einer Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu.
1. Greifen Sie auf die `parent_series_group` der Diagrammserie zu und legen Sie Ihren bevorzugten Überlappungswert für die Serie fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammserie festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Fügt ein Diagramm hinzu
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # Setzt die Überlappung der Serie
        series[0].parent_series_group.overlap = -30

    # Speichert die Präsentationsdatei auf der Festplatte
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Serienfarbe ändern**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Farbe einer Serie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.
1. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
1. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie die Farbe einer Serie ändern:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[1]
    
    point.explosion = 30
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Farbe der Serienkategorie ändern**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Farbe einer Serienkategorie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.
1. Legen Sie Ihren bevorzugten Fülltyp und die Füllfarbe fest.
1. Speichern Sie die modifizierte Präsentation.

Dieser Code in Python zeigt Ihnen, wie Sie die Farbe einer Serienkategorie ändern:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    point = chart.chart_data.series[0].data_points[0]
    
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Serienname ändern** 

Standardmäßig sind die Legendenbezeichnungen für ein Diagramm die Inhalte der Zellen über jeder Spalte oder Zeile von Daten. 

In unserem Beispiel (Beispielbild), 

* die Spalten sind *Serie 1, Serie 2,* und *Serie 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.* 

Aspose.Slides für Python über .NET ermöglicht es Ihnen, einen Seriennamen in den Diagrammdaten und der Legende zu aktualisieren oder zu ändern. 

Dieser Python-Code zeigt Ihnen, wie Sie den Namen einer Serie in den Diagrammdaten `ChartDataWorkbook` ändern:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "Neuer Name"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

Dieser Python-Code zeigt Ihnen, wie Sie den Namen einer Serie in der Legende über `Series` ändern:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "Neuer Name"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **Füllfarbe der Diagrammserie festlegen**

Aspose.Slides für Python über .NET ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standardeinstellungen basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.CLUSTERED_COLUMN` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatisch.
1. Speichern Sie die Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Erstellt ein gruppiertes Säulendiagramm
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # Setzt das Füllformat der Serie auf automatisch
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # Speichert die Präsentationsdatei auf der Festplatte
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Füllfarben der Diagrammserien invertieren**
Aspose.Slides ermöglicht es Ihnen, die invertierte Füllfarbe für Diagrammserien innerhalb eines Diagrammbereichs wie folgt festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
1. Erhalten Sie eine Referenz auf eine Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standardeinstellungen basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel haben wir `ChartType.CLUSTERED_COLUMN` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invertiert.
1. Speichern Sie die Präsentation in eine PPTX-Datei.

Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Fügt neue Serien und Kategorien hinzu
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Kategorie 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Kategorie 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Kategorie 3"))

    # Nimmt die erste Diagrammserie und füllt deren Seriendaten.
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Serie umkehren, wenn der Wert negativ ist**
Aspose.Slides ermöglicht es Ihnen, Umkehrungen über die `ChartDataPoint.invert_if_negative` Eigenschaften festzulegen. Wenn eine Umkehrung mit den Eigenschaften festgelegt wird, invertiert der Datenpunkt seine Farben, wenn er einen negativen Wert erhält.

Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    chart.chart_data.series.clear()

    series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
    series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

    series[0].invert_if_negative = False

    series[0].data_points[2].invert_if_negative = True

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Spezifische Datenpunkte löschen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die `data_points` Daten für eine spezifische Diagrammserie wie folgt zu löschen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Erhalten Sie die Referenz einer Folie über ihren Index.
3. Erhalten Sie die Referenz eines Diagramms über seinen Index.
4. Iterieren Sie durch alle Diagramm `data_points` und setzen Sie `x_value` und `y_value` auf null.
5. Löschen Sie alle `data_points` für spezifische Diagrammserien.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code demonstriert die Operation:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **Intervallbreite für Serien setzen**
Aspose.Slides für Python über .NET ermöglicht es Ihnen, die Intervallbreite einer Serie über die **`gap_width`** Eigenschaft wie folgt festzulegen:

1. Erstellen Sie eine Instanz der `Presentation` Klasse.
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie ein Diagramm mit Standardeinstellungen hinzu.
4. Greifen Sie auf eine beliebige Diagrammserie zu.
5. Setzen Sie die `gap_width` Eigenschaft.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Intervallbreite einer Serie festlegen:

```py
# Erstellt eine leere Präsentation 
with slides.Presentation() as presentation:

    # Greift auf die erste Folie der Präsentation zu
    slide = presentation.slides[0]

    # Fügt ein Diagramm mit Standardeinstellungen hinzu
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # Setzt den Index des Diagrammdatenblatts
    defaultWorksheetIndex = 0

    # Erhält das Diagrammdatenblatt
    fact = chart.chart_data.chart_data_workbook

    # Fügt Serien hinzu
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Fügt Kategorien hinzu
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Kategorie 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Kategorie 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Kategorie 3"))

    # Nimmt die zweite Diagrammserie
    series = chart.chart_data.series[1]

    # Füllt die Seriendaten aus
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Setzt den GapWidth-Wert
    series.parent_series_group.gap_width = 50

    # Speichert die Präsentation auf der Festplatte
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```