---
title: Diagrammdatenserien in Python verwalten
linktitle: Datenserien
type: docs
url: /de/python-net/chart-series/
keywords:
- Diagrammserien
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenserien in Python für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

## **Übersicht**

Dieser Artikel beschreibt die Rolle von [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) in Aspose.Slides für Python und konzentriert sich darauf, wie Daten in Präsentationen strukturiert und visualisiert werden. Diese Objekte bilden die Grundelemente, die einzelne Datensätze, Kategorien und Darstellungseigenschaften in einem Diagramm definieren. Durch die Arbeit mit [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) können Entwickler Datenquellen nahtlos integrieren und die Anzeige von Informationen vollständig steuern, was zu dynamischen, datengetriebenen Präsentationen führt, die Erkenntnisse und Analysen klar vermitteln.

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Serieüberlappung festlegen**

Die [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/)‑Eigenschaft steuert, wie Balken und Säulen in einem 2D‑Diagramm überlappen, indem ein Wertebereich von –100 bis 100 angegeben wird. Da diese Eigenschaft der Seriengruppe und nicht einzelnen Diagrammserien zugeordnet ist, ist sie auf Serienebene schreibgeschützt. Um Überlappungswerte zu konfigurieren, verwenden Sie die Lese‑/Schreib‑Eigenschaft `parent_series_group.overlap`, die die angegebene Überlappung auf alle Serien in dieser Gruppe anwendet.

Unten steht ein Python‑Beispiel, das zeigt, wie man eine Präsentation erstellt, ein gruppiertes Säulendiagramm hinzufügt, die erste Diagrammserie abruft, die Überlappung einstellt und das Ergebnis als PPTX‑Datei speichert:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Legen Sie die Serienüberlappung fest.
        series.parent_series_group.overlap = series_overlap

    # Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The series overlap](series_overlap.png)

## **Füllfarbe einer Serie ändern**

Aspose.Slides macht es einfach, die Füllfarben von Diagrammserien anzupassen, sodass Sie bestimmte Datenpunkte hervorheben und visuell ansprechende Diagramme erstellen können. Dies wird über das [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/)‑Objekt erreicht, das verschiedene Fülltypen, Farbkonfigurationen und weitere erweiterte Stiloptionen unterstützt. Nachdem Sie ein Diagramm zu einer Folie hinzugefügt und die gewünschte Serie abgerufen haben, erhalten Sie die Serie und wenden die entsprechende Füllfarbe an. Neben einfarbigen Füllungen können Sie auch Farbverläufe oder Musterfüllungen für mehr Gestaltungs‑Flexibilität nutzen. Sobald Sie die Farben nach Ihren Anforderungen festgelegt haben, speichern Sie die Präsentation, um das aktualisierte Aussehen zu finalisieren.

Das folgende Python‑Code‑Beispiel zeigt, wie die Farbe der ersten Serie geändert wird:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Setzen Sie die Farbe der ersten Serie.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The color of the series](series_color.png)

## **Serie umbenennen**

Aspose.Slides bietet eine einfache Möglichkeit, die Namen von Diagrammserien zu ändern, sodass Daten klar und aussagekräftig beschriftet werden können. Durch den Zugriff auf die entsprechende Tabellenblattzelle in den Diagrammdaten können Entwickler anpassen, wie die Daten präsentiert werden. Diese Änderung ist besonders nützlich, wenn Seriennamen basierend auf dem Kontext der Daten aktualisiert oder präzisiert werden müssen. Nach dem Umbenennen der Serie kann die Präsentation gespeichert werden, um die Änderungen zu übernehmen.

Unten finden Sie einen Python‑Code‑Abschnitt, der diesen Vorgang demonstriert.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Setzen Sie den Namen der ersten Serie.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


Der folgende Python‑Code zeigt eine alternative Methode, den Seriennamen zu ändern:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Setzen Sie den Namen der ersten Serie.
    series.name.as_cells[0].value = series_name

    # Speichern Sie die Präsentationsdatei auf der Festplatte.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Das Ergebnis:

![The series name](series_name.png)

## **Automatische Füllfarbe einer Serie abrufen**

