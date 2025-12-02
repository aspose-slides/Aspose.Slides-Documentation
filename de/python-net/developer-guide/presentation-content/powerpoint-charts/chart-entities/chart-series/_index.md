---
title: Diagrammdatenreihen in Python verwalten
linktitle: Datenreihen
type: docs
url: /de/python-net/chart-series/
keywords:
- Diagrammreihen
- Reihenüberlappung
- Reihenfarbe
- Kategoriefarbe
- Reihenname
- Datenpunkt
- Reihenlücke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenreihen in Python für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

## **Übersicht**

Dieser Artikel beschreibt die Rolle von ChartSeries in Aspose.Slides für Python und konzentriert sich darauf, wie Daten innerhalb von Präsentationen strukturiert und visualisiert werden. Diese Objekte stellen die grundlegenden Elemente bereit, die einzelne Sätze von Datenpunkten, Kategorien und Anzeigeparametern in einem Diagramm definieren. Durch die Arbeit mit ChartSeries können Entwickler Datenquellen nahtlos integrieren und die vollständige Kontrolle darüber behalten, wie Informationen angezeigt werden, was zu dynamischen, datengetriebenen Präsentationen führt, die Erkenntnisse und Analysen klar vermitteln.

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![Diagramm-Serie-PowerPoint](chart-series-powerpoint.png)

## **Serienüberlappung festlegen**

The ChartSeries.overlap property steuert, wie Balken und Säulen in einem 2D‑Diagramm überlappen, indem ein Wertebereich von -100 bis 100 angegeben wird. Da diese Eigenschaft der Seriengruppe und nicht einzelnen Diagrammserien zugeordnet ist, ist sie auf Serienebene schreibgeschützt. Um Überlappungswerte zu konfigurieren, verwenden Sie die les‑/schreibbare Eigenschaft parent_series_group.overlap, die die angegebene Überlappung auf alle Serien dieser Gruppe anwendet.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Setze die Serienüberlappung.
        series.parent_series_group.overlap = series_overlap

    # Speichere die Präsentationsdatei auf dem Datenträger.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die Serienüberlappung](series_overlap.png)

## **Serienfüllfarbe ändern**

Aspose.Slides ermöglicht es, die Füllfarben von Diagrammserien einfach anzupassen, sodass Sie bestimmte Datenpunkte hervorheben und optisch ansprechende Diagramme erstellen können. Dies wird über das Format‑Objekt realisiert, das verschiedene Fülltypen, Farbkombinationen und weitere erweiterte Stiloptionen unterstützt. Nachdem Sie ein Diagramm zu einer Folie hinzugefügt und die gewünschte Serie abgerufen haben, wenden Sie einfach die passende Füllfarbe an. Neben Vollfarben können Sie auch Verlauf‑ oder Musterfüllungen für mehr Gestaltungsspielraum nutzen. Sobald Sie die Farben nach Ihren Anforderungen festgelegt haben, speichern Sie die Präsentation, um das aktualisierte Aussehen zu finalisieren.

Das folgende Python‑Codebeispiel zeigt, wie die Farbe der ersten Serie geändert wird:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Setze die Farbe der ersten Serie.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Speichere die Präsentationsdatei auf dem Datenträger.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die Farbe der Serie](series_color.png)

## **Serie umbenennen**

Aspose.Slides bietet eine einfache Möglichkeit, die Namen von Diagrammserien zu ändern, sodass Daten klar und sinnvoll beschriftet werden können. Durch den Zugriff auf die entsprechende Arbeitsblattzelle in den Diagrammdaten können Entwickler die Darstellung der Daten anpassen. Diese Änderung ist besonders nützlich, wenn Seriennamen basierend auf dem Kontext der Daten aktualisiert oder präzisiert werden müssen. Nach dem Umbenennen der Serie kann die Präsentation gespeichert werden, um die Änderungen zu übernehmen.

Unten steht ein Python‑Code‑Snippet, das diesen Prozess in Aktion demonstriert.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Setze den Namen der ersten Serie.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Speichere die Präsentationsdatei auf dem Datenträger.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


