---
title: Diagramme in Präsentationen mit Python formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/python-net/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagrammobjekt
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- abgerundete Rahmen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für Python über .NET formatieren und Ihre PowerPoint- oder OpenDocument-Präsentation mit professionellem, ansprechendem Design aufwerten."
---

## **Übersicht**

Dieser Leitfaden zeigt, wie Sie PowerPoint-Diagramme mit Aspose.Slides für Python formatieren. Er führt Sie durch die Anpassung zentraler Diagrammelemente – wie Kategorien‑ und Werte‑Achsen, Rasterlinien, Beschriftungen, Titel, Legenden und Sekundärachsen – und demonstriert, wie Sie Schriften, Zahlenformate, Füllungen, Konturen, Plot‑Bereich‑ und Hintergrundwand‑Farben sowie abgerundete Diagrammecken mit kompakten, ausführbaren Code‑Beispielen steuern. Durch die schrittweisen Beispiele erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), fügen ein Diagramm hinzu, konfigurieren es und speichern das Ergebnis als PPTX mit präzisen visuellen und typografischen Einstellungen.

## **Diagrammelemente formatieren**

Aspose.Slides für Python ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Abschnitt erklärt, wie verschiedene Diagrammelemente, einschließlich der Kategorie‑ und Werte‑Achsen, formatiert werden.

Aspose.Slides bietet eine einfache API zur Verwaltung von Diagrammelementen und zur Anwendung benutzerdefinierter Formatierungen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie sich einen Verweis auf die Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu (in diesem Beispiel `ChartType.LINE_WITH_MARKERS`).  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie Folgendes:  
   1. Setzen Sie das **Linienformat** für die Haupt‑Rasterlinien der Werte‑Achse.  
   1. Setzen Sie das **Linienformat** für die Neben‑Rasterlinien der Werte‑Achse.  
   1. Setzen Sie das **Zahlenformat** für die Werte‑Achse.  
   1. Setzen Sie die **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die Werte‑Achse.  
   1. Setzen Sie die **Texteigenschaften** für die Beschriftungen der Werte‑Achse.  
   1. Setzen Sie den **Titel** für die Werte‑Achse.  
   1. Setzen Sie das **Linienformat** für die Werte‑Achse.  
1. Greifen Sie auf die Kategorie‑Achse des Diagramms zu und setzen Sie Folgendes:  
   1. Setzen Sie das **Linienformat** für die Haupt‑Rasterlinien der Kategorie‑Achse.  
   1. Setzen Sie das **Linienformat** für die Neben‑Rasterlinien der Kategorie‑Achse.  
   1. Setzen Sie die **Texteigenschaften** für die Beschriftungen der Kategorie‑Achse.  
   1. Setzen Sie den **Titel** für die Kategorie‑Achse.  
   1. Setzen Sie die **Beschriftungsposition** der Kategorie‑Achse.  
   1. Setzen Sie den **Drehwinkel** der Beschriftungen der Kategorie‑Achse.  
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie deren **Texteigenschaften**.  
1. Zeigen Sie die Diagramm‑Legende an, ohne das Diagramm zu überdecken.  
1. Greifen Sie auf die **sekundäre Werte‑Achse** des Diagramms zu und setzen Sie Folgendes:  
   1. Aktivieren Sie die sekundäre **Werte‑Achse**.  
   1. Setzen Sie das **Linienformat** für die sekundäre Werte‑Achse.  
   1. Setzen Sie das **Zahlenformat** für die sekundäre Werte‑Achse.  
   1. Setzen Sie die **Min‑, Max‑, Haupt‑ und Neben‑Einheiten** für die sekundäre Werte‑Achse.  
1. Plotten Sie die erste Diagramm‑Serie auf der sekundären Werte‑Achse.  
1. Setzen Sie die Füllfarbe der Hintergrundwand des Diagramms.  
1. Setzen Sie die Füllfarbe des Plot‑Bereichs des Diagramms.  
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add a sample chart.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Set the chart title.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Set major gridline format for the value axis.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Set minor gridline format for the value axis.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Set the value axis number format.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Set value-axis maximum, minimum, major unit, and minor unit.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Set value-axis text properties.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Set the value axis title.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Set major gridline format for the category axis.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Set minor gridline format for the category axis.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Set category-axis text properties.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Set the category axis title.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Set the category-axis label position.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Set the category-axis label rotation angle.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Set legend text properties.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Show the chart legend overlapping the chart.
    chart.legend.overlay = True
                
    # Set chart back wall color.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Set the plot area color.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save the presentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagrammschrift-Eigenschaften festlegen**

Aspose.Slides für Python unterstützt das Festlegen von schriftbezogenen Eigenschaften für Diagramme. Folgen Sie den untenstehenden Schritten, um Diagrammschrift‑Eigenschaften zu konfigurieren:

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.  
1. Fügen Sie ein Diagramm zur Folie hinzu.  
1. Setzen Sie die Schriftgröße.  
1. Speichern Sie die modifizierte Präsentation.

Ein Beispielcode ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Zahlenformat festlegen**

Aspose.Slides für Python bietet eine einfache API zur Verwaltung von Diagrammdatenformaten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
1. Holen Sie sich einen Verweis auf die Folie über deren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten des gewünschten Typs hinzu.  
1. Setzen Sie ein voreingestelltes Zahlenformat aus den verfügbaren Vorgaben.  
1. Durchlaufen Sie die Diagrammdatenzellen jeder Serie und setzen Sie das Zahlenformat.  
1. Speichern Sie die Präsentation.  
1. Setzen Sie ein benutzerdefiniertes Zahlenformat.  
1. Durchlaufen Sie die Diagrammdatenzellen jeder Serie und setzen Sie ein unterschiedliches Zahlenformat.  
1. Speichern Sie die Präsentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Add a default clustered column chart.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Set the preset number format.
    # Traverse each chart series.
    for series in chart.chart_data.series:
        # Traverse each data point in the series.
        for cell in series.data_points:
            # Set the number format.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Save the presentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Die verfügbaren voreingestellten Zahlenformate und ihre entsprechenden Indizes sind unten aufgeführt.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Abgerundete Rahmen für den Diagrammbereich festlegen**

Aspose.Slides für Python unterstützt die Konfiguration des Diagrammbereichs über die Eigenschaft `Chart.has_rounded_corners`.

1. Instanziieren Sie ein [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekt.  
2. Fügen Sie ein Diagramm zur Folie hinzu.  
3. Setzen Sie den Fülltyp und die Füllfarbe des Diagramms.  
4. Setzen Sie die Eigenschaft für abgerundete Ecken auf `True`.  
5. Speichern Sie die modifizierte Präsentation.

Ein Beispiel ist unten angegeben.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen setzen, während der Rand undurchsichtig bleibt?**

Ja. Transparenz der Füllung und die Kontur werden getrennt konfiguriert. Das ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie gehe ich mit Datenbeschriftungen um, wenn sie sich überschneiden?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), setzen Sie den Beschriftungs‑Offset/-Position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl Voll‑ als auch Verlauf‑/Muster‑Füllungen sind in der Regel verfügbar. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Raster und Text verringern.