Aspose.Slides für Python ermöglicht das Abrufen der automatischen Füllfarbe von Diagrammserien innerhalb eines Plot‑Bereichs. Nachdem Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse erstellt haben, können Sie über den Index auf die gewünschte Folie zugreifen und ein Diagramm mit dem gewünschten Typ hinzufügen (z. B. `ChartType.CLUSTERED_COLUMN`). Durch den Zugriff auf die Serien im Diagramm erhalten Sie die automatische Füllfarbe.

Der nachstehende Python‑Code demonstriert diesen Vorgang im Detail.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Fügen Sie ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Die Füllfarbe der Serie abrufen.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


Beispielausgabe:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Invertierte Füllfarben für eine Serie festlegen**

Enthält Ihre Datenserie sowohl positive als auch negative Werte, kann die einheitliche Färbung von Säulen oder Balken das Diagramm schwer lesbar machen. Aspose.Slides für Python ermöglicht das Zuweisen einer invertierten Füllfarbe – eine separate Füllung, die automatisch auf Datenpunkte unterhalb der Null angewendet wird – so dass negative Werte sofort auffallen. In diesem Abschnitt erfahren Sie, wie Sie diese Option aktivieren, eine passende Farbe auswählen und die aktualisierte Präsentation speichern.

Das folgende Code‑Beispiel demonstriert die Vorgehensweise:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Neue Kategorien hinzufügen.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Eine neue Serie hinzufügen.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Seriendaten befüllen.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Farbeinstellungen für die Serie festlegen.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The inverted solid fill color](inverted_solid_fill_color.png)

Sie können die invertierte Füllfarbe auch für einen einzelnen Datenpunkt statt für die gesamte Serie festlegen. Greifen Sie einfach auf das gewünschte `ChartDataPoint` zu und setzen Sie dessen `invert_if_negative`‑Eigenschaft auf `True`.

Das folgende Code‑Beispiel zeigt, wie das geht:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **Daten für bestimmte Datenpunkte löschen**

Manchmal enthält ein Diagramm Testwerte, Ausreißer oder veraltete Einträge, die Sie entfernen möchten, ohne die gesamte Serie neu aufzubauen. Aspose.Slides für Python lässt Sie jeden Datenpunkt über dessen Index anvisieren, dessen Inhalte löschen und das Plot‑Diagramm sofort aktualisieren, sodass die übrigen Punkte verschoben werden und die Achsen automatisch neu skaliert werden.

Das folgende Code‑Beispiel demonstriert die Vorgehensweise:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Lückenbreite der Serie festlegen**

Die Lückenbreite steuert den Abstand zwischen benachbarten Säulen oder Balken – größere Lücken betonen einzelne Kategorien, während engere Lücken ein kompakteres Erscheinungsbild erzeugen. Mit Aspose.Slides für Python können Sie diesen Parameter für eine gesamte Serie feinjustieren und so genau das visuelle Gleichgewicht erreichen, das Ihre Präsentation erfordert, ohne die zugrunde liegenden Daten zu verändern.

Das folgende Code‑Beispiel zeigt, wie die Lückenbreite für eine Serie gesetzt wird:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Leere Präsentation erstellen.
with slides.Presentation() as presentation:

    # Auf die erste Folie zugreifen.
    slide = presentation.slides[0]

    # Diagramm mit Standarddaten hinzufügen.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Präsentation auf Festplatte speichern.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # gap_width-Wert festlegen.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Präsentation auf Festplatte speichern.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![The gap width](gap_width.png)

## **FAQ**

**Gibt es ein Limit, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides legt keine feste Obergrenze für die Anzahl der hinzugefügten Serien fest. Die praktische Grenze wird durch die Lesbarkeit des Diagramms und den verfügbaren Arbeitsspeicher Ihrer Anwendung bestimmt.

**Was tun, wenn die Säulen innerhalb eines Clusters zu dicht beieinander oder zu weit auseinander liegen?**

Passen Sie die [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/)‑Einstellung für diese Serie (oder deren übergeordnete Seriengruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Säulen, ein niedrigerer Wert bringt sie näher zusammen.