Der folgende Python‑Code zeigt eine alternative Möglichkeit, den Seriennamen zu ändern:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Setze den Namen der ersten Serie.
    series.name.as_cells[0].value = series_name

    # Speichere die Präsentationsdatei auf dem Datenträger.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Das Ergebnis:

![Der Serienname](series_name.png)

## **Automatische Serienfüllfarbe abrufen**

Aspose.Slides für Python ermöglicht das Abrufen der automatischen Füllfarbe für Diagrammserien innerhalb eines Zeichenbereichs. Nachdem Sie eine Instanz der Klasse Presentation erstellt haben, können Sie über den Index auf die gewünschte Folie zugreifen und anschließend ein Diagramm Ihres bevorzugten Typs hinzufügen (z. B. ChartType.CLUSTERED_COLUMN). Durch den Zugriff auf die Serien im Diagramm können Sie die automatische Füllfarbe erhalten.

Der unten stehende Python‑Code demonstriert diesen Vorgang im Detail.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Füge ein gruppiertes Säulendiagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Hole die Füllfarbe der Serie.
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

Wenn Ihre Datenserie sowohl positive als auch negative Werte enthält, kann das einheitliche Färben jeder Säule oder jedes Balkens das Diagramm schwer lesbar machen. Aspose.Slides für Python ermöglicht das Zuweisen einer invertierten Füllfarbe – einer separaten Füllung, die automatisch auf Datenpunkte unter Null angewendet wird – sodass negative Werte sofort hervorstechen. In diesem Abschnitt lernen Sie, wie Sie diese Option aktivieren, eine passende Farbe auswählen und die aktualisierte Präsentation speichern.

Das folgende Codebeispiel demonstriert den Vorgang:

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

    # Neue Serie hinzufügen.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Seriendaten füllen.
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

![Die invertierte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die Füllfarbe für einen einzelnen Datenpunkt anstatt für die gesamte Serie invertieren. Greifen Sie einfach auf den gewünschten ChartDataPoint zu und setzen Sie dessen invert_if_negative‑Eigenschaft auf True.

Das folgende Codebeispiel zeigt, wie das geht:

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

Manchmal enthält ein Diagramm Testwerte, Ausreißer oder veraltete Einträge, die Sie entfernen müssen, ohne die gesamte Serie neu zu erstellen. Aspose.Slides für Python ermöglicht es, beliebige Datenpunkte per Index anzusprechen, deren Inhalt zu leeren und das Diagramm sofort zu aktualisieren, sodass die verbleibenden Punkte verschoben und die Achsen automatisch neu skaliert werden.

Das folgende Codebeispiel demonstriert den Vorgang:

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


## **Serienlückenbreite festlegen**

Die Lückenbreite steuert den Abstand zwischen benachbarten Säulen oder Balken – breitere Lücken betonen einzelne Kategorien, während engere Lücken ein dichteres, kompakteres Erscheinungsbild erzeugen. Mit Aspose.Slides für Python können Sie diesen Parameter für eine gesamte Serie feinjustieren und so genau das visuelle Gleichgewicht erreichen, das Ihre Präsentation erfordert, ohne die zugrunde liegenden Daten zu ändern.

Das folgende Codebeispiel zeigt, wie die Lückenbreite für eine Serie festgelegt wird:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Erstelle eine leere Präsentation.
with slides.Presentation() as presentation:

    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Füge ein Diagramm mit Standarddaten hinzu.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Setze den gap_width-Wert.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


Das Ergebnis:

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Gibt es eine Obergrenze für die Anzahl der Serien, die ein einzelnes Diagramm enthalten kann?**

Aspose.Slides legt keine feste Obergrenze für die Anzahl der Serien fest, die Sie hinzufügen können. Der praktische Grenzwert wird durch die Lesbarkeit des Diagramms und den für Ihre Anwendung verfügbaren Speicher bestimmt.

**Was ist, wenn die Säulen innerhalb eines Clusters zu eng beieinander oder zu weit auseinander liegen?**

Passen Sie die Einstellung gap_width für diese Serie (oder deren übergeordnete Seriengruppe) an. Ein Erhöhen des Wertes vergrößert den Abstand zwischen den Säulen, ein Verringern bringt sie näher zusammen.